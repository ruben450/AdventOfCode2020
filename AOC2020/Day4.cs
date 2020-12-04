using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2020
{
    public class Day4 : Base
    {
        string inputTxt = System.IO.File.ReadAllText(@"../../../Inputs/Input4.txt");
        List<string> input = new List<string>();
        public Day4()
        {
            input = inputTxt.Split(new string[] { "\r\n\r\n" },
                StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        public override void Part1()
        {
            var validPassports = 0;
            foreach (var item in input)
            {
                var passport = item.Replace("\r\n", string.Empty);
                var byr = Regex.Match(passport, @"byr:\s*(\w*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var iyr = Regex.Match(passport, @"iyr:\s*(\w*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var eyr = Regex.Match(passport, @"eyr:\s*(\w*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var hgt = Regex.Match(passport, @"hgt:\s*(\w[0-9]*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var hcl = Regex.Match(passport, @"hcl:\s*([#\w]*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var ecl = Regex.Match(passport, @"ecl:\s*([#\w]*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var pid = Regex.Match(passport, @"pid:\s*([#\w]*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var cid = Regex.Match(passport, @"cid:\s*(\w*)", RegexOptions.IgnoreCase).Groups[1].Value;

                if (!string.IsNullOrEmpty(byr) && !string.IsNullOrEmpty(iyr) && !string.IsNullOrEmpty(eyr) &&
                    !string.IsNullOrEmpty(hgt) && !string.IsNullOrEmpty(hcl) && !string.IsNullOrEmpty(ecl) &&
                    !string.IsNullOrEmpty(pid))
                {
                    validPassports++;
                }
            }

            Console.WriteLine(validPassports);
        }

        public override void Part2()
        {
            var validPassports = 0;
            foreach (var item in input)
            {
                var passport = item.Replace("\r\n", string.Empty);
                var byr = Regex.Match(passport, @"byr:\s*(\w[0-9]*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var iyr = Regex.Match(passport, @"iyr:\s*(\w[0-9]*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var eyr = Regex.Match(passport, @"eyr:\s*(\w*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var hgt = Regex.Match(passport, @"hgt:\s*([\w]*[mn])", RegexOptions.IgnoreCase).Groups[1].Value;
                var hcl = Regex.Match(passport, @"hcl:\s*([#\w]*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var ecl = Regex.Match(passport, @"ecl:\s*([#\w]*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var pid = Regex.Match(passport, @"pid:\s*([#\w]*)", RegexOptions.IgnoreCase).Groups[1].Value;
                var cid = Regex.Match(passport, @"cid:\s*(\w*)", RegexOptions.IgnoreCase).Groups[1].Value;

                if (!string.IsNullOrEmpty(byr) && !string.IsNullOrEmpty(iyr) && !string.IsNullOrEmpty(eyr) &&
                    !string.IsNullOrEmpty(hgt) && !string.IsNullOrEmpty(hcl) && !string.IsNullOrEmpty(ecl) &&
                    !string.IsNullOrEmpty(pid))
                {
                    if (int.Parse(byr) >= 1920 && int.Parse(byr) <= 2002)
                    {
                        if (int.Parse(iyr) >= 2010 && int.Parse(iyr) <= 2020)
                        {
                            eyr = eyr.Substring(0, 4);
                            if (int.Parse(eyr) >= 2020 && int.Parse(eyr) <= 2030)
                            {
                                if (hcl.StartsWith("#"))
                                {
                                    hcl = hcl.Substring(1, 6);
                                    if (hcl.Length == 6 && Regex.Match(hcl, @"^[0-9a-zA-Z]+$", RegexOptions.IgnoreCase).Success)
                                    {
                                        ecl = ecl.Substring(0, 3);
                                        if (ecl.Length == 3)
                                        {
                                            if (ecl == "amb" || ecl == "blu" || ecl == "brn" || ecl == "gry" ||
                                                ecl == "grn" || ecl == "hzl" || ecl == "oth")
                                            {
                                                pid = Regex.Replace(pid, "[^0-9.]", "");
                                                if (pid.Length == 9)
                                                {
                                                    if (hgt.EndsWith("cm"))
                                                    {
                                                        hgt = hgt.Substring(0, hgt.Length - 2);
                                                        if (int.Parse(hgt) >= 150 &&
                                                            int.Parse(hgt) <= 193)
                                                        {
                                                            validPassports++;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        hgt = hgt.Substring(0, hgt.Length - 2);
                                                        if (int.Parse(hgt) >= 59 &&
                                                            int.Parse(hgt) <= 76)
                                                        {
                                                            validPassports++;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(validPassports);
        }
    }
}
