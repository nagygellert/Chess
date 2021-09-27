﻿using Chess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Entities
{
    public class TableSpace
    {
        public TableColumn Column { get; set; } 

        public int Row { get; set; }
    }
}
