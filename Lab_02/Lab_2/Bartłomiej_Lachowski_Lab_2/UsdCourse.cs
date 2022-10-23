using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class UsdCourse
    {
        public static float Current = 0;

        public async static Task<float> GetUsdCourseAsync()
        {
            var wc = new HttpClient();
            var response = await wc.GetAsync("http://www.nbp.pl/kursy/xml/LastA.xml");

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException();

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(await response.Content.ReadAsStringAsync());
            foreach(System.Xml.XmlNode node in doc.GetElementsByTagName("pozycja"))
            {
                if(node.NodeType == System.Xml.XmlNodeType.Element)
                {
                    System.Xml.XmlElement pp = (System.Xml.XmlElement)node;
                    System.Xml.XmlElement w = (System.Xml.XmlElement)pp.GetElementsByTagName("kod_waluty")[0];

                    if(w.InnerText == "USD")
                    {
                        return Convert.ToSingle(pp.GetElementsByTagName("kurs_sredni")[0].InnerText);
                    }
                }
            }
            throw new InvalidOperationException();
        }
    }
}
