using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        public string Game => $"valve";//gearbox    //valve     //cstrike

        public string PFx86 => Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        public string DedicatedServerFolder => $@"{PFx86}\Valve\Half-Life";
        public string DedicatedServerMapCyclePath => $@"{DedicatedServerFolder}\{Game}";
        //public string DedicatedServerFolder => $"{PFx86}\\servers\\gameserver";
        // public string DedicatedServerMapCyclePath => $"{PFx86}\\servers\\gameserver\\{Game}";

        public string SteamFolder => $"D:\\SteamLibrary";
        public string SteamMapCyclePath => $"D:\\SteamLibrary\\steamapps\\common\\Half-Life\\{Game}";

        #region Exclude Filters
        private readonly List<string> _filter = new List<string>()
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


        public List<string> ExcludeFilter
        {
            get
            {
                var list = Settings.Default.ExcludedMaps.Split(',').ToList().Where(x => x != string.Empty).ToList();
                return list;
            }

            set
            {
                var xFilter = value.Aggregate((current, item) => $"{current},{item}");
                Settings.Default.ExcludedMaps = xFilter;
                Settings.Default.Save();
            }
        
        }

        #endregion

        public List<string> LastSelectedMaps
        {
            get
            {
                var list = Settings.Default.SelectedMaps.Split(',').ToList().Where(x => x != string.Empty).ToList();
                return list;
            }

            set
            {
                var xFilter = value.Aggregate((current, item) => $"{current},{item}");
                Settings.Default.SelectedMaps = xFilter;
                Settings.Default.Save();
            }

        }



        public Form1()
        {
            InitializeComponent();
        }

        private void FullListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
//            var items = FullListBox.SelectedItems;
//            SelectedListBox.Items.Clear();
//            foreach (var item in items)
//            {
//                SelectedListBox.Items.Add(item);
//            }
        }

        /// <summary>
        /// Find Map Folders
        /// </summary>
        /// <param name="Path">Supply the path for the method to start looking in</param>
        /// <returns>IEnumerable of folders</returns>
        private IEnumerable<string> FindMapFolders(string Path)
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

        private IEnumerable<string> FindMapFiles(IEnumerable<string> mapFolders)
        {
            var maps = new List<string>();
            foreach (var folder in mapFolders)
            {
                var tempfiles = Directory.EnumerateFiles(folder);

                var filteredFiles = tempfiles.Where(x => x.EndsWith(".bsp") && !_filter.Any(x.Contains)).ToList();



                foreach (var tempFile in filteredFiles)
                {
                    maps.Add(Path.GetFileNameWithoutExtension(tempFile));
                    maps.Sort();
                }
               // break;
            }


            //path get file name

            return maps;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FindMaps();
            LoadExcludedMaps();
        }

        private void btnReloadMaps_Click(object sender, EventArgs e)
        {
            ReLoadFullList();
        }

        private void ReLoadFullList()
        {
            FullListView.Items.Clear();
            FindMaps();
            LoadExcludedMaps();
            LoadLastSelectedMaps();
        }

        private void FindMaps()
        {
            var mapfolders = FindMapFolders(DedicatedServerFolder).ToList();
            mapfolders.AddRange(FindMapFolders(DedicatedServerFolder));

            var maps = FindMapFiles(mapfolders);

            var filteredMaps = maps.Where(x => !ExcludeFilter.Any(x.Contains));

            foreach (var map in filteredMaps.Distinct())
            {
                FullListView.Items.Add(map);
            }

           

        }

        private void LoadExcludedMaps()
        {
            if (ExcludeFilter.Count > 0)
            {
                foreach (var map in ExcludeFilter)
                {
                    ExcludeListView.Items.Add(map);
                }
            }
        }

        private void LoadLastSelectedMaps()
        {
            if (LastSelectedMaps.Count > 0)
            {
                foreach (var map in LastSelectedMaps)
                {
                    SelectedListView.Items.Add(map);
                }
            }
        }




        private void CreateMapCycle(List<string> selectedMaps, string mapCyclePath)
        {
            var mapcycle = $"{mapCyclePath}\\mapcycle.txt";
            using (var file = new System.IO.StreamWriter(mapcycle))
            {
                foreach (var map in selectedMaps)
                {
                    file.WriteLine(map);
                }
            }

            var motd = $"{mapCyclePath}\\motd.txt";
            using (var file = new System.IO.StreamWriter(motd))
            {
                file.WriteLine("CREATED bY --> The Grumpy Map Cycler<--");
                file.WriteLine("--------------------------");
                file.WriteLine("");
                file.WriteLine("Hello  TIM,  Hello Dillon.");
                file.WriteLine("");
                file.WriteLine("WHo's gonna KICK your BUTT!!!!!!");
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

        private void btnCreateMapCycle_Click(object sender, EventArgs e)
        {
            var selectedMaps = new List<string>();
            for (int i = 0; i < SelectedListView.Items.Count; i++)
            {
                selectedMaps.Add(SelectedListView.Items[i].Text);
            }
            CreateMapCycle(selectedMaps, DedicatedServerMapCyclePath);
          //  CreateMapCycle(selectedMaps, SteamMapCyclePath);
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            var items = FullListView.SelectedItems;
            SelectedListView.Items.Clear();
            for (int i = 0; i < items.Count ; i++)
            {
                SelectedListView.Items.Add(items[i].Text);
            }

           
        }

        private void FullListView_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
            {
                FullListContextMenu.Show(FullListView, new Point(e.X,e.Y));
            }
        }

        private void excludeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = FullListView.SelectedItems.Count;
            var newList = new List<string>();
            for (var i = 0; i < items; i++)
            {
                ExcludeListView.Items.Add(FullListView.SelectedItems[i].Text);
                newList.Add( FullListView.SelectedItems[i].Text);
            }
            ExcludeFilter = newList;

            ReLoadFullList();
        }

        private void includeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = ExcludeListView.SelectedItems.Count;

            for (var i = 0; i < items; i++)
            {
                ExcludeListView.Items.Remove(FullListView.SelectedItems[0]);
            }
            ReLoadFullList();
        }
    }
}
