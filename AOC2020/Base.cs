using System;
using System.Diagnostics;

namespace AOC2020
{
    public abstract class Base
    {
        public abstract void Part1();
        public abstract void Part2();
        public void HandleSelect()
        {
            var watch = new Stopwatch();
            // the code that you want to measure comes here
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine("Do you want to solve Part 1 or 2?");
            switch (Console.ReadLine())
            {
                case "1":
                    watch.Start();
                    Part1();
                    watch.Stop();
                    Console.WriteLine("Time to solve: " + watch.ElapsedMilliseconds +"ms");
                    break;
                case "2":
                    watch.Start();
                    Part2();
                    watch.Stop();
                    Console.WriteLine("Time to solve: " + watch.ElapsedMilliseconds);
                    break;
                default:
                    Console.WriteLine($"Not implemented");
                    HandleSelect();
                    break;
            }
        }
    }
}
