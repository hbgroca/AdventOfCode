namespace Day2;

internal class Program
{
    static void Main(string[] args)
    {
        bool isPart2 = true;

        int SafeReports = 0;

        // Read txt file and save to variable
        var input = File.ReadAllText("input.txt");

        // Split linebreak/lineendings with ,
        var separated = input.ReplaceLineEndings(",");

        // Split each string between , into separate strings and store in an array 
        var splittedArray = separated.Split(",");

        // Part2
        if (isPart2)
        {
            List<int> numInString = new();

            for (int i = 0; i < splittedArray.Length; i++)
            {
                //Console.WriteLine($"! - {splittedArray[i]}");

                // Split each number in string into an new array
                string[] x = splittedArray[i].Split(" ");

                // Save each value in new list
                numInString = new();
                foreach (var c in x)
                {
                    //Console.WriteLine(c);
                    numInString.Add(int.Parse(c));
                }


                // Check
                bool FailedReport = checkValue(numInString);

                if (!FailedReport)
                {
                    SafeReports++;
                    Console.WriteLine($" #  Safe: {splittedArray[i]}");
                }
                else
                {
                    Console.WriteLine($" #  Unsafe: {string.Join(", ", numInString)}");
                }
                Console.WriteLine($"");
            }
        }

        // Part 1
        else
        {
            foreach (var separatedString in splittedArray)
            {

                Console.WriteLine(separatedString);

                string Direction = null!;
                bool isSafe = true;

                // Split each number into an new array
                string[] x = separatedString.Split(" ");

                // We check each number agains each other
                for (int i = 1; i < x.Length; i++)
                {
                    if (Direction == null)
                    {
                        if (Convert.ToInt32(x[0]) < Convert.ToInt32(x[1]))
                        {
                            Console.WriteLine(" Direction is set to positive");
                            Direction = "positive";
                        }
                        else
                        {
                            Console.WriteLine(" Direction is set to negative");
                            Direction = "negative";
                        }
                    }


                    if (Direction == "positive")
                    {
                        int relative = Convert.ToInt32(x[i]) - Convert.ToInt32(x[i - 1]);
                        Console.WriteLine($"  Checking: {x[i]} - {x[i - 1]} = {relative}");

                        if (relative > 3 || relative < 1)
                        {
                            Console.WriteLine($"   Failed: {x[i]} - {x[i - 1]} = {relative}. Is outside of 1-3");
                            isSafe = false;
                            break;
                        }
                    }
                    else
                    {
                        int relative = Convert.ToInt32(x[i - 1]) - Convert.ToInt32(x[i]);
                        Console.WriteLine($"  Checking: {x[i - 1]} - {x[i]} = {relative}");

                        if (relative > 3 || relative < 1)
                        {
                            Console.WriteLine($"   Failed: {x[i]} - {x[i - 1]} = {relative}. Is outside of 1-3");
                            isSafe = false;
                            break;
                        }
                    }
                }

                if (isSafe)
                {
                    SafeReports++;
                    Console.WriteLine($" #  Safe: {separatedString}");
                }
                else
                {
                    Console.WriteLine($" #  Unsafe: {separatedString}");
                }
                Console.WriteLine($"");
            }

        }
        
        Console.WriteLine($"Safe reports: {SafeReports} of {splittedArray.Length}");

        Console.ReadKey();
    }

    static public bool checkValue(List<int> input)
    {
        string Direction = null!;
        bool failed = false;
        bool numberHasBeenRemoved = false;
        int iterations = input.Count;
        bool leaveLoop = false;
        do
        {
            Console.Write($"Current: ");
            foreach (var value in input)
            {
            Console.Write($"{value} ");
            }
            Console.Write($"\n");

            bool firstNr = true;
            // We check each number agains each other
            for (int m = 0; m < iterations; m++)
            {
                // Check direction
                if (Direction == null)
                {
                    if (Convert.ToInt32(input[0]) < Convert.ToInt32(input[input.Count()-1]))
                    {
                        Console.WriteLine(" Direction is set to positive");
                        Direction = "positive";
                    }
                    else
                    {
                        Console.WriteLine(" Direction is set to negative");
                        Direction = "negative";
                    }
                }

                int relative = 1;
                if (Direction == "positive")
                {
                    try
                    {
                        relative = input[m + 1] - input[m];
                        Console.Write($"  Checking: {input[m + 1]} - {input[m]} = {relative}");
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        relative = input[m] - input[m + 1];
                        Console.Write($"  Checking: {input[m]} - {input[m + 1]} = {relative}");
                    }
                    catch { }
                }

                if (relative > 3 || relative < 1)
                {
                    Console.Write($" - Failed\n");

                    if (!numberHasBeenRemoved)
                    {
                        if (Direction == "positive")
                        {
                            try
                            {
                                relative = input[m + 2] - input[m];
                                Console.Write($"  Checking: {input[m + 1]} - {input[m]} = {relative}\n");
                                if (firstNr)
                                {
                                    if (relative > 3 || relative < 1)
                                    {
                                        input.RemoveAt(m);
                                        Console.WriteLine($"{input[m]} was removed. v");
                                    }
                                    else
                                    {
                                        input.RemoveAt(m + 1);
                                        Console.WriteLine($"{input[m + 1]} was removed. x");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"{input[m]} was removed. n");
                                    input.RemoveAt(m);
                                }
                            }
                            catch { }
                            firstNr = false;
                        }
                        else
                        {
                            try
                            {
                                relative = input[m] - input[m + 2];
                                Console.Write($"  Checking: {input[m]} - {input[m + 1]} = {relative}\n");
                                if (firstNr)
                                {
                                    if (relative > 3 || relative < 1)
                                    {
                                        input.RemoveAt(m);
                                        Console.WriteLine($"{input[m]} was removed. v ");
                                    }
                                    else
                                    {
                                        input.RemoveAt(m + 1);
                                        Console.WriteLine($"{input[m + 1]} was removed. x");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"{input[m]} was removed. n");
                                    input.RemoveAt(m);
                                }
                                firstNr = false;
                            }
                            catch { }
                            firstNr = false;
                        }
                        numberHasBeenRemoved = true;
                        m = -2;
                        continue;
                    }
                    else
                    {
                        //Console.WriteLine($"{input[m]} was not ok");
                        return true;
                    }
                }
                else
                {
                    leaveLoop = true;
                    Console.Write($" - OK\n");
                }
            }
        } while (!leaveLoop);


        return failed;
    }
}
