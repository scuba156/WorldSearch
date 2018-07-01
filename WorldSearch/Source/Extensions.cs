using System.Globalization;
using System.Linq;
using System.Text;

namespace WorldSearch {

    public static class Extensions {

        public static string ReplaceDiacritics(this string text) {
            string decomposed = text.Normalize(NormalizationForm.FormD);
            char[] filtered = decomposed
                .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();
            return new string(filtered);
        }
    }
}