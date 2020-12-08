using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020
{
    public class Day7 : Base
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input7.txt");
        List<string> input = new List<string>();
        Dictionary<string, List<string>> bagsDetails = new Dictionary<string, List<string>>();
        List<string> toLook = new List<string>();
        List<string> toLookHistory = new List<string>();
        public Day7()
        {
            input = inputTxt.Split(new[] { Environment.NewLine },
                StringSplitOptions.None).ToList();

            foreach (var rule in input)
            {
                var bag = rule.Split("contain")[0];
                bag = bag.Remove(bag.Length - 1);
                bagsDetails.Add(bag, new List<string>());

                foreach (var contains in rule.Split("contain")[1].Split(","))
                {
                    if (contains.EndsWith("."))
                    {
                        bagsDetails[bag].Add(BagWithS(contains.Remove(contains.Length - 1)));
                    }
                    else if (contains.StartsWith(" "))
                    {
                        bagsDetails[bag].Add(BagWithS(contains.Substring(1, contains.Length - 1)));
                    }
                    else
                    {
                        bagsDetails[bag].Add(BagWithS(contains));
                    }
                }
            }
        }
        public override void Part1()
        {
            int amount = 0;
            foreach (var bagsDetail in bagsDetails)
            {
                if (bagsDetail.Value.Any(x => x.Contains("shiny gold")))
                {
                    toLook.Add(bagsDetail.Key);
                    //amount++;
                }
            }

            while (toLook.Count > 1)
            {
                amount += RecursiveSearch();
            }
            Console.WriteLine(amount);
        }

        public override void Part2()
        {
            throw new NotImplementedException();
        }

        private int RecursiveSearch()
        {
            var amount = 0;
            var toLookCount = toLook.Count;
            var toRemove = new List<string>();

            for (int i = 0; i < toLookCount; i++)
            {
                var toAdd = bagsDetails.Where(x => x.Value.Any(y => y.EndsWith(toLook[i]))).Select(x => x.Key).ToList();
                amount++;
                foreach (var add in toAdd)
                {
                    if (!toLook.Contains(add) && bagsDetails.Where(x => x.Value.Any(y => y.EndsWith(add))).ToList().Count > 0 && !toLookHistory.Contains(add))
                        toLook.Add(add);
                    else if (bagsDetails.Where(x => x.Value.Any(y => y.EndsWith(add))).ToList().Count == 0 && !toLookHistory.Contains(add))
                        amount++;
                    toLookHistory.Add(add);
                }
                toRemove.Add(toLook[i]);
            }

            foreach (var remove in toRemove)
            {
                toLook.Remove(remove);
            }

            return amount;
        }

        private string BagWithS(string bag)
        {
            if (bag.EndsWith("s"))
                return bag;
            return bag + "s";
        }
    }
}
