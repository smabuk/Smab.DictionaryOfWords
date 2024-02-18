namespace Smab.DictionaryOfWords.CSW21;

public class CSW21Dictionary : IDictionaryService
{
	private DictionaryService dictionaryOfWords = null!;

	public static CSW21Dictionary Create() => new CSW21Dictionary().InitAsync().Result;
	public static Task<CSW21Dictionary> CreateAsync() => new CSW21Dictionary().InitAsync();

	private async Task<CSW21Dictionary> InitAsync()
	{
		await Task.Run(() =>
		{
			EmbeddedFileProvider embeddedProvider = new(Assembly.GetExecutingAssembly());
			IFileInfo fileInfo = embeddedProvider.GetFileInfo("words.txt");
			using Stream reader = fileInfo.CreateReadStream();
			using StreamReader streamReader = new(reader);
			dictionaryOfWords = new(streamReader.ReadToEnd().ReplaceLineEndings().Split(Environment.NewLine));
		});

		return this;
	}

	public int  Count    => dictionaryOfWords.Count;
	public bool HasWords => dictionaryOfWords.HasWords;

	public void AddWord(string word) => dictionaryOfWords.AddWord(word);
	public bool IsWord(string word)  => dictionaryOfWords.IsWord(word);
}
