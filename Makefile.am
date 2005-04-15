ASSEMBLY=DebuggerVisualizers.dll

if ENABLE_GECKO_VISUALIZERS
GECKO_SOURCES=	gecko/HTMLVisualizer.cs \
		gecko/XMLVisualizer.cs \
		gecko/GeckoWindow.cs

GECKO_FLAGS= -define:ENABLE_GECKO_VISUALIZERS

GLADE_FILES=gecko/geckovis.glade

RESOURCES=
	/resource:./gecko/geckovis.glade,geckovis.glade
endif

CSFILES=AssemblyInfo.cs \
	DebugAttributes.cs \
	corlib/StringVisualizer.cs \
	gtk/PixbufVisualizer.cs
	$(GECKO_SOURCES)

CSFLAGS=-g $(GECKO_FLAGS)

$(ASSSEMBLY): $(SOURCES) $(GLADE_FILES)
	$(CSC) $(CSFLAGS) -target:library -out:$@ $(SOURCES) $(GLADE_SHARP_LIBS) $(GECKO_SHARP_LIBS) -r:/home/toshok/src/mono/MonoDevelop/build/AddIns/DebuggerAddIn/MonoDevelop.Visualizers.dll $(RESOURCES)
