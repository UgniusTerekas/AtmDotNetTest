using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmProject
{
    public class ExchangeMoney
    {
        public string NominalName { get; set; }
        public int Count { get; set; }

        public ExchangeMoney(string nominalName, int count)
        {
            NominalName = nominalName;
            Count = count;
        }

        
    }

}
