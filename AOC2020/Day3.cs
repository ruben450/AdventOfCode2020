using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020
{
    public class Day3 : Base
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input3.txt");
        List<string> input = new List<string>();

        public Day3()
        {
            input = inputTxt.Split(new[] { Environment.NewLine },
                StringSplitOptions.None).ToList();
        }

        public override void Part1()
        {
            Console.WriteLine(CountTrees(3, 1));
        }

        public override void Part2()
        {
            long trees = CountTrees(1, 1);
            trees *= CountTrees(3, 1);
            trees *= CountTrees(5, 1);
            trees *= CountTrees(7, 1);
            trees *= CountTrees(1, 2);

            Console.WriteLine(trees);
        }

        private int CountTrees(int x, int y)
        {
            var trees = 0;
            var right = 0;
            var down = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (right >= 31)
                    right -= 31;
                char spot = new char();
                if (down <= input.Count)
                    spot = input[down][right];

                if (spot == '#')
                {
                    trees++;
                }

                right += x;
                down += y;
            }

            return trees;
        }
    }
}
