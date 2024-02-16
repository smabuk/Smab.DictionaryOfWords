﻿namespace Smab.DictionaryOfWords;

public class DictionaryOfWords : IDictionaryOfWords
{

	public int Count { get; private set; }
	public bool HasWords => Count > 0;

	private readonly Trie _trie = new();

	public DictionaryOfWords()
	{
		Count = 0;
	}

	public DictionaryOfWords(string filename)
	{
		if (!File.Exists(filename))
		{
			throw new FileNotFoundException(nameof(filename));
		}

		foreach (var word in File.ReadAllLines(filename))
		{
			_trie.Insert(word.ToUpperInvariant());
			Count++;
		}
	}

	public DictionaryOfWords(IEnumerable<string> words)
	{
		foreach (var word in words)
		{
			_trie.Insert(word.ToUpperInvariant());
			Count++;
		}
	}

	public bool IsWord(string word) => _trie.Search(word.ToUpperInvariant());
}
