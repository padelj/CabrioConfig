
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;TRACE"
ASSEMBLY = bin/Debug/CabrioConfig.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug/

CABRIOCONFIG_EXE_MDB_SOURCE=bin/Debug/CabrioConfig.exe.mdb
CABRIOCONFIG_EXE_MDB=$(BUILD_DIR)/CabrioConfig.exe.mdb

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-define:TRACE"
ASSEMBLY = bin/Release/CabrioConfig.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release/

CABRIOCONFIG_EXE_MDB=

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(CABRIOCONFIG_EXE_MDB)  

BINARIES = \
	$(CABRIOCONFIG)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES = \
	Form1.cs \
	Form1.Designer.cs \
	Program.cs \
	Properties/AssemblyInfo.cs \
	Properties/Resources.Designer.cs \
	Properties/Settings.Designer.cs 

DATA_FILES = 

RESOURCES = \
	Form1.resx,CabrioConfig.frmMain.resources \
	Properties/Resources.resx,CabrioConfig.Properties.Resources.resources 

EXTRAS = \
	Properties/Settings.settings \
	appconfig.xml \
	appconfig.xsd \
	Resources/action_add_16xLG.png \
	Resources/folder_Open_32xLG.png \
	Resources/save_16xLG.png \
	cabrioconfig.in 

REFERENCES =  \
	System \
	System.Core \
	System.Xml.Linq \
	System.Data.DataSetExtensions \
	Microsoft.CSharp \
	System.Data \
	System.Drawing \
	System.Windows.Forms \
	System.Xml

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

CABRIOCONFIG = $(BUILD_DIR)/cabrioconfig

$(eval $(call emit-deploy-wrapper,CABRIOCONFIG,cabrioconfig,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
