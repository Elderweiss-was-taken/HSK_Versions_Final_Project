using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HSK_Versions_Final_Project
{
    
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            _ = HSK.Everything_As_Dictionary_final;
            _ = HSK_Presence__or_HSK_Version_change._111__Present_in_all_versions                                .Give_All_Characters;
            _ = HSK_Presence__or_HSK_Version_change._110__Removed_in_HSK3_1__Present_in_HSK2_0_and_HSK3_0        .Give_All_Characters;
            _ = HSK_Presence__or_HSK_Version_change._101__Removed_in_HSK3_0__Put_back_in_HSK3_1                  .Give_All_Characters;
            _ = HSK_Presence__or_HSK_Version_change._100__HSK2_0_Exclusive___Never_added_back_later              .Give_All_Characters;
            _ = HSK_Presence__or_HSK_Version_change._011__NEW_CHAR___________Absent_in_HSK2_0__Added_since_HSK3_0.Give_All_Characters;
            _ = HSK_Presence__or_HSK_Version_change._010__HSK3_0_Exclusive___Never_added_back_later              .Give_All_Characters;
            _ = HSK_Presence__or_HSK_Version_change._001__NEW_CHAR___________HSK3_1_Exclusive                    .Give_All_Characters;
            Console.Write(HSK.Show_counts);

            _ = 55;
        }
    }
}