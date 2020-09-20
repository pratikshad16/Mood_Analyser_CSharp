using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyser
{
    class MoodAnalyserException : Exception
    {
        string message;
        public MoodAnalyserException(string message)
        {
            this.message = message;

        }
    }
}
