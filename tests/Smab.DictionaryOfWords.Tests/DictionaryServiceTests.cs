namespace Smab.DictionaryOfWords.Tests;

public class DictionaryServiceTests
{
	private static readonly string[] _wordsList = ["this", "is", "a", "sample", "word", "list", "of", "words"];
	private static readonly DictionaryService _dictionaryFromList = new(_wordsList);
	private static readonly DictionaryService _dictionaryFromFile = new("TestWordsList.txt");

	[Theory]
	[InlineData("this")]
	[InlineData("THIS")]
	[InlineData("word")]
	[InlineData("words")]
	public void Is_A_Word(string word)
	{
		_dictionaryFromList.IsWord(word).ShouldBeTrue();
		_dictionaryFromFile.IsWord(word).ShouldBeTrue();
	}

	[Theory]
	[InlineData("")]
	[InlineData("bad")]
	[InlineData("wor")]
	[InlineData("wordier")]
	public void Is_Not_AWord(string word)
	{
		_dictionaryFromList.IsWord(word).ShouldBeFalse();
		_dictionaryFromFile.IsWord(word).ShouldBeFalse();
	}

	[Fact]
	public void Dictionary_Has_8_Words()
	{
		_dictionaryFromList.HasWords.ShouldBeTrue();
		_dictionaryFromFile.HasWords.ShouldBeTrue();

		_dictionaryFromList.Count.ShouldBe(8);
		_dictionaryFromFile.Count.ShouldBe(8);
	}

	[Fact]
	public async void Can_Be_Created_Asynchronously()
	{
		IDictionaryService dictionary = await DictionaryService.CreateAsync(_wordsList);
		dictionary.HasWords.ShouldBeTrue();
		dictionary.Count.ShouldBe(8);
	}
}
