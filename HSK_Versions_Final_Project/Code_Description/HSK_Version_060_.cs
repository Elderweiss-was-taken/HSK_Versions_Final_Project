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
                            int tmp2 = _All_Characters_accross_all_levels_for_HSK20.Count();

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