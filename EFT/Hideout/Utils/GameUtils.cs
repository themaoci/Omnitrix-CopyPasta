using System;
using System.Collections.Generic;
using System.Linq;
using Diz.Skinning;
using EFT.Interactive;
using UnityEngine;

namespace EFT.HideOut.Utils
{
	// Token: 0x02002185 RID: 8581
	public static class GameUtils
	{
		// Token: 0x0600B89C RID: 47260 RVA: 0x00115102 File Offset: 0x00113302
		public static float Map(float value, float sourceFrom, float sourceTo, float destinationFrom, float destinationTo)
		{
			return (value - sourceFrom) / (sourceTo - sourceFrom) * (destinationTo - destinationFrom) + destinationFrom;
		}

		// Token: 0x0600B89D RID: 47261 RVA: 0x00115112 File Offset: 0x00113312
		public static bool IsPlayerValid(Player player)
		{
			return player != null && player.Transform != null && player.PlayerBones != null && player.PlayerBones.transform != null;
		}

		// Token: 0x0600B89E RID: 47262 RVA: 0x00115146 File Offset: 0x00113346
		public static bool IsExfiltrationPointValid(ExfiltrationPoint lootItem)
		{
			return lootItem != null;
		}

		// Token: 0x0600B89F RID: 47263 RVA: 0x0011514F File Offset: 0x0011334F
		public static bool IsLootItemValid(LootItem lootItem)
		{
			return lootItem != null && lootItem.Item != null && lootItem.Item.Template != null;
		}

		// Token: 0x0600B8A0 RID: 47264 RVA: 0x00115172 File Offset: 0x00113372
		public static bool IsLootableContainerValid(LootableContainer lootableContainer)
		{
			return lootableContainer != null && lootableContainer.Template != null;
		}

		// Token: 0x0600B8A1 RID: 47265 RVA: 0x00115188 File Offset: 0x00113388
		public static bool IsPlayerAlive(Player player)
		{
			return GameUtils.IsPlayerValid(player) && player.HealthController != null && player.HealthController.IsAlive;
		}

		// Token: 0x0600B8A2 RID: 47266 RVA: 0x003B44F0 File Offset: 0x003B26F0
		public static Vector3 WorldPointToScreenPoint(Vector3 worldPoint)
		{
			Vector3 vector = Camera.main.WorldToScreenPoint(worldPoint);
			vector.y = (float)Screen.height - vector.y;
			return vector;
		}

		// Token: 0x0600B8A3 RID: 47267 RVA: 0x003B4520 File Offset: 0x003B2720
		public static bool IsScreenPointVisible(Vector3 screenPoint)
		{
			return screenPoint.z > 0.01f && screenPoint.x > -5f && screenPoint.y > -5f && screenPoint.x < (float)Screen.width && screenPoint.y < (float)Screen.height;
		}

		// Token: 0x0600B8A4 RID: 47268 RVA: 0x003B4574 File Offset: 0x003B2774
		public static Vector3 GetBonePosByID(Player player, int id)
		{
			Vector3 result;
			try
			{
				result = GameUtils.SkeletonBonePos(player.PlayerBones.AnimatedTransform.Original.gameObject.GetComponent<PlayerBody>().SkeletonRootJoint, id);
			}
			catch (Exception)
			{
				result = Vector3.zero;
			}
			return result;
		}

		// Token: 0x0600B8A5 RID: 47269 RVA: 0x003B42B8 File Offset: 0x003B24B8
		public static Vector3 SkeletonBonePos(Skeleton skeleton, int id)
		{
			return skeleton.Bones.ElementAt(id).Value.position;
		}
	}
}
