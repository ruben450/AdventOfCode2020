using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2020
{
    public class Day9 : Base
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input9.txt");
        List<long> input = new List<long>();
        Dictionary<string, KeyValuePair<List<long>, bool>> trySum = new Dictionary<string, KeyValuePair<List<long>, bool>>();
        public Day9()
        {
            input = inputTxt.Split('\n').Select(long.Parse).ToList();
            for (int i = 0; i < input.Count - 25; i++)
            {
                trySum.Add(Guid.NewGuid().ToString() + input[i + 25].ToString(), new KeyValuePair<List<long>, bool>(input.Skip(i).Take(25).ToList(), false));
            }
        }
        public override void Part1()
        {
            // Create a TaskFactory and pass it our custom scheduler.
            List<Task> tasks = new List<Task>();
            TaskFactory factory = new TaskFactory();
            CancellationTokenSource cts = new CancellationTokenSource();

            foreach (var item in trySum)
            {
                Task t = new Task(() => {
                    ThreadFunc(item.Key, item.Value.Key);
                }, cts.Token);
                tasks.Add(t);
            }
            foreach (var item in tasks)
            {
                item.Start();
            }
            Task.WaitAll(tasks.ToArray());
            cts.Dispose();
            var result = trySum.FirstOrDefault(x => x.Value.Value).Key;
            Console.WriteLine(result.Substring(36, result.Length - 36));
        }

        public override void Part2()
        {
            long answerPart1 = 177777905;

            var index = 2;
            var skip = 0;
            var loop = true;
            while (loop)
            {
                var values = input.Skip(skip).Take(index).ToList();
                var result = FindSetMakesSum(values);
                index++;
                if (result > answerPart1)
                {
                    skip++;
                    index = 2;
                }
                if (result == answerPart1)
                {
                    loop = false;
                    Console.WriteLine(values.Min() + values.Max());
                }
            } 
        }

        private bool TryEverySum(long total, List<long> values)
        {
            if (values.Count < 2)
            {
                return false;
            }
            var correct = 0;
            for (int i = 0; i < values.Count - 1; i++)
            {
                var a = values[0];
                var b = values[i + 1];
                if (a + b == total)
                    correct++;
            }
            if(correct >= 1)
                return false;
            return true;
        }

        private long FindSetMakesSum(List<long> values)
        {
            long sum = 0;
            for (int i = 0; i < values.Count; i++)
            {
                sum += values[i];
            }
            return sum;
        }

        private void ThreadFunc(string total, List<long> values) 
        {
            var loop = true;
            var valuesToTry = new List<long> (values);
            var totalLong = long.Parse(total.Substring(36, total.Length - 36));
            while (loop)
            {
                loop = TryEverySum(totalLong, valuesToTry);
                valuesToTry.RemoveAt(0);
            }
            if (valuesToTry.Count >= 1)
            {
                lock (trySum)
                {
                    trySum[total] = new KeyValuePair<List<long>, bool>(new List<long>(values), false);
                }
            }
            else if (valuesToTry.Count == 0)
            {
                lock (trySum)
                {
                    trySum[total] = new KeyValuePair<List<long>, bool>(new List<long> (values), true);
                }
            }
        }
    }
}
