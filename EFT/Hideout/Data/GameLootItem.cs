using System;
using System.Runtime.CompilerServices;
using EFT.HideOut.Utils;
using EFT.Interactive;
using UnityEngine;

namespace EFT.HideOut.Data
{
	// Token: 0x02002182 RID: 8578
	public class GameLootItem
	{
		// Token: 0x0600B88C RID: 47244 RVA: 0x00115039 File Offset: 0x00113239
		public GameLootItem(LootItem lootItem)
		{
			if (lootItem == null)
			{
				throw new ArgumentNullException(Class52.smethod_0(-1339809529));
			}
			this.lootItem_0 = lootItem;
			this.vector3_0 = default(Vector3);
			this.method_1(0f);
		}

		// Token: 0x170016C1 RID: 5825
		// (get) Token: 0x0600B88D RID: 47245 RVA: 0x00115078 File Offset: 0x00113278
		public LootItem LootItem
		{
			[CompilerGenerated]
			get
			{
				return this.lootItem_0;
			}
		}

		// Token: 0x170016C2 RID: 5826
		// (get) Token: 0x0600B88E RID: 47246 RVA: 0x00115080 File Offset: 0x00113280
		public Vector3 ScreenPosition
		{
			get
			{
				return this.vector3_0;
			}
		}

		// Token: 0x170016C3 RID: 5827
		// (get) Token: 0x0600B88F RID: 47247 RVA: 0x00115088 File Offset: 0x00113288
		public bool IsOnScreen
		{
			[CompilerGenerated]
			get
			{
				return this.bool_0;
			}
		}

		// Token: 0x0600B890 RID: 47248 RVA: 0x00115090 File Offset: 0x00113290
		private void method_0(bool bool_1)
		{
			this.bool_0 = bool_1;
		}

		// Token: 0x170016C4 RID: 5828
		// (get) Token: 0x0600B891 RID: 47249 RVA: 0x00115099 File Offset: 0x00113299
		public float Distance
		{
			[CompilerGenerated]
			get
			{
				return this.float_0;
			}
		}

		// Token: 0x0600B892 RID: 47250 RVA: 0x001150A1 File Offset: 0x001132A1
		private void method_1(float float_1)
		{
			this.float_0 = float_1;
		}

		// Token: 0x170016C5 RID: 5829
		// (get) Token: 0x0600B893 RID: 47251 RVA: 0x001150AA File Offset: 0x001132AA
		public string FormattedDistance
		{
			get
			{
				return string.Format(Class52.smethod_0(-1339809520), Math.Round((double)this.Distance));
			}
		}

		// Token: 0x0600B894 RID: 47252 RVA: 0x003B442C File Offset: 0x003B262C
		public void RecalculateDynamics()
		{
			if (!GameUtils.IsLootItemValid(this.LootItem))
			{
				return;
			}
			this.vector3_0 = GameUtils.WorldPointToScreenPoint(this.LootItem.transform.position);
			this.method_0(GameUtils.IsScreenPointVisible(this.vector3_0));
			this.method_1(Vector3.Distance(Camera.main.transform.position, this.LootItem.transform.position));
		}

		// Token: 0x0400A8E7 RID: 43239
		private readonly LootItem lootItem_0;

		// Token: 0x0400A8E8 RID: 43240
		private bool bool_0;

		// Token: 0x0400A8E9 RID: 43241
		private float float_0;

		// Token: 0x0400A8EA RID: 43242
		private Vector3 vector3_0;
	}
}
