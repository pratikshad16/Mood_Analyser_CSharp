using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyser
{
   public class MoodAnalyserException : Exception
    {
        public enum ExceptionType
        {
            NotAValidInput, ENTERED_EMPTY, ENTERED_NULL

        }
        string message;
        public ExceptionType type;
        public MoodAnalyserException(ExceptionType type, String message)
        {
            this.type = type;
            this.message = message;
        }
    }
}
