using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace _400_League_C_Sharp
{
    static class JSONtoCSV
    {
        // Not working yet
        public static void toCSV(string json, string new_csv_filename)
        {
            XmlNode xml = JsonConvert.DeserializeXmlNode(json);//"{records:{record:" + json + "}}"); 
            
            XmlDocument xmldoc = new XmlDocument();
            //Create XmlDoc Object
            xmldoc.LoadXml(xml.InnerXml);
            //Create XML Steam 
            var xmlReader = new XmlNodeReader(xmldoc);
            DataSet dataSet = new DataSet();
            //Load Dataset with Xml
            dataSet.ReadXml(xmlReader);
            //return single table inside of dataset
            var csv = dataSet.Tables[0].ToCSV(",");

            int a = 1;
        }

        private static string ToCSV(this DataTable table, string delimator)
        {
            var result = new StringBuilder();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(table.Columns[i].ColumnName);
                result.Append(i == table.Columns.Count - 1 ? "\n" : delimator);
            }
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    result.Append(row[i].ToString());
                    result.Append(i == table.Columns.Count - 1 ? "\n" : delimator);
                }
            }
            return result.ToString().TrimEnd(new char[] { '\r', '\n' });
            //return result.ToString();
        }
    }
}
