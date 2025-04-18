using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_4 : Purple
    {
        private (string, char)[] _codes;
        
        
        private string _output;



        public string Output => _output;

        public Purple_4(string input, (string, char)[] codes) : base(input) { _codes = codes; }
        
        public override void Review()
        {
            if (Input == null || _codes == null) return;
            string res = Input;
            for (int i = 0; i < 5; i++)
            {
                res = res.Replace(_codes[i].Item2.ToString(), _codes[i].Item1);
            }
            _output = res;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
