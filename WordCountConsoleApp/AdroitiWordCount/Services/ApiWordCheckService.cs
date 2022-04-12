using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdroitiWordCount.Services
{
    public class ApiWordCheckService : IApiWordCheckService
    {
        public async Task<int> CountEnglishWords(string[] names)
        {
            HttpClient client = new HttpClient();
            int englishWordsCount = 0;
            foreach (string name in names)
            {
                HttpResponseMessage httpResponseMessage = await client.GetAsync($"https://api.dictionaryapi.dev/api/v2/entries/en/" + name);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    englishWordsCount++;
                }
            }
            return englishWordsCount;
        }
    }
}
