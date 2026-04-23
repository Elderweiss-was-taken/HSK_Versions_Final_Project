using System.Collections.Generic;
using System.Text;

namespace HSK_Versions_Final_Project
{
    public static class DictionaryRuneCustomObjectExtensions
    {
        public static Dictionary<Rune, HSK.Custom_object> WhereHasMultipleHskLevels(
            this IReadOnlyDictionary<Rune, HSK.Custom_object> source)
        {
            var result = new Dictionary<Rune, HSK.Custom_object>();
            foreach (var kv in source)
            {
                if (kv.Value.Has_Multiple_HSK_Levels)
                    result.Add(kv.Key, kv.Value);
            }

            return result;
        }

        public static Dictionary<Rune, HSK.Custom_object> WhereHasSingleHskLevel(
            this IReadOnlyDictionary<Rune, HSK.Custom_object> source)
        {
            var result = new Dictionary<Rune, HSK.Custom_object>();
            foreach (var kv in source)
            {
                if (kv.Value.Has_Single_HSK_Level)
                    result.Add(kv.Key, kv.Value);
            }

            return result;
        }
    }
}
