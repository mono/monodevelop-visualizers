CSC=mcs

SOURCES=AssemblyInfo.cs \
	DebugAttributes.cs \
	corlib/StringVisualizer.cs \
	gtk/PixbufVisualizer.cs \
	gecko/HTMLVisualizer.cs \
	gecko/XMLVisualizer.cs \
	gecko/GeckoWindow.cs

DebugAttributes.dll: $(SOURCES) gecko/geckovis.glade
	$(CSC) -g -target:library $(SOURCES) -pkg:glade-sharp-2.0 -pkg:gecko-sharp-2.0 -r:/home/toshok/src/mono/MonoDevelop/build/AddIns/DebuggerAddIn/MonoDevelop.Visualizers.dll /resource:./gecko/geckovis.glade,geckovis.glade
