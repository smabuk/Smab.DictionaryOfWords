
namespace Smab.DictionaryOfWords;

public interface IDictionaryService
{
	int Count { get; }
	bool HasWords { get; }

	void AddWord(string word);
	void AddWords(IEnumerable<string> words);
	bool IsWord(string word);
}
