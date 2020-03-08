using System;
using System.Reflection;
using System.Runtime.InteropServices;
using SaberClient;

namespace EFT.HideOut
{
	// Token: 0x0200210B RID: 8459
	public static class MA
	{
		// Token: 0x0600B535 RID: 46389
		[DllImport("mono.dll")]
		public static extern IntPtr mono_get_root_domain();

		// Token: 0x0600B536 RID: 46390 RVA: 0x003A67D4 File Offset: 0x003A49D4
		public unsafe static void UnlinkAssemblies()
		{
			IntPtr pointer = MA.mono_get_root_domain();
			MA.GSList* next;
			for (MA.GSList* ptr = *(IntPtr*)((void*)(pointer + 200)); ptr != null; ptr = next)
			{
				next = ptr->next;
				ptr->prev = null;
				ptr->next = null;
			}
			*(IntPtr*)((void*)(pointer + 200)) = (IntPtr)0;
		}

		// Token: 0x0600B537 RID: 46391 RVA: 0x00112F34 File Offset: 0x00111134
		public static void DestroySClient()
		{
			SClientWrapper.Unload();
		}

		// Token: 0x0600B538 RID: 46392 RVA: 0x003A6830 File Offset: 0x003A4A30
		public static void Init()
		{
			try
			{
				MA.refAssembly = typeof(Player).Assembly;
				MA.mainModule = typeof(Player).Module;
			}
			catch
			{
			}
		}

		// Token: 0x0600B539 RID: 46393 RVA: 0x003A687C File Offset: 0x003A4A7C
		public static object CreateType(Type type)
		{
			try
			{
				return Activator.CreateInstance(type);
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x0600B53A RID: 46394 RVA: 0x003A68A8 File Offset: 0x003A4AA8
		public static Type FindType(string typeName)
		{
			try
			{
				return MA.refAssembly.GetType(typeName, false, true);
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x0600B53B RID: 46395 RVA: 0x003A68DC File Offset: 0x003A4ADC
		public static MethodInfo FindMethod(string typeName, string methodName)
		{
			try
			{
				return MA.FindType(typeName).GetMethod(methodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x0600B53C RID: 46396 RVA: 0x003A6910 File Offset: 0x003A4B10
		public static MethodInfo FindMethod(Type type, string methodName)
		{
			try
			{
				return type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x0600B53D RID: 46397 RVA: 0x003A6940 File Offset: 0x003A4B40
		public static FieldInfo FindField(string typeName, string fieldName)
		{
			try
			{
				return MA.FindType(typeName).GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x0600B53E RID: 46398 RVA: 0x003A6974 File Offset: 0x003A4B74
		public static FieldInfo FindField(Type type, string fieldName)
		{
			try
			{
				return type.GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x0600B53F RID: 46399 RVA: 0x003A69A4 File Offset: 0x003A4BA4
		public static PropertyInfo FindProperty(Type type, string propertyName)
		{
			try
			{
				return type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x0400A684 RID: 42628
		public const string DLLMONO = "mono.dll";

		// Token: 0x0400A685 RID: 42629
		public const int RID_LOCALIZATION_TRANSLATE_METHOD = 28269;

		// Token: 0x0400A686 RID: 42630
		public const int RID_LOCATIONSCENE_GET_OBJECTS_METHOD = 17319;

		// Token: 0x0400A687 RID: 42631
		public static Module mainModule;

		// Token: 0x0400A688 RID: 42632
		public static Assembly refAssembly;

		// Token: 0x0200210C RID: 8460
		public struct GSList
		{
			// Token: 0x0400A689 RID: 42633
			public unsafe void* data;

			// Token: 0x0400A68A RID: 42634
			public unsafe MA.GSList* next;

			// Token: 0x0400A68B RID: 42635
			public unsafe MA.GSList* prev;
		}
	}
}
