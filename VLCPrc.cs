using System;
using UnityEngine;

namespace EFT.HideOut
{
	// Token: 0x02002111 RID: 8465
	public static class VLCPrc
	{
		// Token: 0x0600B568 RID: 46440 RVA: 0x003AAE6C File Offset: 0x003A906C
		public static void Load()
		{
			MA.Init();
			try
			{
				GameObject gameObject = new GameObject();
				gameObject.AddComponent<SisaKuracPicka>();
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
			catch
			{
			}
			try
			{
				HookManager.Init();
			}
			catch
			{
			}
		}
	}
}
