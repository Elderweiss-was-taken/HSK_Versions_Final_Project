using StrEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HSK_Versions_Final_Project
{
    public static partial class HSK
    {
        public class Custom_object
        {
            public Rune Character { get; init; }
            public (HSK_Version hsk_version, HSK_Level hsk_level)?[] HSK_details { get; init; }

            public HSK_Presence__or_HSK_Version_change HSK_presence { get; init; }

            private bool _levelHistoryByVersionInitialized;
            private (HSK_Level? V20, HSK_Level? V30, HSK_Level? V31) _levelHistoryByVersion;
            private List<HSK_Level>? _levelHistoryTimeline;

            public (HSK_Level? V20, HSK_Level? V30, HSK_Level? V31) LevelHistoryByVersion
            {
                get
                {
                    EnsureLevelHistoryByVersionPopulated();
                    return _levelHistoryByVersion;
                }
            }

            public IReadOnlyList<HSK_Level> LevelHistoryTimeline
            {
                get
                {
                    EnsureLevelHistoryByVersionPopulated();
                    return _levelHistoryTimeline!;
                }
            }

            public bool Has_Multiple_HSK_Levels
            {
                get
                {
                    EnsureLevelHistoryByVersionPopulated();
                    ClassifyLevelHistoryTimeline(_levelHistoryTimeline!, out var hasMultiple, out _);
                    return hasMultiple;
                }
            }

            public bool Has_Single_HSK_Level
            {
                get
                {
                    EnsureLevelHistoryByVersionPopulated();
                    ClassifyLevelHistoryTimeline(_levelHistoryTimeline!, out _, out var hasSingle);
                    return hasSingle;
                }
            }

            private static void ClassifyLevelHistoryTimeline(IReadOnlyList<HSK_Level> timeline, out bool hasMultiple, out bool hasSingle)
            {
                var first = timeline[0];
                if (timeline.Count == 1)
                {
                    hasMultiple = false;
                    hasSingle = true;
                    return;
                }

                for (var i = 1; i < timeline.Count; i++)
                {
                    if (timeline[i] != first)
                    {
                        hasMultiple = true;
                        hasSingle = false;
                        return;
                    }
                }

                hasMultiple = false;
                hasSingle = true;
            }

            internal void EnsureLevelHistoryByVersionPopulated()
            {
                if (_levelHistoryByVersionInitialized)
                    return;

                var d = HSK_details;
                _levelHistoryByVersion = (
                    d[0]?.hsk_level,
                    d[1]?.hsk_level,
                    d[2]?.hsk_level);

#if DEBUG
                if (d[0] is { hsk_version: var hv0 } && hv0 != HSK_Version.HSK_2_0__From_2010)
                    throw new InvalidOperationException("HSK_details[0] must refer to HSK 2.0.");
                if (d[1] is { hsk_version: var hv1 } && hv1 != HSK_Version.HSK_3_0__From_2021)
                    throw new InvalidOperationException("HSK_details[1] must refer to HSK 3.0.");
                if (d[2] is { hsk_version: var hv2 } && hv2 != HSK_Version.HSK_3_1__From_2025)
                    throw new InvalidOperationException("HSK_details[2] must refer to HSK 3.1.");
#endif

                var timeline = new List<HSK_Level>(3);
                if (d[0] is { } t0) timeline.Add(t0.hsk_level);
                if (d[1] is { } t1) timeline.Add(t1.hsk_level);
                if (d[2] is { } t2) timeline.Add(t2.hsk_level);
                _levelHistoryTimeline = timeline;

                if (timeline.Count == 0)
                    throw new InvalidOperationException(
                        $"This character is absent from all HSK versions (all three HSK_details slots are null). Character (rune): {Character}.");

                _levelHistoryByVersionInitialized = true;
            }

            public Custom_object(Rune rune, HSK_Presence__or_HSK_Version_change hsk_presence, (HSK_Version hsk_version, HSK_Level hsk_level)?[] HSK_details)
            {
                if (HSK_details.Count() != 3) throw new Exception("must be 3");

                this.Character = rune;
                this.HSK_details = HSK_details;
                this.HSK_presence = hsk_presence;
            }
        }
    }
}