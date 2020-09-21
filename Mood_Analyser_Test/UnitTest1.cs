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
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator();
                MoodAnalyserMain obj = (MoodAnalyserMain)MoodAnalyserFactory.InstanceCreator
                ("Mood_Analyser.MoodAnalyserMain", constructorInfo);
                MoodAnalyserMain moodAnalyserMain = new MoodAnalyserMain();
                Assert.IsInstanceOf(typeof(MoodAnalyserMain), obj);
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
        public void givenMoodAnalyserWithWrongConstructor_shouldThrowMoodAnalyserException()
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
    }
}