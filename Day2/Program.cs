namespace Day2;

internal class Program
{
    static void Main(string[] args)
    {
        int SafeReports = 0;

        // Read txt file and save to variable
        var input = File.ReadAllText("input.txt");

        // Split linebreak/lineendings with ,
        var separated = input.ReplaceLineEndings(",");

        // Split each string between , into separate strings and store in an array 
        var splittedArray = separated.Split(",");


        foreach (var separatedString in splittedArray) {

            Console.WriteLine(separatedString);

            string Direction = null!;
            bool isSafe = true;

            // Split each number into an new array
            string[] x = separatedString.Split(" ");

            // We check each number agains each other
            for (int i = 1; i < x.Length; i++)
            {
                if(Direction == null)
                {
                    if(Convert.ToInt32(x[0]) < Convert.ToInt32(x[1]))
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


                if(Direction == "positive")
                {
                    int relative = Convert.ToInt32(x[i]) - Convert.ToInt32(x[i - 1]);
                    Console.WriteLine($"  Checking: {x[i]} - {x[i - 1]} = {relative}");

                    if(relative > 3 || relative < 1)
                    {
                        Console.WriteLine($"   Failed: {x[i]} - {x[i - 1]} = {relative}. Is outside of 1-3");
                        isSafe = false;
                        break;
                    }
                }
                else
                {
                    int relative = Convert.ToInt32(x[i-1]) - Convert.ToInt32(x[i]);
                    Console.WriteLine($"  Checking: {x[i-1]} - {x[i]} = {relative}");

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
            else {
                Console.WriteLine($" #  Unsafe: {separatedString}");
            }
            Console.WriteLine($"");
        }
        Console.WriteLine($"Safe reports: {SafeReports}");

        Console.ReadKey();
    }
}
