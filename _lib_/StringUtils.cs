namespace StringUtils
{
  public static class StringExtensions
  {
    public static int ToInt(this string s)
    {
      int i;
      if (!int.TryParse(s, out i))
        return 0;
      return i;
    }
  }

  public static class Str 
  {
    public static string FormatFileSize(long bytes, bool suffix=true)
    {
      decimal size = bytes / 1024; //kb
      if (size <= 1024)
        return size.ToString("F2") + (suffix? " KB" : "");

      size /= 1024; //mb
      if (size <= 1024)
        return size.ToString("F2") + (suffix ? " MB" : "");

      size /= 1024; //gb
      return size.ToString("F2") + (suffix ? " GB" : "");
    }
  }
}