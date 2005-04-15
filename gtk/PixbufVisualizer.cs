using System;
using System.IO;
using System.Runtime.InteropServices;

using Gtk;
using Gdk;
using Glade;

using MonoDevelop.DebuggerVisualizers;

namespace GtkVisualizers
{
	class PixbufWindow 
	{
		[Widget] Gtk.Dialog pixbuf_dialog;
		[Widget] Gtk.Image pixbuf_image;

		public PixbufWindow (string title, Pixbuf pixbuf)
		{
			Glade.XML ui;

			ui = Glade.XML.FromAssembly ("pixbufvis.glade", "pixbuf_dialog", null);
			ui.Autoconnect (this);

			pixbuf_dialog.Title = title;
			pixbuf_image.Pixbuf = pixbuf;
		}

		public void Show ()
		{
			pixbuf_dialog.Run();
			pixbuf_dialog.Hide();
		}

	}

	// Debugger side class
	public class PixbufVisualizer : DialogDebuggerVisualizer
	{
		protected override void Show (IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			Stream pixbuf_stream = objectProvider.GetData();
			BinaryReader reader = new BinaryReader (pixbuf_stream);

			bool has_alpha;
			int bits_per_sample, width, height, rowstride;
			Gdk.Pixbuf pixbuf;

			has_alpha = reader.ReadBoolean ();
			bits_per_sample = reader.ReadInt32 ();
			width = reader.ReadInt32 ();
			height = reader.ReadInt32 ();
			rowstride = reader.ReadInt32 ();

			int size = height * rowstride;

			byte[] pixbuf_data = new byte [size];

			reader.Read (pixbuf_data, 0, size);

			pixbuf = new Pixbuf (Gdk.Colorspace.Rgb, has_alpha, bits_per_sample, width, height);
			
			Marshal.Copy (pixbuf_data, 0, pixbuf.Pixels, size);

			PixbufWindow win = new PixbufWindow ("Pixbuf Visualizer", pixbuf);

			win.Show ();
		}
	}

	// Debugee side class.  This is necessary since Gdk.Pixbuf
	// isn't serializable, a requirement for
	// VisualizerObjectSource.
	public class PixbufObjectSource : VisualizerObjectSource
	{
		void WriteBuf (Stream outgoingData, byte[] buf)
		{
			outgoingData.Write (buf, 0, buf.Length);
		}

		public override void GetData (object target, Stream outgoingData)
		{
			Gdk.Pixbuf pixbuf = (Gdk.Pixbuf)target;

			WriteBuf (outgoingData, BitConverter.GetBytes (pixbuf.HasAlpha));
			WriteBuf (outgoingData, BitConverter.GetBytes (pixbuf.BitsPerSample));
			WriteBuf (outgoingData, BitConverter.GetBytes (pixbuf.Width));
			WriteBuf (outgoingData, BitConverter.GetBytes (pixbuf.Height));
			WriteBuf (outgoingData, BitConverter.GetBytes (pixbuf.Rowstride));

			int size = pixbuf.Height * pixbuf.Rowstride;

			byte[] pixel_buf = new byte[size];
			Marshal.Copy (pixbuf.Pixels, pixel_buf, 0, size);

			WriteBuf (outgoingData, pixel_buf);
		}
	}
}
