
namespace Smab.DictionaryOfWords;

public interface IDictionaryService
{
	int Count { get; }
	bool HasWords { get; }

	bool AddWord(string word);
	int AddWords(IEnumerable<string> words);
	bool IsWord(string word);
}
