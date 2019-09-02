using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        public string GameMode => $"valve";//gearbox    //valve     //cstrike

        public string PFx86 => Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

        public string DedicatedServerFolder => $@"{PFx86}\Valve\Half-Life";

        public string DedicatedServerGameModePath => $@"{DedicatedServerFolder}\{GameMode}";

        public string DedicatedServerMapPath => $@"{DedicatedServerFolder}\{GameMode}\maps";

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
            setPositions();
        }

        public static List<string> ExcludeFilter
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
        private void RemoveFromExclusionList(string item)
        {
            Settings.Default.ExcludedMaps = Settings.Default.ExcludedMaps.Replace(item,"").Replace(",,",",");
            Settings.Default.Save();
        }

        private void AddToExclusionFiler(string item)
        {
            Settings.Default.ExcludedMaps += string.IsNullOrEmpty(Settings.Default.ExcludedMaps) ? item : $",{item}";
            Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var map in FileHelper.FindMaps(DedicatedServerMapPath, ExcludeFilter))
            {
                FullListView.Items.Add(map);
            }
            LoadExcludedMaps();
            setPositions();
        }

        private void btnReloadMaps_Click(object sender, EventArgs e)
        {
            LoadExcludedMaps();
            ReLoadFullList();
        }

        private void ReLoadFullList()
        {
            FullListView.Items.Clear();
            foreach (var map in FileHelper.FindMaps(DedicatedServerMapPath, ExcludeFilter))
            {
                FullListView.Items.Add(map);
            }
            LoadLastSelectedMaps();
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

        private void LoadExcludedMaps()
        {
            ExcludeListView.Items.Clear();
            if (ExcludeFilter.Count > 0)
            {
                foreach (var item in ExcludeFilter)
                {
                    ExcludeListView.Items.Add(item);
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
            FileHelper.CreateMapCycle(selectedMaps, DedicatedServerGameModePath);
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            var items = FullListView.SelectedItems;
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
            foreach (ListViewItem selectedItem in FullListView.SelectedItems)
            {
                AddToExclusionFiler(selectedItem.Text);
            }
            LoadExcludedMaps();
            ReLoadFullList();
        }

        private void includeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in ExcludeListView.SelectedItems)
            {
                RemoveFromExclusionList(selectedItem.Text);
            }
            LoadExcludedMaps();
            ReLoadFullList();
        }

        private void setPositions()
        {
            FullListView.Top = 100;
            FullListView.Left = 10;
            FullListView.Width = (int)(((double)this.Width) / 2.4);
            FullListView.Height = ExcludeListView.Top - FullListView.Top - 10;
            SelectedListView.Top = FullListView.Top;
            SelectedListView.Width = FullListView.Width;
            SelectedListView.Left = this.Width - (SelectedListView.Width + 27);
            SelectedListView.Height = FullListView.Height;
            btnAddToList.Left = FullListView.Right + ((SelectedListView.Left - FullListView.Right) / 2) - (btnAddToList.Width / 2);
            btnAddToList.Top = (FullListView.Top + (FullListView.Height / 2)) - (btnAddToList.Height / 2);
            ExcludeListView.Top = this.Height - 80 - ExcludeListView.Height;
            ExcludeListView.Left = FullListView.Left;
            ExcludeListView.Width = this.Width - 37;
            ExcludeListView.Height = this.Height / 5;
            btnCreateMapCycle.Top = ExcludeListView.Bottom + 10;
            btnCreateMapCycle.Left = ExcludeListView.Right - btnCreateMapCycle.Width;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            setPositions();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            setPositions();
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            setPositions();
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedListView.Items.Clear();
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in SelectedListView.SelectedItems)
            {
                SelectedListView.Items.Remove(item);
            }
        }

        private void SelectedListView_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0)
            {
                SelectedListContextMenu.Show(SelectedListView, new Point(e.X, e.Y));
            }
        }


    }
}
