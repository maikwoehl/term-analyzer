using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner2
{
    class Taschenrechner
    {
        private string analyzeResult;
        private string analyzeDesc;
        private string unusedVariables;
        public bool warning;

        public string[] Analyze(string term)
        {
            string unknownVariablesUsed = "false";
            string[] arrayOfUnusedVariables = unusedVariables.Split(',');
            for (int i = 0; i <= arrayOfUnusedVariables.Length - 1; i++)
            {
                if (term.IndexOf(arrayOfUnusedVariables[i]) != -1)
                {
                    unknownVariablesUsed = "true";
                }
            }

            if (unknownVariablesUsed == "true")
            {
                ThrowError("syntax");
            }
            else if (term == "")
            {
                ThrowError("empty");
            }
            else if (term.IndexOf("x") != -1)
            {
                if (term.IndexOf("(x") != -1)
                {
                    string s = (term.Split('('))[0];
                    string binom = "";
                    string x = "";
                    string y = "";

                    try
                    {
                        if ((((term.Split('(')[1]).Split(')'))[0]).IndexOf("-") != -1)
                        { // If negative x-value -> (x-2)^2+3
                            binom = ((term.Split('('))[1]); // Get behind the '(' -> x-2)^2+3
                            x = (binom.Split(')'))[0]; // Get before the ')' -> x-2
                            x = ((x.Split('-'))[1]); // Get behind the '-' and before the ')' -> 2
                            y = (binom.Split(')'))[1]; // Get behind the ')' -> ^2+3
                            y = ((binom.Split('^'))[1]); // Get behind the ')' and behind the '^' -> 2+3
                            y = y.Substring(1, y.Length - 1); // Get behind the ')' and behind the '^' and behind the '2' of '^2' -> +3 
                        }
                        else
                        { // If positive x-value -> (x+2)^2+3
                            binom = ((term.Split('('))[1]);  // Get behind the '(' -> x+2)^2+3
                            x = (binom.Split(')'))[0];  // Get before the ')' -> x+2
                            x = ((x.Split('+'))[1]); // Get behind the '+' and before the ')' > 2
                            y = (binom.Split(')'))[1]; // Get behind the ')' -> ^2+3
                            y = ((binom.Split('^'))[1]);  // Get behind the ')' and behind the '^' -> 2+3
                            y = y.Substring(1, y.Length - 1); // Get behind the ')' and behind the '^' and behind the '2' of '^2' -> +3
                        }

                        analyzeResult = "Parabola";
                        if (s.IndexOf("-") != -1)
                        {
                            analyzeDesc = Convert.ToString(term) + " describes a negative parabola with the coordinates (" + Convert.ToString(x) + "|" + Convert.ToString(y) + ")";

                        }
                        else
                        {
                            analyzeDesc = Convert.ToString(term) + " describes a positive parabola with the coordinates (" + Convert.ToString(x) + "|" + Convert.ToString(y) + ")";
                        }

                    }
                    catch (IndexOutOfRangeException)
                    {
                        ThrowError("syntax");
                    }
                }
                else if (term.IndexOf("^2") != -1 && term.IndexOf("-") == -1)
                {
                    analyzeResult = "Parabola";
                    analyzeDesc = Convert.ToString(term) + " describes a normal positive parabola";
                }
                else if (term.IndexOf("^2") != -1 && term.IndexOf("-x") != -1)
                {
                    analyzeResult = "Parabola";
                    analyzeDesc = Convert.ToString(term) + " describes a normal negative parabola";
                }
                // TODO: Analyze the stretching of Parabola in "x^2 +mx +b" and implement the "binomial form"

            }
            else if (term.IndexOf("+") != -1)
            {
                double x = Convert.ToDouble(((term.Split('+'))[0]));
                double y = Convert.ToDouble(((term.Split('+'))[1]));
                analyzeResult = Convert.ToString(x + y);
                analyzeDesc = Convert.ToString(x) + " plus " + Convert.ToString(y);

            }
            else if (term.IndexOf("-") != -1)
            {
                double x = Convert.ToDouble(((term.Split('-'))[0]));
                double y = Convert.ToDouble(((term.Split('-'))[1]));
                analyzeResult = Convert.ToString(x - y);
                analyzeDesc = Convert.ToString(x) + " minus " + Convert.ToString(y);
            }
            else if (term.IndexOf("*") != -1)
            {
                double x = Convert.ToDouble(((term.Split('*'))[0]));
                double y = Convert.ToDouble(((term.Split('*'))[1]));
                analyzeResult = Convert.ToString(x * y);
                analyzeDesc = Convert.ToString(x) + " times " + Convert.ToString(y);
            }
            else if (term.IndexOf("/") != -1)
            {
                double x = Convert.ToDouble(((term.Split('/'))[0]));
                double y = Convert.ToDouble(((term.Split('/'))[1]));
                analyzeResult = Convert.ToString(x / y);
                analyzeDesc = Convert.ToString(x) + " divided by " + Convert.ToString(y);
            }
            else if (term.IndexOf("^") != -1)
            {
                double x = Convert.ToDouble(((term.Split('^'))[0]));
                double y = Convert.ToDouble(((term.Split('^'))[1]));
                analyzeResult = Convert.ToString(Math.Pow(x, y));
                if (y != 2)
                {
                    analyzeDesc = Convert.ToString(x) + " raised to the power of " + Convert.ToString(y);
                }
                else
                {
                    analyzeDesc = Convert.ToString(x) + " squared";
                }
            }
            else if (term.IndexOf("lg(") != -1)
            {
                string log = ((term.Split('('))[1]);
                double x = Convert.ToDouble(((log.Split(')'))[0]));
                analyzeResult = Convert.ToString(Math.Log10(x));
                analyzeDesc = "The logarithm of " + Convert.ToString(x) + " to the base of " + Convert.ToString(10);
            }
            else if (term.IndexOf("ln(") != -1)
            {
                string log = ((term.Split('('))[1]);
                double x = Convert.ToDouble(((log.Split(')'))[0]));
                analyzeResult = Convert.ToString(Math.Log(x));
                analyzeDesc = "The logarithm of " + Convert.ToString(x) + " to the base of " + Convert.ToString(Math.E);
            }
            else if (term.IndexOf("log_") != -1)
            {
                string log = ((term.Split('_'))[1]);
                double x = Convert.ToDouble(((log.Split('('))[0]));
                string number = (log.Split('('))[1];
                double y = Convert.ToDouble(((number.Split(')'))[0]));
                analyzeResult = Convert.ToString(Math.Log10(x) / Math.Log10(y));
                analyzeDesc = "The logarithm of " + Convert.ToString(y) + " to the base of " + Convert.ToString(x);
            }
            else if (term.IndexOf("sqrt(") != -1)
            {
                string sqrt = ((term.Split('('))[1]);
                double x = Convert.ToDouble(((sqrt.Split(')'))[0]));
                analyzeResult = Convert.ToString(Math.Sqrt(x));
                analyzeDesc = "The square root of " + Convert.ToString(x);
            }
            else if (term.IndexOf("sqrt[") != -1)
            {
                string sqrt = ((term.Split('['))[1]);
                double x = Convert.ToDouble(((sqrt.Split(']'))[0]));
                string number = (sqrt.Split('('))[1];
                double y = Convert.ToDouble(((number.Split(')'))[0]));
                analyzeResult = Convert.ToString(Math.Pow(y, (1 / x)));
                analyzeDesc = "The " + Convert.ToString(x) + ". root of " + Convert.ToString(y);
            }
            else if (term.IndexOf("=") != -1)
            {
                double x = Convert.ToDouble(((term.Split('='))[0]));
                double y = Convert.ToDouble(((term.Split('='))[1]));
                if (x == y)
                {
                    analyzeResult = "True";
                    analyzeDesc = Convert.ToString(x) + " equals " + Convert.ToString(y);
                }
                else
                {
                    analyzeResult = "False";
                    analyzeDesc = Convert.ToString(x) + " is not equal to " + Convert.ToString(y);
                }
            }
            else
            {
                ThrowError("unknown");
            }

            analyzeDesc += ".";

            string[] response = { analyzeResult, analyzeDesc };
            return response;
        }

        public void ThrowError(string type)
        {
            if (type == "syntax")
            {
                analyzeResult = "NULL";
                analyzeDesc = "Wrong syntax";
            }
            else if (type == "unknown")
            {
                analyzeResult = "";
                analyzeDesc = "Unknown Error";
            }
            else if (type == "empty")
            {
                analyzeResult = "";
                analyzeDesc = "Nothing to calculate";
            }
            warning = true;
        }

        public void Initialize()
        {
            unusedVariables = "a,b,c,d,e,f,h,i,j,k,m,p,u,v,w,y,z";
        }
    }
}
