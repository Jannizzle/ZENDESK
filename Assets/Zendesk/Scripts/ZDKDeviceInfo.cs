using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace ZendeskSDK {

	/// <summary>
	/// Helper class for retrieving device information.
	/// </summary>
	public class ZDKDeviceInfo {

		private static string _logTag = "ZDKDeviceInfo";
		
		public static void Log (string message) {
			if(Debug.isDebugBuild)
				Debug.Log(_logTag + "/" + message);
		}

		#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IPHONE)

		/// <summary>
		/// Returns a formatted strong of all device info.
		/// </summary>
		/// <returns>all device info</returns>
		public static string DeviceInfoString() {
			Log("Unity : DeviceInfoString");
			return "";
		}
		
		/// <summary>
		/// Returns an NSDictionary of all device info.all device info
		/// </summary>
		/// <returns></returns>
		public static Hashtable DeviceInfoDictionary() {
			Log("Unity : DeviceInfoDictionary");
			return new Hashtable();
		}

		#elif UNITY_IPHONE

		[DllImport("__Internal")]
		private static extern string _zendeskDeviceInfoString();
		[DllImport("__Internal")]
		private static extern string _zendeskDeviceInfoDictionary();

		public static string DeviceInfoString() {
			return _zendeskDeviceInfoString();
		}
		
		public static Hashtable DeviceInfoDictionary() {
			return (Hashtable) ZenJSON.Deserialize(_zendeskDeviceInfoDictionary());
		}

		#elif UNITY_ANDROID

		public static string DeviceInfoString() {
			AndroidJavaObject _plugin;
			using(var pluginClass = new AndroidJavaClass("com.zendesk.unity.ZDK_Plugin"))
			{
				_plugin = pluginClass.CallStatic<AndroidJavaObject>("instance");
			}
			return _plugin.Call<String> ("zendeskDeviceInfoString");
		}
		
		public static Hashtable DeviceInfoDictionary() {
			AndroidJavaObject _plugin;
			using(var pluginClass = new AndroidJavaClass("com.zendesk.unity.ZDK_Plugin"))
			{
				_plugin = pluginClass.CallStatic<AndroidJavaObject>("instance");
			}
			return (Hashtable)ZenJSON.Deserialize(_plugin.Call<String> ("zendeskDeviceInfoDictionary"));
		}

		#endif

		#if UNITY_EDITOR || !UNITY_IPHONE

		/// <summary>
		/// Get a String of the device type, e.g. 'iPad 3 (WiFi)'
		/// </summary>
		/// <returns></returns>
		public static string DeviceTypeiOS() {
			Log("Unity : DeviceType");
			return "";
		}

		/// <summary>
		/// Get the total device memory.
		/// </summary>
		/// <returns>the device memory in GB</returns>
		public static double TotalDeviceMemoryiOS() {
			Log("Unity : TotalDeviceMemory");
			return 0;
		}

		/// <summary>
		/// Get the free disk space of the device.
		/// </summary>
		/// <returns>the free disk space of the device in GB</returns>
		public static double FreeDiskspaceiOS() {
			Log("Unity : FreeDiskspace");
			return 0;
		}

		/// <summary>
		/// Get the total disk space of the device.
		/// </summary>
		/// <returns>the total disk space of the device in GB</returns>
		public static double TotalDiskspaceiOS() {
			Log("Unity : TotalDiskspace");
			return 0;
		}

		/// <summary>
		/// The current battery level of the device.
		/// </summary>
		/// <returns>the current battery level of the device as a percentage</returns>
		public static float BatteryLeveliOS() {
			Log("Unity : BatteryLevel");
			return 0;
		}

		/// <summary>
		/// The current region setting of the device.
		/// </summary>
		/// <returns>the current region</returns>
		public static string RegioniOS() {
			Log("Unity : Region");
			return "";
		}

		/// <summary>
		/// The current language of the device
		/// </summary>
		/// <returns>the language</returns>
		public static string LanguageiOS() {
			Log("Unity : Language");
			return "";
		}

		#elif UNITY_IPHONE

		[DllImport("__Internal")]
		private static extern string _zendeskDeviceType();
		[DllImport("__Internal")]
		private static extern double _zendeskTotalDeviceMemory();
		[DllImport("__Internal")]
		private static extern double _zendeskFreeDiskspace();
		[DllImport("__Internal")]
		private static extern double _zendeskTotalDiskspace();
		[DllImport("__Internal")]
		private static extern float _zendeskBatteryLevel();
		[DllImport("__Internal")]
		private static extern string _zendeskRegion();
		[DllImport("__Internal")]
		private static extern string _zendeskLanguage();
		
		public static string DeviceTypeiOS() {
			return _zendeskDeviceType();
		}
		
		public static double TotalDeviceMemoryiOS() {
			return _zendeskTotalDeviceMemory();
		}
		
		public static double FreeDiskspaceiOS() {
			return _zendeskFreeDiskspace();
		}
		
		public static double TotalDiskspaceiOS() {
			return _zendeskTotalDiskspace();
		}
		
		public static float BatteryLeveliOS() {
			return _zendeskBatteryLevel();
		}
		
		public static string RegioniOS() {
			return _zendeskRegion();
		}
		
		public static string LanguageiOS() {
			return _zendeskLanguage();
		}
		#endif

		#if UNITY_EDITOR || !UNITY_ANDROID

		/// <summary>
		/// The manufacturer of the device like HTC, Samsung etc. Android only method.
		/// </summary>
		/// <returns>the manufacturer of the device</returns>
		public static string ModelManufacturerAndroid(){
			Log("Unity : ModelManufacturerAndroid");
			return "";
		}

		/// <summary>
		/// The OS version name of the device. Android only method.
		/// </summary>
		/// <returns>the OS version of the device, like 4.4.2</returns>
		public static string VersionNameAndroid(){
			Log ("Unity: DeviceOsAndroid");
			return "";
		}

		/// <summary>
		/// The device name. This is usually a code-name like m7 for the HTC One. Android only method.
		/// </summary>
		/// <returns>The device name</returns>
		public static string ModelDeviceNameAndroid(){
			Log ("Unity: ModelDeviceNameAndroid");
			return "";
		}

		/// <summary>
		/// Model name of the device. This will be the model name that is most recognizable
		/// by users. Android only method.
		/// </summary>
		/// <returns>A descriptive name of the device like "HTC One"</returns>
		public static string ModelNameAndroid(){
			Log("Unity: ModelNameAndroid");
			return "";
		}

		/// <summary>
		/// API level of the OS. Android only method. 
		/// </summary>
		/// <returns>The api level of the OS</returns>
		public static int VersionCodeAndroid(){
			Log ("Unity: VersionCodeAndroid");
			return 0;
		}

		/// <summary>
		/// Gets the total memory in megabytes that this device has. This version will automatically pick
		/// the best way of determining the total amount of memory depending on the what Android API level the 
		/// device is running on. If the API level is 17 or later, the memory is read directly from the Memory 
		/// Info API. If the API level is lower than 17 then the memory will be determined by examining the
		/// proc/meminfo file. Android only method.
		/// </summary>
		/// <returns>The total memory in megabytes.</returns>
		public static int TotalMemoryAndroid(){
			Log ("Unity: TotalMemoryAndroid");
			return 0;
		}

		/// <summary>
		/// The used memory in megabytes. Android only method.
		/// </summary>
		/// <returns>The used memory in megabytes</returns>
		public static int UsedMemoryAndroid(){
			Log ("Unity UsedMemoryAndroid");
			return 0;
		}

		#elif UNITY_ANDROID

		public static string ModelManufacturerAndroid(){
			AndroidJavaObject _plugin;
			using(var pluginClass = new AndroidJavaClass("com.zendesk.unity.ZDK_Plugin"))
			{
				_plugin = pluginClass.CallStatic<AndroidJavaObject>("instance");
			}
			return _plugin.Call<String> ("zendeskModelManufacturer");
		}

		public static string VersionNameAndroid(){
			AndroidJavaObject _plugin;
			using(var pluginClass = new AndroidJavaClass("com.zendesk.unity.ZDK_Plugin"))
			{
				_plugin = pluginClass.CallStatic<AndroidJavaObject>("instance");
			}
			return _plugin.Call<String> ("zendeskVersionName");
		}
	
		public static string ModelDeviceNameAndroid(){
			AndroidJavaObject _plugin;
			using(var pluginClass = new AndroidJavaClass("com.zendesk.unity.ZDK_Plugin"))
			{
				_plugin = pluginClass.CallStatic<AndroidJavaObject>("instance");
			}
			return _plugin.Call<String> ("zendeskModelDeviceName");
		}

		public static string ModelNameAndroid(){
			AndroidJavaObject _plugin;
			using(var pluginClass = new AndroidJavaClass("com.zendesk.unity.ZDK_Plugin"))
			{
				_plugin = pluginClass.CallStatic<AndroidJavaObject>("instance");
			}
			return _plugin.Call<String> ("zendeskModelName");
		}

		public static int VersionCodeAndroid(){
			AndroidJavaObject _plugin;
			using(var pluginClass = new AndroidJavaClass("com.zendesk.unity.ZDK_Plugin"))
			{
				_plugin = pluginClass.CallStatic<AndroidJavaObject>("instance");
			}
			return _plugin.Call<int> ("zendeskVersionCode");
		}

		public static int TotalMemoryAndroid(){
			AndroidJavaObject _plugin;
			using(var pluginClass = new AndroidJavaClass("com.zendesk.unity.ZDK_Plugin"))
			{
				_plugin = pluginClass.CallStatic<AndroidJavaObject>("instance");
			}
			return _plugin.Call<int> ("zendeskTotalMemory");
		}

		public static int UsedMemoryAndroid(){
			AndroidJavaObject _plugin;
			using(var pluginClass = new AndroidJavaClass("com.zendesk.unity.ZDK_Plugin"))
			{
				_plugin = pluginClass.CallStatic<AndroidJavaObject>("instance");
			}
			return _plugin.Call<int> ("zendeskUsedMemory");
		}

		#endif
	}
}
