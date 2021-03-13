using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace ImageResizerApp
{
  internal class Settings
  {
    public static Settings Load()
    {
      string path = GetPath();

      if (File.Exists(path))
      {
        string json = File.ReadAllText(path);

        if (!string.IsNullOrWhiteSpace(json))
        {
          return JsonConvert.DeserializeObject<Settings>(json);
        }
      }

      return null;
    }

    public void Save()
    {
      string json = JsonConvert.SerializeObject(this);
      File.WriteAllText(GetPath(), json);
    }

    private static string GetPath()
    {
      string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
      return Path.Combine(directory, "settings.json");
    }

    public string SaveDirectory;
  }
}