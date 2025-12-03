namespace HashUtils
{
  public static class Crc32
  {
    private static readonly uint[] Table;

    static Crc32()
    {
      Table = new uint[256];
      const uint poly = 0xEDB88320;
      for (uint i = 0; i < Table.Length; ++i)
      {
        uint temp = i;
        for (int j = 0; j < 8; ++j)
        {
          if ((temp & 1) == 1)
            temp = (temp >> 1) ^ poly;
          else
            temp >>= 1;
        }
        Table[i] = temp;
      }
    }

    public static string FromFile(string path)
    {
      uint crc = 0xFFFFFFFF;
      int b;

      using (var stream = File.OpenRead(path))
      {
        while ((b = stream.ReadByte()) != -1)
        {
          crc = (crc >> 8) ^ Table[(crc ^ b) & 0xFF];
        }
      }
      crc = ~crc;
      return crc.ToString("X8"); // Hex string, 8 digits
    }
  }
}