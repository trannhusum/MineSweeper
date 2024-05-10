using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] map = {
                             {"*", ".", ".", "."},
                              {".", ".", ".", "."},
                              {".", "*", ".", "."},
                              {".", ".", ".", "."}
 };
            int MAP_HEIGHT = map.GetLength(0);
            int MAP_WIDTH = map.GetLength(1);

            string[,] mapReport = new string[MAP_HEIGHT, MAP_WIDTH];
            for (int yOrdinate = 0; yOrdinate < MAP_HEIGHT; yOrdinate++)
            {
                for (int xOrdinate = 0; xOrdinate < map.GetLength(1); xOrdinate++)
                {
                    String curentCell = map[yOrdinate, xOrdinate];
                    if (curentCell.Equals("*"))
                    {
                        mapReport[yOrdinate, xOrdinate] = "*";
                    }
                    else
                    {
                        int[,] NEIGHBOURS_ORDINATE = { { yOrdinate, xOrdinate - 1 }, { yOrdinate, xOrdinate + 1 } };

                        int minesAround = 0;
                        for (int i = 0; i < NEIGHBOURS_ORDINATE.GetLength(0); i++)
                        {
                            int xOrdinateOfNeighbour = NEIGHBOURS_ORDINATE[i, 1];
                            int yOrdinateOfNeighbour = NEIGHBOURS_ORDINATE[i, 0];

                            bool isOutOfMapNeighbour = xOrdinateOfNeighbour < 0 || xOrdinateOfNeighbour == MAP_WIDTH;
                            if (isOutOfMapNeighbour) continue;

                            bool isMineOwnerNeighbour = map[yOrdinateOfNeighbour, xOrdinateOfNeighbour].Equals("*");
                            if (isMineOwnerNeighbour) minesAround++;
                        }

                        mapReport[yOrdinate, xOrdinate] = minesAround.ToString();
                    }
                }
            }
            for (int yOrdinate = 0; yOrdinate < MAP_HEIGHT; yOrdinate++)
            {
                Console.WriteLine("\n");
                for (int xOrdinate = 0; xOrdinate < MAP_WIDTH; xOrdinate++)
                {
                    String currentCellReport = mapReport[yOrdinate, xOrdinate];
                    Console.Write(currentCellReport);
                }
            }   
            Console.ReadKey();
        }
    }
}
