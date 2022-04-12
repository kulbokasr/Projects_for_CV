using AdroitiWordCount.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.IO;

namespace WordCountTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetWordsAndCharactersCount_GivenSampleText_CalculatesCorrectly()
        {
            string[] names = { };
            Mock<IFileService> fileServiceMock = new Mock<IFileService>();
            fileServiceMock.Setup(f => f.ReadFile()).Returns("Count three words");
            Mock<IApiWordCheckService> apiWordCheckServiceMock = new Mock<IApiWordCheckService>();
            apiWordCheckServiceMock.Setup(f => f.CountEnglishWords(names)).ReturnsAsync(3);
            var WordCountService = new WordCountService(fileServiceMock.Object, apiWordCheckServiceMock.Object);

            string[] words = {};
            int CharacterCount = 0;
            (words, CharacterCount) = WordCountService.CountWordsAndPrint();
            words.Length.Should().Be(3);
            CharacterCount.Should().Be(17);
        }
    }
}