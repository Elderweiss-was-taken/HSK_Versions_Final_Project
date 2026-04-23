using StrEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

/// Presence enums
namespace HSK_Versions_Final_Project
{
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
    }
}

/// Versions enums
namespace HSK_Versions_Final_Project
{
    public partial class HSK_Version : StringEnum<HSK_Version>
    {
        public static readonly HSK_Version HSK_2_0__From_2010 = Define("2.0");
        public static readonly HSK_Version HSK_3_0__From_2021 = Define("3.0");
        public static readonly HSK_Version HSK_3_1__From_2025 = Define("3.1");
    }
    public enum HSK_Version_Index : byte
    {
        HSK_2_0__From_2010 = 0,
        HSK_3_0__From_2021 = 1,
        HSK_3_1__From_2025 = 2
    }
}

/// Levels enums
namespace HSK_Versions_Final_Project
{
    public class HSK_Level : StringEnum<HSK_Level>
    {
        public static readonly HSK_Level HSK_Level_1 = Define("1");
        public static readonly HSK_Level HSK_Level_2 = Define("2");
        public static readonly HSK_Level HSK_Level_3 = Define("3");
        public static readonly HSK_Level HSK_Level_4 = Define("4");
        public static readonly HSK_Level HSK_Level_5 = Define("5");
        public static readonly HSK_Level HSK_Level_6 = Define("6");
        public static readonly HSK_Level HSK_Level_7 = Define("7-9");

        public static implicit operator byte(HSK_Level hsk_level) => hsk_level switch
        {
            _ when hsk_level == HSK_Level.HSK_Level_1 => (byte)HSK_Level_Index.HSK_Level_1,
            _ when hsk_level == HSK_Level.HSK_Level_2 => (byte)HSK_Level_Index.HSK_Level_2,
            _ when hsk_level == HSK_Level.HSK_Level_3 => (byte)HSK_Level_Index.HSK_Level_3,
            _ when hsk_level == HSK_Level.HSK_Level_4 => (byte)HSK_Level_Index.HSK_Level_4,
            _ when hsk_level == HSK_Level.HSK_Level_5 => (byte)HSK_Level_Index.HSK_Level_5,
            _ when hsk_level == HSK_Level.HSK_Level_6 => (byte)HSK_Level_Index.HSK_Level_6,
            _ when hsk_level == HSK_Level.HSK_Level_7 => (byte)HSK_Level_Index.HSK_Level_7,
            _ => throw new InvalidOperationException($"IMPOSSIBLE/ILLEGAL OPERATION : {hsk_level}")
        };
    }

    /// <summary>
    /// 
    /// Safe to use because the order is guaranteed by `HSK_Version.HSK_Levels_for_this_version`,
    /// 
    /// more specifically the private members `HSK_Version._HSK_2_0` and `HSK_Version._HSK_3_0_and_3_1`
    /// 
    /// </summary>
    public enum HSK_Level_Index : byte
    {
        HSK_Level_1 = 0,
        HSK_Level_2 = 1,
        HSK_Level_3 = 2,
        HSK_Level_4 = 3,
        HSK_Level_5 = 4,
        HSK_Level_6 = 5,
        HSK_Level_7 = 6
    }
}