using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020
{
    public class Day11 : Base
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input11.txt");
        List<string> input = new List<string>();
        Dictionary<KeyValuePair<int,int>, char> seats = new Dictionary<KeyValuePair<int, int>, char>();
        public Day11()
        {
            input = inputTxt.Split(new[] { Environment.NewLine },
                StringSplitOptions.None).ToList();
            for (int i = 0; i < input.Count; i++)
            {
                var row = input[i].ToCharArray();
                for (int j = 0; j < row.Length; j++)
                {
                    seats.Add(new KeyValuePair<int, int>(i , j), row[j]);
                }
            }
        }
        public override void Part1()
        {
            var keys = new List<KeyValuePair<int,int>>(seats.Keys);
            foreach (var key in keys)
            {
                if (seats[key] == 'L')
                    seats[key] = '#';
            }

            Console.WriteLine();
        }

        public override void Part2()
        {
            throw new NotImplementedException();
        }

        private void CheckAdjacent(KeyValuePair<int, int> location)
        {
            List<KeyValuePair<int, int>> toCheck = new List<KeyValuePair<int, int>>();


        }
    }
}
