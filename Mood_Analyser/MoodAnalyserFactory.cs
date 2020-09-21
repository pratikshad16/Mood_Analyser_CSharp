using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Mood_Analyser
{
    public class MoodAnalyserFactory
    {
        public static MoodAnalyserMain GetMoodAnalyserObject(string className)
        {
            try
            {
                Assembly excutingAssambly = Assembly.GetExecutingAssembly();
                Type type = excutingAssambly.GetType(className);
                MoodAnalyserMain MoodAnalyserMainObject = (MoodAnalyserMain)Activator.CreateInstance(type);
                return MoodAnalyserMainObject;
            }
            catch (Exception e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.INVALID_INPUT, "invalid input");
            }
        }
    }
}
