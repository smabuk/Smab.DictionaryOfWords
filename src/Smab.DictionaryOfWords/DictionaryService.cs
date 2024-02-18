namespace Smab.DictionaryOfWords;

public class DictionaryService : IDictionaryService
{
	private readonly Trie _trie = new();

	public DictionaryService() { }

	public DictionaryService(string filename)           => AddFile(filename);
	public DictionaryService(IEnumerable<string> words) => AddWords(words);

	public void AddWords(IEnumerable<string> words)
	{
		foreach (string word in words)
		{
			AddWord(word);
		}
	}

	public void AddFile(string filename)
	{
		if (!File.Exists(filename))
		{
			throw new FileNotFoundException(nameof(filename));
		}

		foreach (string word in File.ReadAllLines(filename))
		{
			AddWord(word);
		}
	}

	public int Count { get; private set; } = 0;
	public bool HasWords => Count > 0;

	public void AddWord(string word)
	{
		_trie.Insert(word.ToUpperInvariant());
		Count++;
	}

	public bool IsWord(string word) => _trie.Search(word.ToUpperInvariant());
}
