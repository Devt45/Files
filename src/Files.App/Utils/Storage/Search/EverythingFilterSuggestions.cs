// Copyright (c) Files Community
// SPDX-License-Identifier: MPL-2.0

namespace Files.App.Utils.Storage
{
	/// <summary>
	/// Suggests Everything search filters (ext:, size:, dm:…) while the user types in the search box.
	/// </summary>
	internal static class EverythingFilterSuggestions
	{
		private static readonly (string Filter, string DescriptionKey)[] Filters =
		[
			("ext:", "EverythingFilterExt"),
			("size:", "EverythingFilterSize"),
			("dm:", "EverythingFilterDm"),
			("dupe:", "EverythingFilterDupe"),
			("file:", "EverythingFilterFile"),
			("folder:", "EverythingFilterFolder"),
			("parent:", "EverythingFilterParent"),
			("path:", "EverythingFilterPath"),
			("nosubfolders:", "EverythingFilterNoSubfolders"),
			("regex:", "EverythingFilterRegex"),
		];

		/// <summary>
		/// Returns the filters whose name starts with the last word of <paramref name="text"/>,
		/// with the full search text completed for each of them.
		/// </summary>
		public static IReadOnlyList<(string CompletedText, string Filter, string Description)> GetCompletions(string? text)
		{
			if (string.IsNullOrEmpty(text) || char.IsWhiteSpace(text[^1]))
				return [];

			int start = text.LastIndexOf(' ') + 1;
			string token = text[start..];
			string prefix = token.StartsWith('!') ? "!" : string.Empty;
			string word = token[prefix.Length..];

			if (word.Length < 2 || word.Contains(':'))
				return [];

			var results = new List<(string, string, string)>();
			foreach (var (filter, descriptionKey) in Filters)
			{
				if (filter.StartsWith(word, StringComparison.OrdinalIgnoreCase) && filter.Length > word.Length)
					results.Add((text[..start] + prefix + filter, filter, descriptionKey.GetLocalizedResource()));
			}

			return results;
		}
	}
}
