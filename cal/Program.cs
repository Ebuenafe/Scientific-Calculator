using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cal
{
        public class CalculatorCore
        {
            public double Add(double a, double b) => a + b;
            public double Subtract(double a, double b) => a - b;
            public double Multiply(double a, double b) => a * b;
            public double Divide(double a, double b)
            {
                if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
                return a / b;
            }

            public double SquareRoot(double a) => Math.Sqrt(a);
            public double Power(double a, double b) => Math.Pow(a, b);
            public double Sin(double angleInDegrees) => Math.Sin(DegreeToRadian(angleInDegrees));
            public double Cos(double angleInDegrees) => Math.Cos(DegreeToRadian(angleInDegrees));
            public double Tan(double angleInDegrees) => Math.Tan(DegreeToRadian(angleInDegrees));
            private double DegreeToRadian(double angle) => angle * (Math.PI / 180);
        }

        public class CalculatorService
        {
            private readonly CalculatorCore _calculatorCore;

            public CalculatorService()
            {
                _calculatorCore = new CalculatorCore();
            }

        public double ProcessCalculation(string operation, double a, double b = 0)
        {
            switch (operation.ToLower())
            {
                case "add":
                    return _calculatorCore.Add(a, b);
                case "subtract":
                    return _calculatorCore.Subtract(a, b);
                case "multiply":
                    return _calculatorCore.Multiply(a, b);
                case "divide":
                    return _calculatorCore.Divide(a, b);
                case "sqrt":
                    return _calculatorCore.SquareRoot(a);
                case "power":
                    return _calculatorCore.Power(a, b);
                case "sin":
                    return _calculatorCore.Sin(a);
                case "cos":
                    return _calculatorCore.Cos(a);
                case "tan":
                    return _calculatorCore.Tan(a);
                default:
                    throw new InvalidOperationException("Invalid operation.");
            }
        }
    }

        public class CalculatorUI
        {
            private readonly CalculatorService _calculatorService;

            public CalculatorUI()
            {
                _calculatorService = new CalculatorService();
            }

            public void Run()
            {
                while (true)
                {
                    Console.WriteLine("Enter operation (add, subtract, multiply, divide, sqrt, power, sin, cos, tan) or 'exit' to quit:");
                    string operation = Console.ReadLine().ToLower();

                    if (operation == "exit") break;

                    Console.WriteLine("Enter the first number:");
                    if (!double.TryParse(Console.ReadLine(), out double a))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        continue;
                    }

                    double b = 0;
                    if (operation != "sqrt" && operation != "sin" && operation != "cos" && operation != "tan")
                    {
                        Console.WriteLine("Enter the second number:");
                        if (!double.TryParse(Console.ReadLine(), out b))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            continue;
                        }
                    }

                    try
                    {
                        double result = _calculatorService.ProcessCalculation(operation, a, b);
                        Console.WriteLine($"The result is: {result}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                CalculatorUI calculatorUI = new CalculatorUI();
                calculatorUI.Run();
            }
        }
    }
