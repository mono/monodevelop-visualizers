using Gtk;
using MonoDevelop.DebuggerVisualizers;

namespace GeckoVisualizers
{
  public class XMLVisualizer : DialogDebuggerVisualizer
  {
    protected override void Show (IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
    {
      GeckoWindow win = new GeckoWindow ("XML Visualizer", objectProvider.GetObject().ToString(), "text/xml");

      win.Show();
    }
  }
}
