using StrEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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