using System;
using HtmlAgilityPack;
using Kurapov.Bll.HttpClients.Abstractions;

namespace Kurapov.Bll.HttpClients.Implementations
{
    public class Client: IClient, IDisposable
    {
        public HtmlDocument WebDoc { get; set; }

        public Client()
        {
            WebDoc = new HtmlDocument();
        }

        public Client(string url)
        {
            WebDoc = new HtmlDocument();
            WebDoc.Load(url);
        }

        public void Load(string url)
        {
            WebDoc.LoadHtml(url);
        }

        public void Dispose()
        {
        }
    }
}
