using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveDescentParser
{
    class Program
    {
        enum Token
        {
            NAME,
            NUMBER,
            END,
            PLUS = '+',
            MINUS = '-',
            MUL = '*',
            DIV = '/',
            LP = '(',
            RP = ')'
        };

        enum Number
        {
            NUM1 = '1',
            NUM2 = '2',
            NUM3 = '3',
            NUM4 = '4',
            NUM5 = '5',
            NUM6 = '6',
            NUM7 = '7',
            NUM8 = '8',
            NUM9 = '9',
            NUM0 = '0',
            NUMP = '.',
        };
        Stack<string> answer = new Stack<string>();
        Dictionary<char, double> variables = new Dictionary<char, double>();
        Token currentToken = new Token();

        Token GetToken(char ch)
        {
            switch (ch)
            {
                case PLUS:

            }
        }

        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            



        }


    }
}
