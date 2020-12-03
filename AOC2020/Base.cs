using System;

namespace AOC2020
{
    public abstract class Base
    {
        public abstract void Part1();
        public abstract void Part2();
        public void HandleSelect()
        {
            Console.WriteLine("Do you want to solve Part 1 or 2?");

            switch (Console.ReadLine())
            {
                case "1":
                    Part1();
                    break;
                case "2":
                    Part2();
                    break;
                default:
                    Console.WriteLine($"Not implemented");
                    HandleSelect();
                    break;
            }
        }
    }
}
