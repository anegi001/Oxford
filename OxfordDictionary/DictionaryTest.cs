using System;
using NUnit.Framework;

namespace OxfordDictionary 
{
    [TestFixture]
    public class DictionaryTest : Library
    {
        [Test(Description = "User gets a response of 200 and is able to find the meanings of Valid words from the Retrieve dictionary information for a given word api")]
        [TestCase("Encyclopedia")]
        [TestCase("Hello")]
        [Category("Positive Test")]     
        public void DictonaryGetRequestSuccess(String word)
        {
            var response = GetDictonaryInformation(word);   
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "The meaning of the word is not found");
            var result = ParseDictionaryObject(response);
            TestContext.WriteLine("Definition(s) of the word is :\n");
            result.ForEach(i => TestContext.WriteLine(i.ToString()));            
            TestContext.WriteLine("\nResponse code is " + (int)response.StatusCode);            
        }

        [Test (Description = "User responds with a 404 for invalid words that do not exist")]
        [TestCase("Invalidword")]
        [Category("Exception Test")]
        public void DictonaryGetRequestFail(String word)
        {
            var response = GetDictonaryInformation(word);
            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode, "The expected response is not correct. The word should not retur success");
            TestContext.WriteLine("\nResponse code is " + (int)response.StatusCode);
        }
    }
}
