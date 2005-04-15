using Gtk;
using Glade;

using MonoDevelop.DebuggerVisualizers;

namespace CorlibVisualizers
{
	public class StringWindow
	{
		[Widget] Gtk.Dialog string_dialog;
		[Widget] Gtk.TextView string_textview;
		Gtk.TextBuffer buffer;
	  
		public StringWindow (string data)
		{
			Glade.XML ui;

			buffer = new Gtk.TextBuffer (null);

			ui = Glade.XML.FromAssembly ("stringvis.glade", "string_dialog", null);
			ui.Autoconnect (this);

			string_dialog.SetDefaultSize (400, 300);

			string_textview.Buffer = buffer;
			buffer.Text = data;
		}

		public void Show ()
		{
			string_dialog.Run();
			string_dialog.Hide();
		}

		public bool Editable {
			get {
				return string_textview.Editable;
			}
			set {
				string_textview.Editable = value;
				string_textview.CursorVisible = value;
			}
		}
	}

	public class StringVisualizer : DialogDebuggerVisualizer
	{
		protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			StringWindow win = new StringWindow (objectProvider.GetObject().ToString());

			win.Editable = objectProvider.IsObjectReplaceable;

			win.Show ();
		}
	}
}
