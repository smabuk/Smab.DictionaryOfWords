using Smab.DictionaryOfWords.CSW21;

namespace Smab.DictionaryOfWords.Tests;

public class CSW21DictionaryTests
{
	private static readonly CSW21Dictionary _csw21Dictionary = CSW21Dictionary.Create();
	private const int Expected_Number_Of_Words = 279_077;

	[Fact]
	public void Is_PreLoaded()
	{
		_csw21Dictionary.HasWords.ShouldBeTrue();
		_csw21Dictionary.Count.ShouldBe(Expected_Number_Of_Words);
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


	[Fact]
	public async void Can_Be_Created_Asynchronously()
	{
		CSW21Dictionary dictionary = await CSW21Dictionary.CreateAsync();
		dictionary.HasWords.ShouldBeTrue();
		dictionary.Count.ShouldBe(Expected_Number_Of_Words);
	}
}
