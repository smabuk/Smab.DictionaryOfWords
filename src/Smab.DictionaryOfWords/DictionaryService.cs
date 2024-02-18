namespace Smab.DictionaryOfWords;

public class DictionaryService : IDictionaryService
{
	private readonly Trie _trie = new();

	public DictionaryService() { }

	public DictionaryService(string filename)           => _ = InitAsync(filename).Result;
	public DictionaryService(IEnumerable<string> words) => _ = InitAsync(words).Result;


	public static Task<DictionaryService> CreateAsync(string filename)           => new DictionaryService().InitAsync(filename);
	public static Task<DictionaryService> CreateAsync(IEnumerable<string> words) => new DictionaryService().InitAsync(words);


	private async Task<DictionaryService> InitAsync(IEnumerable<string> words)
	{
		await Task.Run(() =>
		{
			foreach (string word in words)
			{
				AddWord(word);
			}
		});

		return this;
	}

	private async Task<DictionaryService> InitAsync(string filename)
	{
		if (!File.Exists(filename))
		{
			throw new FileNotFoundException(nameof(filename));
		}

		foreach (string word in await File.ReadAllLinesAsync(filename))
		{
			AddWord(word);
		}

		return this;
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
