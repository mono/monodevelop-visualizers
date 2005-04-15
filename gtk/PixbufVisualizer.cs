using Gtk;
using Gdk;
using MonoDevelop.DebuggerVisualizers;

namespace GtkVisualizers
{
	public class PixbufVisualizer : DialogDebuggerVisualizer
	{
		protected override void Show (IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			Gtk.Window window = new Gtk.Window (Gtk.WindowType.Toplevel);
			Gdk.Pixbuf pixbuf = (Gdk.Pixbuf) objectProvider.GetObject ();

			Widget image = new Gtk.Image(pixbuf);

			window.Title = "Pixbuf Visualizer";
			window.Add (image);

			window.ShowAll ();
		}
	}
}
