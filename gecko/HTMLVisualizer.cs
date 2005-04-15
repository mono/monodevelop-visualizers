using Gtk;
using MonoDevelop.DebuggerVisualizers;

namespace GeckoVisualizers
{
  public class HTMLVisualizer : DialogDebuggerVisualizer
  {
    protected override void Show (IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
    {
      GeckoWindow win = new GeckoWindow ("HTML Visualizer", objectProvider.GetObject().ToString(), "text/html");

      win.Show();
    }
  }

}
