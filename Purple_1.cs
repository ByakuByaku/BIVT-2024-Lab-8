﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        public Purple_1(string input) : base(input) { }

        private string _output;

        public string Output => _output;

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
                    if ((chars[left] == 't' && chars[right] == 'h') || (chars[left] == 'n' && chars[right] == 'd') || (chars[left] == 's' && chars[right] == 't') || (chars[left] == 'r' && chars[right] == 'd'))
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

        
        public void Print()
        {
            for (int i = 0; i < _output.Length; i++)
            {
                Console.Write(_output[i]);
            }
        }
        public override string ToString()
        {
            return _output;
        }
    }
}
