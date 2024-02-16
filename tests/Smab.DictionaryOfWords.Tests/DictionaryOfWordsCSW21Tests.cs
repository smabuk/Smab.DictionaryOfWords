using Smab.DictionaryOfWords.CSW21;

namespace Smab.DictionaryOfWords.Tests;

public class DictionaryOfWordsCSW21Tests
{
	private static readonly IDictionaryOfWords _dictionaryOfWords = new EmbeddedWords();

	[Fact]
	public void Is_PreLoaded()
	{
		_dictionaryOfWords.HasWords.ShouldBeTrue();
		_dictionaryOfWords.Count.ShouldBeGreaterThan(20_000);
	}

	[Theory]
	[InlineData("all")]
	[InlineData("of")]
	[InlineData("these")]
	[InlineData("words")]
	[InlineData("are")]
	[InlineData("in")]
	[InlineData("English")]
	public void Is_A_Word(string word)
	{
		bool actual = _dictionaryOfWords.IsWord(word);
		Assert.True(actual);
	}

	[Theory]
	[InlineData("xyzzy")]
	[InlineData("plugh")]
	[InlineData("  spacing  ")]
	[InlineData("1")]
	public void Is_Not_A_Word(string word)
	{
		bool actual = _dictionaryOfWords.IsWord(word);
		Assert.False(actual);
	}
}
