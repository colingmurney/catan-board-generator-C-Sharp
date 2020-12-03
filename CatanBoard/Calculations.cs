using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace CatanBoard
{
    class Calculations
    {
        public static double getStandardDeviation(List<KeyValueCustom> keyValuePairList)
        {
            //conver custom list to list of type int
            var numbers = new List<int>();

            foreach (KeyValueCustom terrainSum in keyValuePairList)
            {
                numbers.Add(terrainSum.sum);
            }

            // Step 1
            var meanOfNumbers = numbers.Average();

            // Step 2
            var squaredDifferences = new List<double>(numbers.Count);
            foreach (var number in numbers)
            {
                var difference = number - meanOfNumbers;
                var squaredDifference = Math.Pow(difference, 2);
                squaredDifferences.Add(squaredDifference);
            }

            // Step 3
            var meanOfSquaredDifferences = squaredDifferences
                .Average();

            // Step 4
            var standardDeviation = Math.Sqrt(meanOfSquaredDifferences);

            return standardDeviation;
        }

        public static bool isValidNumber(Dictionary<char, Tile> tiles)
        {
            if (tiles['b'].tileNum == tiles['a'].tileNum) return false;
            else if (tiles['c'].tileNum == tiles['b'].tileNum) return false;
            else if (tiles['d'].tileNum == tiles['a'].tileNum) return false;
            else if (tiles['e'].tileNum == tiles['a'].tileNum) return false;
            else if (tiles['e'].tileNum == tiles['b'].tileNum) return false;
            else if (tiles['e'].tileNum == tiles['d'].tileNum) return false;
            else if (tiles['f'].tileNum == tiles['b'].tileNum) return false;
            else if (tiles['f'].tileNum == tiles['e'].tileNum) return false;
            else if (tiles['f'].tileNum == tiles['c'].tileNum) return false;
            else if (tiles['g'].tileNum == tiles['c'].tileNum) return false;
            else if (tiles['g'].tileNum == tiles['f'].tileNum) return false;
            else if (tiles['h'].tileNum == tiles['d'].tileNum) return false;
            else if (tiles['i'].tileNum == tiles['d'].tileNum) return false;
            else if (tiles['i'].tileNum == tiles['e'].tileNum) return false;
            else if (tiles['i'].tileNum == tiles['h'].tileNum) return false;
            else if (tiles['j'].tileNum == tiles['f'].tileNum) return false;
            else if (tiles['j'].tileNum == tiles['e'].tileNum) return false;
            else if (tiles['j'].tileNum == tiles['i'].tileNum) return false;
            else if (tiles['k'].tileNum == tiles['f'].tileNum) return false;
            else if (tiles['k'].tileNum == tiles['g'].tileNum) return false;
            else if (tiles['k'].tileNum == tiles['j'].tileNum) return false;
            else if (tiles['l'].tileNum == tiles['g'].tileNum) return false;
            else if (tiles['l'].tileNum == tiles['k'].tileNum) return false;
            else if (tiles['m'].tileNum == tiles['h'].tileNum) return false;
            else if (tiles['m'].tileNum == tiles['i'].tileNum) return false;
            else if (tiles['n'].tileNum == tiles['i'].tileNum) return false;
            else if (tiles['n'].tileNum == tiles['j'].tileNum) return false;
            else if (tiles['n'].tileNum == tiles['m'].tileNum) return false;
            else if (tiles['o'].tileNum == tiles['j'].tileNum) return false;
            else if (tiles['o'].tileNum == tiles['k'].tileNum) return false;
            else if (tiles['o'].tileNum == tiles['n'].tileNum) return false;
            else if (tiles['p'].tileNum == tiles['k'].tileNum) return false;
            else if (tiles['p'].tileNum == tiles['l'].tileNum) return false;
            else if (tiles['p'].tileNum == tiles['o'].tileNum) return false;
            else if (tiles['q'].tileNum == tiles['m'].tileNum) return false;
            else if (tiles['q'].tileNum == tiles['n'].tileNum) return false;
            else if (tiles['r'].tileNum == tiles['n'].tileNum) return false;
            else if (tiles['r'].tileNum == tiles['o'].tileNum) return false;
            else if (tiles['r'].tileNum == tiles['q'].tileNum) return false;
            else if (tiles['s'].tileNum == tiles['o'].tileNum) return false;
            else if (tiles['s'].tileNum == tiles['p'].tileNum) return false;
            else if (tiles['s'].tileNum == tiles['r'].tileNum) return false;
            else return true;
        }

        public static bool isValidTerrain(Dictionary<char, Tile> tiles)
        {
            if (tiles['b'].tileTerrain == tiles['a'].tileTerrain) return false;
            else if (tiles['c'].tileTerrain == tiles['b'].tileTerrain) return false;
            else if (tiles['d'].tileTerrain == tiles['a'].tileTerrain) return false;
            else if (tiles['e'].tileTerrain == tiles['a'].tileTerrain) return false;
            else if (tiles['e'].tileTerrain == tiles['b'].tileTerrain) return false;
            else if (tiles['e'].tileTerrain == tiles['d'].tileTerrain) return false;
            else if (tiles['f'].tileTerrain == tiles['b'].tileTerrain) return false;
            else if (tiles['f'].tileTerrain == tiles['e'].tileTerrain) return false;
            else if (tiles['f'].tileTerrain == tiles['c'].tileTerrain) return false;
            else if (tiles['g'].tileTerrain == tiles['c'].tileTerrain) return false;
            else if (tiles['g'].tileTerrain == tiles['f'].tileTerrain) return false;
            else if (tiles['h'].tileTerrain == tiles['d'].tileTerrain) return false;
            else if (tiles['i'].tileTerrain == tiles['d'].tileTerrain) return false;
            else if (tiles['i'].tileTerrain == tiles['e'].tileTerrain) return false;
            else if (tiles['i'].tileTerrain == tiles['h'].tileTerrain) return false;
            else if (tiles['j'].tileTerrain == tiles['f'].tileTerrain) return false;
            else if (tiles['j'].tileTerrain == tiles['e'].tileTerrain) return false;
            else if (tiles['j'].tileTerrain == tiles['i'].tileTerrain) return false;
            else if (tiles['k'].tileTerrain == tiles['f'].tileTerrain) return false;
            else if (tiles['k'].tileTerrain == tiles['g'].tileTerrain) return false;
            else if (tiles['k'].tileTerrain == tiles['j'].tileTerrain) return false;
            else if (tiles['l'].tileTerrain == tiles['g'].tileTerrain) return false;
            else if (tiles['l'].tileTerrain == tiles['k'].tileTerrain) return false;
            else if (tiles['m'].tileTerrain == tiles['h'].tileTerrain) return false;
            else if (tiles['m'].tileTerrain == tiles['i'].tileTerrain) return false;
            else if (tiles['n'].tileTerrain == tiles['i'].tileTerrain) return false;
            else if (tiles['n'].tileTerrain == tiles['j'].tileTerrain) return false;
            else if (tiles['n'].tileTerrain == tiles['m'].tileTerrain) return false;
            else if (tiles['o'].tileTerrain == tiles['j'].tileTerrain) return false;
            else if (tiles['o'].tileTerrain == tiles['k'].tileTerrain) return false;
            else if (tiles['o'].tileTerrain == tiles['n'].tileTerrain) return false;
            else if (tiles['p'].tileTerrain == tiles['k'].tileTerrain) return false;
            else if (tiles['p'].tileTerrain == tiles['l'].tileTerrain) return false;
            else if (tiles['p'].tileTerrain == tiles['o'].tileTerrain) return false;
            else if (tiles['q'].tileTerrain == tiles['m'].tileTerrain) return false;
            else if (tiles['q'].tileTerrain == tiles['n'].tileTerrain) return false;
            else if (tiles['r'].tileTerrain == tiles['n'].tileTerrain) return false;
            else if (tiles['r'].tileTerrain == tiles['o'].tileTerrain) return false;
            else if (tiles['r'].tileTerrain == tiles['q'].tileTerrain) return false;
            else if (tiles['s'].tileTerrain == tiles['o'].tileTerrain) return false;
            else if (tiles['s'].tileTerrain == tiles['p'].tileTerrain) return false;
            else if (tiles['s'].tileTerrain == tiles['r'].tileTerrain) return false;
            else return true;
        }
    }
}
