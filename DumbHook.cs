using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace EFT.HideOut
{
	// Token: 0x02002106 RID: 8454
	public class DumbHook
	{
		// Token: 0x0600B527 RID: 46375 RVA: 0x003A5EF4 File Offset: 0x003A40F4
		public DumbHook()
		{
			this.\u0002 = null;
			this.OriginalMethod = (this.HookMethod = null);
		}

		// Token: 0x0600B528 RID: 46376 RVA: 0x00112F11 File Offset: 0x00111111
		public DumbHook(MethodInfo orig, MethodInfo hook)
		{
			this.\u0002 = null;
			this.Init(orig, hook);
		}

		// Token: 0x0600B529 RID: 46377 RVA: 0x003A5F20 File Offset: 0x003A4120
		public void Init(MethodInfo orig, MethodInfo hook)
		{
			orig.MethodHandle.GetFunctionPointer();
			hook.MethodHandle.GetFunctionPointer();
			this.OriginalMethod = orig;
			this.HookMethod = hook;
		}

		// Token: 0x0600B52A RID: 46378 RVA: 0x003A5F5C File Offset: 0x003A415C
		public unsafe void Hook()
		{
			if (this.\u0002 != null)
			{
				return;
			}
			IntPtr functionPointer = this.OriginalMethod.MethodHandle.GetFunctionPointer();
			IntPtr functionPointer2 = this.HookMethod.MethodHandle.GetFunctionPointer();
			uint u;
			if (IntPtr.Size == 8)
			{
				this.\u0002 = new byte[12];
				DumbHook.\u0002.\u0002(functionPointer, (IntPtr)((long)((ulong)12)), 64u, out u);
				byte* ptr = (byte*)((void*)functionPointer);
				int num = 0;
				while ((long)num < 12L)
				{
					this.\u0002[num] = ptr[num];
					num++;
				}
				*ptr = 72;
				ptr[1] = 184;
				*(IntPtr*)(ptr + 2) = functionPointer2;
				ptr[10] = byte.MaxValue;
				ptr[11] = 224;
				DumbHook.\u0002.\u0002(functionPointer, (IntPtr)((long)((ulong)12)), u, out u);
				return;
			}
			this.\u0002 = new byte[7];
			DumbHook.\u0002.\u0002(functionPointer, (IntPtr)((long)((ulong)7)), 64u, out u);
			byte* ptr2 = (byte*)((void*)functionPointer);
			int num2 = 0;
			while ((long)num2 < 7L)
			{
				this.\u0002[num2] = ptr2[num2];
				num2++;
			}
			*ptr2 = 184;
			*(IntPtr*)(ptr2 + 1) = functionPointer2;
			ptr2[5] = byte.MaxValue;
			ptr2[6] = 224;
			DumbHook.\u0002.\u0002(functionPointer, (IntPtr)((long)((ulong)7)), u, out u);
		}

		// Token: 0x0600B52B RID: 46379 RVA: 0x003A609C File Offset: 0x003A429C
		public unsafe void Unhook()
		{
			if (this.\u0002 == null)
			{
				return;
			}
			uint num = (uint)this.\u0002.Length;
			IntPtr functionPointer = this.OriginalMethod.MethodHandle.GetFunctionPointer();
			uint num2;
			DumbHook.\u0002.\u0002(functionPointer, (IntPtr)((long)((ulong)num)), 64u, out num2);
			byte* ptr = (byte*)((void*)functionPointer);
			int num3 = 0;
			while ((long)num3 < (long)((ulong)num))
			{
				ptr[num3] = this.\u0002[num3];
				num3++;
			}
			DumbHook.\u0002.\u0002(functionPointer, (IntPtr)((long)((ulong)num)), 64u, out num2);
			this.\u0002 = null;
		}

		// Token: 0x0400A5F4 RID: 42484
		private byte[] \u0002;

		// Token: 0x0400A5F5 RID: 42485
		public MethodInfo OriginalMethod;

		// Token: 0x0400A5F6 RID: 42486
		public MethodInfo HookMethod;

		// Token: 0x02002107 RID: 8455
		internal sealed class \u0002
		{
			// Token: 0x0600B52D RID: 46381
			[DllImport("kernel32.dll", EntryPoint = "VirtualProtect", SetLastError = true)]
			internal static extern bool \u0002(IntPtr \u0002, IntPtr \u0003, uint \u0005, out uint \u0008);
		}
	}
}
