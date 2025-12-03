using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace FileRenamer
{
  public partial class Form1 : Form
  {
    const string SEPARATOR = " >> ";

    public Form1()
    {
      InitializeComponent();

      //txtPath.Text = "D:\\Downloads\\_teste";
    }

    private void btnPath_Click(object sender, EventArgs e)
    {
      using (var dialog = new FolderBrowserDialog())
      {
        dialog.Description = "Selecione a pasta";
        dialog.UseDescriptionForTitle = true; // For Windows 10+
        dialog.ShowNewFolderButton = true;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          txtPath.Text = dialog.SelectedPath;
        }
      }
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      string path = txtPath.Text.Trim();
      if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
      {
        MessageBox.Show("Please enter a valid directory path.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      try
      {
        lstFiles.Visible = false;
        btnSort.Visible = false;

        Progress(true, "Loading files...");

        string[] files = ListFiles(path);
        if (files.Length == 0)
        {
          MessageBox.Show("No files found in the specified directory.", "No Files", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }

        Progress(true, "Sorting files...");
        string[] subfolders = new string[files.Length];
        var i = 0;

        // Display sorted file names in the ListBox
        lstFiles.Items.Clear();
        var previous = "";
        foreach (var file in files)
        {
          //if no "-", skip
          if (!file.Contains("-", StringComparison.CurrentCulture))
            continue;

          subfolders[i] = CalcSubfolder(file);

          string s = (previous == subfolders[i] ? "" : subfolders[i]);
          previous = subfolders[i];
          lstFiles.Items.Add(s.PadRight(20) + SEPARATOR + Path.GetFileName(file));
          if (i++ % 6 > 0)
            Application.DoEvents();
        }

        lstFiles.Visible = true;
        btnSort.Visible = true;
      }
      catch (Exception ex)
      {
        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        Progress(false);
      }
    }

    private void btnSort_Click(object sender, EventArgs e)
    {
      try
      {
        Progress(true, "Moving files...");
        MoveFiles();
        MessageBox.Show($"{lstFiles.Items.Count} files sorted!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      finally
      {
        Progress(false);
      }
    }

    private void MoveFiles()
    {
      var previous = "";
      for (int i = 0; i < lstFiles.Items.Count; i++)
      {
        lblProgress.Text = $"Moving file {i + 1} / {lstFiles.Items.Count}...";
        if (i % 6 > 0)
          Application.DoEvents();

        var file = "";
        var folder = "";
        var item = lstFiles.Items[i].ToString()?.Trim() ?? "";
        var split = item.Split(SEPARATOR, 2, StringSplitOptions.TrimEntries);
        //same previous path
        if (split.Length < 2)
        {
          folder = previous;
          file = split[0].Substring(3); //remove SEPARATOR
        }
        else
        {
          folder = split[0];
          file = split[1];
        }
        previous = folder;

        var path = txtPath.Text.Trim() + "\\" + folder;
        Directory.CreateDirectory(path);

        //Arquivo já existe?
        var sufix = "";
        if (File.Exists(path + "\\" + file))
          sufix = DateTime.Now.Ticks + Path.GetExtension(file);

        File.Move(txtPath.Text + "\\" + file, path + "\\" + file + sufix);
      }
    }

    private void Progress(bool start, string txt = "")
    {
      if (start)
      {
        pnlProgress.Visible = true;
        pnlProgress.BringToFront();
      }
      else
      {
        pnlProgress.Visible = false;
        pnlProgress.SendToBack();

      }

      if (txt != "")
        lblProgress.Text = txt;
    }

    private string[] ListFiles(string path)
    {
      if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
        throw new ArgumentException("Invalid directory path.", nameof(path));

      var files = Directory.GetFiles(path);
      if (files.Length == 0)
        return Array.Empty<string>();

      Array.Sort(files);
      return files;
    }

    private string CalcSubfolder(string file)
    {
      string s = Path.GetFileNameWithoutExtension(file);
      int i = s.IndexOf("-");
      if (i == -1)
        return "";
      return s.Substring(0, i);
    }

  }
}
