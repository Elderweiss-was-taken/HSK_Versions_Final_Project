using StrEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/// 
namespace HSK_Versions_Final_Project
{
    public static partial class HSK
    {
        private static Dictionary<Rune, (HSK_Version hsk_version, HSK_Level hsk_level)?[]> _Everything_As_Dictionary;
        private static List<Rune> _Everything_As_List;
        public static List<Rune> Everything_As_List
        {
            get
            {
                if (HSK._Everything_As_List == null)
                {
                    HSK._Everything_As_List = [];

                    HSK._Everything_As_List.AddRange(HSK_Version.HSK_2_0__From_2010.All_Characters_accross_all_levels_within_the_same_HSK_Version);
                    HSK._Everything_As_List.AddRange(HSK_Version.HSK_3_0__From_2021.All_Characters_accross_all_levels_within_the_same_HSK_Version);
                    HSK._Everything_As_List.AddRange(HSK_Version.HSK_3_1__From_2025.All_Characters_accross_all_levels_within_the_same_HSK_Version);

                    HSK._Everything_As_List = HSK._Everything_As_List.Distinct().ToList();
                }

                return HSK._Everything_As_List;
            }
        }
        public static Dictionary<Rune, (HSK_Version hsk_version, HSK_Level hsk_level)?[]> Everything_As_Dictionary
        {
            get
            {
                const int hsk_20_index = 0;
                const int hsk_30_index = 1;
                const int hsk_31_index = 2;

                if (HSK._Everything_As_Dictionary == null)
                {
                    HSK._Everything_As_Dictionary = [];

                    foreach (Rune rune in HSK.Everything_As_List)
                    {
                        (HSK_Version hsk_version, HSK_Level hsk_level)?[] versions_and_levels = new (HSK_Version hsk_version, HSK_Level hsk_level)?[3];

                        if (HSK_Version.HSK_2_0__From_2010.All_Characters_accross_all_levels_within_the_same_HSK_Version.Contains(rune))
                        {
                            HSK_Version hsk_version = HSK_Version.HSK_2_0__From_2010;
                            HSK_Level? hsk_level = null;

                            if (HSK_Version.HSK_2_0__From_2010.Level_1.Contains(rune)) hsk_level = HSK_Level.HSK_Level_1;
                            if (HSK_Version.HSK_2_0__From_2010.Level_2.Contains(rune)) hsk_level = HSK_Level.HSK_Level_2;
                            if (HSK_Version.HSK_2_0__From_2010.Level_3.Contains(rune)) hsk_level = HSK_Level.HSK_Level_3;
                            if (HSK_Version.HSK_2_0__From_2010.Level_4.Contains(rune)) hsk_level = HSK_Level.HSK_Level_4;
                            if (HSK_Version.HSK_2_0__From_2010.Level_5.Contains(rune)) hsk_level = HSK_Level.HSK_Level_5;
                            if (HSK_Version.HSK_2_0__From_2010.Level_6.Contains(rune)) hsk_level = HSK_Level.HSK_Level_6;

                            if (hsk_level == null) throw new Exception();

                            (HSK_Version hsk_version, HSK_Level hsk_level) tuple = (hsk_version, hsk_level);

                            versions_and_levels[hsk_20_index] = tuple;
                        }
                        else { versions_and_levels[hsk_20_index] = null; }
                        if (HSK_Version.HSK_3_0__From_2021.All_Characters_accross_all_levels_within_the_same_HSK_Version.Contains(rune))
                        {
                            HSK_Version hsk_version = HSK_Version.HSK_3_0__From_2021;
                            HSK_Level? hsk_level = null;

                            if (HSK_Version.HSK_3_0__From_2021.Level_1.Contains(rune)) hsk_level = HSK_Level.HSK_Level_1;
                            if (HSK_Version.HSK_3_0__From_2021.Level_2.Contains(rune)) hsk_level = HSK_Level.HSK_Level_2;
                            if (HSK_Version.HSK_3_0__From_2021.Level_3.Contains(rune)) hsk_level = HSK_Level.HSK_Level_3;
                            if (HSK_Version.HSK_3_0__From_2021.Level_4.Contains(rune)) hsk_level = HSK_Level.HSK_Level_4;
                            if (HSK_Version.HSK_3_0__From_2021.Level_5.Contains(rune)) hsk_level = HSK_Level.HSK_Level_5;
                            if (HSK_Version.HSK_3_0__From_2021.Level_6.Contains(rune)) hsk_level = HSK_Level.HSK_Level_6;
                            if (HSK_Version.HSK_3_0__From_2021.Level_7.Contains(rune)) hsk_level = HSK_Level.HSK_Level_7;

                            if (hsk_level == null) throw new Exception();

                            (HSK_Version hsk_version, HSK_Level hsk_level) tuple = (hsk_version, hsk_level);

                            versions_and_levels[hsk_30_index] = tuple;
                        }
                        else { versions_and_levels[hsk_30_index] = null; }
                        if (HSK_Version.HSK_3_1__From_2025.All_Characters_accross_all_levels_within_the_same_HSK_Version.Contains(rune))
                        {
                            HSK_Version hsk_version = HSK_Version.HSK_3_1__From_2025;
                            HSK_Level? hsk_level = null;

                            if (HSK_Version.HSK_3_1__From_2025.Level_1.Contains(rune)) hsk_level = HSK_Level.HSK_Level_1;
                            if (HSK_Version.HSK_3_1__From_2025.Level_2.Contains(rune)) hsk_level = HSK_Level.HSK_Level_2;
                            if (HSK_Version.HSK_3_1__From_2025.Level_3.Contains(rune)) hsk_level = HSK_Level.HSK_Level_3;
                            if (HSK_Version.HSK_3_1__From_2025.Level_4.Contains(rune)) hsk_level = HSK_Level.HSK_Level_4;
                            if (HSK_Version.HSK_3_1__From_2025.Level_5.Contains(rune)) hsk_level = HSK_Level.HSK_Level_5;
                            if (HSK_Version.HSK_3_1__From_2025.Level_6.Contains(rune)) hsk_level = HSK_Level.HSK_Level_6;
                            if (HSK_Version.HSK_3_1__From_2025.Level_7.Contains(rune)) hsk_level = HSK_Level.HSK_Level_7;

                            if (hsk_level == null) throw new Exception();

                            (HSK_Version hsk_version, HSK_Level hsk_level) tuple = (hsk_version, hsk_level);

                            versions_and_levels[hsk_31_index] = tuple;
                        }
                        else { versions_and_levels[hsk_31_index] = null; }


                        HSK._Everything_As_Dictionary.Add(rune, versions_and_levels);
                    }
                }

                return HSK._Everything_As_Dictionary;
            }
        }
    }
}