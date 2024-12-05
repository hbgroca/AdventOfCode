namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPart2 = true;

            if (isPart2) {
                Part2();
                return;
            }

            string input = File.ReadAllText("input.txt");

            Console.WriteLine(input);
            Console.WriteLine("");

            int stringXMASCounter = 0;

            // Split in to array where when ever we have 3 spaces.
            var lines = input.Split("\r\n");
            int lineLength = lines[0].Length;
            int charStartPoint = 0;
            

            Console.WriteLine($"Letters in lenght: {lineLength}");

            // Horizontal search
            Console.WriteLine("Horisontal");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($" - {lines[i]}");

                int charPosition = 0;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    string letter1 = "";
                    string letter2 = "";
                    string letter3 = "";
                    string letter4 = "";

                    letter1 = lines[i][j].ToString();
                    try
                    {

                        letter2 = lines[i][j + 1].ToString();
                        letter3 = lines[i][j + 2].ToString();
                        letter4 = lines[i][j + 3].ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    string result = (letter1 + letter2 + letter3 + letter4);
                    if (result == "XMAS" || result == "SAMX")
                    {
                        stringXMASCounter++;
                    }

                    Console.WriteLine(letter1 + letter2 + letter3 + letter4);
                    charPosition++;
                }
            }


            // Vertical
            Console.WriteLine("Vertical");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($" - {lines[i]}");

                int charPosition = 0;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    string letter1 = "";
                    string letter2 = "";
                    string letter3 = "";
                    string letter4 = "";

                    letter1 = lines[i][j].ToString();
                    try
                    {

                        letter2 = lines[i+1][j].ToString();
                        letter3 = lines[i+2][j].ToString();
                        letter4 = lines[i+3][j].ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    string result = (letter1 + letter2 + letter3 + letter4);
                    if (result == "XMAS" || result == "SAMX")
                    {
                        stringXMASCounter++;
                    }

                    Console.WriteLine(letter1 + letter2 + letter3 + letter4);
                    charPosition++;
                }
            }

            // Vertical backwards
            Console.WriteLine("Vertical");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($" - {lines[i]}");

                int charPosition = 0;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    string letter1 = "";
                    string letter2 = "";
                    string letter3 = "";
                    string letter4 = "";

                    letter1 = lines[i][j].ToString();
                    try
                    {
                        letter2 = lines[i + 1][j-1].ToString();
                        letter3 = lines[i + 2][j-2].ToString();
                        letter4 = lines[i + 3][j-3].ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    string result = (letter1 + letter2 + letter3 + letter4);
                    if (result == "XMAS" || result == "SAMX")
                    {
                        stringXMASCounter++;
                    }

                    Console.WriteLine(letter1 + letter2 + letter3 + letter4);
                    charPosition++;
                }
            }
            // Vertical forwards
            Console.WriteLine("Vertical");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($" - {lines[i]}");

                int charPosition = 0;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    string letter1 = "";
                    string letter2 = "";
                    string letter3 = "";
                    string letter4 = "";

                    letter1 = lines[i][j].ToString();
                    try
                    {
                        letter2 = lines[i + 1][j + 1].ToString();
                        letter3 = lines[i + 2][j + 2].ToString();
                        letter4 = lines[i + 3][j + 3].ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    string result = (letter1 + letter2 + letter3 + letter4);
                    if (result == "XMAS" || result == "SAMX")
                    {
                        stringXMASCounter++;
                    }

                    Console.WriteLine(letter1 + letter2 + letter3 + letter4);
                    charPosition++;
                }
            }

            Console.WriteLine($"We have found the word XMAS {stringXMASCounter} times.");

            Console.ReadKey();
        }

        public static void Part2()
        {
            string input = File.ReadAllText("input.txt");

            Console.WriteLine(input);
            Console.WriteLine("");

            int stringXMASCounter = 0;

            // Split in to array where when ever we have 3 spaces.
            var lines = input.Split("\r\n");
            int lineLength = lines[0].Length;
            int charStartPoint = 0;


            // Vertical backwards
            Console.WriteLine("Vertical");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($" - {lines[i]}");

                int charPosition = 0;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    string letter1 = "";
                    string letter2 = "";
                    string letter3 = "";

                    bool leftstatus = false;
                    
                    try
                    {
                        letter1 = lines[i-1][j-1].ToString(); // up left
                        letter2 = lines[i ][j ].ToString(); // center
                        letter3 = lines[i + 1][j + 1].ToString(); // down right
                    }
                    catch (Exception ex)
                    {
                    }
                    string result = (letter1 + letter2 + letter3 );
                    if (result == "MAS" || result == "SAM")
                    {
                        leftstatus = true;
                    }

                    // Vertical forwards
                    if (leftstatus)
                    {
                        letter1 = "";
                        letter2 = "";
                        letter3 = "";

                        try
                        {
                            letter1 = lines[i + 1][j - 1].ToString(); // up right
                            letter2 = lines[i][j].ToString(); // center
                            letter3 = lines[i - 1][j + 1].ToString(); // down left
                        }
                        catch (Exception ex)
                        {
                        }
                        result = (letter1 + letter2 + letter3);
                        if (result == "MAS" || result == "SAM")
                        {
                            stringXMASCounter++;
                        }

                    }


                    Console.WriteLine(letter1 + letter2 + letter3);
                    charPosition++;
                }
            }
            Console.WriteLine($"We have found the word MAS {stringXMASCounter} times.");

            Console.ReadKey();
        }
    }
}
