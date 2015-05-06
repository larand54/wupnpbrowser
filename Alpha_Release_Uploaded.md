# Alpha Code and Binaries available #

A first basic version of the app is now available as binary MSI package. The sources of 0.1 (Alpha) can also be found in the svn. The application is a bit rough on the edges but it does some basic stuff:

  * Discovers any UPnP devices in the network
  * Finds any new devices added to the network while running
  * Should recognize when a device is removed from the network (have not been able to test this yet)
  * Displays details of the device selected in the tree view control

The next step would be to complete the detailed device information tab and add some more graphics to the UI to make it more complete.

This release has only been tested on my development box (32bit Win XP) so there might be pieces missing in the installer for a "clean" machine. It is built using Visual Studio 2005 on .Net 2.0.