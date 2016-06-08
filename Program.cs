using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Tools.Collection;

namespace WorkWithStack
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                JStack nums = new JStack();
                JStack ops = new JStack(); // Need to add user input option
                string expression = "5 + 10 + 15 + 20";
                Calculate(nums, ops, expression);
                Console.WriteLine(nums.Pop());
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Invalid Input");
                Console.ReadLine();
            }
        }
        
        //IsNumeric isn't built into C# so we must define it. Boom!
        static bool IsNumeric(string input)
        {
            bool flag = true;
            string pattern = (@"^\d+$"); //@ is used because otherwise, we would need to put ("^\\d+$"). @ means literal. This is a regular expression
            Regex validate = new Regex(pattern); //Regex - Regular expression engine
            if (!validate.IsMatch(input))
            {
                flag = false;
            }
            return flag;
        }
        static void Calculate(JStack N, JStack O, string exp)
        {
            string ch;
            string token = string.Empty;
            for(int p =0; p < exp.Length; p++)
            {
                ch = exp.Substring(p, 1);
                if (IsNumeric(ch) == true)
                
                    token += ch;
                    if(ch == " " || p ==(exp.Length-1))
                    {
                        if (IsNumeric(token))
                        {
                            N.Push(token);
                            token = string.Empty;
                        }
                    }
                    else if (ch == "+" || ch == "-" || ch == "*" || ch == "/")
                    {
                        O.Push(ch);
                    }
                    if (N.Count == 2)
                    {
                        Compute(N, O);
                    }
            }
        }

        static void Compute(JStack N, JStack O)
        {
            int operand1;
            int operand2;
            string oper;
            operand1 = Convert.ToInt32(N.Pop());
            operand2 = Convert.ToInt32(N.Pop());
            oper = Convert.ToString(O.Pop());
            switch (oper)
            {
                case "+":
                    N.Push(operand1 + operand2);
                    break;
                case "-":
                    N.Push(operand1 - operand2);
                    break;
                case "*":
                    N.Push(operand1 * operand2);
                    break;
                case "/":
                    N.Push(operand1 / operand2);
                    break;
            }
        }
    }
}
