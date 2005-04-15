if ENABLE_GECKO_VISUALIZERS
GECKO_CSFILES=gecko/HTMLVisualizer.cs \
	      gecko/XMLVisualizer.cs \
	      gecko/GeckoWindow.cs

GECKO_FLAGS= -define:ENABLE_GECKO_VISUALIZERS

GECKO_GLADE_FILES=gecko/geckovis.glade

GECKO_RESOURCES= /resource:./gecko/geckovis.glade,geckovis.glade
endif

CSFILES=AssemblyInfo.cs \
	DebugAttributes.cs \
	corlib/StringVisualizer.cs \
	gtk/PixbufVisualizer.cs \
	$(GECKO_CSFILES)

GLADE_FILES=corlib/stringvis.glade gtk/pixbufvis.glade $(GECKO_GLADE_FILES)
RESOURCES= /resource:./corlib/stringvis.glade,stringvis.glade /resource:./gtk/pixbufvis.glade,pixbufvis.glade $(GECKO_RESOURCES)

CSFLAGS=-g $(GECKO_FLAGS)

noinst_DATA=DebuggerVisualizers.dll

DebuggerVisualizers.dll: $(CSFILES) $(GLADE_FILES)
	$(CSC) $(CSFLAGS) -target:library -out:$@ $(CSFILES) $(GLADE_SHARP_LIBS) $(GECKO_SHARP_LIBS) -r:/home/toshok/src/mono/MonoDevelop/build/AddIns/DebuggerAddIn/MonoDevelop.Visualizers.dll $(RESOURCES)
