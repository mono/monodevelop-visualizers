using Gtk;
using MonoDevelop.DebuggerVisualizers;

namespace CorlibVisualizers
{
	public class StringVisualizer : DialogDebuggerVisualizer
	{
		protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			MessageDialog dialog = new MessageDialog (null, 
								  DialogFlags.Modal, MessageType.Info, ButtonsType.Close, false,
								  objectProvider.GetObject().ToString());
			dialog.Title = "String Visualizer";

			dialog.Run();
			dialog.Hide();
		}
	}
}
