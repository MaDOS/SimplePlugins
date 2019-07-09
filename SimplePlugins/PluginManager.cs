using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

      this.Plugins.Add(typeof(T), new T());
    }

    public void InitializePlugins()
    {
      foreach(IPluginRunnable plugin in this.Plugins.Values)
      {
        plugin.Initialize();
      }
    }

    public void StartPlugins()
    {
      foreach(IPluginRunnable plugin in this.Plugins.Values)
      {
        plugin.Start();
      }
    }

    public void StopPlugins()
    {
      foreach (IPluginRunnable plugin in this.Plugins.Values)
      {
        plugin.Stop();
      }
    }
  }
}
