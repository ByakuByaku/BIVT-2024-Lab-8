using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_8
{
    public class Purple_3 : Purple
    {


        private string _output;

        private (string, char)[] _codes;
        public string Output => _output;
        
        public (string, char)[] Codes
        {
            get
            {
                if (_codes == null) return null;
                (string, char)[] codes = new (string, char)[_codes.Length];
                Array.Copy(_codes, codes, _codes.Length);
                return codes;
            }
        }
        
        
        public Purple_3(string input) : base(input) { _codes = new (string, char)[5]; }
        public override void Review()
        {
            if (_codes == null || Input == null) return;
            if (string.IsNullOrEmpty(Input))
            {
                _output = "";
                return;
            }
            string[] uniquePairs = new string[0];
            string[] allPairs = new string[0];
            

            for (int i = 0; i < Input.Length - 1; i++)
            {
                if (Input[i] == ' ' || Input[i + 1] == ' ')
                    continue;
                Array.Resize(ref allPairs, allPairs.Length + 1);
                allPairs[allPairs.Length - 1] = $"{Input[i]}{Input[i + 1]}";

            }
            uniquePairs = allPairs.Distinct().ToArray();
            int[] count = new int[uniquePairs.Length];
            for (int i = 0; i < count.Length; i++)
            {
                count[i] = allPairs.Count(r => r == uniquePairs[i]);
            }

            for (int i = 0, j=1; i < count.Length;)
            {
                if (i==0 || count[i] <= count[i - 1])
                {
                    i=j;
                    j++;
                }
                else
                {
                    int temp = count[i];
                    count[i] = count[i-1];
                    count[i-1] = temp;
                    var temp2 = uniquePairs[i];
                    uniquePairs[i] = uniquePairs[i-1];
                    uniquePairs[i-1] = temp2;
                    i--;
                }
            }
            
            char[] symbols = new char[0];
            for (int i = 32;i<= 126; i++)
            {
                if (Input.Count(r => (char)i == r) == 0)
                {
                    Array.Resize(ref symbols, symbols.Length+1);
                    symbols[symbols.Length-1] = (char) i;

                }
            }
            
            _output = Input;
            for (int i = 0; i < 5; i++)
            {
                _codes[i] = (uniquePairs[i], symbols[i]);
                
                
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < Input.Length - 1; j++)
                {
                    if ($"{Input[j]}{Input[j + 1]}" == _codes[i].Item1)
                    {
                        _output = _output.Replace(_codes[i].Item1, _codes[i].Item2.ToString());
                    }

                }
            }
            
            
        }
        public override string ToString()
        {
            
            return _output;
        }
    }
}
