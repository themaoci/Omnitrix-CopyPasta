using System;
using Comfort.Common;
using EFT.UI;
using UnityEngine;

namespace EFT.HideOut
{
	// Token: 0x02002177 RID: 8567
	public class CGameWorld : MonoBehaviour
	{
		// Token: 0x0600B837 RID: 47159 RVA: 0x003ADEBC File Offset: 0x003AC0BC
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

		// Token: 0x0600B838 RID: 47160 RVA: 0x003ADEE8 File Offset: 0x003AC0E8
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

		// Token: 0x0600B839 RID: 47161 RVA: 0x003ADF14 File Offset: 0x003AC114
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

		// Token: 0x0600B83A RID: 47162 RVA: 0x003ADF6C File Offset: 0x003AC16C
		private void OnGUI()
		{
			try
			{
				if (Event.current.type == EventType.Repaint)
				{
					CGameWorld.activeGameworld;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400A7F6 RID: 42998
		public static GameWorld activeGameworld;
	}
}
