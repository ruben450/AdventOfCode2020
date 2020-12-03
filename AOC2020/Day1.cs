using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020
{
    public class Day1
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input1.txt");
        List<int> input = new List<int>();
        public Day1()
        {
            input = inputTxt.Split('\n').Select(int.Parse).ToList();
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    for (int k = 0; k < input.Count; k++)
                    {
                        if (input[i] + input[j] + input[k] == 2020)
                        {
                            Console.WriteLine(input[i] * input[j] * input[k]);
                        }
                    }
                }
            }
        }
    }
}
