namespace FileDuplicates
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      lblPath = new Label();
      txtPath = new TextBox();
      btnStart = new Button();
      pnlProgress = new Panel();
      lblProgress = new Label();
      progress = new ProgressBar();
      btnPath = new Button();
      lstFiles = new ListView();
      mnuFiles = new ContextMenuStrip(components);
      mniOpen = new ToolStripMenuItem();
      mniDelete = new ToolStripMenuItem();
      mniRename = new ToolStripMenuItem();
      mniFolder = new ToolStripMenuItem();
      txtMaxDeletions = new TextBox();
      label1 = new Label();
      lblStatus = new Label();
      btnDeleteDuplicates = new Button();
      pnlProgress.SuspendLayout();
      mnuFiles.SuspendLayout();
      SuspendLayout();
      //
      // lblPath
      //
      lblPath.AutoSize = true;
      lblPath.Location = new Point(14, 19);
      lblPath.Name = "lblPath";
      lblPath.Size = new Size(40, 15);
      lblPath.TabIndex = 0;
      lblPath.Text = "Folder";
      //
      // txtPath
      //
      txtPath.Location = new Point(60, 16);
      txtPath.Name = "txtPath";
      txtPath.Size = new Size(504, 23);
      txtPath.TabIndex = 1;
      //
      // btnStart
      //
      btnStart.Cursor = Cursors.Hand;
      btnStart.Location = new Point(605, 13);
      btnStart.Name = "btnStart";
      btnStart.Size = new Size(75, 23);
      btnStart.TabIndex = 2;
      btnStart.Text = "Start";
      btnStart.UseVisualStyleBackColor = true;
      btnStart.Click += btnStart_Click;
      //
      // pnlProgress
      //
      pnlProgress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
      pnlProgress.Controls.Add(lblProgress);
      pnlProgress.Controls.Add(progress);
      pnlProgress.Location = new Point(-1, 3);
      pnlProgress.Name = "pnlProgress";
      pnlProgress.Size = new Size(694, 2048);
      pnlProgress.TabIndex = 5;
      pnlProgress.Visible = false;
      //
      // lblProgress
      //
      lblProgress.AutoSize = true;
      lblProgress.Location = new Point(263, 83);
      lblProgress.Name = "lblProgress";
      lblProgress.Size = new Size(38, 15);
      lblProgress.TabIndex = 7;
      lblProgress.Text = "label2";
      lblProgress.TextAlign = ContentAlignment.TopCenter;
      //
      // progress
      //
      progress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      progress.Location = new Point(49, 105);
      progress.MarqueeAnimationSpeed = 30;
      progress.Name = "progress";
      progress.Size = new Size(553, 32);
      progress.Step = 20;
      progress.Style = ProgressBarStyle.Marquee;
      progress.TabIndex = 6;
      //
      // btnPath
      //
      btnPath.Cursor = Cursors.Hand;
      btnPath.Location = new Point(565, 12);
      btnPath.Name = "btnPath";
      btnPath.Size = new Size(28, 25);
      btnPath.TabIndex = 0;
      btnPath.Text = "...";
      btnPath.UseVisualStyleBackColor = true;
      btnPath.Click += btnPath_Click;
      //
      // lstFiles
      //
      lstFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lstFiles.ContextMenuStrip = mnuFiles;
      lstFiles.Font = new Font("Segoe UI", 10F);
      lstFiles.FullRowSelect = true;
      lstFiles.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      lstFiles.Location = new Point(13, 51);
      lstFiles.Name = "lstFiles";
      lstFiles.Size = new Size(666, 696);
      lstFiles.TabIndex = 9;
      lstFiles.UseCompatibleStateImageBehavior = false;
      lstFiles.View = View.Details;
      lstFiles.MouseDoubleClick += lstFiles_MouseDoubleClick;
      //
      // mnuFiles
      //
      mnuFiles.Font = new Font("Segoe UI", 10F);
      mnuFiles.Items.AddRange(new ToolStripItem[] { mniOpen, mniDelete, mniRename, mniFolder });
      mnuFiles.Name = "mnuFiles";
      mnuFiles.Size = new Size(179, 100);
      //
      // mniOpen
      //
      mniOpen.Name = "mniOpen";
      mniOpen.ShortcutKeys = Keys.Control | Keys.O;
      mniOpen.Size = new Size(178, 24);
      mniOpen.Text = "&Open";
      mniOpen.Click += mniOpen_Click;
      //
      // mniDelete
      //
      mniDelete.Name = "mniDelete";
      mniDelete.ShortcutKeys = Keys.Delete;
      mniDelete.Size = new Size(178, 24);
      mniDelete.Text = "&Delete";
      mniDelete.Click += mniDelete_Click;
      //
      // mniRename
      //
      mniRename.Name = "mniRename";
      mniRename.ShortcutKeys = Keys.F2;
      mniRename.Size = new Size(178, 24);
      mniRename.Text = "&Rename";
      mniRename.Click += mniRename_Click;
      //
      // mniFolder
      //
      mniFolder.Name = "mniFolder";
      mniFolder.ShortcutKeys = Keys.F3;
      mniFolder.Size = new Size(178, 24);
      mniFolder.Text = "Open &Folder";
      mniFolder.Click += mniFolder_Click;
      //
      // txtMaxDeletions
      //
      txtMaxDeletions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      txtMaxDeletions.Location = new Point(136, 766);
      txtMaxDeletions.Name = "txtMaxDeletions";
      txtMaxDeletions.Size = new Size(33, 23);
      txtMaxDeletions.TabIndex = 16;
      txtMaxDeletions.Text = "20";
      txtMaxDeletions.TextAlign = HorizontalAlignment.Right;
      //
      // label1
      //
      label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      label1.AutoSize = true;
      label1.Location = new Point(11, 773);
      label1.Name = "label1";
      label1.Size = new Size(125, 15);
      label1.TabIndex = 15;
      label1.Text = "Max deletions at once:";
      //
      // lblStatus
      //
      lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      lblStatus.Location = new Point(438, 769);
      lblStatus.Name = "lblStatus";
      lblStatus.Size = new Size(240, 20);
      lblStatus.TabIndex = 14;
      lblStatus.Text = "label1";
      lblStatus.TextAlign = ContentAlignment.BottomRight;
      lblStatus.Visible = false;
      //
      // btnDeleteDuplicates
      //
      btnDeleteDuplicates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnDeleteDuplicates.Cursor = Cursors.Hand;
      btnDeleteDuplicates.Location = new Point(218, 759);
      btnDeleteDuplicates.Name = "btnDeleteDuplicates";
      btnDeleteDuplicates.Size = new Size(215, 30);
      btnDeleteDuplicates.TabIndex = 13;
      btnDeleteDuplicates.Text = "Delete duplicates";
      btnDeleteDuplicates.UseVisualStyleBackColor = true;
      btnDeleteDuplicates.Visible = false;
      btnDeleteDuplicates.Click += btnDeleteDuplicates_Click;
      //
      // Form1
      //
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(692, 798);
      Controls.Add(txtMaxDeletions);
      Controls.Add(label1);
      Controls.Add(lblStatus);
      Controls.Add(btnDeleteDuplicates);
      Controls.Add(lstFiles);
      Controls.Add(txtPath);
      Controls.Add(lblPath);
      Controls.Add(btnPath);
      Controls.Add(btnStart);
      Controls.Add(pnlProgress);
      Name = "Form1";
      Text = "Duplicate File Finder";
      pnlProgress.ResumeLayout(false);
      pnlProgress.PerformLayout();
      mnuFiles.ResumeLayout(false);
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private Label lblPath;
    private TextBox txtPath;
    private Button btnStart;
    private Panel pnlProgress;
    private Label lblProgress;
    private ProgressBar progress;
    private Button btnPath;
    private ListView lstFiles;
    private ContextMenuStrip mnuFiles;
    private ToolStripMenuItem mniDelete;
    private ToolStripMenuItem mniRename;
    private ToolStripMenuItem mniOpen;
    private ToolStripMenuItem mniFolder;
    private TextBox txtMaxDeletions;
    private Label label1;
    private Label lblStatus;
    private Button btnDeleteDuplicates;
  }
}
