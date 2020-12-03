using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CatanBoard
{
    class Board
    {
        public List<int> rollList { get; set; }

        public List<string> terrainList { get; set; }

        public List<int> corners { get; set; }

        public Dictionary<int, int> oddsDict { get; }

        public List<KeyValueCustom> terrainOddsSum { get; set; }

        public Dictionary<char, Tile> tiles { get; set; }

        public Board()
        {
            rollList = new List<int>() { 6, 6, 6, 6, 9, 9, 5, 5, 10, 10, 4, 4, 3, 3, 11, 11, 12, 2, 0};
            terrainList = new List<string>() { "mountain", "mountain", "mountain", "hill", "hill", "hill", "forest", "forest", "forest", "forest", "field", "field", "field", "field", "pasture", "pasture", "pasture", "pasture"};
            corners = new List<int>();

            oddsDict = new Dictionary<int, int>()
            {
                { 0, 0 },
                { 2, 1 },
                { 3, 2 },
                { 4, 3 },
                { 5, 4 },
                { 6, 5 },
                { 7, 6 },
                { 8, 5 },
                { 9, 4 },
                { 10, 3 },
                { 11, 2 },
                { 12, 1 }
            };

            terrainOddsSum = new List<KeyValueCustom>()
            {
                new KeyValueCustom("mountain"),
                new KeyValueCustom("hill"),
                new KeyValueCustom("pasture"),
                new KeyValueCustom("forest"),
                new KeyValueCustom("field"),
            };

            tiles = new Dictionary<char, Tile>()
            {
                { 'a', new Tile() },
                { 'b', new Tile() },
                { 'c', new Tile() },
                { 'd', new Tile() },
                { 'e', new Tile() },
                { 'f', new Tile() },
                { 'g', new Tile() },
                { 'h', new Tile() },
                { 'i', new Tile() },
                { 'j', new Tile() },
                { 'k', new Tile() },
                { 'l', new Tile() },
                { 'm', new Tile() },
                { 'n', new Tile() },
                { 'o', new Tile() },
                { 'p', new Tile() },
                { 'q', new Tile() },
                { 'r', new Tile() },
                { 's', new Tile() },
            };
        }

        public void generateNumbers(int maxOdds)
        {
            Random random = new Random();
            //int maxOdds = 12;

            while (true)
            {
                //Randomly assign a rollList item to each Tile object tileNum field
                foreach (KeyValuePair<char, Tile> tile in tiles)
                {
                    var index = random.Next(rollList.Count);
                    tile.Value.tileNum = rollList[index];
                    rollList.RemoveAt(index);
                }

                //Check that the no two numbers touch on the board
                if (!Calculations.isValidNumber(tiles))
                {
                    //reset rollList
                    resetRollList();
                    continue;
                }

                //Calc and add probability of each interior corner point (intersection of 3 hexagons) to corner list
                corners.Add(oddsDict[tiles['a'].tileNum] + oddsDict[tiles['d'].tileNum] + oddsDict[tiles['e'].tileNum]);
                corners.Add(oddsDict[tiles['b'].tileNum] + oddsDict[tiles['e'].tileNum] + oddsDict[tiles['f'].tileNum]);
                corners.Add(oddsDict[tiles['c'].tileNum] + oddsDict[tiles['f'].tileNum] + oddsDict[tiles['g'].tileNum]);
                corners.Add(oddsDict[tiles['d'].tileNum] + oddsDict[tiles['h'].tileNum] + oddsDict[tiles['i'].tileNum]);
                corners.Add(oddsDict[tiles['e'].tileNum] + oddsDict[tiles['i'].tileNum] + oddsDict[tiles['j'].tileNum]);
                corners.Add(oddsDict[tiles['f'].tileNum] + oddsDict[tiles['j'].tileNum] + oddsDict[tiles['k'].tileNum]);
                corners.Add(oddsDict[tiles['g'].tileNum] + oddsDict[tiles['k'].tileNum] + oddsDict[tiles['l'].tileNum]);
                corners.Add(oddsDict[tiles['h'].tileNum] + oddsDict[tiles['i'].tileNum] + oddsDict[tiles['m'].tileNum]);
                corners.Add(oddsDict[tiles['i'].tileNum] + oddsDict[tiles['j'].tileNum] + oddsDict[tiles['n'].tileNum]);
                corners.Add(oddsDict[tiles['j'].tileNum] + oddsDict[tiles['k'].tileNum] + oddsDict[tiles['o'].tileNum]);
                corners.Add(oddsDict[tiles['k'].tileNum] + oddsDict[tiles['l'].tileNum] + oddsDict[tiles['p'].tileNum]);
                corners.Add(oddsDict[tiles['m'].tileNum] + oddsDict[tiles['n'].tileNum] + oddsDict[tiles['q'].tileNum]);
                corners.Add(oddsDict[tiles['n'].tileNum] + oddsDict[tiles['o'].tileNum] + oddsDict[tiles['r'].tileNum]);
                corners.Add(oddsDict[tiles['o'].tileNum] + oddsDict[tiles['p'].tileNum] + oddsDict[tiles['s'].tileNum]);

                //Check if each item in corners is within maxOdds threshold
                var continueChecker = corners.Count;
                foreach (int item in corners)
                {
                    if (item > maxOdds) continue;
                    continueChecker--;
                }

                if (continueChecker > 0)
                {
                    resetRollList();
                    resetCorners();
                    continue;
                }

                //Change the first two instances of 6 to 8
                foreach (KeyValuePair<char, Tile> tile in tiles)
                {
                    var sixCount = 2;
                    if (tile.Value.tileNum == 6 && sixCount > 0)
                    {
                        tile.Value.tileNum = 8;
                        sixCount--;
                    };
                }

                break;
            }
        }

        public void GenerateTerrain(int stdTerrainSums)
        {
            Random random = new Random();

            while (true)
            {
                //Loop through tiles
                foreach (KeyValuePair<char, Tile> tile in tiles)
                {
                    //if tile.numTile is 0, assign "desert" to tile
                    if (tile.Value.tileNum == 0) tile.Value.tileTerrain = "desert";
                    else
                    {
                        //select random item from terrain list and remove from list
                        var index = random.Next(terrainList.Count);
                        tile.Value.tileTerrain = terrainList[index];
                        terrainList.RemoveAt(index);
                    }
                }
                //if any tiles that touch each other == the same terrain, reset terrain list and continue loop
                if (!Calculations.isValidTerrain(tiles))
                {
                    resetTerrainList();
                    continue;
                }

                //create custom key value pair object with mutable values
                foreach (KeyValuePair<char, Tile> tile in tiles)
                {
                    foreach (KeyValueCustom terrainSum in terrainOddsSum)
                    {
                        if (tile.Value.tileTerrain == terrainSum.terrainType)
                        {
                            terrainSum.sum += oddsDict[tile.Value.tileNum];
                        }
                    }
                }

                //calculate std of temp sums
                double stdev = Calculations.getStandardDeviation(terrainOddsSum);

                //if std is > 3, reset terrain list and continue loop
                if (stdev > stdTerrainSums)
                {
                    resetTerrainList();
                    resetTerrainOddsSum();
                    continue;
                }

                //break loop
                break;
            }
        }

        public void resetRollList()
        {
            //rollList = new List<int>() { 6, 6, 6, 6, 9, 9, 5, 5, 10, 10, 4, 4, 3, 3, 11, 11, 12, 2, 0 };
            int[] rolls = { 6, 6, 6, 6, 9, 9, 5, 5, 10, 10, 4, 4, 3, 3, 11, 11, 12, 2, 0 };
            foreach (int roll in rolls)
            {
                rollList.Add(roll);
            }
        }

        public void resetCorners()
        {
            corners.Clear();
        }

        public void resetTerrainList()
        {
            terrainList = new List<string> { "mountain", "mountain", "mountain", "hill", "hill", "hill", "forest", "forest", "forest", "forest", "field", "field", "field", "field", "pasture", "pasture", "pasture", "pasture" };
        }

        public void resetTerrainOddsSum()
        {
            foreach (KeyValueCustom terrainSum in terrainOddsSum)
            {
                terrainSum.sum = 0;
            }
        }

        public void printBoard()
        {
            //Stringbuilder, then convert to string and Console.log
            foreach (KeyValueCustom terrainsum in terrainOddsSum)
            {
                Console.WriteLine(terrainsum.terrainType + " total is " + terrainsum.sum.ToString());
            }
            
            Console.WriteLine("\n");
            Console.WriteLine("      " + tiles['a'].tileNum.ToString() + " " + " " + tiles['a'].tileTerrain + " - " + tiles['b'].tileNum.ToString() + " " + tiles['b'].tileTerrain + " - " + tiles['c'].tileNum.ToString() + " " + tiles['c'].tileTerrain);
            Console.WriteLine("\n");
            Console.WriteLine("   " + tiles['d'].tileNum.ToString() + " " + tiles['d'].tileTerrain + " - " + tiles['e'].tileNum.ToString() + " " + tiles['e'].tileTerrain + " - " + tiles['f'].tileNum.ToString() + " " + tiles['f'].tileTerrain + " - " + tiles['g'].tileNum.ToString() + " " + tiles['g'].tileTerrain);
            Console.WriteLine("\n");
            Console.WriteLine(tiles['h'].tileNum.ToString() + " " + tiles['h'].tileTerrain + " - " + tiles['i'].tileNum.ToString() + " " + tiles['i'].tileTerrain + " - " + tiles['j'].tileNum.ToString() + " " + tiles['j'].tileTerrain + " - " + tiles['k'].tileNum.ToString() + " " + tiles['k'].tileTerrain + " - " + tiles['l'].tileNum.ToString() + " " + tiles['l'].tileTerrain);
            Console.WriteLine("\n");
            Console.WriteLine("   " + tiles['m'].tileNum.ToString() + " " + tiles['m'].tileTerrain + " - " + tiles['n'].tileNum.ToString() + " " + tiles['n'].tileTerrain +  " - " + tiles['o'].tileNum.ToString() + " " + tiles['o'].tileTerrain + " - " + tiles['p'].tileNum.ToString() + " " + tiles['p'].tileTerrain);
            Console.WriteLine("\n");
            Console.WriteLine("      " + tiles['q'].tileNum.ToString() + " " + tiles['q'].tileTerrain + " - " + tiles['r'].tileNum.ToString() + " " + tiles['r'].tileTerrain +  " - " + tiles['s'].tileNum.ToString() + " " + tiles['s'].tileTerrain);
        }
    }
}
