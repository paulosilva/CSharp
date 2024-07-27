using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		string msg = "\"As vezes é preciso coragem\" para não desistir";
		//msg ="\"As vezes é preciso coragem\" para não \"desistir\"";
		//msg = "As vezes é preciso coragem\" para não \"desistir";
		//msg = "As vezes é preciso coragem para não \"desistir";
		msg ="Participar no ciclo da vida de uma criança muda a nossa \"Visão do Futuro\"";
		msg ="Participar no ciclo da vida de uma criança muda a nossa \"Visão do Futuro";
		msg ="Participar no ciclo da vida de uma criança muda a nossa\" \"Visão do Futuro\"";
		msg ="\"Participar no ciclo\" da vida de uma criança muda a nossa \"Visão do Futuro\"";
		
		/** /
		var msg2 = AddQuotes(msg);
		Console.Write("AddQuotes: ");
		Console.WriteLine(msg2);
		Console.WriteLine("");
		
		Console.WriteLine("--//--");
		string[] wordsOrPhrases2 = WordsOrPhrases(msg2);
		
		foreach(string item in wordsOrPhrases2) {
			Console.Write("Is Phrase: ");
			Console.WriteLine(IsPhrase(item));
			Console.Write("Is Word: ");
			Console.WriteLine(IsWord(item));
			Console.Write("Item: ");
			Console.WriteLine(item);
			Console.WriteLine("");
		}
		
		/**/

		/**/		
		Console.WriteLine("--//--");
		string[] wordsOrPhrases = WordsOrPhrases(msg);
		
		foreach(string item in wordsOrPhrases) {			
			Console.Write("Is Phrase: ");
			Console.WriteLine(IsPhrase(item));
			Console.Write("Is Word: ");
			Console.WriteLine(IsWord(item));
			Console.Write("Item: ");
			Console.WriteLine(item);
			Console.WriteLine("");
		}
		/**/
	}
	
	public static string[] WordsOrPhrases(string text)
	{
		List<String> excludeWords = new List<String>() { "", "\"\\\"\\\"\"" };
		List<string> wordsOrPhrases = new List<string>();

		if (NeedExtraQuotes(text))
		{
			text = text + "\"";
		}

		var phrases = text.Split('"');
		for (int i = 0; i < phrases.Length; i++)
		{
			phrases[i] = phrases[i].Trim();
		}

		for (int i = 0; i < phrases.Length; i++)
		{
			if (i % 2 == 0)
			{
				var words = phrases[i].Split(' ');
				foreach (var word in words)
				{
					wordsOrPhrases.Add(word);
				}
			}
			else
			{
				wordsOrPhrases.Add("\"\\\"" + phrases[i] + "\\\"\"");
			}
		}

		var output = new List<string>();
		for (int i = 0; i < wordsOrPhrases.Count; i++)
		{
			if (!excludeWords.Contains(wordsOrPhrases[i]))
			{
				output.Add(wordsOrPhrases[i]);
			}
		}

		return output.ToArray();
	}
	
	private static Boolean IsWord(string text)
	{
		var words = text.Split(' ');
		return words.Length == 1;
	}
	
	private static Boolean IsPhrase(string text)
	{
		var words = text.Split(' ');
		return text.StartsWith("\"") && text.EndsWith("\"") && words.Length > 1;
	}

	private static Boolean NeedExtraQuotes(string text)
	{
		var results = text.Split('"');
		Console.WriteLine(results.Length);
		return results.Length % 2 == 0;
	}

	private static string AddQuotes(string text)
	{
		text = text.Replace("\"", "\\\"");

		if (NeedExtraQuotes(text)) {    
			text = text + "\\\"";
		}

		return "\"" + text + "\"";
	}
}
