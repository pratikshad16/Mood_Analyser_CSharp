using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyser
{
   public class MoodAnalyserMain
    {
        public string getMood(string message)
        {
            if (message.Contains("I am in sad mood"))
                return "SAD";
            else
                return "HAPPY";
        }
    }
}
