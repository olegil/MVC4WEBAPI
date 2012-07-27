using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace WebAPIClient
{
    class Program
    {
        static void Main()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/xml"));

            var result = client.GetAsync(new Uri("http://localhost:1362/api/webapi")).Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var doc = XDocument.Load(result.Content.ReadAsStreamAsync().Result);
                var ns = (XNamespace) "http://schemas.datacontract.org/2004/07/Videos.Models";
                foreach (var name in doc.Descendants(ns+"Name"))
                {
                    Console.WriteLine(name.Value);

                }

            }
            Console.ReadLine();
        }
    }
}
