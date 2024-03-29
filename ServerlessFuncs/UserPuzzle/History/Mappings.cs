﻿using System;
using System.Diagnostics;
using System.Globalization;
using Microsoft.Graph;
using Microsoft.Graph.ExternalConnectors;

namespace ServerlessFuncs.History
{
    public static class Mappings
    {
        public static UserPuzzleHistory ToUserPuzzleHistry(this UserPuzzleHistoryEntity entity)
        {
            return new UserPuzzleHistory()
            {
                PCompSeconds = entity.PCompSeconds,
                Success = entity.Success,
                ID = entity.RowKey,
                CompletedOn = entity.CompletedOn.ToString(),
                PFen = entity.PFen,
                PID = entity.PID,
                PLevel = entity.PLevel,
                PRating = entity.PRating,
                PMoves = entity.PMoves,
                RatingAfter = entity.RatingAfter,
                RatingBefore = entity.RatingBefore,
                Marked = entity.Marked
            };
        }

        public static UserPuzzleHistoryEntity ToUserPuzzleHistoryEntity(this UserPuzzleHistory history, string userID)
        {

            Trace.WriteLine($"Completed on: {history.CompletedOn}");

            var compDate = DateTimeOffset.ParseExact(history.CompletedOn, "s", CultureInfo.InvariantCulture);
            return new UserPuzzleHistoryEntity()
            {
                RowKey = history.ID,
                PartitionKey = userID,
                RatingAfter = history.RatingAfter,
                RatingBefore = history.RatingBefore,
                PCompSeconds = history.PCompSeconds,
                Success = history.Success,
                PID = history.PID,
                PLevel = history.PLevel,
                PRating = history.PRating,
                PFen = history.PFen,
                PMoves = history.PMoves,
                Marked = history.Marked,
                CompletedOn = compDate
            };
        }
    }
}

