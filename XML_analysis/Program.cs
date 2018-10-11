using System;
using OpenDataImport.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OpenDataImport
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var nodes = FindOpenData();
            ShowOpenData(nodes);
            Console.ReadKey();
        }

        static List<OpenData> FindOpenData()
        {
            List<OpenData> result = new List<OpenData>();
            var xml = XElement.Load(@"C:\Users\Chao\Desktop\臺中市百大名攤名產.xml");
            var nodes = xml.Descendants("RECORD").ToList();

            for (var i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                OpenData item = new OpenData();

                item.編號 = int.Parse(getValue(node, "編號"));
                item.攤名 = getValue(node, "攤名");
                item.區域 = getValue(node, "區域");
                item.電話 = getValue(node, "電話");
                item.地址 = getValue(node, "地址");
                result.Add(item);
            }
            return result;
        }
        public static string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value?.Trim();
        }

        public static void ShowOpenData(List<OpenData> nodes)
        {
            Console.WriteLine(string.Format("共收到[0]筆的資料", nodes.Count));
            nodes.GroupBy(node => node.區域).ToList()
                .ForEach(group =>
                {
                    var key = group.Key;
                    var groupDatas = group.ToList();
                    var message = $"區域:{key},共有{groupDatas.Count()}筆資料";
                    Console.WriteLine(message);
                });
        }
    }
}