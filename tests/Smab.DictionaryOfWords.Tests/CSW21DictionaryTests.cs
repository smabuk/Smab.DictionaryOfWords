using Smab.DictionaryOfWords.CSW21;

namespace Smab.DictionaryOfWords.Tests;

public class CSW21DictionaryTests
{
	private static readonly CSW21Dictionary _csw21Dictionary = new();

	[Fact]
	public void Is_PreLoaded()
	{
		_csw21Dictionary.HasWords.ShouldBeTrue();
		_csw21Dictionary.Count.ShouldBeGreaterThan(20_000);
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
		_csw21Dictionary.IsWord(word).ShouldBeTrue();
	}

	[Theory]
	[InlineData("")]
	[InlineData("xyzzy")]
	[InlineData("plugh")]
	[InlineData("  spacing  ")]
	[InlineData("1")]
	public void Is_Not_A_Word(string word)
	{
		_csw21Dictionary.IsWord(word).ShouldBeFalse();
	}
}
