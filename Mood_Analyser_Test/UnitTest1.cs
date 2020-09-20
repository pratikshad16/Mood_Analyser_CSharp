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

            MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("I am in sad mood");
            string result = moodAnalyser.getMood();
            Assert.AreEqual("SAD", result);
        }
        [Test]
        public void givenMessage_WhenAnyMood_ShouldReturnHappy()
        {
            MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("I am in any mood");
            string result = moodAnalyser.getMood();
            Assert.AreEqual("HAPPY", result);
        }
        [Test]
        public void GivenNull_ShouldReturnNull()
        {
           
            MoodAnalyserMain moodAnalyser = new MoodAnalyserMain(" ");
            string result = moodAnalyser.getMood();
            Assert.AreEqual("HAPPY", result);
        }
       
    }
}