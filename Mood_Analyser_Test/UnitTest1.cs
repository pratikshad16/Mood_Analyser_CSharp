using Mood_Analyser;
using NUnit.Framework;
using System;
using System.Reflection;

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
                string result = moodAnalyser.AnalyseMood();
                Assert.AreEqual("SAD", result);
        }
        [Test]
        public void GivenMessage_WhenAnyMood_ShouldReturnHappy()
        {
                MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("I am in any mood");
                string result = moodAnalyser.AnalyseMood();
                Assert.AreEqual("HAPPY", result);
        }
        [Test]
        public void GivenMessage_whenNull_shouldReturnHappy()
        {
                MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("NULL");
                string result = moodAnalyser.AnalyseMood();
                Assert.AreEqual("HAPPY", result);
        }
        [Test]
        public void GivenMessage_whenEmpty_shouldThrowMoodAnalyserException()
        {
            try
            {
                MoodAnalyserMain moodAnalyser = new MoodAnalyserMain("");
                string result = moodAnalyser.AnalyseMood();

            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.ENTERED_EMPTY, e.type);
            }
        }
        [Test]
        public void GivenMoodAnalyserClassName_shouldReturnMoodAnalyserObject()
        {
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator();
                MoodAnalyserMain obj = (MoodAnalyserMain)MoodAnalyserFactory.InstanceCreator
                ("Mood_Analyser.MoodAnalyserMain", constructorInfo);
                MoodAnalyserMain moodAnalyserMain = new MoodAnalyserMain();
                Assert.IsInstanceOf(typeof(MoodAnalyserMain), obj);
        }
        [Test]
        public void GivenMoodAnalyserClassWithWrongName_shouldReturnMoodAnalyserException()
        {
            try
            {
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator();
                object obj = MoodAnalyserFactory.InstanceCreator("MoodAnalyserMain1234", constructorInfo);
                MoodAnalyserMain moodAnalyserMain = new MoodAnalyserMain();
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.INVALID_INPUT, e.type);
            } 
        }
        [Test]
        public void GivenMoodAnalyserWithWrongConstructor_shouldThrowMoodAnalyserException()
        {
            try
            {
                String className = "MoodAnalyser";
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator(className);
                MoodAnalyserMain obj = (MoodAnalyserMain)MoodAnalyserFactory.InstanceCreator
                ("Mood_Analyser.MoodAnalyserMain", constructorInfo);
                MoodAnalyserMain moodAnalyserMain = new MoodAnalyserMain("hey");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.INVALID_INPUT, e.type);
            }
        }
        [Test]
        public void GivenMoodAnalyserWithParameterConstructorWhenProper_shouldReturnMoodAnalyserObject()
        {
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator(3);
                MoodAnalyserMain obj = (MoodAnalyserMain)MoodAnalyserFactory.InstanceCreator
                ("Mood_Analyser.MoodAnalyserMain", constructorInfo, "I am in happy mood");
                Assert.IsInstanceOf(typeof(MoodAnalyserMain), obj);
        }
        [Test]
        public void GivenMoodAnalyserWithParameterConstructorButWrongClassName_shouldThrowMoodAnalyserException()
        {
            try
            {
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator();
                MoodAnalyserMain obj = (MoodAnalyserMain)MoodAnalyserFactory.InstanceCreator
                ("Mood_Analyser.MoodAnalyserMainClass", constructorInfo, "I am in happy mood");

            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.INVALID_INPUT, e.type);
            }
        }
        [Test]
        public void GivenMoodAnalyserWithParameterConstructorWhenWrongConstructorName_shouldThrowMoodAnalyserException()
        {
            try
            {
                String className = "MoodAnalyser";
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator(className);
                MoodAnalyserMain obj = (MoodAnalyserMain)MoodAnalyserFactory.InstanceCreator
                ("Mood_Analyser.MoodAnalyserMain", constructorInfo, "I am in happy mood");

            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.INVALID_INPUT, e.type);
            }
        }
        [Test]
        public void GivenHappyMessageUsingReflectionWhenProper_shouldReturnHappy()
        {
            string message = MoodAnalyserFactory.GetMethod("Mood_Analyser.MoodAnalyserMain", "GetMood", "happy");
            Assert.AreEqual("HAPPY", message);
        }
        [Test]
        public void GivenHappyMessageUsingReflectionWhenImproperMethod_shouldThrowMoodAnayserException()
        {
            try
            {
                string message = MoodAnalyserFactory.GetMethod("Mood_Analyser.MoodAnalyserMain", "getMethod", "happy");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.INVALID_INPUT, e.type);
            }
        }
    }
}