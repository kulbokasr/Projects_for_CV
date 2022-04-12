
namespace AdroitiWordCount.Services
{
    public interface IApiWordCheckService
    {
        Task<int> CountEnglishWords(string[] names);
    }
}