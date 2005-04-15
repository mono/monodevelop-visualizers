using System;

using Gtk;
using Glade;
using Gecko;

namespace GeckoVisualizers
{
  public class GeckoWindow
  {
    [Widget] Gtk.Dialog gecko_dialog;
    [Widget] WebControl gecko_control;

    public GeckoWindow (string title, string data, string mime_type)
    {
	this.data = data;
	this.mime_type = mime_type;

    	Glade.XML ui;

    	Glade.Global.SetCustomHandler (new XMLCustomWidgetHandler (CustomWidgetHandler));

    	ui = Glade.XML.FromAssembly ("geckovis.glade", "gecko_dialog", null);
	ui.Autoconnect (this);

	gecko_control.Show ();

    	gecko_dialog.SetDefaultSize (400, 300);
	gecko_dialog.Title = title;
    }

    public void Show ()
    {
    	gecko_control.OpenStream ("visualizer-data:///", mime_type);
    	gecko_control.AppendData (data);
	gecko_control.CloseStream();

    	gecko_dialog.Run();
	gecko_dialog.Hide();
    }


    public Widget CustomWidgetHandler (XML xml, string func_name, string name, string string1, string string2, int int1, int int2)
    {
      if (func_name.Equals ("CreateGeckoControl")) {
	return new Gecko.WebControl ();
      }

      return null;
    }

    string data;
    string mime_type;
  }

}
