using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020
{
    public class Day3
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input3.txt");
        List<string> input = new List<string>();

        public Day3()
        {
            input = inputTxt.Split(new[] { Environment.NewLine },
                StringSplitOptions.None).ToList();

            var trees = CountTrees(1,1) * CountTrees(3, 1) * CountTrees(5, 1) * CountTrees(7, 1) * CountTrees(1, 2);

            Console.WriteLine(trees);
        }

        public int CountTrees(int x, int y)
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
