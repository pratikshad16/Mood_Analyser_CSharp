using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyser
{
    public class MoodAnalyserMain
    {
        string message;
        public MoodAnalyserMain()
        {

        }

        public MoodAnalyserMain(string message)
        {
            this.message = message;
        }
       
        public string AnalyseMood()
        {
            return this.GetMood(message);
        }
        public string GetMood(string message)
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
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NotAValidInput, "Please entered valid input");
            }
        }
    }
}
