using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarioClone
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: More Features!!!!
            
            Program lol = new Program();
            int width = 100;
            int heigthStart = 0;

            //bool wat = true;
            //ConsoleKey key = new ConsoleKey();
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Welcome to some sort of mario game\n\npress any key to start");
            Console.ReadKey();          
            lol.levelOne(width, heigthStart);
            Console.Write("Game Over. Press any key to exit");
            Console.ReadKey();

        }
        public bool levelOne(int width, int heigthStart)
        {
            //TODO: make obcurrentPlayerRowect of different levels maybe a dictionary? or currentPlayerRowust a list



            //TODO: impliment queue to keep track of last n values.
            //think momemtum if press -1 and press -2 = d currentPlayerRowump 3 places, else currentPlayerRowump 1

            // to generate level string.substring incraments of 20 with random 20 char string arrays maybe?

            GenerateLevel gen = new GenerateLevel();
            int[] randomSeed = gen.randomLevelSeed(20);//level length in 20char blocks
            string[] level = gen.level(randomSeed);
            bool fall = false;
            int position = 1; //set to 0 to see bounds, set to 4 to start at beginning of the game
            int currentPlayerRow = level.Length - 2;
            do
            {
                

                ConsoleKey key = Console.ReadKey(true).Key;

                int playerPos = position + (width / 3);
                //int playerPos = currentPlayerRow + (level[i].Length / (level[i].Length / 3));
                if (currentPlayerRow == level.Length - 1)
                {
                    fall = true;
                }


                level[0] = level[0].Insert(playerPos, "↓");
                level[0].Remove(playerPos + 1, 1);
                level[3] = level[3].Insert(playerPos, "↑");
                level[3].Remove(playerPos + 1, 1);
                //TODO: make is so character can run to end of letter when bounds are met
                
                // I think i need a while loop somewhre in here to drop the player until there is ground or nothing 
                if ((key == ConsoleKey.Spacebar))
                {
                    currentPlayerRow--;
                    level[currentPlayerRow] = level[currentPlayerRow].Remove(playerPos, 1);
                    level[currentPlayerRow] = level[currentPlayerRow].Insert(playerPos, "M");
                    if (level[currentPlayerRow + 1].Substring(playerPos + 1, 1) != "█")
                    {
                        currentPlayerRow++;
                    }
                }
                else if (key == ConsoleKey.D)
                {
                    //if (level[currentPlayerRow + 1].Substring(playerPos + 1, 1) != "█" && level[level.Length - 2].Substring(playerPos, 1) == " ")
                        //currentPlayerRow++;

                    //all of these statements can go into their own functions
                    if (level[currentPlayerRow].Substring(playerPos + 1, 1) != "█")
                    {
                        level[currentPlayerRow] = level[currentPlayerRow].Remove(playerPos, 1);
                        level[currentPlayerRow] = level[currentPlayerRow].Insert(playerPos, "M");
                        while (level[currentPlayerRow + 1].Substring(playerPos, 1) == " " && playerPos != 12)
                        {
                            currentPlayerRow++;
                        }
                        //for (int i = currentPlayerRow; i < level.Length - 1; i++)
                        //{ 

                        //    currentPlayerRow++;
                        //}
                    }
                    else  
                    {
                        position--;
                        level[currentPlayerRow] = level[currentPlayerRow].Remove(playerPos, 1); 
                        level[currentPlayerRow] = level[currentPlayerRow].Insert(playerPos, "M");
                    }

                }
                else
                {
                    position--;
                }
                

                

                //Display screen
                Console.Clear();
                for (int k = heigthStart; k < level.Length; k++)
                {
                    
                    Console.WriteLine(level[k].Substring(position, width));
                }
                
                level = gen.level(randomSeed);
                position++;
            } while (!fall);
            return (position != level[5].Length - (width + 4)) && !fall;



        }

    }

}
