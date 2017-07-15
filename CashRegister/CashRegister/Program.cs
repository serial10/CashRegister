using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            List<float> cashRegister = new List<float>();
            Console.WriteLine("Enter the prices for items, press q and hit enter when you are done.");
            float number;
            string input = Console.ReadLine();
            float.TryParse(input,out number);
            while (input != "total")
            { 
                if (input == "exit")
                {
                    Environment.Exit(0);
                }
                else if (input == "subtotal")
                {
                    float subTotal = cashRegister.Sum();
                    Console.WriteLine("Subtotal: {0:C2}", subTotal);
                    Console.WriteLine("You can enter more prices or if you are done, type q and hit enter.");
                    input = Console.ReadLine();
                    float.TryParse(input, out number);
                    continue;
                }
                else if (!IsANumber(input))
                {                   
                    Console.WriteLine($"{input} is not a valid dollar amount. Please enter only numbers greater than 0.");
                    input = Console.ReadLine();
                    float.TryParse(input, out number);
                    continue;
                }                
                else
                { 
                    float addInput = float.Parse(input);
                    cashRegister.Add(addInput);
                    Console.WriteLine("Enter the prices for items, press q and hit enter when you are done.");
                    input = Console.ReadLine();
                    float.TryParse(input, out number);
                }
            }
            //float taxRate = .03f;
            //float overAllTotal = (cashRegister.Sum() * taxRate) + cashRegister.Sum();
            //Console.WriteLine("Your SubTotal: {0:C2} Your Total: {1:C2}", cashRegister.Sum(),overAllTotal();
            var sumOfCash = cashRegister.Sum();
            Console.WriteLine("Your SubTotal: {0:C2} Your Total: {1:C2}", sumOfCash, Total(sumOfCash));
        }       
        static bool IsANumber(string inputToCheck)
        {
            double defaultValue;
            var isANumber = Double.TryParse(inputToCheck, out defaultValue);
            return isANumber;
        }
        static float Total (float numbersToCalculate)
        {
            float taxRate = .03f;
            float overAllTotal = (numbersToCalculate * taxRate) + numbersToCalculate;
            return overAllTotal;
        }
    }
}