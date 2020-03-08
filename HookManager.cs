using System;
using System.Reflection;
using EFT.HideOut.Hooks;
using UnityEngine;

namespace EFT.HideOut
{
	// Token: 0x0200210A RID: 8458
	public static class HookManager
	{
		// Token: 0x0600B534 RID: 46388 RVA: 0x003A6774 File Offset: 0x003A4974
		public static void Init()
		{
			if (HookManager.SAimbotHook != null)
			{
				HookManager.SAimbotHook.Unhook();
			}
			MethodInfo orig = MA.FindMethod(\u0003\u2000__2.\u0002(872575296), \u0003\u2000__2.\u0002(872575342));
			MethodInfo hook = methodof(SAimbot.hkInitiateShot(object, Vector3, Vector3));
			HookManager.SAimbotHook = new DumbHook(orig, hook);
			HookManager.SAimbotHook.Hook();
		}

		// Token: 0x0400A683 RID: 42627
		public static DumbHook SAimbotHook;
	}
}
