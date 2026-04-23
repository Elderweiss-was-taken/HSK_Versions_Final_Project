using StrEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/// Populating the 3 HSK Versions with all the HSK Levels (   with List<Rune>[]   )
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