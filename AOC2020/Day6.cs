using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020
{
    public class Day6 : Base
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input6.txt");
        List<string> input = new List<string>();

        public Day6()
        {
            input = inputTxt.Split(new string[] { "\r\n\r\n" },
                StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        public override void Part1()
        {
            var yes = 0;
            foreach (var item in input)
            {
                string[] stringSeparators = new string[] { "\r\n" };
                var groups = item.Split(stringSeparators, StringSplitOptions.None);
                var groupQuestions = "";
                foreach (var answers in groups)
                {
                    var result = RemoveDuplicates(answers);
                    groupQuestions += result;
                }
                groupQuestions = RemoveDuplicates(groupQuestions);
                yes += groupQuestions.Length;
            }
            Console.WriteLine(yes);
        }

        public override void Part2()
        {
            var yes = 0;
            foreach (var item in input)
            {
                string[] stringSeparators = new string[] { "\r\n" };
                var groups = item.Split(stringSeparators, StringSplitOptions.None);
                foreach (var answers in groups)
                {
                    var neededYes = groups.Length;
                    var answersDistinct = RemoveDuplicates(answers);
                    foreach (var letter in answersDistinct)
                    {
                        if (item.Count(x => x == letter) == neededYes)
                        {
                            yes += 1;
                        }
                    }
                    break;
                }
            }
            Console.WriteLine(yes);
        }

        private string RemoveDuplicates(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }
    }
}
