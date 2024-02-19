# Smab.DictionaryOfWords.CSW21

A .NET 8.0 library of English words suitable for word games.

## Documentation

### Initialisation

Just instantiate the object:

1. Create
	``` cs
	CSW21Dictionary dictionary = new();
	```
1. Once created, extra words can be manually added using `AddWord()` or `AddWords()`
	``` cs
	CSW21Dictionary dictionary = new CSW21Dictionary();
	bool succuess = dictionary.AddWord("newword");
	int noAdded = dictionary.AddWords(["newwordafain", "anothernewword"]);
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
