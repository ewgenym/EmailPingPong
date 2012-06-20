﻿// Type: Microsoft.Office.Interop.Outlook.ItemsEvents_ItemChangeEventHandler
// Assembly: Microsoft.Office.Interop.Outlook, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c
// Assembly location: C:\Program Files (x86)\Microsoft Visual Studio 10.0\Visual Studio Tools for Office\PIA\Office14\Microsoft.Office.Interop.Outlook.dll

using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Outlook
{
	/// <summary>
	/// This is a delegate for an event in the corresponding object. After implementing a callback method for the event, use this delegate to connect the callback method to the event. If there are multiple versions of the event interface, this delegate connects the callback method for the event in the specified version of Outlook.
	/// </summary>
	/// <param name="Item">The item that was changed.</param>
	[ComVisible(false)]
	[TypeLibType(16)]
	public delegate void ItemsEvents_ItemChangeEventHandler([MarshalAs(UnmanagedType.IDispatch), In] object Item);
}
