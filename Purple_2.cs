using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2 : Purple
    {
        public Purple_2(string input) : base(input) { }

        private string[] _output;

        public string[] Output => _output;

        public override void Review()
        {
            if (Input == null) return;
            string[] split_text = Input.Split(' ');
            string[] prepared_text = new string[0];
            //for (int i = 0; i < 11; i++)
            //{
            //    Console.WriteLine(split_text[i]+"");
            //}
            int start = 0;
            int index = 0;
            int count = 0;

            while (index < split_text.Length)
            {
                
                if (count == 0)
                {
                    count = split_text[index].Length;
                }
                else
                {
                    count += 1 + split_text[index].Length; 
                }


                if (count <= 50)
                {
                    index++;
                }

                else
                {

                    string line = string.Join(" ", split_text, start, index - start);
                    string[] L = line.Split(' ');
                    int whiteSpaces = L.Length-1;
                    int quantity = (line.Length-whiteSpaces);
                    int indexx = 0;
                    while (quantity != 50)
                    {
                        L[indexx] += " ";
                        quantity++;
                        indexx++;
                        if (indexx == whiteSpaces)
                        {
                            indexx = 0;
                        }

                    }
                    string newLine = string.Join("", L);
                    Array.Resize(ref prepared_text, prepared_text.Length+1);
                    prepared_text[prepared_text.Length - 1] = (newLine);

                    
                    start = index;
                    count = 0;
                }
            }
            if (start < split_text.Length)
            {
                string lastLine = string.Join(" ", split_text, start, split_text.Length - start);
                
                string[] Last_L = lastLine.Split(' ');
                if (Last_L.Length == 1)
                {
                    
                    Array.Resize(ref prepared_text, prepared_text.Length + 1);
                    prepared_text[prepared_text.Length - 1] = (lastLine);
                    
                }
                else
                {
                int whiteSpaces = Last_L.Length - 1;
                int quantity = (lastLine.Length - whiteSpaces);
                int indexx = 0;
                while (quantity != 50)
                {
                    Last_L[indexx] += " ";
                    quantity++;
                    indexx++;
                    if (indexx == whiteSpaces)
                    {
                        indexx = 0;
                    }

                }
                string newLine = string.Join("", Last_L);
                Array.Resize(ref prepared_text, prepared_text.Length + 1);
                prepared_text[prepared_text.Length - 1] = (newLine);
                }
                

            }

            _output = prepared_text;

        }
        public override string ToString()
        {
            if (Output == null) return null;

            return String.Join(Environment.NewLine, Output);
        }
    }
}
