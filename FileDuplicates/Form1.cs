using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using StringUtils;
using IoUtils;
using HashUtils;

namespace FileDuplicates
{
  public partial class Form1 : Form
  {
    List<FileItem> files = new List<FileItem>();

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

    private void btnStart_Click(object? sender, EventArgs? e)
    {
      string path = txtPath.Text.Trim();
      if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
      {
        MessageBox.Show("Please enter a valid directory path.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      try
      {
        lblStatus.Visible = false;
        lstFiles.Visible = false;
        btnDeleteDuplicates.Visible = false;

        Progress("Loading files...");

        files.Clear();
        ListFiles(path);
        if (files.Count == 0)
        {
          MessageBox.Show("No files found in the specified directory.", "No Files", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return;
        }

        Progress("Sorting files...");
        files.Sort((a, b) => b.Size.CompareTo(a.Size));

        Progress("Finding duplicates...");
        FindDuplicates();
        Progress();
        files.Sort((a, b) => b.DuplicateId.CompareTo(a.DuplicateId));
        Progress();

        lstFiles.Items.Clear();
        foreach (var file in files)
        {
          var item = new ListViewItem(file.Name);
          item.SubItems.Add(file.Folder);
          item.SubItems.Add(file.SizeFormatted);
          item.SubItems.Add(file.Size.ToString());
          item.Tag = file.DuplicateId.ToString();
          if (file.DuplicateId != 0)
            item.BackColor = (file.DuplicateId % 2 == 0 ? System.Drawing.Color.LightYellow : System.Drawing.Color.LightCyan);
          lstFiles.Items.Add(item);
          Progress();
        }

        lstFiles.View = View.Details;
        lstFiles.Columns.Clear();
        lstFiles.Columns.Add("File", 250);
        lstFiles.Columns.Add("Folder", 300);
        lstFiles.Columns.Add("Size", 80);
        lstFiles.Columns.Add("Bytes", 100);

        lblStatus.Visible = true;
        lstFiles.Visible = true;
        btnDeleteDuplicates.Visible = true;
      }
      catch (Exception ex)
      {
        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        Progress("", true);
      }
    }

    private void FindDuplicates()
    {
      int id = 0;
      int count = 0;
      FileItem? prev = null;
      foreach (var file in files)
      {
        if (prev == null)
        {
          prev = file;
          continue;
        }

        Progress("");

        //if size !=, not duplicate
        if (file.Size != prev.Size)
        {
          prev = file;
          continue;
        }

        //deep check if duplicate
        if (file.Hash != prev.Hash)
        {
          prev = file;
          continue;
        }

        //duplicate found
        if (prev.DuplicateId == 0)
          prev.DuplicateId = ++id;
        file.DuplicateId = prev.DuplicateId;
        count++;
      }
      var n = files.Count.ToString();
      if (n.Length > 3)
        n = n.Insert(n.Length - 3, ".");
      lblStatus.Text = $"{n} files | {count} duplicates | {id} groups";
    }

    private void btnDeleteDuplicates_Click(object sender, EventArgs e)
    {
      try
      {
        Progress("Deleting duplicates...");
        var n = DeleteDuplicates();
        Progress("", true);

        var more = n > 19 ? "\r\n\r\nStoping at 20, maybe more duplicates..." : "";
        MessageBox.Show($"{n} duplicates selected, check the items and press DELETE to confirm the exclusion! {more}", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        lstFiles.Select();
      }
      finally
      {
        Progress("", true);
      }
    }

    private int DeleteDuplicates()
    {
      int count = 0;
      lstFiles.SelectedIndices.Clear();
      int max = files.Count - 1;
      int maxDeletions = txtMaxDeletions.Text.ToInt();
      if (maxDeletions == 0)
        maxDeletions = Int32.MaxValue;

      for (int i = 0; i < max; i++)
      {
        //limit selected files by each time
        if (count >= maxDeletions)
          break;

        var file = files[i];
        var next = files[i + 1];

        Progress();

        //not duplicated
        if (file.DuplicateId == 0)
          continue;

        if (file.DuplicateId != next.DuplicateId)
          continue;
        lstFiles.SelectedIndices.Add(i);
        count++;
      }

      return count;
    }

    private void Progress(string txt = "", bool close = false)
    {
      if (close)
      {
        pnlProgress.Visible = false;
        pnlProgress.SendToBack();
      }
      else
      {
        if (pnlProgress.Visible == false)
        {
          pnlProgress.Visible = true;
          pnlProgress.BringToFront();
        }

        if (txt != "")
          lblProgress.Text = txt;
      }
      Application.DoEvents();
    }

    private void ListFiles(string path)
    {
      Application.DoEvents();

      if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
        throw new ArgumentException("Invalid directory path.", nameof(path));

      //recursive directories
      var dirs = Directory.GetDirectories(path);
      foreach (var dir in dirs)
      {
        Application.DoEvents();
        ListFiles(dir);
      }

      foreach (var dir in Directory.GetFiles(path))
      {
        files.Add(new FileItem(dir));
      }
    }

    private void mniFolder_Click(object sender, EventArgs e)
    {
      var items = lstFiles.SelectedIndices;
      if (items.Count == 0)
        return;

      if (items.Count > 1)
      {
        MessageBox.Show("Cannot open multiple folders at once!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      try
      {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = "explorer.exe";
        psi.Arguments = files[(int)items[0]].Folder;
        Process.Start(psi);
      }
      catch (Exception)
      {
        throw;
      }
    }

    private void mniOpen_Click(object sender, EventArgs e)
    {
      var items = lstFiles.SelectedIndices;
      if (items.Count == 0)
        return;

      if (items.Count > 1)
      {
        if (MessageBox.Show($"Do you really want to open {items.Count} files?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
          return;
      }

      try
      {
        foreach (var item in items)
        {
          int i = (int)item;
          Io.OpenFile(files[i].FullPath);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    private void mniDelete_Click(object sender, EventArgs e)
    {
      var items = lstFiles.SelectedIndices;
      if (items.Count == 0)
        return;

      var msg = "Do you really want to delete {file}?";
      var comp = (items.Count == 1 ? files[(int)items[0]].Name : items.Count + " files");
      msg = msg.Replace("{file}", comp);

      if (MessageBox.Show(msg, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
        return;

      bool multiple = (items.Count > 1);
      if (multiple)
        Progress("Deleting files from disk...");

      try
      {
        for (int i = items.Count - 1; i >= 0; i--)
        {
          int id = (int)items[i];
          FileSystem.DeleteFile(files[id].FullPath, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
          //update the screen
          if (multiple)
          {
            Progress();
          }
          else
          {
            files.RemoveAt(id);
            lstFiles.Items.RemoveAt(id);
          }
        }
        //update the screen
        if (multiple)
          btnStart_Click(null, null);
      }
      catch (Exception)
      {
        throw;
      }
      finally
      {
        Progress("", true);
      }
    }

    private void mniRename_Click(object sender, EventArgs e)
    {
      var items = lstFiles.SelectedIndices;
      if (items.Count == 0)
        return;

      if (items.Count > 1)
      {
        MessageBox.Show("Cannot rename multiple files at once!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      int id = (int)items[0];
      var s = Microsoft.VisualBasic.Interaction.InputBox("Rename " + files[id].Name + " \r\n(extension is optional)", "Rename file", files[id].Name);
      if (s == "")
        return;

      try
      {
        var ext = Path.GetExtension(s);
        if (ext == "")
          s += Path.GetExtension(files[id].Name);
        Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(files[id].FullPath, s);

        //update the screen
        files[id].Name = s;
        lstFiles.Items[id].Text = s;
      }
      catch (Exception)
      {
        throw;
      }
    }
    

    private void lstFiles_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      mniOpen_Click(sender, e);
    }

    private void txtMaxDeletions_Leave(object sender, EventArgs e)
    {
      txtMaxDeletions.Text = txtMaxDeletions.Text.ToInt().ToString();
    }
  }

  class FileItem
  {
    public int DuplicateId { get; set; }
    public string Name { get; set; }
    public string Folder { get; set; }
    public long Size { get; set; }
    public string SizeFormatted { get { return Str.FormatFileSize(Size); } }
    public string FullPath { get { return Folder + "\\" + Name; } }
    public string Hash { get { return _hash ?? CalcCrc32(); } }

    private string? _hash;

    public FileItem(string fullPath)
    {
      DuplicateId = 0;
      Name = Path.GetFileName(fullPath);
      Folder = Path.GetDirectoryName(fullPath) ?? "";
      Size = new FileInfo(fullPath).Length;
    }
    
    private string CalcCrc32()
    {
      if (_hash != null)
        return _hash;

      try
      {
        _hash = Crc32.FromFile(FullPath);
        
      }
      catch
      {
        _hash = "ERROR";
      }
      return _hash;
    }
  }
}