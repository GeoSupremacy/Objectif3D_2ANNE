﻿using System;

namespace RPG
{
    internal class DataMap
    {
        public string[,] Map { get; private set; } = new string[,]
            {
                 {"__","__","__","__","__","__","__","__","__","__","__","__" },
                 {"| ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  "," |" },
                 {"| ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  "," |" },
                 {"| ","  ","  ","  ","  ","  ","  ","  ","  ","  ","  "," |" },
                 {"|_","__","__","__","__","__","PL","__","__","__","__","_|" },
        };
    }
}
