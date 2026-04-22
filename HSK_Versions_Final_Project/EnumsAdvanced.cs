using StrEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HSK_Versions_Final_Project
{
    /// <summary>
    /// Enum for all 3-bit combinations (1 = value, 0 = null)
    /// </summary>
    public partial class HSK_Presence__or_HSK_Version_change : StringEnum<HSK_Presence__or_HSK_Version_change>
    {
        public static readonly HSK_Presence__or_HSK_Version_change _111__Present_in_all_versions                                 = Define(0b_111.ToString());
        public static readonly HSK_Presence__or_HSK_Version_change _110__Removed_in_HSK3_1__Present_in_HSK2_0_and_HSK3_0         = Define(0b_110.ToString());
        public static readonly HSK_Presence__or_HSK_Version_change _101__Removed_in_HSK3_0__Put_back_in_HSK3_1                   = Define(0b_101.ToString());
        public static readonly HSK_Presence__or_HSK_Version_change _100__HSK2_0_Exclusive___Never_added_back_later               = Define(0b_100.ToString());
        public static readonly HSK_Presence__or_HSK_Version_change _011__NEW_CHAR___________Absent_in_HSK2_0__Added_since_HSK3_0 = Define(0b_011.ToString());
        public static readonly HSK_Presence__or_HSK_Version_change _010__HSK3_0_Exclusive___Never_added_back_later               = Define(0b_010.ToString());
        public static readonly HSK_Presence__or_HSK_Version_change _001__NEW_CHAR___________HSK3_1_Exclusive                     = Define(0b_001.ToString());
        public static readonly HSK_Presence__or_HSK_Version_change _000__Not_a_HSK_character                                     = Define(0b_000.ToString());

        private static Dictionary<Rune, HSK.Custom_object> _111;
        private static Dictionary<Rune, HSK.Custom_object> _110;
        private static Dictionary<Rune, HSK.Custom_object> _101;
        private static Dictionary<Rune, HSK.Custom_object> _100;
        private static Dictionary<Rune, HSK.Custom_object> _011;
        private static Dictionary<Rune, HSK.Custom_object> _010;
        private static Dictionary<Rune, HSK.Custom_object> _001;

        public Dictionary<Rune, HSK.Custom_object> Give_All_Characters
        {
            get
            {
                if (_111 == null || _110 == null || _101 == null || _100 == null || _011 == null || _010 == null || _001 == null)
                {
                    _111 = [];
                    _110 = [];
                    _101 = [];
                    _100 = [];
                    _011 = [];
                    _010 = [];
                    _001 = [];

                    foreach (var item in HSK.Everything_As_Dictionary_final)
                    {
                        switch (item.Value.HSK_presence)
                        {
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._111__Present_in_all_versions                                :
                                _111.Add(item.Key, item.Value);
                                break;
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._110__Removed_in_HSK3_1__Present_in_HSK2_0_and_HSK3_0        :
                                _110.Add(item.Key, item.Value);
                                break;
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._101__Removed_in_HSK3_0__Put_back_in_HSK3_1                  :
                                _101.Add(item.Key, item.Value);
                                break;
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._100__HSK2_0_Exclusive___Never_added_back_later              :
                                _100.Add(item.Key, item.Value);
                                break;
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._011__NEW_CHAR___________Absent_in_HSK2_0__Added_since_HSK3_0:
                                _011.Add(item.Key, item.Value);
                                break;
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._010__HSK3_0_Exclusive___Never_added_back_later              :
                                _010.Add(item.Key, item.Value);
                                break;
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._001__NEW_CHAR___________HSK3_1_Exclusive                    :
                                _001.Add(item.Key, item.Value);
                                break;
                        }
                    }
                }

                return this switch
                {
                    _ when this == HSK_Presence__or_HSK_Version_change._111__Present_in_all_versions                                 => _111,
                    _ when this == HSK_Presence__or_HSK_Version_change._110__Removed_in_HSK3_1__Present_in_HSK2_0_and_HSK3_0         => _110,
                    _ when this == HSK_Presence__or_HSK_Version_change._101__Removed_in_HSK3_0__Put_back_in_HSK3_1                   => _101,
                    _ when this == HSK_Presence__or_HSK_Version_change._100__HSK2_0_Exclusive___Never_added_back_later               => _100,
                    _ when this == HSK_Presence__or_HSK_Version_change._011__NEW_CHAR___________Absent_in_HSK2_0__Added_since_HSK3_0 => _011,
                    _ when this == HSK_Presence__or_HSK_Version_change._010__HSK3_0_Exclusive___Never_added_back_later               => _010,
                    _ when this == HSK_Presence__or_HSK_Version_change._001__NEW_CHAR___________HSK3_1_Exclusive                     => _001,
                    _ => throw new Exception("code better")
                };
            }
        }
    }
}

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
                        _Everything_As_Dictionary_final.Add(item.Key, new(item.Key, Get_Pattern(item.Value), item.Value));
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
        public class Custom_object
        {
            public Rune Character { get; init; }
            public (HSK_Version hsk_version, HSK_Level hsk_level)?[] HSK_details { get; init; }

            public HSK_Presence__or_HSK_Version_change HSK_presence { get; init; }

            public Custom_object(Rune rune, HSK_Presence__or_HSK_Version_change hsk_presence, (HSK_Version hsk_version, HSK_Level hsk_level)?[] HSK_details)
            {
                if (HSK_details.Count() != 3) throw new Exception("must be 3");

                this.Character    = rune;
                this.HSK_details  = HSK_details;
                this.HSK_presence = hsk_presence;
            }
        }
    }
}

