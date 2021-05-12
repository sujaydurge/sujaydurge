using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace invalidrecords
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> duplicate = new Dictionary<string,string>();
            List<string> invalidid = new List<string>();
            var jsondata= File.ReadAllText("data.json"); 
            //Get records having unique id
            List<data> data = JsonSerializer.Deserialize<List<data>>(jsondata).GroupBy(x=>x.id).Select(y=>y.First()).ToList();
            //Get invalid/missing/null name,address,zip
            invalidid = data.Where(x => string.IsNullOrEmpty(x.name) || string.IsNullOrEmpty(x.address) || string.IsNullOrEmpty(x.zip)).Select(y=>y.id).ToList();

            //Get duplicate records
            foreach (var item in data.Select(x=>(x.name+x.address+x.zip+"~"+x.id)))
            {
                if (duplicate.ContainsValue(item.Split("~")[0]))
                {
                    invalidid.Add(item.Split("~")[1]);
                    invalidid.Add(duplicate.FirstOrDefault(x=>x.Value== item.Split("~")[0]).Key);
                }
                else
                {
                    duplicate.Add(item.Split("~")[1], item.Split("~")[0]);
                }
            }
            //SHow invalid id list 
            Console.WriteLine("Invalid Ids:");
            foreach (var item in invalidid.Distinct())
            {
                Console.WriteLine(item);

            }
        }
    }
}
