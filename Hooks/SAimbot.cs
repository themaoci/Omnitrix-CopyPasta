using System;
using System.Collections.Generic;
using UnityEngine;

namespace EFT.HideOut.Hooks
{
	// Token: 0x02002112 RID: 8466
	public class SAimbot
	{
		// Token: 0x0600B56B RID: 46443 RVA: 0x003AAEBC File Offset: 0x003A90BC
		public static Player FindPlayer(List<Player> playerList)
		{
			try
			{
				if (playerList.Count == 0)
				{
					return null;
				}
				float num = 180f;
				Player player = null;
				Camera main = Camera.main;
				if (!main)
				{
					return null;
				}
				Vector2 vector = new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2));
				foreach (Player player2 in playerList)
				{
					if (player2 && !(player2 == CPlayer.LocalPlayer))
					{
						Vector3 vector2 = main.WorldToScreenPoint(player2.PlayerBones.Head.position);
						if (vector2.z >= 0.01f)
						{
							vector2.y = (float)Screen.height - vector2.y;
							float num2 = Math.Abs(vector2.x - vector.x) + Math.Abs(vector2.y - vector.y);
							if (!player || num2 < num)
							{
								num = num2;
								player = player2;
							}
						}
					}
				}
				return player;
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x0600B56C RID: 46444 RVA: 0x003AB00C File Offset: 0x003A920C
		public void hkInitiateShot(object ammo, Vector3 shotPosition, Vector3 shotDirection)
		{
			try
			{
				try
				{
					if (SAimbot.RedirectBullets && CGameWorld.activeGameworld != null && CPlayer.LocalPlayer != null)
					{
						Player player = SAimbot.FindPlayer(CPlayer.Players);
						if (player != null)
						{
							Transform transform = player.PlayerBones.Head.Original.transform;
							Vector3 position = CPlayer.LocalPlayer.PlayerBones.Fireport.position;
							Vector3 vector = transform.position - position;
							shotPosition = position;
							shotDirection = vector;
						}
					}
				}
				catch
				{
				}
				HookManager.SAimbotHook.Unhook();
				HookManager.SAimbotHook.OriginalMethod.Invoke(this, new object[]
				{
					ammo,
					shotPosition,
					shotDirection
				});
				HookManager.SAimbotHook.Hook();
			}
			catch
			{
			}
		}

		// Token: 0x0400A6DF RID: 42719
		public static bool RedirectBullets = true;
	}
}
