namespace Smab.DictionaryOfWords;

public interface IDictionaryOfWords
{
	int Count { get; }
	bool HasWords { get; }

	bool IsWord(string word);
}
