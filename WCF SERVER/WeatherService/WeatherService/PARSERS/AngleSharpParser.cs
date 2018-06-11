using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using System.IO;
using System.Linq;
using System.Net;


namespace WeatherService.PARSERS
{
    class AngleSharpParser
    {
        public static string DownloadHTML(string URL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            var _Document = sr.ReadToEnd();
            sr.Close();
            return _Document;
        }
        public static AngleSharp.Dom.IHtmlCollection<AngleSharp.Dom.IElement> ParserHTML(string _document, string _parserTag)
        {
            var parser = new HtmlParser();
            var document = parser.Parse(_document);
            var result = document.QuerySelectorAll(_parserTag);
            return result;
        }
        public static System.Collections.Generic.IEnumerable<AngleSharp.Dom.IElement> ParserHTML(string _document, string _parserTag, System.Func<IElement, bool> cond_func)
        {
            var parser = new HtmlParser();
            var document = parser.Parse(_document);
            var result = document.QuerySelectorAll(_parserTag).Where(cond_func);
            return result;
        }
    }
}
