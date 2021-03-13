namespace ImageResizerApp
{
  internal class AppConfiguration : IConfiguration
  {
    public string[] ImageExtensions
    {
      get
      {
        return new[] { ".jpg", ".jpeg", ".png" };
      }
    }
  }
}