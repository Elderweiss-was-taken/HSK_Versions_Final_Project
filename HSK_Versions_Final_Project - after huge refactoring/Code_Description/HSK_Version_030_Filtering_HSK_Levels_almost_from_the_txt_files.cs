using StrEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/// Getting a specific HSK level from a specific HSK version
namespace HSK_Versions_Final_Project
{
    public partial class HSK_Version : StringEnum<HSK_Version>
    {
        public List<Rune> this[HSK_Level index] => this switch
        {
            _ when this == HSK_Version.HSK_2_0__From_2010 => HSK_Version._HSK_20[(index == HSK_Level.HSK_Level_7 ? throw new Exception("HSK 2.0 only has up to HSK Level 6. There is no HSK Level 7 for HSK 2.0") : index)],
            _ when this == HSK_Version.HSK_3_0__From_2021 => HSK_Version._HSK_30[index],
            _ when this == HSK_Version.HSK_3_1__From_2025 => HSK_Version._HSK_31[index],
            _ => throw new InvalidOperationException($"IMPOSSIBLE/ILLEGAL OPERATION : {this}")
        };
    }
}