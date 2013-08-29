CabrioConfig
============

Version 0.9 Beta


##Mono compliant C# project for editing and updating the Cabrio-FE for emulators config.xml.

Requires that you have created the mameinfo.xml file from the command
  
  mame -listxml >mameinfo.xml
  
This version will run on both Windows AND linux thanks to Mono.  
The WinForms branch, of course, is basically working at this point.  But please be aware that WinForms' 
FolderChooserDialog has an issue with *nix hidden directories.  It is possible to load and save files 
from hidden directories if you manualy type in their path, but you cannot use the browser to do it.  
You can also make 'soft' links to the hidden directories to work around it.

Also you must have a basic cabrio config.xml in place, by running cabrio the first time.  Right now it looks in 
$HOME/.cabrio/config.xml


I need some help getting NodeView to work in GTK using the Stetic Form Designer.  Any help would be greatly 
appreciated.


Required References
  Microsoft.CSharp
  System  
  System.Core  
  System.Data  
  System.Data.DataSetExtensions  
  System.Drawing  
  System.Windows.Forms  
  System.Xml  
  System.Xml.Linq  
  
Built with MonoDevelop/Xamian 4.0
