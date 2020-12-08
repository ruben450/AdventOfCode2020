using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020
{
    public class Day8 : Base
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input8.txt");
        List<string> input = new List<string>();
        public Day8()
        {
            input = inputTxt.Split(new[] { Environment.NewLine },
                StringSplitOptions.None).ToList();
        }

        public override void Part1()
        {
            int acc = 0;
            int index = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[index].StartsWith("done"))
                {
                    break;
                }
                var action = input[index].Split(" ")[0];
                var amount = int.Parse(input[index].Split(" ")[1]);

                switch (action)
                {
                    case "acc":
                        acc += amount;
                        input[index] = "done";
                        index++;
                        break;
                    case "jmp":
                        input[index] = "done";
                        index += amount;
                        break;
                    case "nop":
                        index++;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(acc);
        }

        public override void Part2()
        {
            int acc = 0;
            int index = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[index].StartsWith("done"))
                {
                    break;
                }
                var action = input[index].Split(" ")[0];
                var amount = int.Parse(input[index].Split(" ")[1]);

                switch (action)
                {
                    case "acc":
                        acc += amount;
                        input[index] = "done";
                        index++;
                        break;
                    case "jmp":
                        input[index] = "done";
                        index += amount;
                        break;
                    case "nop":
                        index++;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(acc);
        }
    }
}
