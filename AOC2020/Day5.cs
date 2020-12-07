using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020
{
    public class Day5 : Base
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input5.txt");
        List<string> input = new List<string>();

        public Day5()
        {
            input = inputTxt.Split(new[] { Environment.NewLine },
                StringSplitOptions.None).ToList();
        }
        public override void Part1()
        {
            var highestSeatId = 0;
            foreach (var seat in input)
            {
                var rowIndicator = seat.Substring(0, 7);
                var columnIndicator = seat.Substring(7, 3);
                var seatId = GetSeatId(rowIndicator, columnIndicator);
                if (seatId > highestSeatId)
                {
                    highestSeatId = seatId;
                }
            }
            Console.WriteLine(highestSeatId);
        }

        public override void Part2()
        {
            List<int> seatIds = new List<int>();
            foreach (var seat in input)
            {
                var rowIndicator = seat.Substring(0, 7);
                var columnIndicator = seat.Substring(7, 3);
                var seatId = GetSeatId(rowIndicator, columnIndicator);
                seatIds.Add(seatId);
            }
            seatIds.Sort();
            for (int i = 0; i < seatIds.Count; i++)
            {
                if (seatIds[i] != i + 27)
                {
                    Console.WriteLine(seatIds[i]);
                    break;
                }
            }
        }

        private int GetSeatId(string rowIndicator, string columnIndicator)
        {
            var rowMin = 0;
            var rowMax = 127;
            var columnMin = 0;
            var columnMax = 7;
            for (int i = 0; i < 7; i++)
            {
                if (rowIndicator[i] == 'B')
                {
                    var diff = rowMax - rowMin;
                    rowMin += (int)Math.Ceiling((double)diff / 2);
                }
                if (rowIndicator[i] == 'F')
                {
                    var diff = rowMax - rowMin;
                    rowMax -= (int)Math.Ceiling((double)diff / 2);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (columnIndicator[i] == 'R')
                {
                    var diff = columnMax - columnMin;
                    columnMin += (int)Math.Ceiling((double)diff / 2);
                }
                if (columnIndicator[i] == 'L')
                {
                    var diff = columnMax - columnMin;
                    columnMax -= (int)Math.Ceiling((double)diff / 2);
                }
            }
            return rowMax * 8 + columnMax;
        }
    }
}
