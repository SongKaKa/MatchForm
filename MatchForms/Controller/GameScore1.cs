using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchForms.Controller
{
    class GameScore
    {
        private int _score;

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public TimeSpan Duration { get { return EndTime.Subtract(StartTime); } }
        
        public int Score { 
            get { return _score; }
            set
            {
                _score = value;
                EndTime = DateTime.Now;
                Synchronize();
            }
        }

        public GameScore()
        {
            StartTime = DateTime.Now;
            EndTime = StartTime;
        }

        private void Synchronize()
        {
            // Read results from file

            // Update results

            // Write results to file
        }
    }
}