/// 
namespace HSK_Versions_Final_Project
{
    public static partial class HSK
    {
        private static Dictionary<Rune, (HSK_Version hsk_version, HSK_Level hsk_level)?[]> _Everything_As_Dictionary;
        private static List<Rune>                                                          _Everything_As_List      ;
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
                            HSK_Level?   hsk_level = null;

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

    public partial class HSK_Version : StringEnum<HSK_Version>
    {
        private static List<Rune> _All_Characters_accross_all_levels_for_HSK20;
        private static List<Rune> _All_Characters_accross_all_levels_for_HSK30;
        private static List<Rune> _All_Characters_accross_all_levels_for_HSK31;
        public List<Rune> All_Characters_accross_all_levels_within_the_same_HSK_Version
        {
            get
            {
                switch (this)
                {
                    case { } when this == HSK_Version.HSK_2_0__From_2010:
                        if (HSK_Version._All_Characters_accross_all_levels_for_HSK20 == null)
                        {
                            HSK_Version._All_Characters_accross_all_levels_for_HSK20 = [];

                            HSK_Version._All_Characters_accross_all_levels_for_HSK20.AddRange(this.Level_1);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK20.AddRange(this.Level_2);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK20.AddRange(this.Level_3);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK20.AddRange(this.Level_4);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK20.AddRange(this.Level_5);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK20.AddRange(this.Level_6);

                            int tmp1 = _All_Characters_accross_all_levels_for_HSK20.Distinct().Count();
                            int tmp2 = _All_Characters_accross_all_levels_for_HSK20           .Count();

                            if (tmp1 != tmp2) throw new Exception("It means some characters appear twice from a HSK level to another. If the list was uncompressable, then the UNIQUE count shouldn't change.");
                        }

                        return HSK_Version._All_Characters_accross_all_levels_for_HSK20;

                    case { } when this == HSK_Version.HSK_3_0__From_2021:
                        if (HSK_Version._All_Characters_accross_all_levels_for_HSK30 == null)
                        {
                            HSK_Version._All_Characters_accross_all_levels_for_HSK30 = [];

                            HSK_Version._All_Characters_accross_all_levels_for_HSK30.AddRange(this.Level_1);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK30.AddRange(this.Level_2);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK30.AddRange(this.Level_3);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK30.AddRange(this.Level_4);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK30.AddRange(this.Level_5);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK30.AddRange(this.Level_6);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK30.AddRange(this.Level_7);

                            int tmp1 = _All_Characters_accross_all_levels_for_HSK30.Distinct().Count();
                            int tmp2 = _All_Characters_accross_all_levels_for_HSK30.Count();

                            if (tmp1 != tmp2) throw new Exception("It means some characters appear twice from a HSK level to another. If the list was uncompressable, then the UNIQUE count shouldn't change.");
                        }

                        return HSK_Version._All_Characters_accross_all_levels_for_HSK30;

                    case { } when this == HSK_Version.HSK_3_1__From_2025:
                        if (HSK_Version._All_Characters_accross_all_levels_for_HSK31 == null)
                        {
                            HSK_Version._All_Characters_accross_all_levels_for_HSK31 = [];

                            HSK_Version._All_Characters_accross_all_levels_for_HSK31.AddRange(this.Level_1);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK31.AddRange(this.Level_2);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK31.AddRange(this.Level_3);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK31.AddRange(this.Level_4);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK31.AddRange(this.Level_5);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK31.AddRange(this.Level_6);
                            HSK_Version._All_Characters_accross_all_levels_for_HSK31.AddRange(this.Level_7);

                            int tmp1 = _All_Characters_accross_all_levels_for_HSK31.Distinct().Count();
                            int tmp2 = _All_Characters_accross_all_levels_for_HSK31.Count();

                            if (tmp1 != tmp2) throw new Exception("It means some characters appear twice from a HSK level to another. If the list was uncompressable, then the UNIQUE count shouldn't change.");
                        }

                        return HSK_Version._All_Characters_accross_all_levels_for_HSK31;
                }
                throw new Exception("invalid code path");
            }
        }
    }
}

/// Getting character count across a single AND across all
namespace HSK_Versions_Final_Project
{
    public partial class HSK_Version : StringEnum<HSK_Version>
    {
        public int Count => this switch
        {
            _ when this == HSK_Version.HSK_2_0__From_2010 => this.Level_1.Count + this.Level_2.Count + this.Level_3.Count + this.Level_4.Count + this.Level_5.Count + this.Level_6.Count,
            _ when this == HSK_Version.HSK_3_0__From_2021 => this.Level_1.Count + this.Level_2.Count + this.Level_3.Count + this.Level_4.Count + this.Level_5.Count + this.Level_6.Count + this.Level_7.Count,
            _ when this == HSK_Version.HSK_3_1__From_2025 => this.Level_1.Count + this.Level_2.Count + this.Level_3.Count + this.Level_4.Count + this.Level_5.Count + this.Level_6.Count + this.Level_7.Count,
            _ => throw new InvalidOperationException($"IMPOSSIBLE/ILLEGAL OPERATION : {this}")
        };
    }
}

/// Making the access to the raw data more easy
namespace HSK_Versions_Final_Project
{
    public partial class HSK_Version : StringEnum<HSK_Version>
    {
        public List<Rune> Level_1 => this[HSK_Level.HSK_Level_1];
        public List<Rune> Level_2 => this[HSK_Level.HSK_Level_2];
        public List<Rune> Level_3 => this[HSK_Level.HSK_Level_3];
        public List<Rune> Level_4 => this[HSK_Level.HSK_Level_4];
        public List<Rune> Level_5 => this[HSK_Level.HSK_Level_5];
        public List<Rune> Level_6 => this[HSK_Level.HSK_Level_6];
        public List<Rune> Level_7 => (this == HSK_Version.HSK_2_0__From_2010 ? throw new Exception("HSK 2.0 only has up to HSK Level 6. There is no HSK Level 7 for HSK 2.0") : this[HSK_Level.HSK_Level_7]);
    }
}

/// Getting a specific HSK level from a specific HSK version
namespace HSK_Versions_Final_Project
{
    public partial class HSK_Version : StringEnum<HSK_Version>
    {
        public List<Rune> this[HSK_Level index] => this switch
        {
            _ when this == HSK_Version.HSK_2_0__From_2010 => HSK_Version._HSK_20[(index == HSK_Level.HSK_Level_7 ? throw new Exception("HSK 2.0 only has up to HSK Level 6. There is no HSK Level 7 for HSK 2.0") : index )],
            _ when this == HSK_Version.HSK_3_0__From_2021 => HSK_Version._HSK_30[index],
            _ when this == HSK_Version.HSK_3_1__From_2025 => HSK_Version._HSK_31[index],
            _ => throw new InvalidOperationException($"IMPOSSIBLE/ILLEGAL OPERATION : {this}")
        };
    }
}

/// Storing EVERY DATA into the HSK_Version enum
namespace HSK_Versions_Final_Project
{
    public partial class HSK_Version : StringEnum<HSK_Version>
    {
        private static bool has_Load_Everything_been_called_yet = false;

