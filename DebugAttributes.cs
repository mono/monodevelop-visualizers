using System.Diagnostics;
using MonoDevelop.DebuggerVisualizers;

[assembly: DebuggerVisualizer (typeof (GtkVisualizers.PixbufVisualizer),
			       typeof (VisualizerObjectSource),
			       Target = typeof (Gdk.Pixbuf),
			       Description = "View Pixbuf")]
[assembly: DebuggerVisualizer (typeof (CorlibVisualizers.StringVisualizer),
			       typeof (VisualizerObjectSource),
			       Target = typeof (System.String),
			       Description = "View String")]
#if ENABLE_GECKO_VISUALIZERS
[assembly: DebuggerVisualizer (typeof (GeckoVisualizers.HTMLVisualizer),
			       typeof (VisualizerObjectSource),
			       Target = typeof (System.String),
			       Description = "View as HTML")]
[assembly: DebuggerVisualizer (typeof (GeckoVisualizers.XMLVisualizer),
			       typeof (VisualizerObjectSource),
			       Target = typeof (System.String),
			       Description = "View as XML")]
#endif
