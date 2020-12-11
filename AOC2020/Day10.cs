using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020
{
    public class Day10 : Base
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input10.txt");
        List<int> input = new List<int>();
        public Day10()
        {
            input = inputTxt.Split('\n').Select(int.Parse).ToList();
        }
        public override void Part1()
        {
            var jolt1 = 0;
            var jolt3 = 0;
            var outlet = 0;
            input.Sort();
            foreach (var adapter in input)
            {
                Console.WriteLine($"source = {outlet} plugging in {adapter}");
                if (adapter > outlet)
                {
                    if (adapter - outlet == 1)
                        jolt1++;
                    else if (adapter - outlet == 3)
                        jolt3++;
                    outlet = adapter;
                }
            }

            jolt3++;

            Console.WriteLine("------------------------");
            Console.WriteLine("jolt 1 differences = " + jolt1);
            Console.WriteLine("jolt 3 differences = " + jolt3);
            Console.WriteLine("sum = " + jolt1 * jolt3);
        }

        public override void Part2()
        {
            throw new NotImplementedException();
        }
    }
}
