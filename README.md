﻿# Smab.DictionaryOfWords

A .NET 8.0 library used to check the spelling of words.

## Documentation

### Initialisation

4 ways to initialise the dictionary:

1. With a file of words, 1 word per line.
	``` cs
	string filename = "path to file";
	DictionaryOfWords dictionary = new(filename);
	```

1. With a collection of strings
	``` cs
	IEnumerable<string> words = ["a", "list", "of", "words"];
	DictionaryOfWords dictionary = new(words);
	```

1. Words can be manually added using `AddWord()`.
This returns a 'true' if the word was successfully added to the dictionary, otherwise `false`.
	``` cs
	DictionaryOfWords dictionary = new();
	bool success = dictionary.AddWord("this");
	if (dictionary.AddWord("is"))
	{
		_ = dictionary.AddWord("a");
		_ = dictionary.AddWord("word");
	}
	```

1. Multiple words can be manually added using `AddWords()`.
This returns the number of new words added to the dictionary
	``` cs
	DictionaryOfWords dictionary = new();
	IEnumerable<string> words = ["a", "list", "of", "words"];
	int wordsAdded = dictionary.AddWords(words);
	```

### Status
Once a dictionary has been created there are 2 ways that can be used to check if the words
have loaded correctly:

1. HasWords
	Returns True if the dictionary has more than 1 word.
	``` cs
	bool hasWords = dictionary.HasWords;
	```
1. Count
	Returns the number of words loaded into the dictionary.
	``` cs
	int count = dictionary.Count;
	```

### Check Spelling
Words can be checked using the `IsWord()` method.
Returns `true` if the word exists in the dictionary, otherwise `false`.
``` cs
bool isWord = dictionary.IsWord("word");
```
