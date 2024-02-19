namespace Smab.DictionaryOfWords;

public class DictionaryService : IDictionaryService
{
	private readonly Trie _trie = new();

	public DictionaryService() { }
	public DictionaryService(string filename)           => AddFile(filename);
	public DictionaryService(IEnumerable<string> words) => AddWords(words);

	public int AddWords(IEnumerable<string> words)
	{
		int count = 0;
		foreach (string word in words)
		{
			if (AddWord(word))
			{
				count++;
			}
		}

		return count;
	}

	public int AddFile(string filename)
	{
		if (!File.Exists(filename))
		{
			throw new FileNotFoundException(nameof(filename));
		}

		int count = 0;
		foreach (string word in File.ReadAllLines(filename))
		{
			if (AddWord(word))
			{
				count++;
			}
		}

		return count;
	}

	public int Count { get; private set; } = 0;
	public bool HasWords => Count > 0;

	public bool AddWord(string word)
	{
		if (_trie.Insert(word.ToUpperInvariant()))
		{
			Count++;
			return true;
		}

		return false;
	}

	public bool IsWord(string word) => _trie.Search(word.ToUpperInvariant());
}
