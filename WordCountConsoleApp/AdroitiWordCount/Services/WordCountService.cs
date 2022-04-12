using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetSpell;

namespace AdroitiWordCount.Services
{
    
    public class WordCountService
    {
        private IFileService _fileService;
        private IApiWordCheckService _apiWordCheckService;

        public WordCountService(IFileService fileService, IApiWordCheckService apiWordCheckService)
        {
            _fileService = fileService;
            _apiWordCheckService = apiWordCheckService;
        }

        public (string[] words, int CharacterCount) CountWordsAndPrint()
        {
            var allText = _fileService.ReadFile();
            Console.WriteLine(allText);
            string[] words = allText.Split(" ");
            int englishWords = 0;
            englishWords = _apiWordCheckService.CountEnglishWords(words).Result;
            int CharacterCount = allText.Length;
            Console.WriteLine($"There are {words.Length.ToString()} words, {englishWords} English words and {CharacterCount.ToString()} characters in the file");
            return (words, CharacterCount);
        }
    }
}
