namespace ConsoleApp1
{
    internal class Program
    {
        static public List<int> leftBank = [];
        static public List<int> rightBank = [];

        static void Main(string[] args)
        {
            Methods _methods = new ();

            // Get input file
            var file = File.ReadAllText("input.txt");

            // Replace line endings with 3 spaces.

            var m = file.ReplaceLineEndings("   ");
            // Split in to array where we have 3 spaces.
            var y = m.Split("   ");

            // Sort left and right bank
            _methods.SortLeftAndRight(y);

            // Sort by number
            _methods.SortByNumber();

            // Messure distance between
            _methods.MessureDistance();

            // Kill the application
            Console.ReadKey();
        }

        public class Methods
        {
            public void SortLeftAndRight(string[] input)
            {
                // For each word / line in the list we split them up to each list bank
                bool SaveToLeftBank = true;
                foreach (var line in input)
                {
                    Console.WriteLine($"Saving the value {line} to the {(SaveToLeftBank ? "Left bank" : "Right Bank")}");
                    if (SaveToLeftBank)
                    {
                        leftBank.Add(Convert.ToInt32(line));
                    }
                    else
                        rightBank.Add(Convert.ToInt32(line));

                    // Reverse the bool value.
                    SaveToLeftBank = !SaveToLeftBank;
                }
            }

            public void SortByNumber()
            {
                leftBank.Sort();
                rightBank.Sort();
            }

            public void MessureDistance()
            {
                List<int> distance = new();

                for (int i = 0; i < leftBank.Count; i++)
                {
                    distance.Add(int.Abs(leftBank[i] - rightBank[i]));
                    Console.WriteLine(distance[i]);
                }

                int x = distance.Sum();
                Console.WriteLine($"Total distance is {x}");
            }
        }

    }
}
