using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvingQuadraticEquations
{
    internal class Program
    {
        static void Main(string[] args)
        {




            string equation = "";
            bool playAgain = true;

            while (playAgain)
            {
                Console.WriteLine("Quadratic equation : ax^2 + bx + c = 0");
                Console.WriteLine();
                int constantA = GetValue('a');

                equation = ModifyEquationAccordingToConstantA(constantA, equation);
                Console.WriteLine();


                int constantB = GetValue('b');
                equation = ModifyEquationAccordingToConstantB(constantB, equation);
                Console.WriteLine();

                int constantC = GetValue('c');
                equation = ModifyEquationAccordingToConstantC(constantC, equation);

                Console.WriteLine();


                if (constantA == 0)
                {
                    Console.WriteLine("Invalid equation. 'a' can not be 0");
                }

                else
                {
                    Console.WriteLine($"Our equation : {equation} = 0");
                    Console.WriteLine();

                }



                int discriminant = constantB * constantB - 4 * constantA * constantC;

                if (discriminant >= 0)
                {

                    Console.WriteLine(Math.Sqrt(discriminant));


                    double solution1 = (-(constantB) + Math.Sqrt(discriminant)) / (2 * constantA);
                    double solution2 = (-(constantB) - Math.Sqrt(discriminant)) / (2 * constantA);




                    Console.WriteLine($"Solution 1: {solution1}     Solution 2 : {solution2}");
                    Console.WriteLine();
                }

                else if (discriminant < 0)
                {
                    Console.OutputEncoding = System.Text.Encoding.UTF8;

                    string solution1;
                    string solution2;
                    if (constantB == 0)
                    {
                        solution1 = $"i√{discriminant} / {2 * constantA}";
                        solution2 = $"- i√{discriminant} / {2 * constantA}";
                    }
                    else
                    {
                        solution1 = $"-{constantB} + i√{discriminant} / {2 * constantA}";
                        solution2 = $"-{constantB} - i√{discriminant} / {2 * constantA}";
                    }


                    Console.WriteLine($"Two complex solutions : {solution1} and {solution2}");
                    Console.WriteLine();
                }



                playAgain = AskPlayAgain();


            }







        }





        public static int GetValue(char constant)
        {
            int result;

            Console.WriteLine($"Enter the value for constant '{constant}' :");
            string input = Console.ReadLine();

            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("Invalid input. Try again:");
                input = Console.ReadLine();
            }

            return result;
        }


        public static string ModifyEquationAccordingToConstantA(int constantA, string equation)
        {
            if (constantA != 1 && constantA > 0)
            {
                equation += $"{constantA}x^2";
            }
            else if (constantA == 1)
            {
                equation += "x^2";

            }
            else if (constantA == -1)
            {
                equation += "- x^2";
            }
            else if (constantA < 0)
            {
                equation += $" - {Math.Abs(constantA)}x^2";
            }

            return equation;
        }


        public static string ModifyEquationAccordingToConstantB(int constantB, string equation)
        {
            if (constantB > 0 && constantB != 1)
            {
                equation += $" + {constantB}x";
            }
            else if (constantB == 1)
            {
                equation += " + x";
            }
            else if (constantB == -1)
            {
                equation += " - x";
            }
            else if (constantB < 0)
            {
                equation += $" - {Math.Abs(constantB)}x";
            }
            return equation;

        }




        public static string ModifyEquationAccordingToConstantC(int constantC, string equation)
        {
            if (constantC > 0)
            {
                equation += $" + {constantC}";
            }
            else if (constantC == -1)
            {
                equation += $" - {Math.Abs(constantC)}";
            }
            else if (constantC < 0)
            {
                equation += $" - {Math.Abs(constantC)}";
            }
            return equation;

        }


        public static bool AskPlayAgain()
        {
            bool playAgain;
            Console.WriteLine("If you want to calcualte another equation, press number '0' on keyboard");
            string choice = Console.ReadLine();
            if (choice == "0")
            {
               
                Console.Clear();
                return true;
            }
            else
            {
                
                Console.WriteLine("Thank You!");
                return false;
            }

           


        }
    }
}
