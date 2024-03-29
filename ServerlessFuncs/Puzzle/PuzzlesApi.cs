﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Routing;
using Azure.Data.Tables;
using Azure;
using ServerlessFuncs.TableStorage;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using ServerlessFuncs.PuzzleNS;

namespace ServerlessFuncs.Puzzles
{
    public static class PuzzlesApi
    {
        private const string TableName = "puzzles";
        private const string Route = "puzzles";

 
        [FunctionName("GetPuzzlesForLevel")]
        public static async Task<IActionResult> GetPuzzlesForLevel(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = Route + "/{level}")] HttpRequest req,
            [Table(TableName, Connection = "AzureWebJobsStorage")] TableClient puzzlesTable,
            ILogger log,
            int level)
        {
            int subLevel = Convert.ToInt16(req.Query["subLevel"]);

            /**
             * If the user is not signed in, only allow access to one sublevel
             * for sampling purposes.
             */
            if (subLevel > 1)
            {
                return new UnauthorizedResult();
            }
            var puzzleSetFetcher = new PuzzleSetFetcher(puzzlesTable);
            var puzzleSet = await puzzleSetFetcher.FetchPuzzleSet(
                level,
                subLevel,
                0       
            );

            return new OkObjectResult(puzzleSet);
        }
    }
}

