using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020
{
    public class Day8 : Base
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input8.txt");
        List<string> input = new List<string>();
        List<string> inputMemory = new List<string>();
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
            var result = 0;
            inputMemory = new List<string>(input);
            for (int i = 0; i < input.Count; i++)
            {
                result = Operate();
                inputMemory = new List<string>(input);
                if (result == 0)
                {
                    var toCheck = inputMemory[i].Split(" ")[0];
                    if (toCheck == "nop")
                    {
                        inputMemory[i] = "jmp " + inputMemory[i].Split(" ")[1];
                    }
                    else if (toCheck == "jmp")
                    {
                        inputMemory[i] = "nop " + inputMemory[i].Split(" ")[1];
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(result);
        }

        private int Operate()
        {
            int acc = 0;
            int index = 0;
            Console.WriteLine("Operate called");
            for (int i = 0; i < input.Count; i++)
            {
                if (index >= input.Count)
                    break;
                var action = inputMemory[index].Split(" ")[0];
                var amount = int.Parse(inputMemory[index].Split(" ")[1]);

                if (index == input.Count -1)
                {
                    switch (action)
                    {
                        case "acc":
                            acc += amount;
                            //input[index] = "done" + input[index];
                            index++;
                            break;
                        case "jmp":
                            //input[index] = "done" + input[index];
                            index += amount;
                            break;
                        case "nop":
                            index++;
                            break;
                        default:
                            break;
                    }
                    return acc;
                }
                switch (action)
                {
                    case "acc":
                        acc += amount;
                        //input[index] = "done" + input[index];
                        index++;
                        break;
                    case "jmp":
                        //input[index] = "done" + input[index];
                        index += amount;
                        break;
                    case "nop":
                        index++;
                        break;
                    default:
                        break;
                }
            }

            return 0;
        }
    }
}
