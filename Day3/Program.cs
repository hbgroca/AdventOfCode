namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> mulSums = new (); 

            string input = File.ReadAllText("input.txt");

            // Make one long string by replacing line breaks
            var x = input.ReplaceLineEndings(" ");

            do
            {
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
