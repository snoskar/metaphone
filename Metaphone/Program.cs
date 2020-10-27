using System;

namespace Metaphone
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo();

            Console.WriteLine("Type 'exit' to exit.");

            while (true)
            {
                Console.Write("Input: ");
                var input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                Console.WriteLine($"{input} => {Metaphone.Encode(input)}");
            }
        }

        private static void Demo()
        {
            var demoValues = new[] { "solitude", "debunker", "aardvark", "cutlass", "metaphone", "kiss", "roosevelt", "knock", "xanadu" };

            foreach (var demoValue in demoValues)
            {
                Console.WriteLine($"{demoValue} => {Metaphone.Encode(demoValue)}");
            }

            Console.WriteLine("");
        }
    }
}
