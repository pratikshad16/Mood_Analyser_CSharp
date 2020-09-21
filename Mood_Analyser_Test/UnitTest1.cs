using Mood_Analyser;
using NUnit.Framework;


namespace Mood_Analyser_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void givenMessage_WhenSadMood_ShouldReturnSad()
        {
            try
            {
                MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("I am in sad mood");
                string result = moodAnalyser.getMood();
                Assert.AreEqual("SAD", result);
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NotAValidInput, "Please entered valid input");
            }
        }
        [Test]
        public void givenMessage_WhenAnyMood_ShouldReturnHappy()
        {
            try
            {
                MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("I am in any mood");
                string result = moodAnalyser.getMood();
                Assert.AreEqual("HAPPY", result);
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NotAValidInput, "Please entered valid input");
            }
        }
        [Test]
        public void givenMessage_whenNull_shouldReturnHappy()
        {
            try
            {
                MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("NULL");
                string result = moodAnalyser.getMood();
                Assert.AreEqual("HAPPY", result);
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.ENTERED_NULL, e.type);
            }
        }
        [Test]
        public void givenMessage_whenEmpty_shouldThrowMoodAnalyserException()
        {
            try
            {
                MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("");
                string result = moodAnalyser.getMood();

            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.ENTERED_EMPTY, e.type);
            }
        }
        [Test]
        public void givenMoodAnalyserClassName_shouldReturnMoodAnalyserObject()
        {
            try
            {
                MoodAnalyserMain obj = MoodAnalyserFactory.GetMoodAnalyserObject("Mood_Analyser.MoodAnalyserMain");
                MoodAnalyserMain moodAnalyserMain = new MoodAnalyserMain();
                Assert.IsTrue(obj.ToString().Equals(moodAnalyserMain.ToString()));
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ENTERED_EMPTY, "wrong file");
            }
        }
        [Test]
        public void givenMoodAnalyserClassWithWrongName_shouldReturnMoodAnalyserException()
        {
            try
            {
                MoodAnalyserMain obj = MoodAnalyserFactory.GetMoodAnalyserObject("Mood_Analyser.MoodAnalyserMainClass");
                MoodAnalyserMain moodAnalyserMain = new MoodAnalyserMain();

            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.INVALID_INPUT, e.type);

            }
        }
    }
}