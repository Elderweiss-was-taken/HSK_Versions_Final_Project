using StrEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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