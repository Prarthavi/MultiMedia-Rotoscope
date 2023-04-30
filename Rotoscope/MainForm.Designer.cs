namespace Rotoscope
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMovieItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMovieItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useSourceAudioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pullAudioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generateVideoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openAudioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAudioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFrameItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.writeFrameItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeThenCreateFrameItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeThenCreateSecondItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeThenCreateRemainingItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeRedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MakeGreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBirdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawLineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.drawWormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawMeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDlgRoto = new System.Windows.Forms.OpenFileDialog();
            this.openDlgMovie = new System.Windows.Forms.OpenFileDialog();
            this.openDlgAudio = new System.Windows.Forms.OpenFileDialog();
            this.saveDlgRoto = new System.Windows.Forms.SaveFileDialog();
            this.saveDlgAudio = new System.Windows.Forms.SaveFileDialog();
            this.openDlgOutMovie = new System.Windows.Forms.OpenFileDialog();
            this.saveDlgOutMovie = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.moviesToolStripMenuItem,
            this.playbackToolStripMenuItem,
            this.editToolStripMenuItem,
            this.drawLineToolStripMenuItem1,
            this.drawWormToolStripMenuItem,
            this.DrawMeMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1662, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItem,
            this.openItem,
            this.saveAsItem,
            this.saveItem,
            this.closeItem,
            this.toolStripSeparator4,
            this.exitItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newItem
            // 
            this.newItem.Name = "newItem";
            this.newItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newItem.Size = new System.Drawing.Size(223, 34);
            this.newItem.Text = "New";
            this.newItem.Click += new System.EventHandler(this.newItem_Click);
            // 
            // openItem
            // 
            this.openItem.Name = "openItem";
            this.openItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openItem.Size = new System.Drawing.Size(223, 34);
            this.openItem.Text = "Open";
            this.openItem.Click += new System.EventHandler(this.openRotoItem_Click);
            // 
            // saveAsItem
            // 
            this.saveAsItem.Name = "saveAsItem";
            this.saveAsItem.Size = new System.Drawing.Size(223, 34);
            this.saveAsItem.Text = "Save As";
            this.saveAsItem.Click += new System.EventHandler(this.saveAsRotoItem_Click);
            // 
            // saveItem
            // 
            this.saveItem.Name = "saveItem";
            this.saveItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveItem.Size = new System.Drawing.Size(223, 34);
            this.saveItem.Text = "Save";
            this.saveItem.Click += new System.EventHandler(this.saveRotoItem_Click);
            // 
            // closeItem
            // 
            this.closeItem.Name = "closeItem";
            this.closeItem.Size = new System.Drawing.Size(223, 34);
            this.closeItem.Text = "Close";
            this.closeItem.Click += new System.EventHandler(this.closeAllItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(220, 6);
            // 
            // exitItem
            // 
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(223, 34);
            this.exitItem.Text = "Exit";
            this.exitItem.Click += new System.EventHandler(this.exitItem_Click);
            // 
            // moviesToolStripMenuItem
            // 
            this.moviesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMovieItem,
            this.closeMovieItem,
            this.useSourceAudioItem,
            this.pullAudioItem,
            this.toolStripSeparator1,
            this.generateVideoItem,
            this.toolStripSeparator2,
            this.openAudioItem,
            this.closeAudioItem});
            this.moviesToolStripMenuItem.Name = "moviesToolStripMenuItem";
            this.moviesToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.moviesToolStripMenuItem.Text = "Movies";
            // 
            // openMovieItem
            // 
            this.openMovieItem.Name = "openMovieItem";
            this.openMovieItem.Size = new System.Drawing.Size(269, 34);
            this.openMovieItem.Text = "Open source movie";
            this.openMovieItem.Click += new System.EventHandler(this.openSourceMovieItem_Click);
            // 
            // closeMovieItem
            // 
            this.closeMovieItem.Name = "closeMovieItem";
            this.closeMovieItem.Size = new System.Drawing.Size(269, 34);
            this.closeMovieItem.Text = "Close source movie";
            this.closeMovieItem.Click += new System.EventHandler(this.closeMovieItem_Click);
            // 
            // useSourceAudioItem
            // 
            this.useSourceAudioItem.Checked = true;
            this.useSourceAudioItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useSourceAudioItem.Name = "useSourceAudioItem";
            this.useSourceAudioItem.Size = new System.Drawing.Size(269, 34);
            this.useSourceAudioItem.Text = "Use source audio";
            this.useSourceAudioItem.Click += new System.EventHandler(this.useSourceAudioItem_Click);
            // 
            // pullAudioItem
            // 
            this.pullAudioItem.Name = "pullAudioItem";
            this.pullAudioItem.Size = new System.Drawing.Size(269, 34);
            this.pullAudioItem.Text = "Save movie audio";
            this.pullAudioItem.Click += new System.EventHandler(this.pullAudioItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(266, 6);
            // 
            // generateVideoItem
            // 
            this.generateVideoItem.Name = "generateVideoItem";
            this.generateVideoItem.Size = new System.Drawing.Size(269, 34);
            this.generateVideoItem.Text = "Generate Video";
            this.generateVideoItem.Click += new System.EventHandler(this.generateVideoItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(266, 6);
            // 
            // openAudioItem
            // 
            this.openAudioItem.Name = "openAudioItem";
            this.openAudioItem.Size = new System.Drawing.Size(269, 34);
            this.openAudioItem.Text = "Open audio file";
            this.openAudioItem.Click += new System.EventHandler(this.openAudioItem_Click);
            // 
            // closeAudioItem
            // 
            this.closeAudioItem.Name = "closeAudioItem";
            this.closeAudioItem.Size = new System.Drawing.Size(269, 34);
            this.closeAudioItem.Text = "Close audio file";
            this.closeAudioItem.Click += new System.EventHandler(this.closeAudioItem_Click);
            // 
            // playbackToolStripMenuItem
            // 
            this.playbackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFrameItem,
            this.toolStripSeparator3,
            this.writeFrameItem,
            this.writeThenCreateFrameItem,
            this.writeThenCreateSecondItem,
            this.writeThenCreateRemainingItem});
            this.playbackToolStripMenuItem.Name = "playbackToolStripMenuItem";
            this.playbackToolStripMenuItem.Size = new System.Drawing.Size(77, 29);
            this.playbackToolStripMenuItem.Text = "Frame";
            // 
            // createFrameItem
            // 
            this.createFrameItem.Name = "createFrameItem";
            this.createFrameItem.Size = new System.Drawing.Size(332, 34);
            this.createFrameItem.Text = "Create 1 frame";
            this.createFrameItem.Click += new System.EventHandler(this.createFrameItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(329, 6);
            // 
            // writeFrameItem
            // 
            this.writeFrameItem.Name = "writeFrameItem";
            this.writeFrameItem.Size = new System.Drawing.Size(332, 34);
            this.writeFrameItem.Text = "Write 1 frame";
            this.writeFrameItem.Click += new System.EventHandler(this.writeFrameItem_Click);
            // 
            // writeThenCreateFrameItem
            // 
            this.writeThenCreateFrameItem.Name = "writeThenCreateFrameItem";
            this.writeThenCreateFrameItem.Size = new System.Drawing.Size(332, 34);
            this.writeThenCreateFrameItem.Text = "Write then create 1 frame";
            this.writeThenCreateFrameItem.Click += new System.EventHandler(this.writeThenCreateFrameItem_Click);
            // 
            // writeThenCreateSecondItem
            // 
            this.writeThenCreateSecondItem.Name = "writeThenCreateSecondItem";
            this.writeThenCreateSecondItem.Size = new System.Drawing.Size(332, 34);
            this.writeThenCreateSecondItem.Text = "Write then create 1 second";
            this.writeThenCreateSecondItem.Click += new System.EventHandler(this.writeThenCreateSecondItem_Click);
            // 
            // writeThenCreateRemainingItem
            // 
            this.writeThenCreateRemainingItem.Name = "writeThenCreateRemainingItem";
            this.writeThenCreateRemainingItem.Size = new System.Drawing.Size(332, 34);
            this.writeThenCreateRemainingItem.Text = "Write then create remaining";
            this.writeThenCreateRemainingItem.Click += new System.EventHandler(this.writeThenCreateRemainingItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearFrameToolStripMenuItem,
            this.drawLineToolStripMenuItem,
            this.makeWhiteToolStripMenuItem,
            this.makeRedToolStripMenuItem,
            this.MakeGreenToolStripMenuItem,
            this.addBirdToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearFrameToolStripMenuItem
            // 
            this.clearFrameToolStripMenuItem.Name = "clearFrameToolStripMenuItem";
            this.clearFrameToolStripMenuItem.Size = new System.Drawing.Size(208, 34);
            this.clearFrameToolStripMenuItem.Text = "Clear Frame";
            this.clearFrameToolStripMenuItem.Click += new System.EventHandler(this.clearFrameToolStripMenuItem_Click);
            // 
            // drawLineToolStripMenuItem
            // 
            this.drawLineToolStripMenuItem.Name = "drawLineToolStripMenuItem";
            this.drawLineToolStripMenuItem.Size = new System.Drawing.Size(208, 34);
            this.drawLineToolStripMenuItem.Text = "Draw Line";
            this.drawLineToolStripMenuItem.Click += new System.EventHandler(this.drawLineToolStripMenuItem_Click);
            // 
            // makeWhiteToolStripMenuItem
            // 
            this.makeWhiteToolStripMenuItem.Name = "makeWhiteToolStripMenuItem";
            this.makeWhiteToolStripMenuItem.Size = new System.Drawing.Size(208, 34);
            this.makeWhiteToolStripMenuItem.Text = "Make White";
            this.makeWhiteToolStripMenuItem.Click += new System.EventHandler(this.makeWhiteToolStripMenuItem_Click);
            // 
            // makeRedToolStripMenuItem
            // 
            this.makeRedToolStripMenuItem.Name = "makeRedToolStripMenuItem";
            this.makeRedToolStripMenuItem.Size = new System.Drawing.Size(208, 34);
            this.makeRedToolStripMenuItem.Text = "Make Red";
            this.makeRedToolStripMenuItem.Click += new System.EventHandler(this.makeRedToolStripMenuItem_Click);
            // 
            // MakeGreenToolStripMenuItem
            // 
            this.MakeGreenToolStripMenuItem.Name = "MakeGreenToolStripMenuItem";
            this.MakeGreenToolStripMenuItem.Size = new System.Drawing.Size(208, 34);
            this.MakeGreenToolStripMenuItem.Text = "Make Green";
            this.MakeGreenToolStripMenuItem.Click += new System.EventHandler(this.makeGreenToolStripMenuItem_Click);
            // 
            // addBirdToolStripMenuItem
            // 
            this.addBirdToolStripMenuItem.Name = "addBirdToolStripMenuItem";
            this.addBirdToolStripMenuItem.Size = new System.Drawing.Size(208, 34);
            this.addBirdToolStripMenuItem.Text = "Add Bird";
            this.addBirdToolStripMenuItem.Click += new System.EventHandler(this.addBirdToolStripMenuItem_Click);
            // 
            // drawLineToolStripMenuItem1
            // 
            this.drawLineToolStripMenuItem1.Name = "drawLineToolStripMenuItem1";
            this.drawLineToolStripMenuItem1.Size = new System.Drawing.Size(105, 29);
            this.drawLineToolStripMenuItem1.Text = "Draw Line";
            this.drawLineToolStripMenuItem1.Click += new System.EventHandler(this.drawLineToolStripMenuItem_Click);
            // 
            // drawWormToolStripMenuItem
            // 
            this.drawWormToolStripMenuItem.Name = "drawWormToolStripMenuItem";
            this.drawWormToolStripMenuItem.Size = new System.Drawing.Size(125, 29);
            this.drawWormToolStripMenuItem.Text = "Draw Basket";
            this.drawWormToolStripMenuItem.Click += new System.EventHandler(this.drawBasketToolStripMenuItem_Click);
            // 
            // DrawMeMenuItem
            // 
            this.DrawMeMenuItem.Name = "DrawMeMenuItem";
            this.DrawMeMenuItem.Size = new System.Drawing.Size(99, 29);
            this.DrawMeMenuItem.Text = "Draw Me";
            this.DrawMeMenuItem.Click += new System.EventHandler(this.DrawMeMenuItem_Click);
            // 
            // openDlgRoto
            // 
            this.openDlgRoto.FileName = "openFileDialogRoto";
            this.openDlgRoto.Filter = "XML (*.xml)|*.xml|All Files (*.*)|*.*";
            // 
            // openDlgMovie
            // 
            this.openDlgMovie.Filter = "Video Files (*.avi;*.wmv; *.mp4)|*.avi; *.wmv; *.mp4|All Files (*.*)|*.*";
            // 
            // openDlgAudio
            // 
            this.openDlgAudio.FileName = "openFileDialog1";
            this.openDlgAudio.Filter = "Audio Files (*.wav;*.mp3)|*.wav; *.mp3|All Files (*.*)|*.*";
            // 
            // saveDlgRoto
            // 
            this.saveDlgRoto.Filter = "XML (*.xml)|*.xml|All Files (*.*)|*.*";
            // 
            // saveDlgAudio
            // 
            this.saveDlgAudio.Filter = "WAV (*.wav) |*.wav| MP3 (*.mp3) | *.mp3|All Files (*.*)|*.*";
            // 
            // openDlgOutMovie
            // 
            this.openDlgOutMovie.FileName = "openDlgOutMovie";
            this.openDlgOutMovie.Filter = "MP4 Files (*.mp4)|*.mp4|All Files (*.*)|*.*";
            // 
            // saveDlgOutMovie
            // 
            this.saveDlgOutMovie.Filter = "MP4 Files (*.mp4)|*.mp4|All Files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1662, 1006);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Rotoscope Patnekar Prarthavi";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key_pressed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newItem;
        private System.Windows.Forms.ToolStripMenuItem playbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsItem;
        private System.Windows.Forms.ToolStripMenuItem saveItem;
        private System.Windows.Forms.ToolStripMenuItem closeItem;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.ToolStripMenuItem moviesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMovieItem;
        private System.Windows.Forms.ToolStripMenuItem closeMovieItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem openAudioItem;
        private System.Windows.Forms.ToolStripMenuItem closeAudioItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem createFrameItem;
        private System.Windows.Forms.ToolStripMenuItem writeThenCreateFrameItem;
        private System.Windows.Forms.ToolStripMenuItem writeThenCreateSecondItem;
        private System.Windows.Forms.ToolStripMenuItem writeThenCreateRemainingItem;
        private System.Windows.Forms.OpenFileDialog openDlgRoto;
        private System.Windows.Forms.OpenFileDialog openDlgMovie;
        private System.Windows.Forms.OpenFileDialog openDlgAudio;
        private System.Windows.Forms.SaveFileDialog saveDlgRoto;
        private System.Windows.Forms.ToolStripMenuItem writeFrameItem;
        private System.Windows.Forms.ToolStripMenuItem generateVideoItem;
        private System.Windows.Forms.ToolStripMenuItem pullAudioItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.SaveFileDialog saveDlgAudio;
        private System.Windows.Forms.ToolStripMenuItem useSourceAudioItem;
        private System.Windows.Forms.OpenFileDialog openDlgOutMovie;
        private System.Windows.Forms.SaveFileDialog saveDlgOutMovie;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeRedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MakeGreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBirdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawLineToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem drawWormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DrawMeMenuItem;
    }
}

