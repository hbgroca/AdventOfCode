namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPart2 = false;

            List<int> mulSums = new ();

            string input = File.ReadAllText("input.txt");
            if (isPart2) {
                input = File.ReadAllText("inputpart2.txt");
            }

            // Make one long string by replacing line breaks
            string x = input.ReplaceLineEndings(" ");

            do
            {
                // Part 2 code
                if (isPart2){
                    do
                    {
                        int start = -1;
                        int end = -1;
                        try
                        {
                            start = x.IndexOf("don't()");

                            Console.WriteLine($"don't() @ {start}");

                            end = x.IndexOf("do()", start);
                            Console.WriteLine($"do() @ {end}");

                            int charsToRemove = end - start;

                            x = x.Remove(start, int.Abs(charsToRemove));

                            Console.WriteLine($"Removed index {start} to {start + charsToRemove}");

                        }
                        catch { }

                        if (start == -1 || end == -1) { break; }

                    } while (true);
                }
                
                // Part 1 code below
                Console.WriteLine("");
                // Find first sign of mul(
                var y = x.IndexOf("mul(");

                // If not found we break out and exit the application
                if (y == -1)
                {
                    break;
                }

                // remove anything before the finding.
                var m = x.Substring(y);

                Console.Write("mul(");

                string FirstValue = "";
                string SecondValue = "";

                int SearchCharIndex = 4;
                // Make sure the next number after ( is a number
                while (int.TryParse(m[SearchCharIndex].ToString(), out int value))
                {
                    Console.Write(value);
                    FirstValue = FirstValue + value;
                    SearchCharIndex++;
                }
                // Make sure we have , after the numbers
                if (m[SearchCharIndex] == ',')
                {
                    Console.Write(",");
                    SearchCharIndex++;
                }
                else
                {
                    Console.Write(m[SearchCharIndex] + " ! Fail");
                    // Remove everything before this finding.
                    x = m.Substring(SearchCharIndex);
                    continue;
                }

                // Make sure the next number after , is a number
                while (int.TryParse(m[SearchCharIndex].ToString(), out int value))
                {
                    Console.Write(value);
                    SecondValue = SecondValue + value;
                    SearchCharIndex++;
                }

                // Make sure we finnish with )
                if (m[SearchCharIndex] == ')')
                {
                    Console.Write(")\n");
                    Console.WriteLine($"We are calculating {FirstValue} * {SecondValue}");

                    int sum = Convert.ToInt32(FirstValue) * Convert.ToInt32(SecondValue);

                    mulSums.Add(sum);
                }

                // Remove everything before this finding.
                x = m.Substring(SearchCharIndex);

            } while (true);

            Console.WriteLine($"\nmulSum ends up to: {mulSums.Sum()}");

            Console.ReadKey();
        }
    }
}
