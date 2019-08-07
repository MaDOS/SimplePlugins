namespace SimplePlugins
{
  public interface IPluginRunnable
  {
    /// <summary>
    /// Initializes the plugin
    /// </summary>
    void Initialize();

    /// <summary>
    /// Starts the plugin
    /// </summary>
    void Start();

    /// <summary>
    /// Stops the plugin
    /// </summary>
    void Stop();
  }
}
