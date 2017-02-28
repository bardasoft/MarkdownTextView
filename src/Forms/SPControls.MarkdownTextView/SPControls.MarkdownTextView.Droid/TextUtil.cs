using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace SPControls
{
    internal static class TextUtil
    {
        public static ICharSequence GetFormattedHtml(string htmlText)
        {
            try
            {
                var html = Android.Text.Html.FromHtml(htmlText.ParseCodeTags(), null, new HtmlTagHandler()) as ICharSequence;
                // this is required to get rid of the end two "\n" that android adds with Html.FromHtml
                // see: http://stackoverflow.com/questions/16585557/extra-padding-on-textview-with-html-contents for example
                while (html.CharAt(html.Length() - 1) == '\n')
                {
                    html = html.SubSequenceFormatted(0, html.Length() - 1);
                }
                return html;
            }
            catch
            {
                return null;
            }
        }

    }
}