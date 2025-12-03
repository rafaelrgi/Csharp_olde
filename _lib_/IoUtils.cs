using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace IoUtils
{
  class Io
  {
    public static void OpenFile(string path)
    {
      using Process fileopener = new Process();
      fileopener.StartInfo.FileName = "explorer";
      fileopener.StartInfo.Arguments = "\"" + path + "\"";
      fileopener.Start();
    }    
  }
}