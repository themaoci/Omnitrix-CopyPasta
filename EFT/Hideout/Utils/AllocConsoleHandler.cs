using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

namespace EFT.HideOut.Utils
{
	// Token: 0x02002183 RID: 8579
	public static class AllocConsoleHandler
	{
		// Token: 0x0600B895 RID: 47253
		[DllImport("Kernel32.dll")]
		private static extern bool AllocConsole();

		// Token: 0x0600B896 RID: 47254
		[DllImport("msvcrt.dll")]
		public static extern int system(string cmd);

		// Token: 0x0600B897 RID: 47255 RVA: 0x003B44A0 File Offset: 0x003B26A0
		public static void Open()
		{
			AllocConsoleHandler.AllocConsole();
			Console.SetOut(new StreamWriter(Console.OpenStandardOutput())
			{
				AutoFlush = true
			});
			Application.logMessageReceivedThreaded += new Application.LogCallback(AllocConsoleHandler.Class58.class58_0.method_0);
		}

		// Token: 0x0600B898 RID: 47256 RVA: 0x001150CC File Offset: 0x001132CC
		public static void ClearAllocConsole()
		{
			AllocConsoleHandler.system(Class52.smethod_0(-1339805126));
		}

		// Token: 0x02002184 RID: 8580
		[Serializable]
		private sealed class Class58
		{
			// Token: 0x0600B89B RID: 47259 RVA: 0x001150EA File Offset: 0x001132EA
			internal void method_0(string string_0, string string_1, LogType logType_0)
			{
				Console.WriteLine(string_0 + Class52.smethod_0(-1339805134) + string_1);
			}

			// Token: 0x0400A8EB RID: 43243
			public static readonly AllocConsoleHandler.Class58 class58_0 = new AllocConsoleHandler.Class58();

			// Token: 0x0400A8EC RID: 43244
			public static Application.LogCallback logCallback_0;
		}
	}
}
