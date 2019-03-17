using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable IDE1006 // Naming Styles

namespace DeviceManagerGUI
{
	public enum Flag
	{
		WT_EXECUTEDEFAULT = 0x00000000,
		WT_EXECUTEINIOTHREAD = 0x00000001,
		//WT_EXECUTEINWAITTHREAD       = 0x00000004,
		WT_EXECUTEONLYONCE = 0x00000008,
		WT_EXECUTELONGFUNCTION = 0x00000010,
		WT_EXECUTEINTIMERTHREAD = 0x00000020,
		WT_EXECUTEINPERSISTENTTHREAD = 0x00000080,
		//WT_TRANSFER_IMPERSONATION    = 0x00000100
	}

	public enum DtrControl : int
	{
		Disable = 0,
		Enable = 1,
		Handshake = 2
	};

	public enum RtsControl : int
	{
		Disable = 0,
		Enable = 1,
		Handshake = 2,
		Toggle = 3
	};


	public class DeclareWin32
	{
		public delegate void WaitOrTimerDelegate(IntPtr lpParameter, bool timerOrWaitFired);

		public const short FORMAT_MESSAGE_FROM_SYSTEM = 0X1000;

		public const int FILE_FLAG_OVERLAPPED = 0X40000000;
		public const int FILE_ATTRIBUTE_NORMAL = 0x00000080;
		public const int FILE_FLAG_NO_BUFFERING = 0x20000000;

		public const int FILE_SHARE_READ = 1;
		public const int FILE_SHARE_WRITE = 2;
		public const uint GENERIC_READ = 0X80000000;
		public const uint GENERIC_WRITE = 0X40000000;
		public const int INVALID_HANDLE_VALUE = -1;
		public const int OPEN_EXISTING = 3;
		public const int WAIT_TIMEOUT = 0X102;
		public const int WAIT_OBJECT_0 = 0;

		public const uint MAXDWORD = 0xffffffff;

		public const uint ERROR_SUCCESS = 0;
		public const uint ERROR_FILE_NOT_FOUND = 2;
		public const uint ERROR_PATH_NOT_FOUND = 3;
		public const uint ERROR_ACCESS_DENIED = 5;
		public const uint ERROR_INVALID_HANDLE = 6;
		public const uint ERROR_OUTOFMEMORY = 14;
		public const uint ERROR_SHARING_VIOLATION = 32;
		public const uint ERROR_HANDLE_EOF = 38;
		public const uint ERROR_NOT_SUPPORTED = 50;
		public const uint ERROR_DUP_NAME = 52;
		public const uint ERROR_BAD_NETPATH = 53;
		public const uint ERROR_INVALID_PARAMETER = 87;
		public const uint ERROR_BUFFER_OVERFLOW = 111;
		public const uint ERROR_INVALID_NAME = 123;
		public const uint ERROR_BAD_PATHNAME = 161;
		public const uint ERROR_ALREADY_EXISTS = 183;
		public const uint ERROR_MORE_DATA = 234;
		public const uint ERROR_NO_MORE_ITEMS = 259;
		public const uint ERROR_OPERATION_ABORTED = 995;
		public const uint ERROR_IO_PENDING = 997;
		public const uint ERROR_IO_DEVICE = 1117;
		public const uint ERROR_NOT_FOUND = 1168;
		public const uint ERROR_NO_SYSTEM_RESOURCES = 1450;
		public const uint ERROR_INVALID_USER_BUFFER = 1784;
		public const uint ERROR_CANT_RESOLVE_FILENAME = 1921;
		public const uint ERROR_INVALID_OPERATION = 4317;
		public const uint ERROR_INVALID_STATE = 5023;
		public const uint ERROR_LOG_SECTOR_PARITY_INVALID = 6601;
		public const uint ERROR_LOG_BLOCK_INCOMPLETE = 6603;
		public const uint ERROR_LOG_INVALID_RANGE = 6604;
		public const uint ERROR_LOG_READ_CONTEXT_INVALID = 6606;
		public const uint ERROR_LOG_BLOCK_VERSION = 6608;
		public const uint ERROR_LOG_BLOCK_INVALID = 6609;
		public const uint ERROR_LOG_NO_RESTART = 6611;
		public const uint ERROR_LOG_METADATA_CORRUPT = 6612;
		public const uint ERROR_LOG_RESERVATION_INVALID = 6615;
		public const uint ERROR_LOG_CANT_DELETE = 6616;
		public const uint ERROR_LOG_START_OF_LOG = 6618;
		public const uint ERROR_LOG_POLICY_NOT_INSTALLED = 6620;
		public const uint ERROR_LOG_POLICY_INVALID = 6621;
		public const uint ERROR_LOG_POLICY_CONFLICT = 6622;
		public const uint ERROR_LOG_TAIL_INVALID = 6627;
		public const uint ERROR_LOG_FULL = 6628;
		public const uint ERROR_LOG_NOT_ENOUGH_CONTAINERS = 6635;
		public const uint ERROR_LOG_FULL_HANDLER_IN_PROGRESS = 6638;


		// More error codes from simple file log -
		public const uint ERROR_MEDIUM_FULL = 112;
		public const uint ERROR_DISK_FULL = 127;
		public const uint ERROR_INVALID_HEADER = 251;
		public const uint ERROR_FILE_CORRUPT = 258;
		public const uint ERROR_E_OLDFORMAT = 260;

		///<summary >
		// API declarations relating to device management (SetupDixxx and 
		// RegisterDeviceNotification functions).   
		/// </summary>

		// from dbt.h

		public const int DBT_DEVICEARRIVAL = 0X8000;
		public const int DBT_DEVICEREMOVECOMPLETE = 0X8004;
		public const int DBT_DEVTYP_DEVICEINTERFACE = 5;
		public const int DBT_DEVTYP_HANDLE = 6;
		public const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 4;
		public const int DEVICE_NOTIFY_SERVICE_HANDLE = 1;
		public const int DEVICE_NOTIFY_WINDOW_HANDLE = 0;
		public const int WM_DEVICECHANGE = 0X219;

		// from setupapi.h

