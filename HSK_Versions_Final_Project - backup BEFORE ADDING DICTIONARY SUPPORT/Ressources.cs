using StrEnum;
using System.Buffers;
using System.Reflection;
using System.Text;

namespace HSK_Versions_Final_Project
{
    public static class HSK_Runeloader
    {
        public static (List<Rune>[] HSK2_0, List<Rune>[] HSK3_0, List<Rune>[] HSK3_1) Load()
        {
            //LOCAL FUNCTIONS
            IEnumerable<List<Rune>> Load_Version(HSK_Version hsk_version, params HSK_Level[] hsk_levels_for_this_version)
            {
                for (var i = 0; i < hsk_levels_for_this_version.Length; i++)
                {
                    HSK_Level current_level_in_for_loop = hsk_levels_for_this_version[i];

                    yield return Load_Level_txt_file
                        (
                            hsk_version              ,
                            current_level_in_for_loop
                        );
                }
            }

            HSK_Version[] Get_Versions()
            {
                HSK_Version[] _hsk_versions = HSK_Version.GetMembers().ToArray();

                if (
                       _hsk_versions[(byte)HSK_Version_Index.HSK_2_0__From_2010] != HSK_Version.HSK_2_0__From_2010 ||
                       _hsk_versions[(byte)HSK_Version_Index.HSK_3_0__From_2021] != HSK_Version.HSK_3_0__From_2021 ||
                       _hsk_versions[(byte)HSK_Version_Index.HSK_3_1__From_2025] != HSK_Version.HSK_3_1__From_2025
                   )
                {
                    throw new InvalidOperationException("The String Enums must be written in chronological order. Fix your code.");
                }

                return _hsk_versions;
            }

            IEnumerable<List<Rune>[]> populate()
            {
                HSK_Version[] hsk_versions = Get_Versions();

                for (int i = 0; i < hsk_versions.Length; i++)
                {
                    HSK_Version current_version_in_for_loop = hsk_versions[i];

                    yield return Load_Version
                        (
                            current_version_in_for_loop                              ,

                            current_version_in_for_loop . HSK_Levels_for_this_version
                        ).ToArray();
                }
            }
            // START OF THE METHOD

            var return_value = populate().ToArray();

            return
                (
                    return_value[(byte)HSK_Version_Index.HSK_2_0__From_2010],
                    return_value[(byte)HSK_Version_Index.HSK_3_0__From_2021],
                    return_value[(byte)HSK_Version_Index.HSK_3_1__From_2025]
                );
        }

        private static List<Rune> Load_Level_txt_file(HSK_Version hsk_version, HSK_Level hsk_level)
        {
            string cook_ressource_name(Assembly _assembly, HSK_Version _hsk_version, HSK_Level _hsk_level)
            {
                //The ! :
                // is the null-forgiving operator. It tells the compiler :
                // “I know this value won’t be null at runtime, so don’t warn me about it.”

                string rootNamespace = _assembly.GetName().Name!;//Normally equal to HSK_Versions_Final_Project

                const string _HSK = "HSK";//MAGIC, trust the files respect this structure, otherwise it will break.

                string hsk_version_Text = (string)_hsk_version;
                string hsk_level_Text   = (string)_hsk_level  ;

                string fileName   = $"{_HSK}{hsk_version_Text}_chars_level{hsk_level_Text}.txt";//MAGIC, trust the files respect this structure, otherwise it will break.
                string folderName = $"{_HSK}{Normalize_Version_For_Resource(hsk_version_Text)}";

                return $"{rootNamespace}.{folderName}.{fileName}";

                string Normalize_Version_For_Resource(string string_to_edit)
                {
                    // Local helper:
                    // When a folder name contains a dot (e.g. "HSK2.0"),
                    // the C# compiler interprets it as a namespace split:
                    //   "HSK2.0" → ["HSK2", "0"]
                    // Then it fixes invalid identifiers:
                    //   "0" is not a valid identifier → becomes "_0"
                    // Final embedded resource segment:
                    //   "HSK2._0"
                    //
                    // To match the actual embedded resource name, we mimic this behavior
                    // by replacing "." with "._"
                    //
                    // ⚠️ This is NOT a general solution—it's a targeted fix based on how
                    // the compiler transforms numeric namespace segments.

                    return string_to_edit.Replace(".", "._");
                }
            }

            Assembly assembly = Assembly.GetExecutingAssembly();

            string resourceName = cook_ressource_name(assembly, hsk_version, hsk_level);

            using Stream stream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new FileNotFoundException($"Embedded resource not found: {resourceName}");

            using var reader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);

            List<Rune> result = [];

            while (true)
            {
                string? line = reader.ReadLine();
                // ReadLine() returns null when the end of the stream is reached, so exit the loop.
                if (line is null)
                    break;

                if (line.Length == 0)
                {
                    // Peek() returns -1 when there are no more characters to read (end-of-file).
                    // Here, it allows a final empty line only if it is immediately followed by EOF.
                    if (reader.Peek() == -1)
                        break;

                    throw new InvalidOperationException($"Empty line found inside resource: {resourceName}");
                }

                int runeCount = 0;
                foreach (Rune _ in line.EnumerateRunes())
                {
                    runeCount++;
                    if (runeCount > 1)
                        break;
                }

                if (runeCount < 1)
                    throw new InvalidOperationException($"Line contained zero characters in resource: {resourceName}");

                if (runeCount > 1) // A chinese word, for example. This method should never be called to treat word files, but only character files.
                    throw new InvalidOperationException($"Line contained more than one character in resource: {resourceName}. Line: '{line}'");

                result.Add(Rune.GetRuneAt(line, 0));
            }

            return result;
        }
    }
}