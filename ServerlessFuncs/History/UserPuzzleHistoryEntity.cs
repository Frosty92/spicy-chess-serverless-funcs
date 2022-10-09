﻿using System;
using ServerlessFuncs.Database;

namespace ServerlessFuncs.History
{
    public class UserPuzzleHistoryEntity : BaseTableEntity
    {
        public int RatingBefore { get; set; }
        public int RatingAfter { get; set; }
        public bool Success { get; set; }
        public int? PCompSeconds { get; set; }
        public string PID { get; set; }
        public int PLevel { get; set; }
        public int PSubLevel { get; set; }
    }

}
