namespace FileRenamer
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
      lstFiles = new ListBox();
      lblPath = new Label();
      txtPath = new TextBox();
      btnStart = new Button();
      btnSort = new Button();
      pnlProgress = new Panel();
      btnPath = new Button();
      lblProgress = new Label();
      progress = new ProgressBar();
      pnlProgress.SuspendLayout();
      SuspendLayout();
      //
      // lstFiles
      //
      lstFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      lstFiles.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
      lstFiles.FormattingEnabled = true;
      lstFiles.ItemHeight = 18;
      lstFiles.Location = new Point(9, 56);
      lstFiles.Name = "lstFiles";
      lstFiles.Size = new Size(637, 688);
      lstFiles.TabIndex = 3;
      lstFiles.Visible = false;
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
      txtPath.Size = new Size(477, 23);
      txtPath.TabIndex = 1;
      //
      // btnStart
      //
      btnStart.Cursor = Cursors.Hand;
      btnStart.Location = new Point(571, 16);
      btnStart.Name = "btnStart";
      btnStart.Size = new Size(75, 23);
      btnStart.TabIndex = 2;
      btnStart.Text = "Start";
      btnStart.UseVisualStyleBackColor = true;
      btnStart.Click += btnStart_Click;
      //
      // btnSort
      //
      btnSort.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      btnSort.Cursor = Cursors.Hand;
      btnSort.Location = new Point(177, 758);
      btnSort.Name = "btnSort";
      btnSort.Size = new Size(226, 30);
      btnSort.TabIndex = 4;
      btnSort.Text = "Sort Files";
      btnSort.UseVisualStyleBackColor = true;
      btnSort.Visible = false;
      btnSort.Click += btnSort_Click;
      //
      // pnlProgress
      //
      pnlProgress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      pnlProgress.Controls.Add(btnPath);
      pnlProgress.Controls.Add(lblProgress);
      pnlProgress.Controls.Add(progress);
      pnlProgress.Location = new Point(-1, 3);
      pnlProgress.Name = "pnlProgress";
      pnlProgress.Size = new Size(658, 785);
      pnlProgress.TabIndex = 5;
      pnlProgress.Visible = false;
      //
      // btnPath
      //
      btnPath.Cursor = Cursors.Hand;
      btnPath.Location = new Point(538, 14);
      btnPath.Name = "btnPath";
      btnPath.Size = new Size(28, 23);
      btnPath.TabIndex = 0;
      btnPath.Text = "...";
      btnPath.UseVisualStyleBackColor = true;
      btnPath.Click += btnPath_Click;
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
      progress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      progress.Location = new Point(49, 105);
      progress.MarqueeAnimationSpeed = 30;
      progress.Name = "progress";
      progress.Size = new Size(517, 23);
      progress.Step = 20;
      progress.Style = ProgressBarStyle.Marquee;
      progress.TabIndex = 6;
      //
      // Form1
      //
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(658, 798);
      Controls.Add(btnSort);
      Controls.Add(btnStart);
      Controls.Add(txtPath);
      Controls.Add(lblPath);
      Controls.Add(lstFiles);
      Controls.Add(pnlProgress);
      Controls.Add(btnPath);
      Name = "Form1";
      Text = "Files Renamer";
      pnlProgress.ResumeLayout(false);
      pnlProgress.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private ListBox lstFiles;
    private Label lblPath;
    private TextBox txtPath;
    private Button btnStart;
    private Button btnSort;
    private Panel pnlProgress;
    private Label lblProgress;
    private ProgressBar progress;
    private Button btnPath;
  }
}
