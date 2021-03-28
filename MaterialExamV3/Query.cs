using MaterialExamV3.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialExamV3
{
    class Query
    {
        public static Dictionary<int, string> InitDataBase()
        {
            string material = Resources.Material;

            string[] Context = material.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            

            //string[] Context = File.ReadAllLines("Material.txt");
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            for (int i = 0; i < Context.Length; i++)
            {
                keyValuePairs.Add(i, Context[i]);
            }
            return keyValuePairs;
        }

        public static IEnumerable<KeyValuePair<int, string>> DoQuery(Dictionary<int, string> keyValuePairs, string s)
        {
            var rows = from pairs in keyValuePairs
                       where pairs.Value.Contains(s)
                       select pairs;

            return rows;
        }

        public static string Formatted(IEnumerable<KeyValuePair<int, string>> eum, Dictionary<int, string> Context)
        {
            string res = "";
            string enter = "\r\n";
            List<int> rows = new List<int>();
            foreach (var item in eum)
            {
                rows.Add(item.Key);
            }
            foreach (int row in rows)
            {
                var s1 = Context[row];
                var s2 = Context[row + 1];
                var s3 = Context[row + 2];
                var s4 = Context[row + 3];
                res += s1 + enter + s2 + enter + s3 + enter + s4 + enter;
            }
            return res;
        }

    }
}
