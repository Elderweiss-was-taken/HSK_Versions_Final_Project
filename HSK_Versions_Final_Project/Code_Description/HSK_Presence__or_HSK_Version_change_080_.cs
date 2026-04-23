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
        private static Dictionary<Rune, HSK.Custom_object> _111;
        private static Dictionary<Rune, HSK.Custom_object> _110;
        private static Dictionary<Rune, HSK.Custom_object> _101;
        private static Dictionary<Rune, HSK.Custom_object> _100;
        private static Dictionary<Rune, HSK.Custom_object> _011;
        private static Dictionary<Rune, HSK.Custom_object> _010;
        private static Dictionary<Rune, HSK.Custom_object> _001;

        public Dictionary<Rune, HSK.Custom_object> Give_All_Characters_LevelChange
        {
            get
            {
                _ = HSK_Presence__or_HSK_Version_change._111__Present_in_all_versions.Give_All_Characters;

                if (_111 == null || _110 == null || _101 == null || _100 == null || _011 == null || _010 == null || _001 == null) throw new Exception("");

                return this switch
                {
                    _ when this == HSK_Presence__or_HSK_Version_change._111__Present_in_all_versions => _111.WhereHasMultipleHskLevels(),
                    _ when this == HSK_Presence__or_HSK_Version_change._110__Removed_in_HSK3_1__Present_in_HSK2_0_and_HSK3_0 => _110.WhereHasMultipleHskLevels(),
                    _ when this == HSK_Presence__or_HSK_Version_change._101__Removed_in_HSK3_0__Put_back_in_HSK3_1 => _101.WhereHasMultipleHskLevels(),
                    _ when this == HSK_Presence__or_HSK_Version_change._100__HSK2_0_Exclusive___Never_added_back_later => _100.WhereHasMultipleHskLevels(),
                    _ when this == HSK_Presence__or_HSK_Version_change._011__NEW_CHAR___________Absent_in_HSK2_0__Added_since_HSK3_0 => _011.WhereHasMultipleHskLevels(),
                    _ when this == HSK_Presence__or_HSK_Version_change._010__HSK3_0_Exclusive___Never_added_back_later => _010.WhereHasMultipleHskLevels(),
                    _ when this == HSK_Presence__or_HSK_Version_change._001__NEW_CHAR___________HSK3_1_Exclusive => _001.WhereHasMultipleHskLevels(),
                    _ => throw new Exception("code better")
                };
            }
        }
        public Dictionary<Rune, HSK.Custom_object> Give_All_Characters_NoLevelChange
        {
            get
            {
                _ = HSK_Presence__or_HSK_Version_change._111__Present_in_all_versions.Give_All_Characters;

                if (_111 == null || _110 == null || _101 == null || _100 == null || _011 == null || _010 == null || _001 == null) throw new Exception("");

                return this switch
                {
                    _ when this == HSK_Presence__or_HSK_Version_change._111__Present_in_all_versions => _111.WhereHasSingleHskLevel(),
                    _ when this == HSK_Presence__or_HSK_Version_change._110__Removed_in_HSK3_1__Present_in_HSK2_0_and_HSK3_0 => _110.WhereHasSingleHskLevel(),
                    _ when this == HSK_Presence__or_HSK_Version_change._101__Removed_in_HSK3_0__Put_back_in_HSK3_1 => _101.WhereHasSingleHskLevel(),
                    _ when this == HSK_Presence__or_HSK_Version_change._100__HSK2_0_Exclusive___Never_added_back_later => _100.WhereHasSingleHskLevel(),
                    _ when this == HSK_Presence__or_HSK_Version_change._011__NEW_CHAR___________Absent_in_HSK2_0__Added_since_HSK3_0 => _011.WhereHasSingleHskLevel(),
                    _ when this == HSK_Presence__or_HSK_Version_change._010__HSK3_0_Exclusive___Never_added_back_later => _010.WhereHasSingleHskLevel(),
                    _ when this == HSK_Presence__or_HSK_Version_change._001__NEW_CHAR___________HSK3_1_Exclusive => _001.WhereHasSingleHskLevel(),
                    _ => throw new Exception("code better")
                };
            }
        }
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
                        item.Value.EnsureLevelHistoryByVersionPopulated();

                        switch (item.Value.HSK_presence)
                        {
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._111__Present_in_all_versions:
                                _111.Add(item.Key, item.Value);
                                break;
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._110__Removed_in_HSK3_1__Present_in_HSK2_0_and_HSK3_0:
                                _110.Add(item.Key, item.Value);
                                break;
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._101__Removed_in_HSK3_0__Put_back_in_HSK3_1:
                                _101.Add(item.Key, item.Value);
                                break;
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._100__HSK2_0_Exclusive___Never_added_back_later:
                                _100.Add(item.Key, item.Value);
                                break;
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._011__NEW_CHAR___________Absent_in_HSK2_0__Added_since_HSK3_0:
                                _011.Add(item.Key, item.Value);
                                break;
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._010__HSK3_0_Exclusive___Never_added_back_later:
                                _010.Add(item.Key, item.Value);
                                break;
                            case { } when item.Value.HSK_presence == HSK_Presence__or_HSK_Version_change._001__NEW_CHAR___________HSK3_1_Exclusive:
                                _001.Add(item.Key, item.Value);
                                break;
                        }
                    }
                }

                return this switch
                {
                    _ when this == HSK_Presence__or_HSK_Version_change._111__Present_in_all_versions => _111,
                    _ when this == HSK_Presence__or_HSK_Version_change._110__Removed_in_HSK3_1__Present_in_HSK2_0_and_HSK3_0 => _110,
                    _ when this == HSK_Presence__or_HSK_Version_change._101__Removed_in_HSK3_0__Put_back_in_HSK3_1 => _101,
                    _ when this == HSK_Presence__or_HSK_Version_change._100__HSK2_0_Exclusive___Never_added_back_later => _100,
                    _ when this == HSK_Presence__or_HSK_Version_change._011__NEW_CHAR___________Absent_in_HSK2_0__Added_since_HSK3_0 => _011,
                    _ when this == HSK_Presence__or_HSK_Version_change._010__HSK3_0_Exclusive___Never_added_back_later => _010,
                    _ when this == HSK_Presence__or_HSK_Version_change._001__NEW_CHAR___________HSK3_1_Exclusive => _001,
                    _ => throw new Exception("code better")
                };
            }
        }
    }
}