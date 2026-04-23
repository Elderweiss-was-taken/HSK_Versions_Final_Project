using StrEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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