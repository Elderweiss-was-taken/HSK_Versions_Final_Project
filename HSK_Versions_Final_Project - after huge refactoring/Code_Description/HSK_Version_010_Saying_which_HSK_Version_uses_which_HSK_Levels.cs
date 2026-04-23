using StrEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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