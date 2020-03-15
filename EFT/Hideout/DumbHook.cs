using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace EFT.HideOut
{
	// Token: 0x0200217A RID: 8570
	public class DumbHook
	{
		// Token: 0x0600B852 RID: 47186 RVA: 0x003AF1F8 File Offset: 0x003AD3F8
		public DumbHook()
		{
			this.byte_0 = null;
			this.OriginalMethod = (this.HookMethod = null);
		}

		// Token: 0x0600B853 RID: 47187 RVA: 0x00114EB6 File Offset: 0x001130B6
		public DumbHook(MethodInfo orig, MethodInfo hook)
		{
			this.byte_0 = null;
			this.Init(orig, hook);
		}

		// Token: 0x0600B854 RID: 47188 RVA: 0x003AF224 File Offset: 0x003AD424
		public void Init(MethodInfo orig, MethodInfo hook)
		{
			orig.MethodHandle.GetFunctionPointer();
			hook.MethodHandle.GetFunctionPointer();
			this.OriginalMethod = orig;
			this.HookMethod = hook;
		}

		// Token: 0x0600B855 RID: 47189 RVA: 0x003AF260 File Offset: 0x003AD460
		public unsafe void Hook()
		{
			if (this.byte_0 != null)
			{
				return;
			}
			IntPtr functionPointer = this.OriginalMethod.MethodHandle.GetFunctionPointer();
			IntPtr functionPointer2 = this.HookMethod.MethodHandle.GetFunctionPointer();
			uint uint_;
			if (IntPtr.Size == 8)
			{
				this.byte_0 = new byte[12];
				DumbHook.Class56.VirtualProtect(functionPointer, (IntPtr)12L, 64u, out uint_);
				byte* ptr = (byte*)((void*)functionPointer);
				int num = 0;
				while ((long)num < 12L)
				{
					this.byte_0[num] = ptr[num];
					num++;
				}
				*ptr = 72;
				ptr[1] = 184;
				*(IntPtr*)(ptr + 2) = functionPointer2;
				ptr[10] = byte.MaxValue;
				ptr[11] = 224;
				DumbHook.Class56.VirtualProtect(functionPointer, (IntPtr)12L, uint_, out uint_);
				return;
			}
			this.byte_0 = new byte[7];
			DumbHook.Class56.VirtualProtect(functionPointer, (IntPtr)7L, 64u, out uint_);
			byte* ptr2 = (byte*)((void*)functionPointer);
			int num2 = 0;
			while ((long)num2 < 7L)
			{
				this.byte_0[num2] = ptr2[num2];
				num2++;
			}
			*ptr2 = 184;
			*(IntPtr*)(ptr2 + 1) = functionPointer2;
			ptr2[5] = byte.MaxValue;
			ptr2[6] = 224;
			DumbHook.Class56.VirtualProtect(functionPointer, (IntPtr)7L, uint_, out uint_);
		}

		// Token: 0x0600B856 RID: 47190 RVA: 0x003AF3C8 File Offset: 0x003AD5C8
		public unsafe void Unhook()
		{
			if (this.byte_0 == null)
			{
				return;
			}
			uint num = (uint)this.byte_0.Length;
			IntPtr functionPointer = this.OriginalMethod.MethodHandle.GetFunctionPointer();
			uint num2;
			DumbHook.Class56.VirtualProtect(functionPointer, (IntPtr)((long)((ulong)num)), 64u, out num2);
			byte* ptr = (byte*)((void*)functionPointer);
			int num3 = 0;
			while ((long)num3 < (long)((ulong)num))
			{
				ptr[num3] = this.byte_0[num3];
				num3++;
			}
			DumbHook.Class56.VirtualProtect(functionPointer, (IntPtr)((long)((ulong)num)), 64u, out num2);
			this.byte_0 = null;
		}

		// Token: 0x0400A803 RID: 43011
		private byte[] byte_0;

		// Token: 0x0400A804 RID: 43012
		public MethodInfo OriginalMethod;

		// Token: 0x0400A805 RID: 43013
		public MethodInfo HookMethod;

		// Token: 0x0200217B RID: 8571
		internal sealed class Class56
		{
			// Token: 0x0600B858 RID: 47192
			[DllImport("kernel32.dll", SetLastError = true)]
			internal static extern bool VirtualProtect(IntPtr intptr_0, IntPtr intptr_1, uint uint_0, out uint uint_1);
		}
	}
}
