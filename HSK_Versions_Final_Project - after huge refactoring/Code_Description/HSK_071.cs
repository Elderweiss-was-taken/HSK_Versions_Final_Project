using StrEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HSK_Versions_Final_Project
{
    public static partial class HSK
    {
        private static Dictionary<Rune, HSK.Custom_object> _Everything_As_Dictionary_final;

        public static Dictionary<Rune, HSK.Custom_object> Everything_As_Dictionary_final
        {
            get
            {
                if (_Everything_As_Dictionary_final == null)
                {
                    _Everything_As_Dictionary_final = [];

                    foreach (var item in HSK.Everything_As_Dictionary)
                    {
                        var custom = new Custom_object(item.Key, Get_Pattern(item.Value), item.Value);
                        custom.EnsureLevelHistoryByVersionPopulated();
                        _Everything_As_Dictionary_final.Add(item.Key, custom);
                    }
                }

                return _Everything_As_Dictionary_final;
            }
        }

        private static HSK_Presence__or_HSK_Version_change Get_Pattern((HSK_Version hsk_version, HSK_Level hsk_level)?[] arr)
        {
            // 1 = value, 0 = null
            int b0 = arr[0] != null ? 1 : 0;
            int b1 = arr[1] != null ? 1 : 0;
            int b2 = arr[2] != null ? 1 : 0;
            int pattern = (b0 << 2) | (b1 << 1) | b2;
            return pattern switch
            {
                0b_111 => HSK_Presence__or_HSK_Version_change.Parse(0b_111.ToString()),
                0b_110 => HSK_Presence__or_HSK_Version_change.Parse(0b_110.ToString()),
                0b_101 => HSK_Presence__or_HSK_Version_change.Parse(0b_101.ToString()),
                0b_100 => HSK_Presence__or_HSK_Version_change.Parse(0b_100.ToString()),
                0b_011 => HSK_Presence__or_HSK_Version_change.Parse(0b_011.ToString()),
                0b_010 => HSK_Presence__or_HSK_Version_change.Parse(0b_010.ToString()),
                0b_001 => HSK_Presence__or_HSK_Version_change.Parse(0b_001.ToString()),
                0b_000 => HSK_Presence__or_HSK_Version_change.Parse(0b_000.ToString()),
                _ => throw new InvalidOperationException()
            };
        }

        private static Dictionary<HSK_Presence__or_HSK_Version_change, int> Give_Pattern_counts(Dictionary<Rune, (HSK_Version hsk_version, HSK_Level hsk_level)?[]> dict)
        {
            var counts = HSK_Presence__or_HSK_Version_change.GetMembers().ToDictionary(p => p, _ => 0);

            foreach (var arr in dict.Values)
            {
                var pattern = Get_Pattern(arr);
                counts[pattern]++;
            }

            return counts;
        }
        public static string Show_counts
        {
            get
            {
                StringBuilder sb = new();

                sb.AppendLine($"HSK 2.0 - 2010 : {HSK_Version.HSK_2_0__From_2010.Count}\t characters{Environment.NewLine}");
                sb.AppendLine($"HSK 3.0 - 2021 : {HSK_Version.HSK_3_0__From_2021.Count}\t characters{Environment.NewLine}");
                sb.AppendLine($"HSK 3.1 - 2025 : {HSK_Version.HSK_3_1__From_2025.Count}\t characters{Environment.NewLine}");

                sb.AppendLine($"Total Unique characters accross all HSK Versions and Levels : {HSK.Everything_As_List.Count}{Environment.NewLine}");

                var pattern_counts = Give_Pattern_counts(HSK.Everything_As_Dictionary);

                HSK_Presence__or_HSK_Version_change presence_number_1 = HSK_Presence__or_HSK_Version_change.Parse(0b_111.ToString());
                HSK_Presence__or_HSK_Version_change presence_number_2 = HSK_Presence__or_HSK_Version_change.Parse(0b_110.ToString());
                HSK_Presence__or_HSK_Version_change presence_number_3 = HSK_Presence__or_HSK_Version_change.Parse(0b_101.ToString());
                HSK_Presence__or_HSK_Version_change presence_number_4 = HSK_Presence__or_HSK_Version_change.Parse(0b_100.ToString());
                HSK_Presence__or_HSK_Version_change presence_number_5 = HSK_Presence__or_HSK_Version_change.Parse(0b_011.ToString());
                HSK_Presence__or_HSK_Version_change presence_number_6 = HSK_Presence__or_HSK_Version_change.Parse(0b_010.ToString());
                HSK_Presence__or_HSK_Version_change presence_number_7 = HSK_Presence__or_HSK_Version_change.Parse(0b_001.ToString());

                sb.AppendLine($"{pattern_counts[presence_number_1].ToString().PadLeft(4)}\t{presence_number_1}");
                sb.AppendLine($"{pattern_counts[presence_number_2].ToString().PadLeft(4)}\t{presence_number_2}");
                sb.AppendLine($"{pattern_counts[presence_number_3].ToString().PadLeft(4)}\t{presence_number_3}");
                sb.AppendLine($"{pattern_counts[presence_number_4].ToString().PadLeft(4)}\t{presence_number_4}");
                sb.AppendLine($"{pattern_counts[presence_number_5].ToString().PadLeft(4)}\t{presence_number_5}");
                sb.AppendLine($"{pattern_counts[presence_number_6].ToString().PadLeft(4)}\t{presence_number_6}");
                sb.AppendLine($"{pattern_counts[presence_number_7].ToString().PadLeft(4)}\t{presence_number_7}");

                return sb.ToString();
            }
        }
    }
}