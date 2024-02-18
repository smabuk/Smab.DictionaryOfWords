namespace Smab.DictionaryOfWords.CSW21;

public class CSW21Dictionary : IDictionaryService
{
	private DictionaryService? dictionaryOfWords = null;
	public CSW21Dictionary() {
		EmbeddedFileProvider embeddedProvider = new(Assembly.GetExecutingAssembly());
		IFileInfo fileInfo = embeddedProvider.GetFileInfo("words.txt");
		using Stream reader = fileInfo.CreateReadStream();
		using StreamReader streamReader = new(reader);
		dictionaryOfWords = new(streamReader.ReadToEnd().ReplaceLineEndings().Split(Environment.NewLine));
	}

	public int  Count    => dictionaryOfWords?.Count ?? 0;
	public bool HasWords => dictionaryOfWords?.HasWords ?? false;

	public void AddWord(string word) => dictionaryOfWords?.AddWord(word);
	public void AddWords(IEnumerable<string> words) => dictionaryOfWords?.AddWords(words);
	public bool IsWord(string word)  => dictionaryOfWords?.IsWord(word) ?? false;
}