		public const int DIGCF_PRESENT = 2;
		public const int DIGCF_DEVICEINTERFACE = 0X10;

		public const int CE_RXOVER = 0x01;
		public const int CE_OVERRUN = 0x02;
		public const int CE_PARITY = 0x04;
		public const int CE_FRAME = 0x08;
		public const int CE_BREAK = 0x10;
		public const int CE_TXFULL = 0x100;

		// Two declarations for the DEV_BROADCAST_DEVICEINTERFACE structure.

		// Use this one in the call to RegisterDeviceNotification() and
		// in checking dbch_devicetype in a DEV_BROADCAST_HDR structure:

		[StructLayout(LayoutKind.Sequential)]
		public class DEV_BROADCAST_DEVICEINTERFACE
		{
			public int dbcc_size;
			public int dbcc_devicetype;
			public int dbcc_reserved;
			public Guid dbcc_classguid;
			public short dbcc_name;
		}

		// Use this to read the dbcc_name String and classguid:

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public class DEV_BROADCAST_DEVICEINTERFACE_1
		{
			public int dbcc_size;
			public int dbcc_devicetype;
			public int dbcc_reserved;
			[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 16)]
			public byte[] dbcc_classguid;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
			public char[] dbcc_name;
		}

		[StructLayout(LayoutKind.Sequential)]
		public class DEV_BROADCAST_HDR
		{
			public int dbch_size;
			public int dbch_devicetype;
			public int dbch_reserved;
		}

		public struct SP_DEVICE_INTERFACE_DATA
		{
			public int cbSize;
			public System.Guid InterfaceClassGuid;
			public int Flags;
			public IntPtr Reserved;
		}

		public struct SP_DEVICE_INTERFACE_DETAIL_DATA
		{
			public int cbSize;
			public string DevicePath;
		}

		public struct SP_DEVINFO_DATA
		{
			public int cbSize;
			public System.Guid ClassGuid;
			public int DevInst;
			public int Reserved;
		}

		public const string Kernel32 = "Kernel32.dll";
		public const string User32 = "user32.dll";
		public const string SetupApi = "setupapi.dll";
		public const string Hid = "hid.dll";

