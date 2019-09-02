using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApplication6
{
    public static class FileHelper
    {
        private static readonly List<string> _filter = new List<string>()
        {
            "c0a",
            "c1a",
            "c2a",
            "c3a",
            "c4a",
            "c5a",
            "c6a",
            "c7a",
            "c8a",
            "c9a",
            "of0a",
            "of1a",
            "of2a",
            "of3a",
            "of4a",
            "of5a",
            "of6a",
            "of7a",
            "t0a",
            "t1a",
            "t2a",
            "t3a",
            "t4a",
            "t5a",
            "t6a",
            "t7a",
            "ofboot",
            "ctf",
            "hl2",
            "half-life 2"
        };

        /// <summary>
        /// Find Map Folders
        /// </summary>
        /// <param name="Path">Supply the path for the method to start looking in</param>
        /// <returns>IEnumerable of folders</returns>
        public static IEnumerable<string> FindMapFolders(string Path)
        {
            var tempDirs = Directory.EnumerateDirectories(Path).ToList();
            var mapFolders = new List<string>();
            do
            {
                var newDirs = new List<string>();
                foreach (var dir in tempDirs)
                {
                    var foundNewDirs = Directory.EnumerateDirectories(dir).ToList();
                    foreach (var fDir in foundNewDirs)
                    {
                        if (fDir.ToLower().Contains("maps") && !fDir.ToLower().Contains("hl2") && !fDir.ToLower().Contains("half-life 2"))
                        {
                            mapFolders.Add(fDir);
                        }
                        else
                        {
                            newDirs.Add(fDir);
                        }

                        //newDirs = Directory.EnumerateDirectories(dir).ToList();
                    }
                    tempDirs = newDirs;
                }


            } while (tempDirs.Count() > 0);


            return mapFolders;
        }

        public static IEnumerable<string> FindMapFiles(string mapFolder)
        {
            var maps = new List<string>();
            var tempfiles = Directory.EnumerateFiles(mapFolder);
            var filteredFiles = tempfiles.Where(x => x.EndsWith(".bsp") && !_filter.Any(x.Contains)).ToList();
            foreach (var tempFile in filteredFiles)
            {
                maps.Add(Path.GetFileNameWithoutExtension(tempFile));
                maps.Sort();
            }
            return maps;
        }

        /// <summary>
        /// Find Half-Life Maps
        /// </summary>
        /// <param name="serverMapPath">Path to maps folder</param>
        /// <param name="excludedMaps">List of maps to exclude</param>
        /// <returns>List of Maps</returns>
        public static List<string> FindMaps(string serverMapPath, List<string> excludedMaps)
        {
            var maps = FindMapFiles(serverMapPath);
            var filteredMaps = maps.Where(x => !excludedMaps.Any(x.Contains)).Distinct().ToList();
            return filteredMaps;
        }

        public static void CreateMapCycle(List<string> selectedMaps, string mapCyclePath)
        {
            var mapcycle = $"{mapCyclePath}\\mapcycle.txt";
            using (var file = new System.IO.StreamWriter(mapcycle))
            {
                foreach (var map in selectedMaps)
                {
                    file.WriteLine(map);
                }
            }

            CreateMessageOfTheDay(mapCyclePath, selectedMaps);
        }

        private static void CreateMessageOfTheDay(string motdPath, List<string> selectedMaps)
        {
            var motd = $"{motdPath}\\motd.txt";
            using (var file = new System.IO.StreamWriter(motd))
            {
                file.WriteLine("CREATED bY --> Grumpy <--");
                file.WriteLine("--------------------------");
                file.WriteLine("");
                file.WriteLine("Hello Peeps.......");
                file.WriteLine("");
                file.WriteLine("Go kick some BUTT!!!!!!");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("The Selected Maps Are :");
                file.WriteLine("");
                foreach (var map in selectedMaps)
                {
                    file.WriteLine(map);
                }
            }
        }

    }
}
