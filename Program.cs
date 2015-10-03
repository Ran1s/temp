using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveDescentParser
{
    class Program
    {
        //enum Token
        //{
        //    NAME,
        //    NUMBER,
        //    END,
        //    PLUS = '+',
        //    MINUS = '-',
        //    MUL = '*',
        //    DIV = '/',
        //    LP = '(',
        //    RP = ')'
        //};

        //enum Number
        //{
        //    NUM1 = '1',
        //    NUM2 = '2',
        //    NUM3 = '3',
        //    NUM4 = '4',
        //    NUM5 = '5',
        //    NUM6 = '6',
        //    NUM7 = '7',
        //    NUM8 = '8',
        //    NUM9 = '9',
        //    NUM0 = '0',
        //    NUMP = '.',
        //};
        //Stack<string> answer = new Stack<string>();
        //Dictionary<char, double> variables = new Dictionary<char, double>();
        //Token currentToken = new Token();

        //Token GetToken(char ch)
        //{
        //    switch (ch)
        //    {
        //        case PLUS:

        //    }
        //}

        
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            Console.WriteLine(Calculation(inputString));
            



        }
        static Dictionary<string, int> vars = new Dictionary<string, int>();


        static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        static int GetPriority(char op)
        {
            return (op == '+' || op == '-') ? 1 : (op == '*' || op == '/') ? 2 : -1;
        }

        static void Operation(List<int> st, char op)
        {
            int r = st.Last();
            st.RemoveAt(st.Count() - 1);
            int l = st.Last();
            st.RemoveAt(st.Count() - 1);

            switch (op)
            {
                case '+':
                    st.Add(l + r);
                    break;
                case '-':
                    st.Add(l - r);
                    break;
                case '*':
                    st.Add(l * r);
                    break;
                case '/':
                    st.Add(l / r);
                    break;

            }
        }

        static int Calculation(string s)
        {
            List<int> st = new List<int>();
            List<char> op = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                    continue;

                if (s[i] == '(')
                    op.Add('(');
                else if (s[i] == ')')
                {
                    while (op.Last() != '(')
                    {
                        Operation(st, op.Last());
                        op.RemoveAt(st.Count() - 1);
                    }
                }
                else if (IsOperator(s[i]))
                {
                    char curop = s[i];
                    while (op.Count != 0 && GetPriority(op.Last()) >= GetPriority(s[i]))
                    {
                        Operation(st, op.Last());
                        op.RemoveAt(st.Count() - 1);
                    }
                    op.Add(curop);
                }
                else
                {
                    string operand = "";
                    while (i < s.Length && Char.IsLetterOrDigit(s[i]))
                    {
                        operand += s[i++];
                    }
                    i--;
                    int temp;
                    if (Int32.TryParse(operand, out temp))
                    {
                        st.Add(temp);
                    }
                    else
                    {
                        st.Add(vars[operand]);
                    }

                }
            }
            while (op.Count != 0)
            {
                Operation(st, op.Last());
                op.RemoveAt(st.Count() - 1);
            }
            

            return st.Last();
        }


    }
}
