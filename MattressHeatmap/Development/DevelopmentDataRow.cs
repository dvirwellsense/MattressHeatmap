using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class DevelopmentDataRow
    {
        public int Index { get; set; }
        public List<int> Values { get; set; }
        public bool IsValid { get; set; }

        public DevelopmentDataRow(string message)
        {
            ParseMessage(message);
        }

        private void ParseMessage(string message)
        {
            try
            {
                Values = new List<int>();

                message = message.Remove(0, 3);
                int n = message.IndexOf(',');
                string s=message.Substring(0, n);
                Index = int.Parse(s)-1;
                message = message.Remove(0, n+1);
                while (message.Length > 0)
                {
                    int endIndex = message.IndexOf(',');
                    string valueStr = message.Substring(0, endIndex);
                    Values.Add(int.Parse(valueStr));
                    message = message.Remove(0, endIndex + 1);
                }
                IsValid = true;
            }
            catch
            {
                IsValid = false;
            }
        }
    }
}
