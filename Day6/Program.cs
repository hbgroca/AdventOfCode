namespace Day6
{
    internal class Program
    {
        public static List<String> rows = new();
        public static int posRow = -1;
        public static int posLine = 0;

        static void Main(string[] args)
        {
            string input = File.ReadAllText("example.txt");
            //input = File.ReadAllText("input.txt");

            string direction = "north";

            int moves = 0;

            string[] splittedToRows = input.Split("\n");

            foreach (var item in splittedToRows)
            {
                rows.Add(item);
            }

            // Find start pos.
            for (int i = 0; i < rows.Count; i++)
            {
                //Console.WriteLine(rows[i]);
                posRow++;
                posLine = rows[i].IndexOf("^");
                if (posLine != -1)
                {
                    break;
                }
            }
            Console.WriteLine($"StartPos: {posRow}x{posLine}");

            
            // Move char
            Console.WriteLine(rows);

            bool failed = false;
            int move = 0;
            bool crossingSelf = true;
            bool turning = false;
            do
            {
                crossingSelf = false;

                if (move > 0)
                {
                    // Render map
                    Thread.Sleep(750);
                    Console.Clear();
                    //Console.WriteLine();
                    for (int i = 0; i < rows.Count; i++)
                    {
                        Console.WriteLine(rows[i]);
                    }
                    move = 0;
                }

                bool isPart2 = true;
                if (!isPart2)
                {
                    switch (direction)
                    {
                        case "north":
                            {
                                // char above
                                try
                                {
                                    if (rows[posRow - 1][posLine] == '#')
                                    {
                                        //Turn 90deg right
                                        Console.WriteLine("Turning right");
                                        direction = "east";
                                        break;
                                    }

                                }
                                catch (Exception e)
                                {
                                }

                                // Edit current row
                                // Convert to char array
                                char[] rowChars = rows[posRow].ToCharArray();

                                // Example modification: replace the character at posLine with 'X'
                                rowChars[posLine] = 'X';

                                // Convert the char array back to a string and update the row in the list
                                rows[posRow] = new string(rowChars);

                                // Move guard up
                                posRow--;

                                // Edit the new row
                                try
                                {
                                    // Convert to char array
                                    rowChars = rows[posRow].ToCharArray();
                                    // Example modification: replace the character at posLine with 'X'
                                    rowChars[posLine] = '^';
                                    // Convert the char array back to a string and update the row in the list
                                    rows[posRow] = new string(rowChars);
                                }
                                catch
                                {
                                    Console.WriteLine("Out of bounds");
                                    failed = true;
                                }
                                break;
                            }
                        case "east":
                            {
                                // char to the east
                                try
                                {
                                    if (rows[posRow][posLine + 1] == '#')
                                    {
                                        //Turn 90deg right
                                        Console.WriteLine("Turning south");
                                        direction = "south";
                                        break;
                                    }
                                }
                                catch (Exception e)
                                {
                                }

                                // Edit current row
                                // Convert to char array
                                char[] rowChars = rows[posRow].ToCharArray();

                                // Example modification: replace the character at posLine with 'X'
                                rowChars[posLine] = 'X';

                                // Convert the char array back to a string and update the row in the list
                                rows[posRow] = new string(rowChars);

                                // Move guard right
                                posLine++;

                                // Edit the new row
                                try
                                {
                                    // Convert to char array
                                    rowChars = rows[posRow].ToCharArray();
                                    // Example modification: replace the character at posLine with 'X'
                                    rowChars[posLine] = '^';
                                    // Convert the char array back to a string and update the row in the list
                                    rows[posRow] = new string(rowChars);
                                }
                                catch
                                {
                                    Console.WriteLine("Out of bounds");
                                    failed = true;
                                }
                                break;
                            }
                        case "south":
                            {
                                // char to the east
                                try
                                {
                                    if (rows[posRow + 1][posLine] == '#')
                                    {
                                        //Turn 90deg right
                                        Console.WriteLine("Turning west");
                                        direction = "west";
                                        break;
                                    }
                                }
                                catch (Exception e)
                                {
                                }

                                // Edit current row
                                // Convert to char array
                                char[] rowChars = rows[posRow].ToCharArray();

                                // Example modification: replace the character at posLine with 'X'
                                rowChars[posLine] = 'X';

                                // Convert the char array back to a string and update the row in the list
                                rows[posRow] = new string(rowChars);

                                // Move guard down
                                posRow++;

                                // Edit the new row
                                try
                                {
                                    // Convert to char array
                                    rowChars = rows[posRow].ToCharArray();
                                    // Example modification: replace the character at posLine with 'X'
                                    rowChars[posLine] = '^';
                                    // Convert the char array back to a string and update the row in the list
                                    rows[posRow] = new string(rowChars);
                                }
                                catch
                                {
                                    Console.WriteLine("Out of bounds");
                                    failed = true;
                                }
                                break;
                            }
                        case "west":
                            {
                                // char to the west
                                try
                                {
                                    if (rows[posRow][posLine - 1] == '#')
                                    {
                                        //Turn 90deg right
                                        Console.WriteLine("Turning north");
                                        direction = "north";
                                        break;
                                    }
                                }
                                catch (Exception e)
                                {
                                }

                                // Edit current row
                                // Convert to char array
                                char[] rowChars = rows[posRow].ToCharArray();

                                // Example modification: replace the character at posLine with 'X'
                                rowChars[posLine] = 'X';

                                // Convert the char array back to a string and update the row in the list
                                rows[posRow] = new string(rowChars);


                                // Move guard down
                                posLine--;

                                // Edit the new row
                                try
                                {
                                    // Convert to char array
                                    rowChars = rows[posRow].ToCharArray();
                                    // Example modification: replace the character at posLine with 'X'
                                    rowChars[posLine] = '^';
                                    // Convert the char array back to a string and update the row in the list
                                    rows[posRow] = new string(rowChars);
                                }
                                catch
                                {
                                    Console.WriteLine("Out of bounds");
                                    failed = true;
                                }
                                break;
                            }
                    }
                }
                
                else if(isPart2)
                {
                    switch (direction)
                    {
                        case "north":
                            {
                                // Edit current row
                                // Convert to char array
                                char[] rowChars = rows[posRow].ToCharArray();

                                // char above
                                try
                                {
                                    if (rows[posRow - 1][posLine] == '#')
                                    {
                                        //Turn 90deg right
                                        Console.WriteLine("Turning right");
                                        direction = "east";
                                        turning = true;
                                        break;
                                    }
                                    else if (rows[posRow - 1][posLine] == '-')
                                    {
                                        Console.WriteLine("We will cross line now");
                                        crossingSelf = true;
                                    }
                                }
                                catch (Exception e)
                                {
                                }

                                // Example modification: replace the character at posLine with 'X'
                                
                                if (rowChars[posLine] != '+')
                                {
                                    rowChars[posLine] = '|';
                                }

                                // Convert the char array back to a string and update the row in the list
                                rows[posRow] = new string(rowChars);

                                // Move guard up
                                posRow--;

                                // Edit the new row
                                try
                                {
                                    // Convert to char array
                                    rowChars = rows[posRow].ToCharArray();
                                    // Example modification: replace the character at posLine with 'X'
                                    rowChars[posLine] = '^';
                                    if (crossingSelf || turning)
                                    {
                                        rowChars[posLine] = '+';
                                    }
                                    // Convert the char array back to a string and update the row in the list
                                    rows[posRow] = new string(rowChars);
                                }
                                catch
                                {
                                    Console.WriteLine("Out of bounds");
                                    failed = true;
                                }
                                break;
                            }
                        case "east":
                            {
                                // Convert to char array
                                char[] rowChars = rows[posRow].ToCharArray();
                                // char to the east
                                try
                                {
                                    if (rows[posRow][posLine + 1] == '#')
                                    {
                                        //Turn 90deg right
                                        Console.WriteLine("Turning south");
                                        direction = "south";
                                        turning = true;
                                        break;
                                    }
                                    else if (rows[posRow][posLine + 1] == '|')
                                    {
                                        Console.WriteLine("We will cross line now");
                                        crossingSelf = true;
                                    }
                                }
                                catch (Exception e)
                                {
                                }

                                // Edit current row

                                // Example modification: replace the character at posLine with '-'
                                if (rowChars[posLine] != '+')
                                {
                                    rowChars[posLine] = '-';
                                }

                                // Convert the char array back to a string and update the row in the list
                                rows[posRow] = new string(rowChars);

                                // Move guard right
                                posLine++;

                                // Edit the new row
                                try
                                {
                                    // Convert to char array
                                    rowChars = rows[posRow].ToCharArray();
                                    // Example modification: replace the character at posLine with 'X'
                                    rowChars[posLine] = '^';
                                    if (crossingSelf)
                                    {
                                        rowChars[posLine] = '+';
                                    }
                                    // Convert the char array back to a string and update the row in the list
                                    rows[posRow] = new string(rowChars);
                                }
                                catch
                                {
                                    Console.WriteLine("Out of bounds");
                                    failed = true;
                                }
                                break;
                            }
                        case "south":
                            {
                                // Convert to char array
                                char[] rowChars = rows[posRow].ToCharArray();
                                // char to the east
                                try
                                {
                                    if (rows[posRow + 1][posLine] == '#')
                                    {
                                        //Turn 90deg right
                                        Console.WriteLine("Turning west");
                                        direction = "west";
                                        rowChars[posLine] = '+';
                                        break;
                                    }
                                    else if (rows[posRow + 1][posLine] == '-')
                                    {
                                        Console.WriteLine("We will cross line now");
                                        crossingSelf = true;
                                    }
                                    turning = false;
                                }
                                catch (Exception e)
                                {
                                }

                                // Edit current row
                                

                                // Example modification: replace the character at posLine with '|'
                                if (rowChars[posLine] != '+')
                                {
                                    rowChars[posLine] = '|';
                                }

                                // Convert the char array back to a string and update the row in the list
                                rows[posRow] = new string(rowChars);

                                // Move guard down
                                posRow++;

                                // Edit the new row
                                try
                                {
                                    // Convert to char array
                                    rowChars = rows[posRow].ToCharArray();
                                    // Example modification: replace the character at posLine with 'X'
                                    rowChars[posLine] = '^';
                                    if (crossingSelf)
                                    {
                                        rowChars[posLine] = '+';
                                    }
                                    // Convert the char array back to a string and update the row in the list
                                    rows[posRow] = new string(rowChars);
                                }
                                catch
                                {
                                    Console.WriteLine("Out of bounds");
                                    failed = true;
                                }
                                break;
                            }
                        case "west":
                            {
                                // Convert to char array
                                char[] rowChars = rows[posRow].ToCharArray();
                                // char to the west
                                try
                                {
                                    if (rows[posRow][posLine - 1] == '#')
                                    {
                                        //Turn 90deg right
                                        Console.WriteLine("Turning north");
                                        direction = "north";
                                        rowChars[posLine] = '+';
                                        break;
                                    }
                                    else if (rows[posRow][posLine -1] == '|')
                                    {
                                        Console.WriteLine("We will cross line now");
                                        crossingSelf = true;
                                    }
                                    turning = false;
                                }
                                catch (Exception e)
                                {
                                }

                                // Edit current row
                                

                                // Example modification: replace the character at posLine with 'X'
                                if(rowChars[posLine] != '+')
                                {
                                    rowChars[posLine] = '-';
                                }
                                
                                // Convert the char array back to a string and update the row in the list
                                rows[posRow] = new string(rowChars);


                                // Move guard down
                                posLine--;

                                // Edit the new row
                                try
                                {
                                    // Convert to char array
                                    rowChars = rows[posRow].ToCharArray();
                                    // Example modification: replace the character at posLine with 'X'
                                    rowChars[posLine] = '^';
                                    if (crossingSelf)
                                    {
                                        rowChars[posLine] = '+';
                                    }
                                    // Convert the char array back to a string and update the row in the list
                                    rows[posRow] = new string(rowChars);
                                }
                                catch
                                {
                                    Console.WriteLine("Out of bounds");
                                    failed = true;
                                }
                                break;
                            }
                    }
                }

                move++;
            } while (!failed);


            int Exes = 0;
            // Calulate X
            foreach (var item in rows)
            {
                foreach (var Character in item)
                {
                    if(Character == 'X')
                    {
                        Exes++;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Result: {Exes}");

            Console.ReadKey();
        }
    }

    
}
