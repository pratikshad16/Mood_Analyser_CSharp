using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyser
{
   public class MoodAnalyserException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            NotAValidInput, ENTERED_EMPTY, ENTERED_NULL,
            INVALID_INPUT
        }
        string message;
        public MoodAnalyserException(ExceptionType type, String message)
        {
            this.type = type;
            this.message = message;
        }
    }
}
