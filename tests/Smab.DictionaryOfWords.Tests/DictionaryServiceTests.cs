namespace Smab.DictionaryOfWords.Tests;

public class DictionaryServiceTests
{
	private static readonly string[] _wordsList = ["this", "is", "a", "sample", "word", "list", "of", "words"];
	private const int Expected_No_Of_Words = 8;
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

		_dictionaryFromList.Count.ShouldBe(Expected_No_Of_Words);
		_dictionaryFromFile.Count.ShouldBe(Expected_No_Of_Words);
	}

	[Fact]
	public void Can_Add_Words()
	{
		DictionaryService dictionary = new(_wordsList);
		dictionary.HasWords.ShouldBeTrue();
		dictionary.Count.ShouldBe(Expected_No_Of_Words);

		dictionary.AddWord("this").ShouldBeFalse(); ;
		dictionary.AddWord("aaaaaaaaaa").ShouldBeTrue();
		dictionary.Count.ShouldBe(Expected_No_Of_Words + 1);
		dictionary.AddWords(["bbbbbbbbbb", "cccccccccc"]).ShouldBe(2);
		dictionary.Count.ShouldBe(Expected_No_Of_Words + 3);
	}
}
