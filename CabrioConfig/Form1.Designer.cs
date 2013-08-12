﻿namespace CabrioConfig
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tabPaths = new System.Windows.Forms.TabPage();
            this.btnSnapBrowse = new System.Windows.Forms.Button();
            this.btnROMSBrowse = new System.Windows.Forms.Button();
            this.btnMAMEBrowse = new System.Windows.Forms.Button();
            this.txtSnapsPath = new System.Windows.Forms.TextBox();
            this.txtROMSPath = new System.Windows.Forms.TextBox();
            this.txtMAMEPath = new System.Windows.Forms.TextBox();
            this.lblSnapsPath = new System.Windows.Forms.Label();
            this.lblROMSPath = new System.Windows.Forms.Label();
            this.lblMAMEPath = new System.Windows.Forms.Label();
            this.tabGames = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLookup = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.TabControl1.SuspendLayout();
            this.tabPaths.SuspendLayout();
            this.tabGames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tabPaths);
            this.TabControl1.Controls.Add(this.tabGames);
            this.TabControl1.Location = new System.Drawing.Point(0, 52);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(546, 211);
            this.TabControl1.TabIndex = 0;
            // 
            // tabPaths
            // 
            this.tabPaths.Controls.Add(this.btnSnapBrowse);
            this.tabPaths.Controls.Add(this.btnROMSBrowse);
            this.tabPaths.Controls.Add(this.btnMAMEBrowse);
            this.tabPaths.Controls.Add(this.txtSnapsPath);
            this.tabPaths.Controls.Add(this.txtROMSPath);
            this.tabPaths.Controls.Add(this.txtMAMEPath);
            this.tabPaths.Controls.Add(this.lblSnapsPath);
            this.tabPaths.Controls.Add(this.lblROMSPath);
            this.tabPaths.Controls.Add(this.lblMAMEPath);
            this.tabPaths.Location = new System.Drawing.Point(4, 22);
            this.tabPaths.Name = "tabPaths";
            this.tabPaths.Padding = new System.Windows.Forms.Padding(3);
            this.tabPaths.Size = new System.Drawing.Size(538, 185);
            this.tabPaths.TabIndex = 0;
            this.tabPaths.Text = "Paths";
            this.tabPaths.UseVisualStyleBackColor = true;
            // 
            // btnSnapBrowse
            // 
            this.btnSnapBrowse.Location = new System.Drawing.Point(455, 107);
            this.btnSnapBrowse.Name = "btnSnapBrowse";
            this.btnSnapBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSnapBrowse.TabIndex = 8;
            this.btnSnapBrowse.Text = "...";
            this.btnSnapBrowse.UseVisualStyleBackColor = true;
            this.btnSnapBrowse.Click += new System.EventHandler(this.btnSnapBrowse_Click);
            // 
            // btnROMSBrowse
            // 
            this.btnROMSBrowse.Location = new System.Drawing.Point(455, 76);
            this.btnROMSBrowse.Name = "btnROMSBrowse";
            this.btnROMSBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnROMSBrowse.TabIndex = 7;
            this.btnROMSBrowse.Text = "...";
            this.btnROMSBrowse.UseVisualStyleBackColor = true;
            this.btnROMSBrowse.Click += new System.EventHandler(this.btnROMSBrowse_Click);
            // 
            // btnMAMEBrowse
            // 
            this.btnMAMEBrowse.Location = new System.Drawing.Point(455, 39);
            this.btnMAMEBrowse.Name = "btnMAMEBrowse";
            this.btnMAMEBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnMAMEBrowse.TabIndex = 6;
            this.btnMAMEBrowse.Text = "...";
            this.btnMAMEBrowse.UseVisualStyleBackColor = true;
            this.btnMAMEBrowse.Click += new System.EventHandler(this.btnMAMEBrowse_Click);
            // 
            // txtSnapsPath
            // 
            this.txtSnapsPath.Location = new System.Drawing.Point(97, 110);
            this.txtSnapsPath.Name = "txtSnapsPath";
            this.txtSnapsPath.Size = new System.Drawing.Size(352, 20);
            this.txtSnapsPath.TabIndex = 5;
            // 
            // txtROMSPath
            // 
            this.txtROMSPath.Location = new System.Drawing.Point(97, 76);
            this.txtROMSPath.Name = "txtROMSPath";
            this.txtROMSPath.Size = new System.Drawing.Size(352, 20);
            this.txtROMSPath.TabIndex = 4;
            // 
            // txtMAMEPath
            // 
            this.txtMAMEPath.Location = new System.Drawing.Point(97, 42);
            this.txtMAMEPath.Name = "txtMAMEPath";
            this.txtMAMEPath.Size = new System.Drawing.Size(352, 20);
            this.txtMAMEPath.TabIndex = 3;
            // 
            // lblSnapsPath
            // 
            this.lblSnapsPath.AutoSize = true;
            this.lblSnapsPath.Location = new System.Drawing.Point(11, 113);
            this.lblSnapsPath.Name = "lblSnapsPath";
            this.lblSnapsPath.Size = new System.Drawing.Size(80, 13);
            this.lblSnapsPath.TabIndex = 2;
            this.lblSnapsPath.Text = "Snapshot Path:";
            // 
            // lblROMSPath
            // 
            this.lblROMSPath.AutoSize = true;
            this.lblROMSPath.Location = new System.Drawing.Point(24, 79);
            this.lblROMSPath.Name = "lblROMSPath";
            this.lblROMSPath.Size = new System.Drawing.Size(67, 13);
            this.lblROMSPath.TabIndex = 1;
            this.lblROMSPath.Text = "ROMS Path:";
            // 
            // lblMAMEPath
            // 
            this.lblMAMEPath.AutoSize = true;
            this.lblMAMEPath.Location = new System.Drawing.Point(24, 45);
            this.lblMAMEPath.Name = "lblMAMEPath";
            this.lblMAMEPath.Size = new System.Drawing.Size(67, 13);
            this.lblMAMEPath.TabIndex = 0;
            this.lblMAMEPath.Text = "MAME Path:";
            // 
            // tabGames
            // 
            this.tabGames.Controls.Add(this.dataGridView1);
            this.tabGames.Controls.Add(this.btnDelete);
            this.tabGames.Controls.Add(this.btnLookup);
            this.tabGames.Controls.Add(this.btnScan);
            this.tabGames.Location = new System.Drawing.Point(4, 22);
            this.tabGames.Name = "tabGames";
            this.tabGames.Padding = new System.Windows.Forms.Padding(3);
            this.tabGames.Size = new System.Drawing.Size(538, 185);
            this.tabGames.TabIndex = 1;
            this.tabGames.Text = "Games List";
            this.tabGames.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(523, 143);
            this.dataGridView1.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(313, 156);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLookup
            // 
            this.btnLookup.Location = new System.Drawing.Point(232, 156);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(75, 23);
            this.btnLookup.TabIndex = 3;
            this.btnLookup.Text = "Lookup";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(151, 156);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(546, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(546, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::CabrioConfig.Properties.Resources.folder_Open_32xLG;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::CabrioConfig.Properties.Resources.save_16xLG;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 266);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(546, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 288);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cabrio Config Builder";
            this.TabControl1.ResumeLayout(false);
            this.tabPaths.ResumeLayout(false);
            this.tabPaths.PerformLayout();
            this.tabGames.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage tabPaths;
        private System.Windows.Forms.TabPage tabGames;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TextBox txtSnapsPath;
        private System.Windows.Forms.TextBox txtROMSPath;
        private System.Windows.Forms.TextBox txtMAMEPath;
        private System.Windows.Forms.Label lblSnapsPath;
        private System.Windows.Forms.Label lblROMSPath;
        private System.Windows.Forms.Label lblMAMEPath;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnSnapBrowse;
        private System.Windows.Forms.Button btnROMSBrowse;
        private System.Windows.Forms.Button btnMAMEBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
