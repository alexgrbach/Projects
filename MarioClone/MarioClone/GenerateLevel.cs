using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioClone
{
    public class GenerateLevel
    {
        public int[] randomLevelSeed(int blocks)
        {
            int[] seed = new int[blocks];
            Random rnd = new Random();
            for(int i = 0; i < seed.Length; i++)
            {
                seed[i] = rnd.Next(0, 5);//make sure this number is the same as levelPieces.Length
            }
            return seed;
        } 
        public string[] level(int[] randomSeed)
        {
            string[] levelStart = new string[]
            {
                "00                                          ",
                "01  |-------------SectionStart-------------|",
                "02  0123456789012345678901234567890123456789",
                "03                                          ",
                "04                                          ",
                "05                                          ",
                "06        Welcome to console Mario          ",
                "07     Press the d key to move forward      ",
                "08        and the spacebar to jump          ",
                "09                                          ",
                "10                                          ",
                "11                                          ",
                "12                                          ",
                "13  ████████████████████████████████████████"
            };
            string[,] levelPieces = new string[,]
            {
                {
                      "                    ",//00
                      "|----SECTION 00----|",//01
                      "01234567890123456789",//02
                      "                    ",//03
                      "  *******        V  ",//04
                      " *********   V      ",//05
                      "  ******            ",//06
                      "                    ",//07
                      "                    ",//08
                      "                 ███",//09
                      "               █████",//10
                      "             ███████",//11
                      "           █████████",//12
                      "████████████████████"//13
                },
                {
                      "                    ",
                      "|----SECTION 01----|", //TODO: figure out how to get numbers in here in the proper order ex |---01---||---02---|
                      "01234567890123456789",
                      "                    ",
                      "  *******        V  ",
                      " *********   V      ",
                      "  ******            ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "  ████   █████      ",
                      "███          ███████"
                },
                {
                      "                    ",
                      "|----SECTION 02----|",
                      "01234567890123456789",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "████████████████████"
                },
                {
                      "                    ",
                      "|----SECTION 03----|",
                      "01234567890123456789",
                      "                    ",
                      "   ##### #####      ",
                      "    #####  ####     ",
                      "      #####  #      ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "        ████        ",
                      "     ████      ███  ",
                      "██████           ███"
                },
                {
                      "                    ",
                      "|----SECTION 04----|",
                      "01234567890123456789",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "                    ",
                      "█  ███   ████   ████"
                }
            };//end levelPiece
            string[] levelEnd = new string[]
            {
                    "                                          00",
                    "|--------------SectionEnd--------------|  01",
                    "0123456789012345678901234567890123456789  02",
                    "                                          03",
                    "                                          04",
                    "                                          05",
                    "                                          06",
                    "                       Level End!!!!!     07",
                    "                                          08",
                    "                                          09",
                    "                                          10",
                    "                                          11",
                    "                                          12",
                    "████████████████████████████████████████  13"
            };
            string[] level = new string[levelStart.Length];

            for (int a = 0; a < randomSeed.Length; a++)
            {
                if (a == 0)
                {
                    for (int b = 0; b < levelStart.Length; b++)
                    {
                        level[b] += levelStart[b];
                    }
                }
                else if (a == randomSeed.Length - 1)
                {
                    for (int b = 0; b < levelStart.Length; b++)
                    {
                        level[b] += levelEnd[b];
                    }
                }
                else
                {
                    for (int b = 0; b < levelStart.Length; b++)
                    {
                        level[b] += levelPieces[randomSeed[a], b];
                        //dlevel[b] += levelPieces[0, b];
                    }
                }
            }
            return level;
        }
    }

}
