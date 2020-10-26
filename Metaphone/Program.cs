using System;

namespace Metaphone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"solitude => {Metaphone.Encode("solitude")}");
            Console.WriteLine($"debunker => {Metaphone.Encode("debunker")}");
            Console.WriteLine($"aardvark => {Metaphone.Encode("aardvark")}");
        }
    }
}
