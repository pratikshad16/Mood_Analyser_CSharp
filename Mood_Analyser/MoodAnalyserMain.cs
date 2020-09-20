using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyser
{
    public class MoodAnalyserMain
    {
        string message;
        public MoodAnalyserMain(string message)
        {
            this.message = message;
        }
        public string getMood()
        {
            try
            {
                if (message.Contains("I am in sad mood"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException("Exception");
            }
        }
    }
}
