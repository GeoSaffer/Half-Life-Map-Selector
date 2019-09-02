namespace WindowsFormsApplication6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnReloadMaps = new System.Windows.Forms.Button();
            this.btnCreateMapCycle = new System.Windows.Forms.Button();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.SelectedListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FullListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FullListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.excludeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcludeListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExcludeListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.includeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectedListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FullListContextMenu.SuspendLayout();
            this.ExcludeListContextMenu.SuspendLayout();
            this.SelectedListContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReloadMaps
            // 
            this.btnReloadMaps.Location = new System.Drawing.Point(13, 13);
            this.btnReloadMaps.Name = "btnReloadMaps";
            this.btnReloadMaps.Size = new System.Drawing.Size(75, 23);
            this.btnReloadMaps.TabIndex = 0;
            this.btnReloadMaps.Text = "ReLoad Maps";
            this.btnReloadMaps.UseVisualStyleBackColor = true;
            this.btnReloadMaps.Click += new System.EventHandler(this.btnReloadMaps_Click);
            // 
            // btnCreateMapCycle
            // 
            this.btnCreateMapCycle.Location = new System.Drawing.Point(490, 466);
            this.btnCreateMapCycle.Name = "btnCreateMapCycle";
            this.btnCreateMapCycle.Size = new System.Drawing.Size(123, 23);
            this.btnCreateMapCycle.TabIndex = 5;
            this.btnCreateMapCycle.Text = "Create MapCycle";
            this.btnCreateMapCycle.UseVisualStyleBackColor = true;
            this.btnCreateMapCycle.Click += new System.EventHandler(this.btnCreateMapCycle_Click);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(296, 175);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(30, 34);
            this.btnAddToList.TabIndex = 6;
            this.btnAddToList.Text = " >>";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // SelectedListView
            // 
            this.SelectedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.SelectedListView.FullRowSelect = true;
            this.SelectedListView.GridLines = true;
            this.SelectedListView.Location = new System.Drawing.Point(359, 58);
            this.SelectedListView.Name = "SelectedListView";
            this.SelectedListView.Size = new System.Drawing.Size(254, 262);
            this.SelectedListView.TabIndex = 7;
            this.SelectedListView.UseCompatibleStateImageBehavior = false;
            this.SelectedListView.View = System.Windows.Forms.View.Details;
            this.SelectedListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SelectedListView_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Maps Selected for Game";
            this.columnHeader1.Width = 245;
            // 
            // FullListView
            // 
            this.FullListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.FullListView.ContextMenuStrip = this.FullListContextMenu;
            this.FullListView.FullRowSelect = true;
            this.FullListView.GridLines = true;
            this.FullListView.Location = new System.Drawing.Point(13, 58);
            this.FullListView.Name = "FullListView";
            this.FullListView.Size = new System.Drawing.Size(254, 262);
            this.FullListView.TabIndex = 8;
            this.FullListView.UseCompatibleStateImageBehavior = false;
            this.FullListView.View = System.Windows.Forms.View.Details;
            this.FullListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FullListView_MouseClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Available Maps";
            this.columnHeader2.Width = 245;
            // 
            // FullListContextMenu
            // 
            this.FullListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excludeToolStripMenuItem});
            this.FullListContextMenu.Name = "contextMenuStrip1";
            this.FullListContextMenu.Size = new System.Drawing.Size(115, 26);
            // 
            // excludeToolStripMenuItem
            // 
            this.excludeToolStripMenuItem.Name = "excludeToolStripMenuItem";
            this.excludeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.excludeToolStripMenuItem.Text = "Exclude";
            this.excludeToolStripMenuItem.Click += new System.EventHandler(this.excludeToolStripMenuItem_Click);
            // 
            // ExcludeListView
            // 
            this.ExcludeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.ExcludeListView.ContextMenuStrip = this.ExcludeListContextMenu;
            this.ExcludeListView.FullRowSelect = true;
            this.ExcludeListView.GridLines = true;
            this.ExcludeListView.Location = new System.Drawing.Point(13, 326);
            this.ExcludeListView.Name = "ExcludeListView";
            this.ExcludeListView.Size = new System.Drawing.Size(600, 134);
            this.ExcludeListView.TabIndex = 9;
            this.ExcludeListView.UseCompatibleStateImageBehavior = false;
            this.ExcludeListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Excluded Maps";
            this.columnHeader3.Width = 255;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Reason";
            this.columnHeader4.Width = 404;
            // 
            // ExcludeListContextMenu
            // 
            this.ExcludeListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeToolStripMenuItem});
            this.ExcludeListContextMenu.Name = "contextMenuStrip1";
            this.ExcludeListContextMenu.Size = new System.Drawing.Size(114, 26);
            // 
            // includeToolStripMenuItem
            // 
            this.includeToolStripMenuItem.Name = "includeToolStripMenuItem";
            this.includeToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.includeToolStripMenuItem.Text = "Include";
            this.includeToolStripMenuItem.Click += new System.EventHandler(this.includeToolStripMenuItem_Click);
            // 
            // SelectedListContextMenu
            // 
            this.SelectedListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.toolStripSeparator1,
            this.removeToolStripMenuItem});
            this.SelectedListContextMenu.Name = "SelectedListContextMenu";
            this.SelectedListContextMenu.Size = new System.Drawing.Size(118, 54);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.clearToolStripMenuItem.Text = " Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 503);
            this.Controls.Add(this.ExcludeListView);
            this.Controls.Add(this.FullListView);
            this.Controls.Add(this.SelectedListView);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.btnCreateMapCycle);
            this.Controls.Add(this.btnReloadMaps);
            this.Name = "Form1";
            this.Text = "Half-Life Multi Player Map Selector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ClientSizeChanged += new System.EventHandler(this.Form1_ClientSizeChanged);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.FullListContextMenu.ResumeLayout(false);
            this.ExcludeListContextMenu.ResumeLayout(false);
            this.SelectedListContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReloadMaps;
        private System.Windows.Forms.Button btnCreateMapCycle;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.ListView SelectedListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView FullListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView ExcludeListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip FullListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem excludeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ExcludeListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem includeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip SelectedListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}

