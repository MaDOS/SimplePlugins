using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePlugins
{
  public interface IPluginRunnable
  {
    void Initialize();

    void Start();

    void Stop();
  }
}
