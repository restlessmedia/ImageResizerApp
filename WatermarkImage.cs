using ImageResizer.Configuration;
using ImageResizer.Plugins.Watermark;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

namespace ImageResizerApp
{
  internal class WatermarkImage
  {
    public WatermarkImage()
    {
      _config = Config.Current;
      new WatermarkPlugin().Install(_config);
      string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
      _filePath = Path.Combine(directory, "wm.png");
    }

    public void CopyToBin()
    {
      using (WebClient client = new WebClient())
      {
        using (Stream stream = client.OpenRead(_imageUrl))
        {
          Bitmap bitmap; bitmap = new Bitmap(stream);

          if (bitmap != null)
          {
            bitmap.Save(_filePath, _imageFormat);
          }

          stream.Flush();
        }
      }
    }

    public Image GetImage()
    {
      EnsureImage();
      return new Bitmap(_filePath);
    }

    public void ApplyTo(string filePath, string saveDirectory)
    {
      EnsureImage();

      Bitmap image = new Bitmap(filePath);

      _config.BuildImage(image, saveDirectory, "watermark=wm");
    }

    private void EnsureImage()
    {
      if (!File.Exists(_filePath))
      {
        CopyToBin();
      }

      EnsureConfiguration();
    }

    /// <summary>
    /// This ensures we have updated the dynamic configuration values like watermark path which we don't know until runtime.
    /// </summary>
    private void EnsureConfiguration()
    {
      WatermarkPlugin plugin = (WatermarkPlugin)_config.Plugins.AllPlugins.First(p => p is WatermarkPlugin);
      ImageLayer imageLayer = (ImageLayer)plugin.NamedWatermarks.First().Value.First();
      imageLayer.Path = _filePath;
    }

    private readonly ImageFormat _imageFormat = ImageFormat.Png;

    private readonly string _imageUrl = "https://www.blakestanley.co.uk/content/wm.png";

    private readonly Config _config;

    private readonly string _filePath;
  }
}