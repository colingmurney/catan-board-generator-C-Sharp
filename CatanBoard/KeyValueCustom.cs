using System;
using System.Collections.Generic;
using System.Text;

namespace CatanBoard
{
        public class KeyValueCustom
        {
            public string terrainType { get; set; }
            public int sum { get; set; }

            public KeyValueCustom(string terrain)
            {
            terrainType = terrain;
            sum = 0;
            }         
        }

    }

