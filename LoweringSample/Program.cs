using System;

namespace LoweringSample
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // Check how it initiates
            var names = new string[] { "Bence", "Shahid", "Jazeem", "Luca", "Nuref", "Ali", "Jimmy", "Emil" };

            ForeachStatement(names);
            SwitchStatement(names);
        }

        private static void ForeachStatement(string[] names)
        {
            // Check how foreach loop is converted
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private static void SwitchStatement(string[] names)
        {
            var random = new Random();
            var name = names[random.Next(0, 3)];

            // Check how switch statement is behaving
            switch (name)
            {
                case "Bence":
                    Console.WriteLine($"{name} selected");
                    break;

                case "Shahid":
                    Console.WriteLine($"{name} selected");
                    break;

                case "Jazeem":
                    Console.WriteLine($"{name} selected");
                    break;

                case "Luca":
                    Console.WriteLine($"{name} selected");
                    break;

                case "Nuref":
                    Console.WriteLine($"{name} selected");
                    break;

                case "Ali":
                    Console.WriteLine($"{name} selected");
                    break;

                //case "Jimmy":
                //    Console.WriteLine($"{name} selected");
                //    break;

                //case "Emil":
                //    Console.WriteLine($"{name} selected");
                //    break;
            }
        }
    }
}