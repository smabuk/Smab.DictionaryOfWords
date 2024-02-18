# Smab.DictionaryOfWords.CSW21

A .NET 8.0 library of English words suitable for word games.

## Documentation

### Initialisation

Can only be retrieved using the static Create methods:

1. Synchronously
	``` cs
	CSW21Dictionary dictionary = CSW21Dictionary.Create();
	```

1. Asynchronously
	``` cs
	CSW21Dictionary dictionary = await CSW21Dictionary.CreateAsync();
	```

1. Once created, extra words can be manually added using `AddWord()`
	``` cs
	CSW21Dictionary dictionary = CSW21Dictionary.Create();
	dictionary.AddWord("newword");
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