        private static List<Rune>[] __HSK_20;
        private static List<Rune>[] __HSK_30;
        private static List<Rune>[] __HSK_31;

        private static List<Rune>[] _HSK_20
        {
            get
            {
                if (has_Load_Everything_been_called_yet == true) return __HSK_20;

                Load_Everything();

                if (__HSK_20 == null) throw new Exception("??? somehow palpatine ... somehow populating the list failed");

                return __HSK_20;
            }
        }
        private static List<Rune>[] _HSK_30
        {
            get
            {
                if (has_Load_Everything_been_called_yet == true) return __HSK_30;

                Load_Everything();

                if (__HSK_30 == null) throw new Exception("??? somehow palpatine ... somehow populating the list failed");

                return __HSK_30;
            }
        }
        private static List<Rune>[] _HSK_31
        {
            get
            {
                if (has_Load_Everything_been_called_yet == true) return __HSK_31;

                Load_Everything();

                if (__HSK_31 == null) throw new Exception("??? somehow palpatine ... somehow populating the list failed");

                return __HSK_31;
            }
        }

        private static void Load_Everything()
        {
            (HSK_Version.__HSK_20, HSK_Version.__HSK_30, HSK_Version.__HSK_31) = HSK_Runeloader.Load();

            HSK_Version.has_Load_Everything_been_called_yet = true;
        }

