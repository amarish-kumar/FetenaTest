using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fetena.Models;

namespace Fetena.Dtos
{
    public class ScoreStatisticsDto
    {
        public string Topic { get; set; }
        public int MaximumScore { get; set; }
        public int MinimumScore { get; set; }
        public double AverageScore { get; set; }
    }
}