		[StructLayout(LayoutKind.Sequential)]
		public class SECURITY_ATTRIBUTES
		{
			public int nLength;
			public int lpSecurityDescriptor;
			public int bInheritHandle;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct COMMTIMEOUTS
		{
			public uint ReadIntervalTimeout;
			public uint ReadTotalTimeoutMultiplier;
			public uint ReadTotalTimeoutConstant;
			public uint WriteTotalTimeoutMultiplier;
			public uint WriteTotalTimeoutConstant;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct COMMCONFIG
		{
			public int dwSize;
			public short wVersion;
			public short wReserved;
			public DCB dcbx;
			public int dwProviderSubType;
			public int dwProviderOffset;
			public int dwProviderSize;
			public byte wcProviderData;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct COMSTAT
		{
			public const uint fCtsHold = 0x1;
			public const uint fDsrHold = 0x2;
			public const uint fRlsdHold = 0x4;
			public const uint fXoffHold = 0x8;
			public const uint fXoffSent = 0x10;
			public const uint fEof = 0x20;
			public const uint fTxim = 0x40;
			public uint Flags;
			public uint cbInQue;
			public uint cbOutQue;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct DCB
		{
			internal uint DCBLength;
			internal uint BaudRate;
			private BitVector32 Flags;

			//I've missed some members...
			internal uint wReserved;        // not currently used 
			internal uint XonLim;           // transmit XON threshold 
			internal uint XoffLim;          // transmit XOFF threshold             

			internal byte ByteSize;
			internal Parity Parity;
			internal StopBits StopBits;

			//...and some more
			internal char XonChar;          // Tx and Rx XON character 
			internal char XoffChar;         // Tx and Rx XOFF character 
			internal char ErrorChar;        // error replacement character 
			internal char EofChar;          // end of input character 
			internal char EvtChar;          // received event character 
			internal uint wReserved1;       // reserved; do not use     

			private static readonly int fBinary;
			private static readonly int fParity;
			private static readonly int fOutxCtsFlow;
			private static readonly int fOutxDsrFlow;
			private static readonly BitVector32.Section fDtrControl;
			private static readonly int fDsrSensitivity;
			private static readonly int fTXContinueOnXoff;
			private static readonly int fOutX;
			private static readonly int fInX;
			private static readonly int fErrorChar;
			private static readonly int fNull;
			private static readonly BitVector32.Section fRtsControl;
			private static readonly int fAbortOnError;

			static DCB()
			{
				fBinary = BitVector32.CreateMask();
				fParity = BitVector32.CreateMask(fBinary);
				fOutxCtsFlow = BitVector32.CreateMask(fParity);
				fOutxDsrFlow = BitVector32.CreateMask(fOutxCtsFlow);
				// Create Boolean Mask
				int previousMask = BitVector32.CreateMask(fOutxDsrFlow);
				previousMask = BitVector32.CreateMask(previousMask);
				fDsrSensitivity = BitVector32.CreateMask(previousMask);
				fTXContinueOnXoff = BitVector32.CreateMask(fDsrSensitivity);
				fOutX = BitVector32.CreateMask(fTXContinueOnXoff);
				fInX = BitVector32.CreateMask(fOutX);
				fErrorChar = BitVector32.CreateMask(fInX);
				fNull = BitVector32.CreateMask(fErrorChar);
				previousMask = BitVector32.CreateMask(fNull);
				previousMask = BitVector32.CreateMask(previousMask);
				fAbortOnError = BitVector32.CreateMask(previousMask);

				// Create section Mask
				BitVector32.Section previousSection;
				previousSection = BitVector32.CreateSection(1);
				previousSection = BitVector32.CreateSection(1, previousSection);
				previousSection = BitVector32.CreateSection(1, previousSection);
				previousSection = BitVector32.CreateSection(1, previousSection);
				fDtrControl = BitVector32.CreateSection(2, previousSection);
				previousSection = BitVector32.CreateSection(1, fDtrControl);
				previousSection = BitVector32.CreateSection(1, previousSection);
				previousSection = BitVector32.CreateSection(1, previousSection);
				previousSection = BitVector32.CreateSection(1, previousSection);
				previousSection = BitVector32.CreateSection(1, previousSection);
				previousSection = BitVector32.CreateSection(1, previousSection);
				fRtsControl = BitVector32.CreateSection(3, previousSection);
				previousSection = BitVector32.CreateSection(1, fRtsControl);
			}

			public bool Binary
			{
				get => Flags[fBinary];
				set => Flags[fBinary] = value;
			}

			public bool CheckParity
			{
				get => Flags[fParity];
				set => Flags[fParity] = value;
			}

			public bool OutxCtsFlow
			{
				get => Flags[fOutxCtsFlow];
				set => Flags[fOutxCtsFlow] = value;
			}

			public bool OutxDsrFlow
			{
				get => Flags[fOutxDsrFlow];
				set => Flags[fOutxDsrFlow] = value;
			}

			public DtrControl DtrControl
			{
				get => (DtrControl)Flags[fDtrControl];
				set => Flags[fDtrControl] = (int)value;
			}

			public bool DsrSensitivity
			{
				get => Flags[fDsrSensitivity];
				set => Flags[fDsrSensitivity] = value;
			}

			public bool TXContinueOnXoff
			{
				get => Flags[fTXContinueOnXoff];
				set => Flags[fTXContinueOnXoff] = value;
			}

			public bool OutX
			{
				get => Flags[fOutX];
				set => Flags[fOutX] = value;
			}

			public bool InX
			{
				get => Flags[fInX];
				set => Flags[fInX] = value;
			}

			public bool ReplaceErrorChar
			{
				get => Flags[fErrorChar];
				set => Flags[fErrorChar] = value;
			}

			public bool Null
			{
				get => Flags[fNull];
				set => Flags[fNull] = value;
			}

			public RtsControl RtsControl
			{
				get => (RtsControl)Flags[fRtsControl];
				set => Flags[fRtsControl] = (int)value;
			}

			public bool AbortOnError
			{
				get => Flags[fAbortOnError];
				set => Flags[fAbortOnError] = value;
			}
		}

		#region Kernel32

		#region Timer

		[DllImport(Kernel32)]
		public static extern int QueryPerformanceCounter(ref long count);
		[DllImport(Kernel32)]
		public static extern int QueryPerformanceFrequency(ref long frequency);
		[DllImport(Kernel32)]
		public static extern bool CreateTimerQueueTimer(
			out IntPtr phNewTimer,          // phNewTimer - Pointer to a handle; this is an out value
			IntPtr TimerQueue,              // TimerQueue - Timer queue handle. For the default timer queue, NULL
			WaitOrTimerDelegate Callback,   // Callback - Pointer to the callback function
			IntPtr Parameter,               // Parameter - Value passed to the callback function
			uint DueTime,                   // DueTime - Time (milliseconds), before the timer is set to the signaled state for the first time 
			uint Period,                    // Period - Timer period (milliseconds). If zero, timer is signaled only once
			uint Flags                      // Flags - One or more of the next values (table taken from MSDN):
											// WT_EXECUTEINTIMERTHREAD 	The callback function is invoked by the timer thread itself. This flag should be used only for short tasks or it could affect other timer operations.
											// WT_EXECUTEINIOTHREAD 	The callback function is queued to an I/O worker thread. This flag should be used if the function should be executed in a thread that waits in an alertable state.

			// The callback function is queued as an APC. Be sure to address reentrancy issues if the function performs an alertable wait operation.
			// WT_EXECUTEINPERSISTENTTHREAD 	The callback function is queued to a thread that never terminates. This flag should be used only for short tasks or it could affect other timer operations.

			// Note that currently no worker thread is persistent, although no worker thread will terminate if there are any pending I/O requests.
			// WT_EXECUTELONGFUNCTION 	Specifies that the callback function can perform a long wait. This flag helps the system to decide if it should create a new thread.
			// WT_EXECUTEONLYONCE 	The timer will be set to the signaled state only once.
			);

		[DllImport(Kernel32)]
		public static extern bool DeleteTimerQueueTimer(
			IntPtr timerQueue,              // TimerQueue - A handle to the (default) timer queue
			IntPtr timer,                   // Timer - A handle to the timer
			IntPtr completionEvent          // CompletionEvent - A handle to an optional event to be signaled when the function is successful and all callback functions have completed. Can be NULL.
			);


		[DllImport(Kernel32)]
		public static extern bool DeleteTimerQueue(IntPtr TimerQueue);

		#endregion

		[DllImport(Kernel32, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle(IntPtr hObject);

		[DllImport(Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int FormatMessage(int dwFlags, ref long lpSource, int dwMessageId, int dwLanguageZId, string lpBuffer, int nSize, int Arguments);

		[DllImport(Kernel32, SetLastError = true)]
		public static extern int CancelIo(SafeFileHandle hFile);

		[DllImport(Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr CreateEvent(IntPtr SecurityAttributes, bool bManualReset, bool bInitialState, string lpName);

		[DllImport(Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, IntPtr lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);

		//[DllImport(DeclareWin32.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		//public static extern SafeFileHandle CreateFile(String lpFileName, UInt32 dwDesiredAccess, Int32 dwShareMode, IntPtr lpSecurityAttributes, Int32 dwCreationDisposition, Int32 dwFlagsAndAttributes, Int32 hTemplateFile);


		[DllImport(Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool GetOverlappedResult(SafeFileHandle hFile, IntPtr lpOverlapped, ref int lpNumberOfBytesTransferred, bool bWait);

		[DllImport(Kernel32, SetLastError = true)]
		public static extern bool ReadFile(IntPtr hFile, IntPtr lpBuffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, IntPtr lpOverlapped);

		[DllImport(Kernel32, SetLastError = true)]
		public static extern int WaitForSingleObject(IntPtr hHandle, int dwMilliseconds);

		[DllImport(Kernel32, SetLastError = true)]
		public static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWritten, IntPtr lpOverlapped);

		[DllImport(Kernel32, SetLastError = true)]
		public static extern bool GetCommTimeouts(IntPtr hFile, out COMMTIMEOUTS lpCommTimeouts);

		[DllImport(Kernel32, SetLastError = true)]
		public static extern bool SetCommTimeouts(IntPtr hFile, ref COMMTIMEOUTS lpCommTimeouts);

		[DllImport(Kernel32, SetLastError = true)]
		public static extern int GetCommConfig(IntPtr hCommDev, ref COMMCONFIG lpCC, ref int lpdwSize);

		[DllImport(Kernel32, SetLastError = true)]
		public static extern int SetCommConfig(IntPtr hCommDev, ref COMMCONFIG lpCC, int dwSize);

		[DllImport(Kernel32, SetLastError = true)]
		public static extern bool GetCommState(IntPtr hFile, ref DCB lpDCB);

		[DllImport(Kernel32, SetLastError = true)]
		public static extern bool SetCommState(IntPtr hFile, [In] ref DCB lpDCB);

		[DllImport(Kernel32, SetLastError = true)]
		public static extern bool ClearCommError(IntPtr hFile, ref int lpErrors, ref COMSTAT lpStat);


		#endregion

		#region user32

		[DllImport(User32, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr NotificationFilter, int Flags);

		[DllImport(User32, SetLastError = true)]
		public static extern bool UnregisterDeviceNotification(IntPtr Handle);

		#endregion

		#region setupapi

		[DllImport(SetupApi, SetLastError = true)]
		public static extern int SetupDiCreateDeviceInfoList(ref System.Guid ClassGuid, int hwndParent);

		[DllImport(SetupApi, SetLastError = true)]
		public static extern int SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

		[DllImport(SetupApi, SetLastError = true)]
		public static extern bool SetupDiEnumDeviceInterfaces(IntPtr DeviceInfoSet, IntPtr DeviceInfoData, ref System.Guid InterfaceClassGuid, int MemberIndex, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

		[DllImport(SetupApi, SetLastError = true, CharSet = CharSet.Auto)]
		public static extern IntPtr SetupDiGetClassDevs(ref System.Guid ClassGuid, IntPtr Enumerator, IntPtr hwndParent, int Flags);

		[DllImport(SetupApi, SetLastError = true, CharSet = CharSet.Auto)]
		public static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, IntPtr DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);


		#endregion

		#region hid

		//  API declarations for HID communications.

		//  from hidpi.h
		//  Typedef enum defines a set of integer constants for HidP_Report_Type

		public const short HidP_Input = 0;
		public const short HidP_Output = 1;
		public const short HidP_Feature = 2;

		[StructLayout(LayoutKind.Sequential)]
		public struct HIDD_ATTRIBUTES
		{
			public int Size;
			public ushort VendorID;
			public ushort ProductID;
			public ushort VersionNumber;
		}

		public struct HIDP_CAPS
		{
			public short Usage;
			public short UsagePage;
			public short InputReportByteLength;
			public short OutputReportByteLength;
			public short FeatureReportByteLength;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
			public short[] Reserved;
			public short NumberLinkCollectionNodes;
			public short NumberInputButtonCaps;
			public short NumberInputValueCaps;
			public short NumberInputDataIndices;
			public short NumberOutputButtonCaps;
			public short NumberOutputValueCaps;
			public short NumberOutputDataIndices;
			public short NumberFeatureButtonCaps;
			public short NumberFeatureValueCaps;
			public short NumberFeatureDataIndices;
		}

		//  If IsRange is false, UsageMin is the Usage and UsageMax is unused.
		//  If IsStringRange is false, StringMin is the String index and StringMax is unused.
		//  If IsDesignatorRange is false, DesignatorMin is the designator index and DesignatorMax is unused.

		public struct HidP_Value_Caps
		{
			public short UsagePage;
			public byte ReportID;
			public int IsAlias;
			public short BitField;
			public short LinkCollection;
			public short LinkUsage;
			public short LinkUsagePage;
			public int IsRange;
			public int IsStringRange;
			public int IsDesignatorRange;
			public int IsAbsolute;
			public int HasNull;
			public byte Reserved;
			public short BitSize;
			public short ReportCount;
			public short Reserved2;
			public short Reserved3;
			public short Reserved4;
			public short Reserved5;
			public short Reserved6;
			public int LogicalMin;
			public int LogicalMax;
			public int PhysicalMin;
			public int PhysicalMax;
			public short UsageMin;
			public short UsageMax;
			public short StringMin;
			public short StringMax;
			public short DesignatorMin;
			public short DesignatorMax;
			public short DataIndexMin;
			public short DataIndexMax;
		}

		[DllImport(Hid, SetLastError = true)]
		public static extern bool HidD_FlushQueue(SafeFileHandle HidDeviceObject);

		[DllImport(Hid, SetLastError = true)]
		public static extern bool HidD_FreePreparsedData(IntPtr PreparsedData);

		[DllImport(Hid, SetLastError = true)]
		public static extern bool HidD_GetAttributes(SafeFileHandle HidDeviceObject, ref HIDD_ATTRIBUTES Attributes);

		[DllImport(Hid, SetLastError = true)]
		public static extern bool HidD_GetFeature(SafeFileHandle HidDeviceObject, byte[] lpReportBuffer, int ReportBufferLength);

		[DllImport(Hid, SetLastError = true)]
		public static extern bool HidD_GetInputReport(SafeFileHandle HidDeviceObject, byte[] lpReportBuffer, int ReportBufferLength);

		[DllImport(Hid, SetLastError = true)]
		public static extern void HidD_GetHidGuid(ref System.Guid HidGuid);

		[DllImport(Hid, SetLastError = true)]
		public static extern bool HidD_GetNumInputBuffers(SafeFileHandle HidDeviceObject, ref int NumberBuffers);

		[DllImport(Hid, SetLastError = true)]
		public static extern bool HidD_GetPreparsedData(SafeFileHandle HidDeviceObject, ref IntPtr PreparsedData);

		[DllImport(Hid, SetLastError = true)]
		public static extern bool HidD_SetFeature(SafeFileHandle HidDeviceObject, byte[] lpReportBuffer, int ReportBufferLength);

		[DllImport(Hid, SetLastError = true)]
		public static extern bool HidD_SetNumInputBuffers(SafeFileHandle HidDeviceObject, int NumberBuffers);

		[DllImport(Hid, SetLastError = true)]
		public static extern bool HidD_SetOutputReport(SafeFileHandle HidDeviceObject, byte[] lpReportBuffer, int ReportBufferLength);

		[DllImport(Hid, SetLastError = true)]
		public static extern int HidP_GetCaps(IntPtr PreparsedData, ref HIDP_CAPS Capabilities);

		[DllImport(Hid, SetLastError = true)]
		public static extern int HidP_GetValueCaps(int ReportType, byte[] ValueCaps, ref int ValueCapsLength, IntPtr PreparsedData);

		#endregion

		#region ResultOfAPICall
		public static string ResultOfAPICall(string functionName)
		{
			int bytes = 0;
			int resultCode = 0;
			string resultString = "";
			resultString = new string(Convert.ToChar(0), 129);
			resultCode = Marshal.GetLastWin32Error();
			long temp = 0;
			bytes = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, ref temp, resultCode, 0, resultString.Trim(), 128, 0);
			if (bytes > 2)
			{
				resultString = resultString.Remove(bytes - 2, 2);
			}
			resultString = functionName + " Result=" + resultString.Substring(0, bytes - 2).Trim() + Environment.NewLine;
			return resultString;
		}
		#endregion

		#region ReadBytes
		public static unsafe bool ReadBytes(IntPtr file, int offset, int bytesToRead, ref int bytesRead, ref byte[] buffer)
		{
			fixed (byte* pBuffer = buffer)
			{
				var p = (IntPtr)(pBuffer + offset);
				if (ReadFile(file, p, bytesToRead, ref bytesRead, IntPtr.Zero))
				{
					return true;
				}
				return false;
			}
		}
		#endregion

	}

	/// <summary>
	/// Device registry property codes
	/// </summary>
	public enum SPDRP : uint
	{
		/// <summary>
		/// DeviceDesc (R/W)
		/// </summary>
		SPDRP_DEVICEDESC = 0x00000000,

		/// <summary>
		/// HardwareID (R/W)
		/// </summary>
		SPDRP_HARDWAREID = 0x00000001,

		/// <summary>
		/// CompatibleIDs (R/W)
		/// </summary>
		SPDRP_COMPATIBLEIDS = 0x00000002,

		/// <summary>
		/// unused
		/// </summary>
		SPDRP_UNUSED0 = 0x00000003,

		/// <summary>
		/// Service (R/W)
		/// </summary>
		SPDRP_SERVICE = 0x00000004,

		/// <summary>
		/// unused
		/// </summary>
		SPDRP_UNUSED1 = 0x00000005,

		/// <summary>
		/// unused
		/// </summary>
		SPDRP_UNUSED2 = 0x00000006,

		/// <summary>
		/// Class (R--tied to ClassGUID)
		/// </summary>
		SPDRP_CLASS = 0x00000007,

		/// <summary>
		/// ClassGUID (R/W)
		/// </summary>
		SPDRP_CLASSGUID = 0x00000008,

		/// <summary>
		/// Driver (R/W)
		/// </summary>
		SPDRP_DRIVER = 0x00000009,

		/// <summary>
		/// ConfigFlags (R/W)
		/// </summary>
		SPDRP_CONFIGFLAGS = 0x0000000A,

		/// <summary>
		/// Mfg (R/W)
		/// </summary>
		SPDRP_MFG = 0x0000000B,

		/// <summary>
		/// FriendlyName (R/W)
		/// </summary>
		SPDRP_FRIENDLYNAME = 0x0000000C,

		/// <summary>
		/// LocationInformation (R/W)
		/// </summary>
		SPDRP_LOCATION_INFORMATION = 0x0000000D,

		/// <summary>
		/// PhysicalDeviceObjectName (R)
		/// </summary>
		SPDRP_PHYSICAL_DEVICE_OBJECT_NAME = 0x0000000E,

		/// <summary>
		/// Capabilities (R)
		/// </summary>
		SPDRP_CAPABILITIES = 0x0000000F,

		/// <summary>
		/// UiNumber (R)
		/// </summary>
		SPDRP_UI_NUMBER = 0x00000010,

		/// <summary>
		/// UpperFilters (R/W)
		/// </summary>
		SPDRP_UPPERFILTERS = 0x00000011,

		/// <summary>
		/// LowerFilters (R/W)
		/// </summary>
		SPDRP_LOWERFILTERS = 0x00000012,

		/// <summary>
		/// BusTypeGUID (R)
		/// </summary>
		SPDRP_BUSTYPEGUID = 0x00000013,

		/// <summary>
		/// LegacyBusType (R)
		/// </summary>
		SPDRP_LEGACYBUSTYPE = 0x00000014,

		/// <summary>
		/// BusNumber (R)
		/// </summary>
		SPDRP_BUSNUMBER = 0x00000015,

		/// <summary>
		/// Enumerator Name (R)
		/// </summary>
		SPDRP_ENUMERATOR_NAME = 0x00000016,

		/// <summary>
		/// Security (R/W, binary form)
		/// </summary>
		SPDRP_SECURITY = 0x00000017,

		/// <summary>
		/// Security (W, SDS form)
		/// </summary>
		SPDRP_SECURITY_SDS = 0x00000018,

		/// <summary>
		/// Device Type (R/W)
		/// </summary>
		SPDRP_DEVTYPE = 0x00000019,

		/// <summary>
		/// Device is exclusive-access (R/W)
		/// </summary>
		SPDRP_EXCLUSIVE = 0x0000001A,

		/// <summary>
		/// Device Characteristics (R/W)
		/// </summary>
		SPDRP_CHARACTERISTICS = 0x0000001B,

		/// <summary>
		/// Device Address (R)
		/// </summary>
		SPDRP_ADDRESS = 0x0000001C,

		/// <summary>
		/// UiNumberDescFormat (R/W)
		/// </summary>
		SPDRP_UI_NUMBER_DESC_FORMAT = 0X0000001D,

		/// <summary>
		/// Device Power Data (R)
		/// </summary>
		SPDRP_DEVICE_POWER_DATA = 0x0000001E,

		/// <summary>
		/// Removal Policy (R)
		/// </summary>
		SPDRP_REMOVAL_POLICY = 0x0000001F,

		/// <summary>
		/// Hardware Removal Policy (R)
		/// </summary>
		SPDRP_REMOVAL_POLICY_HW_DEFAULT = 0x00000020,

		/// <summary>
		/// Removal Policy Override (RW)
		/// </summary>
		SPDRP_REMOVAL_POLICY_OVERRIDE = 0x00000021,

		/// <summary>
		/// Device Install State (R)
		/// </summary>
		SPDRP_INSTALL_STATE = 0x00000022,

		/// <summary>
		/// Device Location Paths (R)
		/// </summary>
		SPDRP_LOCATION_PATHS = 0x00000023,
	}

	#region Unmanaged

	public class Native
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, DEV_BROADCAST_DEVICEINTERFACE NotificationFilter, uint Flags);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern uint UnregisterDeviceNotification(IntPtr hHandle);

		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern IntPtr SetupDiGetClassDevs(ref Guid gClass, uint iEnumerator, IntPtr hParent, uint nFlags);

		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern int SetupDiDestroyDeviceInfoList(IntPtr lpInfoSet);

		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern bool SetupDiEnumDeviceInfo(IntPtr lpInfoSet, uint dwIndex, ref SP_DEVINFO_DATA devInfoData);
		//[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		//public static extern bool SetupDiGetDeviceRegistryProperty(
		//IntPtr deviceInfoSet,ref SP_DEVINFO_DATA deviceInfoData, uint property,out UInt32 propertyRegDataType, byte[] propertyBuffer, uint propertyBufferSize, out UInt32 requiredSize);

		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern bool SetupDiGetDeviceRegistryProperty(
			IntPtr lpInfoSet, ref SP_DEVINFO_DATA DeviceInfoData, uint Property, out uint PropertyRegDataType, StringBuilder PropertyBuffer, uint PropertyBufferSize, IntPtr RequiredSize);

		[DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern bool SetupDiSetClassInstallParams(IntPtr DeviceInfoSet, IntPtr DeviceInfoData, IntPtr ClassInstallParams, int ClassInstallParamsSize);

		[DllImport("setupapi.dll", SetLastError = true)]
		public static extern bool SetupDiChangeState(IntPtr deviceInfoSet, ref SP_DEVINFO_DATA deviceInfoData);

		[DllImport("setupapi.dll", CharSet = CharSet.Auto)]
		public static extern bool SetupDiCallClassInstaller(uint InstallFunction, IntPtr DeviceInfoSet, IntPtr DeviceInfoData);

		// Structure with information for RegisterDeviceNotification.
		[StructLayout(LayoutKind.Sequential)]
		public struct DEV_BROADCAST_HANDLE
		{
			public int dbch_size;
			public int dbch_devicetype;
			public int dbch_reserved;
			public IntPtr dbch_handle;
			public IntPtr dbch_hdevnotify;
			public Guid dbch_eventguid;
			public long dbch_nameoffset;
			public byte dbch_data;
			public byte dbch_data1;
		}

		// Struct for parameters of the WM_DEVICECHANGE message
		[StructLayout(LayoutKind.Sequential)]
		public class DEV_BROADCAST_DEVICEINTERFACE
		{
			public int dbcc_size;
			public int dbcc_devicetype;
			public int dbcc_reserved;
		}

		//SP_DEVINFO_DATA
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct SP_DEVINFO_DATA
		{
			public int cbSize;
			public Guid classGuid;
			public int devInst;
			public IntPtr reserved;
		};

		[StructLayout(LayoutKind.Sequential)]
		public class SP_DEVINSTALL_PARAMS
		{
			public int cbSize;
			public int Flags;
			public int FlagsEx;
			public IntPtr hwndParent;
			public IntPtr InstallMsgHandler;
			public IntPtr InstallMsgHandlerContext;
			public IntPtr FileQueue;
			public IntPtr ClassInstallReserved;
			public int Reserved;
			[MarshalAs(UnmanagedType.LPTStr)]
			public string DriverPath;
		};

		[StructLayout(LayoutKind.Sequential)]
		public struct SP_PROPCHANGE_PARAMS
		{
			public SP_CLASSINSTALL_HEADER ClassInstallHeader;
			public int StateChange;
			public int Scope;
			public int HwProfile;
		};

		[StructLayout(LayoutKind.Sequential)]
		public struct SP_CLASSINSTALL_HEADER
		{
			public int cbSize;
			public int InstallFunction;
		};

		//PARMS
		public const int DIGCF_ALLCLASSES = 0x00000004;
		public const int DIGCF_PRESENT = 0x00000002;
		public const int INVALID_HANDLE_VALUE = -1;
		public const int SPDRP_DEVICEDESC = 0x00000000;
		public const int MAX_DEV_LEN = 1000;
		public const int DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000;
		public const int DEVICE_NOTIFY_SERVICE_HANDLE = 0x00000001;
		public const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 0x00000004;
		public const int DBT_DEVTYP_DEVICEINTERFACE = 0x00000005;
		public const int DBT_DEVNODES_CHANGED = 0x0007;
		public const int WM_DEVICECHANGE = 0x0219;
		public const int DIF_PROPERTYCHANGE = 0x00000012;
		public const int DICS_FLAG_GLOBAL = 0x00000001;
		public const int DICS_FLAG_CONFIGSPECIFIC = 0x00000002;
		public const int DICS_ENABLE = 0x00000001;
		public const int DICS_DISABLE = 0x00000002;
	}

	#endregion

	public class HH_Lib
	{
		private readonly Version m_Version = new Version(1, 0, 0);

		#region Public Methods

		//Name:     GetAll
		//Inputs:   none
		//Outputs:  string array
		//Errors:   This method may throw the following errors.
		//          Failed to enumerate device tree!
		//          Invalid handle!
		//Remarks:  This is code I cobbled together from a number of newsgroup threads
		//          as well as some C++ stuff I translated off of MSDN.  Seems to work.
		//          The idea is to come up with a list of devices, same as the device
		//          manager does.  Currently it uses the actual "system" names for the
		//          hardware.  It is also possible to use hardware IDs.  See the docs
		//          for SetupDiGetDeviceRegistryProperty in the MS SDK for more details.
		public string[] GetAll()
		{
			var HWList = new List<string>();
			uint propertyRegDataType = 0;
			try
			{
				var myGUID = Guid.Empty;
				var hDevInfo = Native.SetupDiGetClassDevs(ref myGUID, 0, IntPtr.Zero, Native.DIGCF_ALLCLASSES | Native.DIGCF_PRESENT);
				if (hDevInfo.ToInt32() == Native.INVALID_HANDLE_VALUE)
				{
					throw new Exception("Invalid Handle");
				}
				Native.SP_DEVINFO_DATA DeviceInfoData;
				DeviceInfoData = new Native.SP_DEVINFO_DATA();
				DeviceInfoData.cbSize = Marshal.SizeOf(DeviceInfoData);
				//is devices exist for class
				DeviceInfoData.devInst = 0;
				DeviceInfoData.classGuid = Guid.Empty;
				DeviceInfoData.reserved = IntPtr.Zero;
				uint i;
				var DeviceName = new StringBuilder("")
				{
					Capacity = Native.MAX_DEV_LEN
				};
				string s = "";
				for (i = 0; Native.SetupDiEnumDeviceInfo(hDevInfo, i, ref DeviceInfoData); i++)
				{
					//Declare vars
					while (!Native.SetupDiGetDeviceRegistryProperty(hDevInfo,
																	ref DeviceInfoData,
																	(uint)SPDRP.SPDRP_DEVICEDESC,
																	out propertyRegDataType,
																	DeviceName,
																	Native.MAX_DEV_LEN,
																	IntPtr.Zero))
					{
						//Skip
						s = DeviceName.ToString();
						if (s.ToLower().Contains("prolific"))
						{
							s += "";
						}
					}
					var my = new StringBuilder();
					if (i == 67 || i == 89)
					{

						while (!Native.SetupDiGetDeviceRegistryProperty(hDevInfo,
																	ref DeviceInfoData,
																	(uint)SPDRP.SPDRP_DRIVER,
																	out propertyRegDataType,
																	my,
																	Native.MAX_DEV_LEN,
																	IntPtr.Zero))
						{

						}
						s += "";
						while (!Native.SetupDiGetDeviceRegistryProperty(hDevInfo,
																	ref DeviceInfoData,
																	(uint)SPDRP.SPDRP_FRIENDLYNAME,
																	out propertyRegDataType,
																	my,
																	Native.MAX_DEV_LEN,
																	IntPtr.Zero))
						{

						}


						s += "";
					}
					HWList.Add(DeviceName.ToString());
					//Skip
					s = DeviceName.ToString();
					if (s.ToLower().Contains("prolific"))
					{
						s += "";
					}
				}
				Native.SetupDiDestroyDeviceInfoList(hDevInfo);
			}
			catch (Exception ex)
			{
				throw new Exception("Failed to enumerate device tree!", ex);
			}
			return HWList.ToArray();
		}
		//Name:     SetDeviceState
		//Inputs:   string[],bool
		//Outputs:  bool
		//Errors:   This method may throw the following exceptions.
		//          Failed to enumerate device tree!
		//Remarks:  This is nearly identical to the method above except it
		//          tries to match the hardware description against the criteria
		//          passed in.  If a match is found, that device will the be
		//          enabled or disabled based on bEnable.
		public bool SetDeviceState(string[] match, bool bEnable)
		{
			bool success = false;
			try
			{
				uint propertyRegDataType = 0;
				var myGUID = Guid.Empty;
				var hDevInfo = Native.SetupDiGetClassDevs(ref myGUID, 0, IntPtr.Zero, Native.DIGCF_ALLCLASSES | Native.DIGCF_PRESENT);
				if (hDevInfo.ToInt32() == Native.INVALID_HANDLE_VALUE)
				{
					return false;
				}
				Native.SP_DEVINFO_DATA DeviceInfoData;
				DeviceInfoData = new Native.SP_DEVINFO_DATA();
				DeviceInfoData.cbSize = Marshal.SizeOf(DeviceInfoData);
				//is devices exist for class
				DeviceInfoData.devInst = 0;
				DeviceInfoData.classGuid = Guid.Empty;
				DeviceInfoData.reserved = IntPtr.Zero;
				uint i;
				var DeviceName = new StringBuilder("")
				{
					Capacity = Native.MAX_DEV_LEN
				};
				for (i = 0; Native.SetupDiEnumDeviceInfo(hDevInfo, i, ref DeviceInfoData); i++)
				{
					//Declare vars
					while (!Native.SetupDiGetDeviceRegistryProperty(hDevInfo,
																	ref DeviceInfoData,
																	Native.SPDRP_DEVICEDESC,
																	out propertyRegDataType,
																	DeviceName,
																	Native.MAX_DEV_LEN,
																	IntPtr.Zero))
					{
						//Skip
					}
					bool bMatch = true;
					foreach (string search in match)
					{
						if (!DeviceName.ToString().ToLower().Contains(search.ToLower()))
						{
							bMatch = false;
							break;
						}
					}
					if (bMatch)
					{
						ChangeIt(hDevInfo, DeviceInfoData, bEnable);
					}
				}
				Native.SetupDiDestroyDeviceInfoList(hDevInfo);
				success = true;
			}
			catch (Exception ex)
			{
				throw new Exception("Failed to enumerate device tree!", ex);
			}
			return success;
		}
		//Name:     HookHardwareNotifications
		//Inputs:   Handle to a window or service, 
		//          Boolean specifying true if the handle belongs to a window
		//Outputs:  false if fail, otherwise true
		//Errors:   This method may log the following errors.
		//          NONE
		//Remarks:  Allow a window or service to receive ALL hardware notifications.
		//          NOTE: I have yet to figure out how to make this work properly
		//          for a service written in C#, though it kicks butt in C++.  At any
		//          rate, it works fine for windows forms in either.
		public bool HookHardwareNotifications(IntPtr callback, bool UseWindowHandle)
		{
			try
			{
				var dbdi = new Native.DEV_BROADCAST_DEVICEINTERFACE();
				dbdi.dbcc_size = Marshal.SizeOf(dbdi);
				dbdi.dbcc_reserved = 0;
				dbdi.dbcc_devicetype = Native.DBT_DEVTYP_DEVICEINTERFACE;
				if (UseWindowHandle)
				{
					Native.RegisterDeviceNotification(callback,
						dbdi,
						Native.DEVICE_NOTIFY_ALL_INTERFACE_CLASSES |
						Native.DEVICE_NOTIFY_WINDOW_HANDLE);
				}
				else
				{
					Native.RegisterDeviceNotification(callback,
						dbdi,
						Native.DEVICE_NOTIFY_ALL_INTERFACE_CLASSES |
						Native.DEVICE_NOTIFY_SERVICE_HANDLE);
				}
				return true;
			}
			catch (Exception ex)
			{
				string err = ex.Message;
				return false;
			}
		}
		//Name:     CutLooseHardareNotifications
		//Inputs:   handle used when hooking
		//Outputs:  None
		//Errors:   This method may log the following errors.
		//          NONE
		//Remarks:  Cleans up unmanaged resources.  
		public void CutLooseHardwareNotifications(IntPtr callback)
		{
			try
			{
				Native.UnregisterDeviceNotification(callback);
			}
			catch
			{
				//Just being extra cautious since the code is unmanged
			}
		}
		#endregion

		#region Private Methods

		//Name:     ChangeIt
		//Inputs:   pointer to hdev, SP_DEV_INFO, bool
		//Outputs:  bool
		//Errors:   This method may throw the following exceptions.
		//          Unable to change device state!
		//Remarks:  Attempts to enable or disable a device driver.  
		//          IMPORTANT NOTE!!!   This code currently does not check the reboot flag.
		//          =================   Some devices require you reboot the OS for the change
		//                              to take affect.  If this describes your device, you 
		//                              will need to look at the SDK call:
		//                              SetupDiGetDeviceInstallParams.  You can call it 
		//                              directly after ChangeIt to see whether or not you need 
		//                              to reboot the OS for you change to go into effect.
		private bool ChangeIt(IntPtr hDevInfo, Native.SP_DEVINFO_DATA devInfoData, bool bEnable)
		{
			try
			{
				//Marshalling vars
				int szOfPcp;
				IntPtr ptrToPcp;
				int szDevInfoData;
				IntPtr ptrToDevInfoData;

				var pcp = new Native.SP_PROPCHANGE_PARAMS();
				if (bEnable)
				{
					pcp.ClassInstallHeader.cbSize = Marshal.SizeOf(typeof(Native.SP_CLASSINSTALL_HEADER));
					pcp.ClassInstallHeader.InstallFunction = Native.DIF_PROPERTYCHANGE;
					pcp.StateChange = Native.DICS_ENABLE;
					pcp.Scope = Native.DICS_FLAG_GLOBAL;
					pcp.HwProfile = 0;

					//Marshal the params
					szOfPcp = Marshal.SizeOf(pcp);
					ptrToPcp = Marshal.AllocHGlobal(szOfPcp);
					Marshal.StructureToPtr(pcp, ptrToPcp, true);
					szDevInfoData = Marshal.SizeOf(devInfoData);
					ptrToDevInfoData = Marshal.AllocHGlobal(szDevInfoData);

					if (Native.SetupDiSetClassInstallParams(hDevInfo, ptrToDevInfoData, ptrToPcp, Marshal.SizeOf(typeof(Native.SP_PROPCHANGE_PARAMS))))
					{
						Native.SetupDiCallClassInstaller(Native.DIF_PROPERTYCHANGE, hDevInfo, ptrToDevInfoData);
					}
					pcp.ClassInstallHeader.cbSize = Marshal.SizeOf(typeof(Native.SP_CLASSINSTALL_HEADER));
					pcp.ClassInstallHeader.InstallFunction = Native.DIF_PROPERTYCHANGE;
					pcp.StateChange = Native.DICS_ENABLE;
					pcp.Scope = Native.DICS_FLAG_CONFIGSPECIFIC;
					pcp.HwProfile = 0;
				}
				else
				{
					pcp.ClassInstallHeader.cbSize = Marshal.SizeOf(typeof(Native.SP_CLASSINSTALL_HEADER));
					pcp.ClassInstallHeader.InstallFunction = Native.DIF_PROPERTYCHANGE;
					pcp.StateChange = Native.DICS_DISABLE;
					pcp.Scope = Native.DICS_FLAG_CONFIGSPECIFIC;
					pcp.HwProfile = 0;
				}
				//Marshal the params
				szOfPcp = Marshal.SizeOf(pcp);
				ptrToPcp = Marshal.AllocHGlobal(szOfPcp);
				Marshal.StructureToPtr(pcp, ptrToPcp, true);
				szDevInfoData = Marshal.SizeOf(devInfoData);
				ptrToDevInfoData = Marshal.AllocHGlobal(szDevInfoData);
				Marshal.StructureToPtr(devInfoData, ptrToDevInfoData, true);

				bool rslt1 = Native.SetupDiSetClassInstallParams(hDevInfo, ptrToDevInfoData, ptrToPcp, Marshal.SizeOf(typeof(Native.SP_PROPCHANGE_PARAMS)));
				bool rstl2 = Native.SetupDiCallClassInstaller(Native.DIF_PROPERTYCHANGE, hDevInfo, ptrToDevInfoData);
				if (!rslt1 || !rstl2)
				{
					throw new Exception("Unable to change device state!");
				}
				else
				{
					return true;
				}
			}
			catch { }
			return false;
		}
		#endregion
	}
}
