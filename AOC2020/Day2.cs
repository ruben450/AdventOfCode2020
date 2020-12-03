using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020
{
    public class Day2
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input2.txt");
        List<string> input = new List<string>();
        public Day2()
        {
            input = inputTxt.Split(new[] { Environment.NewLine },
                StringSplitOptions.None).ToList();


            var goodPasswords = 0;
            foreach (var item in input)
            {
                var rule = item.Split(' ')[0];
                var ruleA = int.Parse(rule.Split('-')[0]);
                var ruleB = int.Parse(rule.Split('-')[1]);

                var letter = item.Split(' ')[1].Remove(1);

                var password = item.Split(' ')[2];


                if (MinOneCharMatch(ruleA, ruleB, Char.Parse(letter), password))
                {
                    goodPasswords++;
                }
            }

            Console.WriteLine(goodPasswords);
        }

        public bool CountChar(int min, int max, char letter, string word)
        {
            var amount = word.Count(x => x == letter);
            return amount >= min && amount <= max;
        }

        public bool MinOneCharMatch(int min, int max, char letter, string word)
        {
            var matches = 0;
            if (word[min -1] == letter)
            {
                matches++;
            }

            if (word[max -1] == letter)
            {
                matches++;
            }

            return matches == 1;
        }
    }
}
