using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchForms.Controller
{
    public class GameScore
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public TimeSpan Duration { get; private set; }
        public int Score { get; set; }
    }
}
