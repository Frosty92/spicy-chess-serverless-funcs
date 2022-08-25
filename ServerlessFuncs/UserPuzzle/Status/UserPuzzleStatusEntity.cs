﻿using System;
using AzureFunctionsTodo.TableStorage;
using ServerlessFuncs.Utils;

namespace ServerlessFuncs.UserPuzzle.Progress
{
    public class UserPuzzleStatusEntity : BaseTableEntity
    {
        public int LevelNum { get; set; }
        public int LoopNum { get; set; }
        public int LastCompletedPuzzleIndex { get; set; }
        public string PaginationToken { get; set; }
        public int UserRating { get; set; }
    }
}

