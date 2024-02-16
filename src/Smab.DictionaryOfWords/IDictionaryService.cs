namespace Smab.DictionaryOfWords;

public interface IDictionaryService
{
	int Count { get; }
	bool HasWords { get; }

	void AddWord(string word);
	bool IsWord(string word);
}