        public List<Rune>[] Get_All_Levels_For_Version => this switch
        {
            _ when this == HSK_Version.HSK_2_0__From_2010 => HSK_Version._HSK_20,
            _ when this == HSK_Version.HSK_3_0__From_2021 => HSK_Version._HSK_30,
            _ when this == HSK_Version.HSK_3_1__From_2025 => HSK_Version._HSK_31,
            _ => throw new InvalidOperationException($"IMPOSSIBLE/ILLEGAL OPERATION : {this}")
        };
    }
}

/// Allowing each enum to return the list of the HSK Levels that he has.
namespace HSK_Versions_Final_Project
{
    public partial class HSK_Version : StringEnum<HSK_Version>
    {
        private static HSK_Level[] _HSK_2_0 =>
        [
            HSK_Level.HSK_Level_1,
            HSK_Level.HSK_Level_2,
            HSK_Level.HSK_Level_3,
            HSK_Level.HSK_Level_4,
            HSK_Level.HSK_Level_5,
            HSK_Level.HSK_Level_6
        ];
        private static HSK_Level[] _HSK_3_0_and_3_1 =>
        [
            HSK_Level.HSK_Level_1,
            HSK_Level.HSK_Level_2,
            HSK_Level.HSK_Level_3,
            HSK_Level.HSK_Level_4,
            HSK_Level.HSK_Level_5,
            HSK_Level.HSK_Level_6,
            HSK_Level.HSK_Level_7
        ];

        public HSK_Level[] HSK_Levels_for_this_version => this switch
        {
            _ when this == HSK_Version.HSK_2_0__From_2010 => HSK_Version._HSK_2_0,
            _ when this == HSK_Version.HSK_3_0__From_2021 => HSK_Version._HSK_3_0_and_3_1,
            _ when this == HSK_Version.HSK_3_1__From_2025 => HSK_Version._HSK_3_0_and_3_1,
            _ => throw new InvalidOperationException($"IMPOSSIBLE/ILLEGAL OPERATION : {this}")
        };
    }
}