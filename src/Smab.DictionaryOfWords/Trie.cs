namespace Smab.DictionaryOfWords;
internal sealed class Trie {
	public TrieNode Root { get; set; }

	public Trie() {
		Root = new TrieNode();
	}

	public bool Insert(string word) {
		TrieNode current = Root;

		for (int i = 0; i < word.Length; i++) {
			char c = word[i];

			if (!current.Children.TryGetValue(c, out TrieNode? value)) {
				value = new TrieNode();
				current.Children.Add(c, value);
			}

			current = value;
		}

		if (current.IsWord)
		{
			return false;
		}

		current.IsWord = true;
		return true;
	}

	public bool Search(string word) {
		TrieNode current = Root;

		for (int i = 0; i < word.Length; i++) {
			char c = word[i];

			if (!current.Children.TryGetValue(c, out TrieNode? value)) {
				return false;
			}

			current = value;
		}

		return current.IsWord;
	}

	internal class TrieNode {
		public Dictionary<char, TrieNode> Children { get; set; } = [];
		public bool IsWord { get; set; }
	}
}

