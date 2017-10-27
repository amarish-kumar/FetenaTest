using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fetena.Dtos
{
    public class ResultDetailsDto
    {
        public ResultDetailsDto()
        {
            IndividualScore = new List<UserScoreDto>();
            OverallScoreStatistics = new List<ScoreStatisticsDto>();
        }
        public List<UserScoreDto> IndividualScore { get; set; }
        public List<ScoreStatisticsDto> OverallScoreStatistics { get; set; }
    }
}