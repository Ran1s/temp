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
            Console.WriteLine(Conversion(inputString));
            Console.WriteLine(Calculation(Conversion(inputString)));



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
            int l = st.Last();
            st.RemoveAt(st.Count() - 1);
            int r = st.Last();
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

            for(int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                    continue;
                else if (IsOperator(s[i]))
                {
                    char curop = s[i];
                    while (op.Count != 0 && GetPriority(op.Last()) > GetPriority(s[i]))
                    {
                        //ans = op.Last() + ((ans == "") ? "" : " " + ans) + " " + ch.Dequeue() + ((ch.Count > 0) ? " " + ch.Dequeue() : "");
                        
                        //string t = sst.Pop();
                        //ans += op.Last() + " " + sst.Pop() + " " + t + " ";
                        Operation(st, op.Last());
                        op.Remove(op.Last());
                    }
                    //ans = curop + " " + ans;
                    Operation(st, curop);
                    //op.Add(curop);
                    //sop.Push(curop.ToString());
                }
                else
                {
                    string operand = "";
                    while (i >= 0 && Char.IsLetterOrDigit(s[i]))
                    {
                        operand = s[i--] + operand;
                    }
                    i++;
                    int temp;
                    if (Int32.TryParse(operand, out temp))
                    {
                        st.Add(temp);
                        //ans += temp.ToString() + " ";
                        //sst.Push(temp.ToString());
                    }
                    else
                    {
                        //ans += vars[operand].ToString() + " ";
                        st.Add(vars[operand]);
                        //sst.Push(vars[operand].ToString());
                    }

                }
            }
            while (op.Count > 0)
            {
                //ans = op.Last() + ((ans == "") ? "" : " " + ans) + " " + ch.Dequeue() + ((ch.Count > 0) ? " " + ch.Dequeue() : "");
                //ans = ((sst.Count > 0) ? " " + sst.Pop() + " " : " ") + op.Last() + " " + ans;
                Operation(st, op.Last());
                op.Remove(op.Last());
            }
            return st.Last();
        }


        static string Conversion(string s)
        {
            string ans = "";
            //List<int> st = new List<int>();
            List<char> op = new List<char>();
            //Stack<string> sst = new Stack<string>();
            //Stack<string> sop = new Stack<string>();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                    continue;

                if (s[i] == ')')
                    op.Add(')');
                else if (s[i] == '(')
                {
                    while (op.Last() != ')')
                    {
                        //ans = op.Last() + ((ans == "" ) ? "" : " " + ans) + " " + ch.Dequeue() + ((ch.Count > 0) ? " " + ch.Dequeue(): "");
                        //string t = sst.Pop();
                        //ans += op.Last() + " " + sst.Pop() + " " + t + " ";

                        ans = op.Last() + " " + ans;

                        //Operation(st, op.Last());
                        op.Remove(op.Last());

                    }
                    op.Remove(op.Last());
                }
                else if (IsOperator(s[i]))
                {
                    char curop = s[i];

                    //int n = ans.Length - 1;

                    ////ans = insertOperator(ans, curop);

                    //if (op.Count != 0 && GetPriority(op.Last()) >= GetPriority(s[i]))
                    //{
                    //    int k = ans.LastIndexOf(op.Last());
                    //    if(k != -1)
                    //    {
                    //        ans = ans.Insert(k, curop.ToString() + " ");
                    //    }
                    //    else
                    //    {
                    //        ans += curop + " ";
                    //    }
                    //}
                    //else
                    //{
                    //    ans += curop + " ";
                    //}

                    //ans += left + " ";
                    //left = null;

                    while (op.Count != 0 && GetPriority(op.Last()) > GetPriority(s[i]))
                    {
                        //ans = op.Last() + ((ans == "") ? "" : " " + ans) + " " + ch.Dequeue() + ((ch.Count > 0) ? " " + ch.Dequeue() : "");

                        //string t = sst.Pop();
                        //ans += op.Last() + " " + sst.Pop() + " " + t + " ";
                        ans = op.Last() + " " + ans;
                        //Operation(st, op.Last());
                        op.Remove(op.Last());
                    }
                    //ans = curop + " " + ans;
                    op.Add(curop);
                    //sop.Push(curop.ToString());
                }
                else
                {
                    string operand = "";
                    while (i >= 0 && Char.IsLetterOrDigit(s[i]))
                    {
                        operand = s[i--] + operand;
                    }
                    i++;
                    int temp;
                    if (Int32.TryParse(operand, out temp))
                    {
                        //st.Add(temp);
                        ans = temp.ToString() + " " + ans;
                        //left = temp.ToString();
                        //ans += temp.ToString() + " ";
                        //sst.Push(temp.ToString());
                    }
                    else
                    {
                        //ans += vars[operand].ToString() + " ";
                        //st.Add(vars[operand]);
                        ans = vars[operand].ToString() + " " + ans;
                        //left = vars[operand].ToString();
                        //sst.Push(vars[operand].ToString());
                    }

                }
            }
            while (op.Count > 0)
            {
                //ans = op.Last() + ((ans == "") ? "" : " " + ans) + " " + ch.Dequeue() + ((ch.Count > 0) ? " " + ch.Dequeue() : "");
                //ans = ((sst.Count > 0) ? " " + sst.Pop() + " " : " ") + op.Last() + " " + ans;
                ans = op.Last() + " " + ans;
                //Operation(st, op.Last());
                op.Remove(op.Last());
            }
            //if (left != null)
            //{
            //    ans += left;
            //}


            return ans;
        }


    }
}
