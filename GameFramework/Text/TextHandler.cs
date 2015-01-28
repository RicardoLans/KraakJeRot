using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GameFramework.Text
{
	public static class TextHandler
	{
		public static Dictionary<string, string> TextDictionary { get; set; }

		public static void FillDictionary(ResourceDictionary dic)
		{
			TextDictionary = new Dictionary<String, String>();
			foreach (DictionaryEntry item in dic)
				TextDictionary.Add(item.Key.ToString(), ((TextBlock)item.Value).Text);
		}

		public static string GetText(string textName)
		{
			String value;
			TextDictionary.TryGetValue(textName, out value);
			if (!String.IsNullOrWhiteSpace(value))
				return value;
			if (value == null) throw new ArgumentException("Text or name doesn't exist");
			return String.Empty;
		}

	}
}
