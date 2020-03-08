using System;
using Comfort.Common;
using EFT.UI;
using UnityEngine;

namespace EFT.HideOut
{
	// Token: 0x02002103 RID: 8451
	public class CGameWorld : MonoBehaviour
	{
		// Token: 0x0600B50C RID: 46348 RVA: 0x003A4BC4 File Offset: 0x003A2DC4
		public static GameWorld FindActiveGameWorld()
		{
			try
			{
				return Singleton<GameWorld>.Instance;
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x0600B50D RID: 46349 RVA: 0x003A4BF0 File Offset: 0x003A2DF0
		private void Awake()
		{
			try
			{
				CGameWorld.activeGameworld = CGameWorld.FindActiveGameWorld();
			}
			catch
			{
			}
		}

		// Token: 0x0600B50E RID: 46350 RVA: 0x003A4C1C File Offset: 0x003A2E1C
		private void Update()
		{
			try
			{
				if (!CGameWorld.activeGameworld)
				{
					CGameWorld.activeGameworld = CGameWorld.FindActiveGameWorld();
				}
			}
			catch
			{
			}
			try
			{
				MonoBehaviourSingleton<PreloaderUI>.Instance != null;
			}
			catch
			{
			}
		}

		// Token: 0x0600B50F RID: 46351 RVA: 0x003A4C74 File Offset: 0x003A2E74
		private void OnGUI()
		{
			try
			{
				if (Event.current.type == 7)
				{
					CGameWorld.activeGameworld;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400A5E7 RID: 42471
		public static GameWorld activeGameworld;
	}
}
