using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        

        private string _output;

        public string Output => _output;
        public Purple_1(string input) : base(input) { }

        public override void Review()
        {
            if (String.IsNullOrEmpty(Input))
            {
                _output = Input;


                return;
            }

            char[] chars = Input.ToCharArray();
            int L = 0, R = 0;
            int n = chars.Length;

            while (R < n)
            {
                while (R < n && !Char.IsLetter(chars[R]))
                {
                    R++;
                }
                L = R;
                while (R < n && (Char.IsLetter(chars[R]) || chars[R] == '-' || chars[R] == '\''))
                {
                    R++;
                }
                int left = L;
                int right = R - 1;
                while (left < right)
                {
                    //while (left < right && chars[left] == '-') left++;

                    //while (left < right && chars[right] == '-') right--;
                    if (left!=0 && Char.IsDigit(chars[left]) && Char.IsLetter(chars[right]) || left!=0 && Char.IsDigit(chars[left - 1]) && Char.IsLetter(chars[right])) 
                    {
                        left++;
                        right--;
                        continue;
                    }
                        var temp = chars[left];
                        chars[left] = chars[right];
                        chars[right] = temp;
                        left++;
                        right--;
                    
                }
            }
            

            _output = new string(chars);
        }

        
        
        public override string ToString()
        {
            return _output;
        }
    }
}
