using System;
using System.Collections.Generic;

namespace SimplePlugins
{
  public class PluginManager
  {
    private Dictionary<Type, IPluginRunnable> Plugins { get; set; }

    public PluginManager()
    {
      this.Plugins = new Dictionary<Type, IPluginRunnable>();
    }

    public T GetPlugin<T>() where T : class, IPluginRunnable, new()
    {
      if (!this.Plugins.ContainsKey(typeof(T)))
      {
        return null;
      }

      return (T)this.Plugins[typeof(T)];
    }

    public void RegisterPlugin<T>() where T : class, IPluginRunnable, new()
    {
      if (this.Plugins.ContainsKey(typeof(T)))
      {
        return;
      }


#if DEBUG
      Console.WriteLine($"Registering plugin {typeof(T).Name}");
#endif

      this.Plugins.Add(typeof(T), new T());
    }

    public void InitializePlugins()
    {
      foreach (IPluginRunnable plugin in this.Plugins.Values)
      {
#if DEBUG
        Console.WriteLine($"Initializing plugin {plugin.GetType().Name}");
#endif
        plugin.Initialize();
      }
    }

    public void StartPlugins()
    {
      foreach (IPluginRunnable plugin in this.Plugins.Values)
      {
#if DEBUG
        Console.WriteLine($"Starting plugin {plugin.GetType().Name}");
#endif
        plugin.Start();
      }
    }

    public void StopPlugins()
    {
      foreach (IPluginRunnable plugin in this.Plugins.Values)
      {
#if DEBUG
        Console.WriteLine($"Stopping plugin {plugin.GetType().Name}");
#endif
        plugin.Stop();
      }
    }
  }
}
