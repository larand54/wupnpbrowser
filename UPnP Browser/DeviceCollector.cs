using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using UPNPLib;
using System.Threading;
using System.Runtime.InteropServices;


namespace UPnP_Browser
{
    //
    // Declare the COM Interface for callback from the search
    //
    [ComVisible(true), ComImport,
    Guid("415A984A-88B3-49F3-92AF-0508BEDF0D6C"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IUPnPDeviceFinderCallback
    {
        [PreserveSig]
        int DeviceAdded([In] int lFindData,
       [In] IUPnPDevice pDevice);

        [PreserveSig]
        int DeviceRemoved([In] int lFindData,
       [In] string bstrUDN);

        [PreserveSig]
        int SearchComplete([In] int lFindData);
    }
    
    class DeviceCollector : IUPnPDeviceFinderCallback
    {
        private UPnPDeviceFinderClass _finder;
        private int _SearchId;

        public delegate void DeviceAddedEventHandler(UPnPDevice addeddevice);
        public delegate void DeviceRemovedEventHandler(string sUDN);
        public delegate void SearchCompletedEventHandler();

        public event DeviceAddedEventHandler DeviceAdded;
        public event DeviceRemovedEventHandler DeviceRemoved;
        public event SearchCompletedEventHandler SearchCompleted;

        
        public DeviceCollector()
        {
            _finder = new UPnPDeviceFinderClass();
            _SearchId = _finder.CreateAsyncFind("upnp:rootdevice", 0, this);
            _finder.StartAsyncFind(_SearchId);
        }

        ~DeviceCollector()
        {
            //_finder.CancelAsyncFind(_SearchId);
        }


        #region IUPnPDeviceFinderCallback Members

        int IUPnPDeviceFinderCallback.DeviceAdded(int lFindData, IUPnPDevice pDevice)
        {
            DeviceAdded((UPnPDevice)pDevice);
            return 0;
        }

        int IUPnPDeviceFinderCallback.DeviceRemoved(int lFindData, string bstrUDN)
        {
            DeviceRemoved(bstrUDN);
            return 0;
        }

        int IUPnPDeviceFinderCallback.SearchComplete(int lFindData)
        {
            SearchCompleted();
            return 0;
        }

        #endregion
    }
}
