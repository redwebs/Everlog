﻿using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EverLog
{
    /// <summary>
    /// Helper to encode and set HTML fragment to clipboard.
    /// See http://theartofdev.com/2014/06/12/setting-htmltext-to-clipboard-revisited/
    /// </summary>
    /// <remarks>
    /// The MIT License (MIT) Copyright (c) 2014 Arthur Teplitzki.
    /// </remarks>
    /// 
    public static class ClipboardHelper
    {
        #region Fields and Consts

        /// <summary>
        /// The string contains index references to other spots in the string, so we need placeholders so we can compute the offsets.
        /// The left arrow strings are just placeholders. We'll back-patch them actual values afterwards. 
        /// The string layout with left arrows also ensures that it can't appear in the body of the html 
        /// because the left arrow character must be escaped.
        /// </summary>
        private const string Header =
@"Version:0.9
StartHTML:<<<<<<<<1
EndHTML:<<<<<<<<2
StartFragment:<<<<<<<<3
EndFragment:<<<<<<<<4
StartSelection:<<<<<<<<3
EndSelection:<<<<<<<<4";

        /// <summary>
        /// html comment to point the beginning of html fragment
        /// </summary>
        public const string StartFragment = "<!--StartFragment-->";

        /// <summary>
        /// html comment to point the end of html fragment
        /// </summary>
        public const string EndFragment = @"<!--EndFragment-->";

        /// <summary>
        /// Used to calculate characters byte count in UTF-8
        /// </summary>
        private static readonly char[] _byteCount = new char[1];

        #endregion

        #region Functions

        /// <summary>
        /// Create DataObject with given html and plain-text ready to be used for clipboard or drag and drop.
        /// Handle missing html tags, specified start\end segments and Unicode characters.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Windows Clipboard works with UTF-8 Unicode encoding while .NET strings use with UTF-16 so for clipboard to correctly
        /// decode Unicode string added to it from .NET we needs to be re-encoded it using UTF-8 encoding.
        /// </para>
        /// <para>
        /// Builds the CF_HTML header correctly for all possible HTMLs
        /// If given html contains start/end fragments then it will use them in the header:
        /// <code><html><body><!--StartFragment-->hello <b>world</b><!--EndFragment--></body></html></code>
        /// If given html contains html/body tags then it will inject start/end fragments to exclude html/body tags:
        /// <code><html><body>hello <b>world</b></body></html>></code>
        /// If given html doesn't contain html/body tags then it will inject the tags and start/end fragments properly:
        /// <code>hello <b>world</b>></code>
        /// In all cases creating a proper CF_HTML header:
        /// <code>
        /// Version:1.0
        /// StartHTML:000000177
        /// EndHTML:000000329
        /// StartFragment:000000277
        /// EndFragment:000000295
        /// StartSelection:000000277
        /// EndSelection:000000277
        /// <html><body><!--StartFragment-->hello <b>world</b><!--EndFragment--></body></html>
        /// </code>
        /// See format specification here: 
        ///     http://msdn.microsoft.com/library/default.asp?url=/workshop/networking/clipboard/htmlclipboard.asp
        /// </para>
        /// </remarks>
        /// <param name="html">An html fragment</param>
        /// <param name="plainText">The plain text</param>
        /// 
        public static DataObject CreateDataObject(string html, string plainText)
        {
            html = html ?? String.Empty;
            var htmlFragment = GetHtmlDataString(html);

            // re-encode the string so it will work correctly (fixed in CLR 4.0)
            if (Environment.Version.Major < 4 && html.Length != Encoding.UTF8.GetByteCount(html))
            {
                htmlFragment = Encoding.Default.GetString(Encoding.UTF8.GetBytes(htmlFragment));
            }

            var dataObject = new DataObject();
            dataObject.SetData(DataFormats.Html, htmlFragment);
            dataObject.SetData(DataFormats.Text, plainText);
            dataObject.SetData(DataFormats.UnicodeText, plainText);
            return dataObject;
        }

        /// <summary>
        /// Clears clipboard and sets the given HTML and plain text fragment to the clipboard, providing additional meta-information for HTML.
        /// See CreateDataObject for HTML fragment details.
        /// </summary>
        /// <example>
        /// ClipboardHelper.CopyToClipboard("Hello <b>World</b>", "Hello World");
        /// </example>
        /// <param name="html">An html fragment</param>
        /// <param name="plainText">The plain text</param>
        /// 
        public static void CopyToClipboard(string html, string plainText)
        {
            var dataObject = CreateDataObject(html, plainText);
            Clipboard.SetDataObject(dataObject, true);
        }

        /// <summary>
        /// Generate HTML fragment data string with header that is required for the clipboard.
        /// </summary>
        /// <param name="html">The html to generate for</param>
        /// <returns>The resulted string</returns>
        /// 
        private static string GetHtmlDataString(string html)
        {
            var sb = new StringBuilder();
            sb.AppendLine(Header);

            // if given html already provided the fragments we won't add them
            int fragmentStart, fragmentEnd;
            var fragmentStartIdx = html.IndexOf(StartFragment, StringComparison.OrdinalIgnoreCase);
            var fragmentEndIdx = html.LastIndexOf(EndFragment, StringComparison.OrdinalIgnoreCase);

            // if html tag is missing add it surrounding the given html (critical)
            var htmlOpenIdx = html.IndexOf("<html", StringComparison.OrdinalIgnoreCase);
            var htmlOpenEndIdx = htmlOpenIdx > -1 ? html.IndexOf('>', htmlOpenIdx) + 1 : -1;
            var htmlCloseIdx = html.LastIndexOf("</html", StringComparison.OrdinalIgnoreCase);

            if (fragmentStartIdx < 0 && fragmentEndIdx < 0)
            {
                var bodyOpenIdx = html.IndexOf("<body", StringComparison.OrdinalIgnoreCase);
                var bodyOpenEndIdx = bodyOpenIdx > -1 ? html.IndexOf('>', bodyOpenIdx) + 1 : -1;

                if (htmlOpenEndIdx < 0 && bodyOpenEndIdx < 0)
                {
                    // the given html doesn't contain html or body tags so we need to add them and place start/end fragments around the given html only
                    sb.Append("<html><body>");
                    sb.Append(StartFragment);
                    fragmentStart = GetByteCount(sb);
                    sb.Append(html);
                    fragmentEnd = GetByteCount(sb);
                    sb.Append(EndFragment);
                    sb.Append("</body></html>");
                }
                else
                {
                    // insert start/end fragments in the proper place (related to html/body tags if exists) so the paste will work correctly
                    var bodyCloseIdx = html.LastIndexOf("</body", StringComparison.OrdinalIgnoreCase);

                    if (htmlOpenEndIdx < 0)
                    {
                        sb.Append("<html>");
                    }
                    else
                    {
                        sb.Append(html, 0, htmlOpenEndIdx);
                    }

                    if (bodyOpenEndIdx > -1)
                    {
                        sb.Append(html, htmlOpenEndIdx > -1 ? htmlOpenEndIdx : 0, bodyOpenEndIdx - (htmlOpenEndIdx > -1 ? htmlOpenEndIdx : 0));
                    }

                    sb.Append(StartFragment);
                    fragmentStart = GetByteCount(sb);

                    var innerHtmlStart = bodyOpenEndIdx > -1 ? bodyOpenEndIdx : (htmlOpenEndIdx > -1 ? htmlOpenEndIdx : 0);
                    var innerHtmlEnd = bodyCloseIdx > -1 ? bodyCloseIdx : (htmlCloseIdx > -1 ? htmlCloseIdx : html.Length);
                    sb.Append(html, innerHtmlStart, innerHtmlEnd - innerHtmlStart);

                    fragmentEnd = GetByteCount(sb);
                    sb.Append(EndFragment);

                    if (innerHtmlEnd < html.Length)
                    {
                        sb.Append(html, innerHtmlEnd, html.Length - innerHtmlEnd);
                    }

                    if (htmlCloseIdx < 0)
                    {
                        sb.Append("</html>");
                    }
                }
            }
            else
            {
                // handle html with existing start\end fragments just need to calculate the correct bytes offset (surround with html tag if missing)
                if (htmlOpenEndIdx < 0)
                {
                    sb.Append("<html>");
                }
                var start = GetByteCount(sb);
                sb.Append(html);
                fragmentStart = start + GetByteCount(sb, start, start + fragmentStartIdx) + StartFragment.Length;
                fragmentEnd = start + GetByteCount(sb, start, start + fragmentEndIdx);

                if (htmlCloseIdx < 0)
                {
                    sb.Append("</html>");
                }
            }

            // Back-patch offsets (scan only the header part for performance)
            sb.Replace("<<<<<<<<1", Header.Length.ToString("D9"), 0, Header.Length);
            sb.Replace("<<<<<<<<2", GetByteCount(sb).ToString("D9"), 0, Header.Length);
            sb.Replace("<<<<<<<<3", fragmentStart.ToString("D9"), 0, Header.Length);
            sb.Replace("<<<<<<<<4", fragmentEnd.ToString("D9"), 0, Header.Length);

            return sb.ToString();
        }

        /// <summary>
        /// Calculates the number of bytes produced by encoding the string in the string builder in UTF-8 and not .NET default string encoding.
        /// </summary>
        /// <param name="sb">the string builder to count its string</param>
        /// <param name="start">optional: the start index to calculate from (default - start of string)</param>
        /// <param name="end">optional: the end index to calculate to (default - end of string)</param>
        /// <returns>the number of bytes required to encode the string in UTF-8</returns>
        /// 
        private static int GetByteCount(StringBuilder sb, int start = 0, int end = -1)
        {
            var count = 0;
            end = end > -1 ? end : sb.Length;

            for (var idx = start; idx < end; idx++)
            {
                _byteCount[0] = sb[idx];
                count += Encoding.UTF8.GetByteCount(_byteCount);
            }
            return count;
        }
        // ==================== End of code from Arthur Teplitzki ==============================

        /// <summary>
        /// Get clipboard objects for display
        ///   Grabs whatever is on the clipboard
        /// </summary>
        /// <returns>Decoded data in a StringBuilder</returns>
        /// 
        public static StringBuilder GetClipbordInfo()
        {
            var sb = new StringBuilder();
            var cbDataObj = Clipboard.GetDataObject();

            if (cbDataObj == null)
            {
                return sb;
            }
            var fmts = cbDataObj.GetFormats();
            sb.AppendLine("Data object formats: ");

            foreach (var t in fmts)
            {
                sb.Append("\"");
                sb.Append(t);
                sb.AppendLine("\"");
            }

            // HTML Object
            if (!cbDataObj.GetDataPresent("HTML Format"))
            {
                sb.AppendLine("No Html object");
            }
            else
            {
                var doc = cbDataObj.GetData("HTML Format");
                sb.AppendLine(doc.ToString().Replace("\n", "\r\n"));
            }
            // Evernote custom object
            if (!cbDataObj.GetDataPresent("ENML Format"))
            {
                sb.AppendLine("No ENML object");
            }
            else
            {
                var memStr = (MemoryStream) cbDataObj.GetData("ENML Format");
                memStr.Position = 0;
                var sr = new StreamReader(memStr);
                sb.Append("ENML:");
                sb.AppendLine(sr.ReadToEnd());
            }
            // Locale, or URL
            if (!cbDataObj.GetDataPresent("locale"))
            {
                sb.AppendLine("No locale object");
            }
            else
            {
                var memStr = (MemoryStream)cbDataObj.GetData("locale");
                memStr.Position = 0;
                var sr = new StreamReader(memStr);
                sb.Append("Locale:");
                sb.AppendLine(sr.ReadToEnd());
            }
            return sb;
        }
        
        #endregion
    }
}
