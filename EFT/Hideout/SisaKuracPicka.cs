using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Comfort.Common;
using Diz.Skinning;
using EFT.Interactive;
using UnityEngine;

namespace EFT.HideOut
{
	// Token: 0x0200217F RID: 8575
	public class SisaKuracPicka : MonoBehaviour
	{
		// Token: 0x0600B869 RID: 47209 RVA: 0x0009EF7C File Offset: 0x0009D17C
		private void Start()
		{
		}

		// Token: 0x0600B86A RID: 47210 RVA: 0x00114FA4 File Offset: 0x001131A4
		public void Load()
		{
			this.gameObject_0 = new GameObject();
			this.gameObject_0.AddComponent<SisaKuracPicka>();
			Object.DontDestroyOnLoad(this.gameObject_0);
		}

		// Token: 0x0600B86B RID: 47211 RVA: 0x00114FC8 File Offset: 0x001131C8
		public void Unload()
		{
			Object.Destroy(this.gameObject_0);
			Object.Destroy(this);
		}

		// Token: 0x0600B86C RID: 47212 RVA: 0x003AFB98 File Offset: 0x003ADD98
		private void Update()
		{
			if (Input.GetKeyDown(292))
			{
				this.bool_0 = !this.bool_0;
				if (this.bool_1)
				{
					this.bool_1 = false;
				}
			}
			if (Input.GetKeyUp(288))
			{
				this.bool_4 = !this.bool_4;
			}
			if (Input.GetKeyUp(289))
			{
				this.bool_5 = !this.bool_5;
			}
			if (Input.GetKeyDown(290))
			{
				this.bool_3 = !this.bool_3;
			}
			if (Input.GetKey(283) && this.bool_7)
			{
				this.method_0();
			}
			if (Input.GetKey(326) && this.aim)
			{
				foreach (Player player in Singleton<GameWorld>.Instance.RegisteredPlayers)
				{
					if (player.PointOfView == EPointOfView.FirstPerson)
					{
						SisaKuracPicka.player_0 = player;
					}
				}
				this.CiterskiPeder();
			}
			if (Input.GetKeyDown(287))
			{
				CPlayer.bDrawSkeleton = !CPlayer.bDrawSkeleton;
			}
			if (Input.GetKeyDown(291))
			{
				this.bool_8 = !this.bool_8;
			}
			if (Input.GetKeyDown(283))
			{
				this.bool_6 = !this.bool_6;
			}
		}

		// Token: 0x0600B86D RID: 47213 RVA: 0x003AFCF8 File Offset: 0x003ADEF8
		private void Awake()
		{
			try
			{
				this.cgameWorld_0 = base.gameObject.AddComponent<CGameWorld>();
				this.cplayer_0 = base.gameObject.AddComponent<CPlayer>();
			}
			catch
			{
			}
		}

		// Token: 0x0600B86E RID: 47214 RVA: 0x003AFD3C File Offset: 0x003ADF3C
		private void OnGUI()
		{
			if (this.bool_0)
			{
				this.DrawESPMenu();
			}
			GUI.Label(new Rect(0f, 0f, 1000f, 500f), Class52.smethod_0(-1339809507));
			if (this.bool_2 && Time.time >= this.float_0)
			{
				this.ienumerable_0 = Object.FindObjectsOfType<Player>();
				this.float_0 = Time.time + this.float_2;
			}
			if (this.bool_2)
			{
				this.method_8();
			}
			if (this._pokaziskeleton)
			{
				if (Time.time >= this.float_0)
				{
					this.float_0 = Time.time + this.float_2;
				}
				this.method_3();
			}
			if (this.bool_3 && Time.time >= this.float_1)
			{
				this.ienumerable_1 = Object.FindObjectsOfType<ExfiltrationPoint>();
				this.float_1 = Time.time + this.float_2;
			}
			if (this.bool_3)
			{
				this.method_1();
			}
			if (this._plusnaekranu)
			{
				this.Nisanusredini();
			}
			if (this.peder)
			{
				this.Penetracija();
			}
			if (this.bool_4)
			{
				if (Time.time >= this.float_4)
				{
					this.float_4 = Time.time + this.float_3;
				}
				this.method_5();
			}
			if (this.bool_5)
			{
				if (Time.time >= this.float_4)
				{
					this.float_4 = Time.time + this.float_3;
				}
				this.method_7();
			}
			if (this.bool_1)
			{
				this.CrtanjeMenijaZaBoje();
			}
		}

		// Token: 0x0600B86F RID: 47215 RVA: 0x003AFEB0 File Offset: 0x003AE0B0
		public void Penetracija()
		{
			foreach (Player player in this.ienumerable_0)
			{
				if (player.Profile.Info.Nickname == Class52.smethod_0(-1339809725))
				{
					player.Weapon.Template.DefAmmoTemplate.PenetrationPower = 400;
					player.Weapon.Template.DefAmmoTemplate.PenetrationChance = 100000f;
				}
				if (player.Profile.Info.Nickname == Class52.smethod_0(-1339809716))
				{
					player.Weapon.Template.DefAmmoTemplate.PenetrationPower = 400;
					player.Weapon.Template.DefAmmoTemplate.PenetrationChance = 100000f;
				}
			}
		}

		// Token: 0x0600B870 RID: 47216 RVA: 0x003AFFA8 File Offset: 0x003AE1A8
		private void method_0()
		{
			if (Input.GetKeyDown(283))
			{
				foreach (Door door in ((IEnumerable<Door>)Object.FindObjectsOfType<Door>()))
				{
					door.enabled = true;
					door.DoorState = EDoorState.Shut;
				}
				foreach (LootableContainer lootableContainer in ((IEnumerable<LootableContainer>)Object.FindObjectsOfType<LootableContainer>()))
				{
					lootableContainer.enabled = true;
					lootableContainer.DoorState = EDoorState.Shut;
				}
			}
		}

		// Token: 0x0600B871 RID: 47217 RVA: 0x003B0048 File Offset: 0x003AE248
		private void method_1()
		{
			foreach (ExfiltrationPoint exfiltrationPoint in this.ienumerable_1)
			{
				if (!(exfiltrationPoint == null) && !(Camera.main == null))
				{
					float num = Vector3.Distance(Camera.main.transform.position, exfiltrationPoint.transform.position);
					Vector3 vector = Camera.main.WorldToScreenPoint(exfiltrationPoint.transform.position);
					if ((double)vector.z > 0.01)
					{
						string name = exfiltrationPoint.name;
						string arg = this.method_2(name);
						string content = string.Format(Class52.smethod_0(-1339809703), arg, (int)num);
						CrtacBoja.Text(new Rect(vector.x - 50f, (float)Screen.height - vector.y, 100f, 50f), content, Color.green);
					}
				}
			}
		}

		// Token: 0x0600B872 RID: 47218 RVA: 0x003B015C File Offset: 0x003AE35C
		private string method_2(string string_0)
		{
			if (string_0.Contains(Class52.smethod_0(-1339809688)))
			{
				return Class52.smethod_0(-1339809671);
			}
			if (string_0.Contains(Class52.smethod_0(-1339809785)))
			{
				return Class52.smethod_0(-1339809772);
			}
			if (string_0.Contains(Class52.smethod_0(-1339809757)))
			{
				return Class52.smethod_0(-1339809744);
			}
			if (string_0.Contains(Class52.smethod_0(-1339809729)))
			{
				return Class52.smethod_0(-1339809772);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808811)))
			{
				return Class52.smethod_0(-1339808789);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808770)))
			{
				return Class52.smethod_0(-1339808873);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808862)))
			{
				return Class52.smethod_0(-1339808850);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808834)))
			{
				return Class52.smethod_0(-1339808933);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808915)))
			{
				return Class52.smethod_0(-1339809015);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808995)))
			{
				return Class52.smethod_0(-1339808970);
			}
			if (string_0.Contains(Class52.smethod_0(-1339809080)))
			{
				return Class52.smethod_0(-1339809056);
			}
			if (string_0.Contains(Class52.smethod_0(-1339809034)))
			{
				return Class52.smethod_0(-1339809130);
			}
			if (string_0.Contains(Class52.smethod_0(-1339809108)))
			{
				return Class52.smethod_0(-1339809210);
			}
			if (string_0.Contains(Class52.smethod_0(-1339809194)))
			{
				return Class52.smethod_0(-1339809168);
			}
			if (string_0.Contains(Class52.smethod_0(-1339809277)))
			{
				return Class52.smethod_0(-1339809253);
			}
			if (string_0.Contains(Class52.smethod_0(-1339809236)))
			{
				return Class52.smethod_0(-1339808310);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808288)))
			{
				return Class52.smethod_0(-1339808258);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808363)))
			{
				return Class52.smethod_0(-1339808349);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808327)))
			{
				return Class52.smethod_0(-1339808438);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808421)))
			{
				return Class52.smethod_0(-1339808396);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808505)))
			{
				return Class52.smethod_0(-1339808471);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808576)))
			{
				return Class52.smethod_0(-1339808536);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808515)))
			{
				return Class52.smethod_0(-1339808603);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808586)))
			{
				return Class52.smethod_0(-1339808679);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808656)))
			{
				return Class52.smethod_0(-1339808751);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808730)))
			{
				return Class52.smethod_0(-1339807802);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807787)))
			{
				return Class52.smethod_0(-1339807759);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807870)))
			{
				return Class52.smethod_0(-1339807852);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807832)))
			{
				return Class52.smethod_0(-1339807813);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807920)))
			{
				return Class52.smethod_0(-1339807908);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807890)))
			{
				return Class52.smethod_0(-1339807999);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807982)))
			{
				return Class52.smethod_0(-1339807961);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807943)))
			{
				return Class52.smethod_0(-1339808056);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808035)))
			{
				return Class52.smethod_0(-1339808014);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808119)))
			{
				return Class52.smethod_0(-1339808099);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808079)))
			{
				return Class52.smethod_0(-1339808192);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808173)))
			{
				return Class52.smethod_0(-1339808142);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808243)))
			{
				return Class52.smethod_0(-1339808218);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808204)))
			{
				return Class52.smethod_0(-1339807263);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807237)))
			{
				return Class52.smethod_0(-1339808192);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807344)))
			{
				return Class52.smethod_0(-1339807307);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807407)))
			{
				return Class52.smethod_0(-1339807373);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807473)))
			{
				return Class52.smethod_0(-1339807448);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807547)))
			{
				return Class52.smethod_0(-1339807513);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807495)))
			{
				return Class52.smethod_0(-1339807595);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807580)))
			{
				return Class52.smethod_0(-1339807559);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807667)))
			{
				return Class52.smethod_0(-1339807635);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807739)))
			{
				return Class52.smethod_0(-1339807710);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807690)))
			{
				return Class52.smethod_0(-1339806764);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806741)))
			{
				return Class52.smethod_0(-1339806844);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806822)))
			{
				return Class52.smethod_0(-1339806793);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806902)))
			{
				return Class52.smethod_0(-1339806865);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806976)))
			{
				return Class52.smethod_0(-1339806947);
			}
			if (string_0.Contains(Class52.smethod_0(-1339808327)))
			{
				return Class52.smethod_0(-1339806930);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807035)))
			{
				return Class52.smethod_0(-1339806930);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807005)))
			{
				return Class52.smethod_0(-1339807094);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807067)))
			{
				return Class52.smethod_0(-1339807044);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807160)))
			{
				return Class52.smethod_0(-1339807143);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807123)))
			{
				return Class52.smethod_0(-1339807110);
			}
			return string_0;
		}

		// Token: 0x0600B873 RID: 47219 RVA: 0x003B081C File Offset: 0x003AEA1C
		public void Nisanusredini()
		{
			this.CrossColor.r = this.cr;
			this.CrossColor.g = this.cg;
			this.CrossColor.b = this.cb;
			this.CrossColor.a = this.ca;
			CrtacBoja.DrawBox((float)Screen.width / 2f, (float)Screen.height / 2f - 5f, 1f, 11f, this.CrossColor);
			CrtacBoja.DrawBox((float)Screen.width / 2f - 5f, (float)Screen.height / 2f, 11f, 1f, this.CrossColor);
		}

		// Token: 0x0600B874 RID: 47220 RVA: 0x003B08D4 File Offset: 0x003AEAD4
		private void method_3()
		{
			foreach (Player player in this.method_12().RegisteredPlayers)
			{
				if (!(player == SisaKuracPicka.player_0) && player.IsVisible)
				{
					Vector3 vector;
					vector..ctor(Camera.main.WorldToScreenPoint(player.PlayerBones.RightPalm.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.RightPalm.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.RightPalm.position).z);
					Vector3 vector2;
					vector2..ctor(Camera.main.WorldToScreenPoint(player.PlayerBones.LeftPalm.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.LeftPalm.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.LeftPalm.position).z);
					Vector3 vector3;
					vector3..ctor(Camera.main.WorldToScreenPoint(player.PlayerBones.LeftShoulder.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.LeftShoulder.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.LeftShoulder.position).z);
					Vector3 vector4;
					vector4..ctor(Camera.main.WorldToScreenPoint(player.PlayerBones.RightShoulder.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.RightShoulder.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.RightShoulder.position).z);
					Vector3 vector5;
					vector5..ctor(Camera.main.WorldToScreenPoint(player.PlayerBones.Neck.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.Neck.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.Neck.position).z);
					Vector3 vector6;
					vector6..ctor(Camera.main.WorldToScreenPoint(player.PlayerBones.Pelvis.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.Pelvis.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.Pelvis.position).z);
					new Vector3(Camera.main.WorldToScreenPoint(player.PlayerBones.RightThigh2.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.RightThigh2.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.RightThigh2.position).z);
					new Vector3(Camera.main.WorldToScreenPoint(player.PlayerBones.LeftThigh2.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.LeftThigh2.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.LeftThigh2.position).z);
					Vector3 vector7;
					vector7..ctor(Camera.main.WorldToScreenPoint(player.PlayerBones.KickingFoot.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.KickingFoot.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.KickingFoot.position).z);
					Vector3 vector8;
					vector8..ctor(Camera.main.WorldToScreenPoint(player.Transform.position).x, Camera.main.WorldToScreenPoint(player.Transform.position).y, Camera.main.WorldToScreenPoint(player.Transform.position).z);
					Vector3 vector9;
					vector9..ctor(Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position).z);
					Vector3 vector10;
					vector10..ctor(Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 18)).x, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 18)).y, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 18)).z);
					Vector3 vector11;
					vector11..ctor(Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 91)).x, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 91)).y, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 91)).z);
					Vector3 vector12;
					vector12..ctor(Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 112)).x, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 112)).y, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 112)).z);
					Vector3 vector13;
					vector13..ctor(Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 17)).x, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 17)).y, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 17)).z);
					Vector3 vector14;
					vector14..ctor(Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 22)).x, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 22)).y, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 22)).z);
					Color color = player.HealthController.IsAlive ? this.method_9(player.Side, player) : Color.gray;
					if (Vector3.Distance(Camera.main.transform.position, player.Transform.position) <= this.float_6 && (double)vector8.z > 0.01 && vector8.x > -5f && vector8.y > -5f && vector8.x < 1920f && vector8.y < 1080f && (double)vector8.z > 0.01)
					{
						CrtacBoja.DrawLine(new Vector2(vector9.x - 2f, (float)Screen.height - vector9.y), new Vector2(vector9.x + 2f, (float)Screen.height - vector9.y), Color.cyan);
						CrtacBoja.DrawLine(new Vector2(vector9.x, (float)Screen.height - vector9.y - 2f), new Vector2(vector9.x, (float)Screen.height - vector9.y + 2f), Color.cyan);
						CrtacBoja.DrawLine(new Vector2(vector5.x, (float)Screen.height - vector5.y), new Vector2(vector6.x, (float)Screen.height - vector6.y), color);
						CrtacBoja.DrawLine(new Vector2(vector3.x, (float)Screen.height - vector3.y), new Vector2(vector11.x, (float)Screen.height - vector11.y), color);
						CrtacBoja.DrawLine(new Vector2(vector4.x, (float)Screen.height - vector4.y), new Vector2(vector12.x, (float)Screen.height - vector12.y), color);
						CrtacBoja.DrawLine(new Vector2(vector11.x, (float)Screen.height - vector11.y), new Vector2(vector2.x, (float)Screen.height - vector2.y), color);
						CrtacBoja.DrawLine(new Vector2(vector12.x, (float)Screen.height - vector12.y), new Vector2(vector.x, (float)Screen.height - vector.y), color);
						CrtacBoja.DrawLine(new Vector2(vector4.x, (float)Screen.height - vector4.y), new Vector2(vector3.x, (float)Screen.height - vector3.y), color);
						CrtacBoja.DrawLine(new Vector2(vector13.x, (float)Screen.height - vector13.y), new Vector2(vector6.x, (float)Screen.height - vector6.y), color);
						CrtacBoja.DrawLine(new Vector2(vector14.x, (float)Screen.height - vector14.y), new Vector2(vector6.x, (float)Screen.height - vector6.y), color);
						CrtacBoja.DrawLine(new Vector2(vector13.x, (float)Screen.height - vector13.y), new Vector2(vector10.x, (float)Screen.height - vector10.y), color);
						CrtacBoja.DrawLine(new Vector2(vector14.x, (float)Screen.height - vector14.y), new Vector2(vector7.x, (float)Screen.height - vector7.y), color);
					}
				}
			}
		}

		// Token: 0x0600B875 RID: 47221 RVA: 0x003B12A0 File Offset: 0x003AF4A0
		private string method_4(string string_0)
		{
			if (string_0.Contains(Class52.smethod_0(-1339807211)))
			{
				return Class52.smethod_0(-1339807189);
			}
			if (string_0.Contains(Class52.smethod_0(-1339807179)))
			{
				return Class52.smethod_0(-1339806269);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806255)))
			{
				return Class52.smethod_0(-1339806243);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806231)))
			{
				return Class52.smethod_0(-1339806222);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806209)))
			{
				return Class52.smethod_0(-1339806323);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806309)))
			{
				return Class52.smethod_0(-1339806294);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806281)))
			{
				return Class52.smethod_0(-1339806388);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806375)))
			{
				return Class52.smethod_0(-1339806358);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806337)))
			{
				return Class52.smethod_0(-1339806454);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806439)))
			{
				return Class52.smethod_0(-1339806419);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806527)))
			{
				return Class52.smethod_0(-1339806513);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806499)))
			{
				return Class52.smethod_0(-1339806484);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806591)))
			{
				return Class52.smethod_0(-1339806561);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806542)))
			{
				return Class52.smethod_0(-1339806640);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806617)))
			{
				return Class52.smethod_0(-1339806720);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806702)))
			{
				return Class52.smethod_0(-1339806671);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805755)))
			{
				return Class52.smethod_0(-1339805727);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805710)))
			{
				return Class52.smethod_0(-1339805807);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805787)))
			{
				return Class52.smethod_0(-1339805770);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805877)))
			{
				return Class52.smethod_0(-1339805864);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805847)))
			{
				return Class52.smethod_0(-1339805952);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805929)))
			{
				return Class52.smethod_0(-1339805915);
			}
			return string_0;
		}

		// Token: 0x0600B876 RID: 47222 RVA: 0x003B152C File Offset: 0x003AF72C
		private void method_5()
		{
			try
			{
				using (List<GInterface7>.Enumerator enumerator = this.method_12().LootList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						LootItem lootItem = (LootItem)enumerator.Current;
						float num = Vector3.Distance(Camera.main.transform.position, lootItem.transform.position);
						Vector3 vector;
						vector..ctor(Camera.main.WorldToScreenPoint(lootItem.transform.position).x, Camera.main.WorldToScreenPoint(lootItem.transform.position).y, Camera.main.WorldToScreenPoint(lootItem.transform.position).z);
						if ((double)vector.z > 0.01 && num <= this.float_7 && (lootItem.name.Contains(Class52.smethod_0(-1339807211)) || lootItem.name.Contains(Class52.smethod_0(-1339806309)) || lootItem.name.Contains(Class52.smethod_0(-1339806281)) || lootItem.name.Contains(Class52.smethod_0(-1339806375)) || lootItem.name.Contains(Class52.smethod_0(-1339806337)) || lootItem.name.Contains(Class52.smethod_0(-1339806439)) || lootItem.name.Contains(Class52.smethod_0(-1339807179)) || lootItem.name.Contains(Class52.smethod_0(-1339806209)) || lootItem.name.Contains(Class52.smethod_0(-1339806231)) || lootItem.name.Contains(Class52.smethod_0(-1339806527)) || lootItem.name.Contains(Class52.smethod_0(-1339806255)) || lootItem.name.Contains(Class52.smethod_0(-1339806499)) || lootItem.name.Contains(Class52.smethod_0(-1339806591)) || lootItem.name.Contains(Class52.smethod_0(-1339806542)) || lootItem.name.Contains(Class52.smethod_0(-1339806617)) || lootItem.name.Contains(Class52.smethod_0(-1339806702)) || lootItem.name.Contains(Class52.smethod_0(-1339805755)) || lootItem.name.Contains(Class52.smethod_0(-1339805710)) || lootItem.name.Contains(Class52.smethod_0(-1339805787)) || lootItem.name.Contains(Class52.smethod_0(-1339805877)) || lootItem.name.Contains(Class52.smethod_0(-1339805847)) || lootItem.name.Contains(Class52.smethod_0(-1339805929))) && (double)vector.z > 0.01)
						{
							int num2 = (int)num;
							string arg;
							try
							{
								arg = this.method_4(lootItem.name);
							}
							catch
							{
								arg = Class52.smethod_0(-1339805896);
							}
							GUIStyle guistyle = new GUIStyle
							{
								fontSize = 12
							};
							guistyle.normal.textColor = Color.red;
							string text = string.Format(Class52.smethod_0(-1339806012), arg, num2);
							GUI.Label(new Rect(vector.x - 50f, (float)Screen.height - vector.y, 100f, 50f), text, guistyle);
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B877 RID: 47223 RVA: 0x003B1930 File Offset: 0x003AFB30
		private string method_6(string string_0)
		{
			if (string_0.Contains(Class52.smethod_0(-1339805993)))
			{
				return Class52.smethod_0(-1339805975);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805957)))
			{
				return Class52.smethod_0(-1339806072);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806055)))
			{
				return Class52.smethod_0(-1339806035);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806143)))
			{
				return Class52.smethod_0(-1339806121);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806099)))
			{
				return Class52.smethod_0(-1339806083);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806195)))
			{
				return Class52.smethod_0(-1339806173);
			}
			if (string_0.Contains(Class52.smethod_0(-1339806151)))
			{
				return Class52.smethod_0(-1339805242);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805225)))
			{
				return Class52.smethod_0(-1339805212);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805195)))
			{
				return Class52.smethod_0(-1339805309);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805295)))
			{
				return Class52.smethod_0(-1339805284);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805269)))
			{
				return Class52.smethod_0(-1339805258);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805371)))
			{
				return Class52.smethod_0(-1339805358);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805341)))
			{
				return Class52.smethod_0(-1339805331);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805321)))
			{
				return Class52.smethod_0(-1339805433);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805417)))
			{
				return Class52.smethod_0(-1339805401);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805385)))
			{
				return Class52.smethod_0(-1339805495);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805477)))
			{
				return Class52.smethod_0(-1339805463);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805449)))
			{
				return Class52.smethod_0(-1339805564);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805547)))
			{
				return Class52.smethod_0(-1339805533);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805517)))
			{
				return Class52.smethod_0(-1339805621);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805612)))
			{
				return Class52.smethod_0(-1339805588);
			}
			if (string_0.Contains(Class52.smethod_0(-1339805578)))
			{
				return Class52.smethod_0(-1339805679);
			}
			return string_0;
		}

		// Token: 0x0600B878 RID: 47224 RVA: 0x003B1BBC File Offset: 0x003AFDBC
		private void method_7()
		{
			try
			{
				using (List<GInterface7>.Enumerator enumerator = this.method_12().LootList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						LootItem lootItem = (LootItem)enumerator.Current;
						float num = Vector3.Distance(Camera.main.transform.position, lootItem.transform.position);
						Vector3 vector;
						vector..ctor(Camera.main.WorldToScreenPoint(lootItem.transform.position).x, Camera.main.WorldToScreenPoint(lootItem.transform.position).y, Camera.main.WorldToScreenPoint(lootItem.transform.position).z);
						if ((double)vector.z > 0.01 && num <= this.float_7 && (lootItem.name.Contains(Class52.smethod_0(-1339805993)) || lootItem.name.Contains(Class52.smethod_0(-1339805957)) || lootItem.name.Contains(Class52.smethod_0(-1339806055)) || lootItem.name.Contains(Class52.smethod_0(-1339806143)) || lootItem.name.Contains(Class52.smethod_0(-1339806099)) || lootItem.name.Contains(Class52.smethod_0(-1339806195)) || lootItem.name.Contains(Class52.smethod_0(-1339806151)) || lootItem.name.Contains(Class52.smethod_0(-1339805225)) || lootItem.name.Contains(Class52.smethod_0(-1339805195)) || lootItem.name.Contains(Class52.smethod_0(-1339805295)) || lootItem.name.Contains(Class52.smethod_0(-1339805269)) || lootItem.name.Contains(Class52.smethod_0(-1339805371)) || lootItem.name.Contains(Class52.smethod_0(-1339805341)) || lootItem.name.Contains(Class52.smethod_0(-1339805321)) || lootItem.name.Contains(Class52.smethod_0(-1339805417)) || lootItem.name.Contains(Class52.smethod_0(-1339805385)) || lootItem.name.Contains(Class52.smethod_0(-1339805477)) || lootItem.name.Contains(Class52.smethod_0(-1339805449)) || lootItem.name.Contains(Class52.smethod_0(-1339805547)) || lootItem.name.Contains(Class52.smethod_0(-1339805517)) || lootItem.name.Contains(Class52.smethod_0(-1339805612)) || lootItem.name.Contains(Class52.smethod_0(-1339805578))) && (double)vector.z > 0.01)
						{
							int num2 = (int)num;
							string arg;
							try
							{
								arg = this.method_6(lootItem.name);
							}
							catch
							{
								arg = Class52.smethod_0(-1339805896);
							}
							GUIStyle guistyle = new GUIStyle
							{
								fontSize = 12
							};
							guistyle.normal.textColor = Color.magenta;
							string text = string.Format(Class52.smethod_0(-1339806012), arg, num2);
							GUI.Label(new Rect(vector.x - 50f, (float)Screen.height - vector.y, 100f, 50f), text, guistyle);
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B879 RID: 47225 RVA: 0x003B1FC0 File Offset: 0x003B01C0
		private void method_8()
		{
			try
			{
				foreach (Player player in this.ienumerable_0.Where(new Func<Player, bool>(SisaKuracPicka.Class57.class57_0.method_0)))
				{
					if (!(player == null) && player.Transform != null && !(Camera.main == null))
					{
						float num = Vector3.Distance(Camera.main.transform.position, player.Transform.position);
						Vector3 vector;
						vector..ctor(Camera.main.WorldToScreenPoint(player.Transform.position).x, Camera.main.WorldToScreenPoint(player.Transform.position).y, Camera.main.WorldToScreenPoint(player.Transform.position).z);
						if (num <= num && (double)vector.z > 0.01 && vector.x > -5f && vector.y > -5f && vector.x < 1920f && vector.y < 1080f)
						{
							if (player.HealthController.IsAlive && player.Profile.Info.RegistrationDate > 0)
							{
								Vector3 vector2 = Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position);
								Vector3 vector3 = Camera.main.WorldToScreenPoint(player.Transform.position);
								float x = vector3.x;
								float num2 = vector2.y + 10f;
								float num3 = Math.Abs(vector2.y - vector3.y) + 10f;
								float num4 = num3 * 0.65f;
								Color color = this.method_9(player.Side, player);
								string text;
								if (!player.HealthController.IsAlive)
								{
									text = Class52.smethod_0(-1339805662);
								}
								else
								{
									GStruct185 bodyPartHealth = player.HealthController.GetBodyPartHealth(EBodyPart.Common, false);
									text = bodyPartHealth.Current.ToString();
								}
								string str = text;
								string str2 = (player.Profile.Info.RegistrationDate <= 0) ? Class52.smethod_0(-1339805654) : player.Profile.Info.Nickname;
								int level = player.Profile.Info.Level;
								if (player.Profile.Info.Nickname == Class52.smethod_0(-1339809716))
								{
									this.Usec.r = this.dr;
									this.Usec.g = this.dg;
									this.Usec.b = this.db;
									this.Usec.a = this.da;
									CrtacBoja.DrawLine(new Vector2(vector2.x - 10f, (float)Screen.height - vector2.y), new Vector2(vector2.x + 10f, (float)Screen.height - vector2.y), this.Usec);
								}
								if (player.Profile.Info.Nickname == Class52.smethod_0(-1339809725))
								{
									this.Bear.r = this.mr;
									this.Bear.g = this.mg;
									this.Bear.b = this.mb;
									this.Bear.a = this.ma;
									CrtacBoja.DrawLine(new Vector2(vector2.x - 10f, (float)Screen.height - vector2.y), new Vector2(vector2.x + 10f, (float)Screen.height - vector2.y), this.Bear);
								}
								string text2 = string.Format(Class52.smethod_0(-1339805641), (int)num, level);
								string text3 = str2 + Class52.smethod_0(-1339804727) + str;
								Vector2 vector4 = GUI.skin.GetStyle(text2).CalcSize(new GUIContent(text2));
								Vector2 vector5 = GUI.skin.GetStyle(text3).CalcSize(new GUIContent(text3));
								CrtacBoja.DrawBox(x - num4 / 2f, (float)Screen.height - num2, num4, num3, color);
								CrtacBoja.DrawLine(new Vector2(vector2.x - 2f, (float)Screen.height - vector2.y), new Vector2(vector2.x + 2f, (float)Screen.height - vector2.y), color);
								CrtacBoja.DrawLine(new Vector2(vector2.x, (float)Screen.height - vector2.y - 2f), new Vector2(vector2.x, (float)Screen.height - vector2.y + 2f), color);
								CrtacBoja.DrawLine(new Vector2(vector2.x, (float)Screen.height - vector2.y - 2f), new Vector2(vector2.x, (float)Screen.height - vector2.y + 2f), SisaKuracPicka.color_0, 3f);
								GUI.Label(new Rect(vector.x - vector4.x / 2f, (float)Screen.height - num2 - 20f, 300f, 50f), text2);
								GUI.Label(new Rect(vector.x - vector5.x / 2f, (float)Screen.height - num2 + num3 + 1f, 300f, 50f), text3);
							}
							else if (player.Profile.Info.RegistrationDate <= 0 && this.bool_6 && player.HealthController.IsAlive)
							{
								Vector3 vector6 = Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position);
								Vector3 vector7 = Camera.main.WorldToScreenPoint(player.Transform.position);
								float x2 = vector7.x;
								float num5 = vector6.y + 10f;
								float num6 = Math.Abs(vector6.y - vector7.y) + 10f;
								float num7 = num6 * 0.65f;
								Color color2 = this.method_9(player.Side, player);
								string text4;
								if (!player.HealthController.IsAlive)
								{
									text4 = Class52.smethod_0(-1339805662);
								}
								else
								{
									GStruct185 bodyPartHealth = player.HealthController.GetBodyPartHealth(EBodyPart.Common, false);
									text4 = bodyPartHealth.Current.ToString();
								}
								string str3 = text4;
								string str4 = (player.Profile.Info.RegistrationDate <= 0) ? Class52.smethod_0(-1339805654) : player.Profile.Info.Nickname;
								int level2 = player.Profile.Info.Level;
								if (player.Profile.Info.Nickname == Class52.smethod_0(-1339809716))
								{
									this.Usec.r = this.dr;
									this.Usec.g = this.dg;
									this.Usec.b = this.db;
									this.Usec.a = this.da;
									CrtacBoja.DrawLine(new Vector2(vector6.x - 10f, (float)Screen.height - vector6.y), new Vector2(vector6.x + 10f, (float)Screen.height - vector6.y), this.Usec);
								}
								if (player.Profile.Info.Nickname == Class52.smethod_0(-1339809725))
								{
									this.Bear.r = this.mr;
									this.Bear.g = this.mg;
									this.Bear.b = this.mb;
									this.Bear.a = this.ma;
									CrtacBoja.DrawLine(new Vector2(vector6.x - 10f, (float)Screen.height - vector6.y), new Vector2(vector6.x + 10f, (float)Screen.height - vector6.y), this.Bear);
								}
								string text5 = string.Format(Class52.smethod_0(-1339805641), (int)num, level2);
								string text6 = str4 + Class52.smethod_0(-1339804727) + str3;
								Vector2 vector8 = GUI.skin.GetStyle(text5).CalcSize(new GUIContent(text5));
								Vector2 vector9 = GUI.skin.GetStyle(text6).CalcSize(new GUIContent(text6));
								CrtacBoja.DrawBox(x2 - num7 / 2f, (float)Screen.height - num5, num7, num6, color2);
								CrtacBoja.DrawLine(new Vector2(vector6.x - 2f, (float)Screen.height - vector6.y), new Vector2(vector6.x + 2f, (float)Screen.height - vector6.y), color2);
								CrtacBoja.DrawLine(new Vector2(vector6.x, (float)Screen.height - vector6.y - 2f), new Vector2(vector6.x, (float)Screen.height - vector6.y + 2f), color2);
								GUI.Label(new Rect(vector.x - vector8.x / 2f, (float)Screen.height - num5 - 20f, 300f, 50f), text5);
								GUI.Label(new Rect(vector.x - vector9.x / 2f, (float)Screen.height - num5 + num6 + 1f, 300f, 50f), text6);
							}
							else if (!player.HealthController.IsAlive && this.bool_8)
							{
								Vector3 vector10 = Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position);
								Vector3 vector11 = Camera.main.WorldToScreenPoint(player.Transform.position);
								float x3 = vector11.x;
								float num8 = vector10.y + 10f;
								float num9 = Math.Abs(vector10.y - vector11.y) + 10f;
								float num10 = num9 * 0.65f;
								Color color3 = player.HealthController.IsAlive ? this.method_9(player.Side, player) : Color.gray;
								string text7 = (player.Profile.Info.RegistrationDate <= 0) ? Class52.smethod_0(-1339805654) : player.Profile.Info.Nickname;
								int level3 = player.Profile.Info.Level;
								if (player.Profile.Info.Nickname == Class52.smethod_0(-1339809716))
								{
									this.Usec.r = this.dr;
									this.Usec.g = this.dg;
									this.Usec.b = this.db;
									this.Usec.a = this.da;
									CrtacBoja.DrawLine(new Vector2(vector10.x - 10f, (float)Screen.height - vector10.y), new Vector2(vector10.x + 10f, (float)Screen.height - vector10.y), this.Usec);
								}
								if (player.Profile.Info.Nickname == Class52.smethod_0(-1339809725))
								{
									this.Bear.r = this.mr;
									this.Bear.g = this.mg;
									this.Bear.b = this.mb;
									this.Bear.a = this.ma;
									CrtacBoja.DrawLine(new Vector2(vector10.x - 10f, (float)Screen.height - vector10.y), new Vector2(vector10.x + 10f, (float)Screen.height - vector10.y), this.Bear);
								}
								string text8 = string.Format(Class52.smethod_0(-1339805641), (int)num, level3);
								string text9 = text7 ?? string.Empty;
								Vector2 vector12 = GUI.skin.GetStyle(text8).CalcSize(new GUIContent(text8));
								Vector2 vector13 = GUI.skin.GetStyle(text9).CalcSize(new GUIContent(text9));
								CrtacBoja.DrawBox(x3 - num10 / 2f, (float)Screen.height - num8, num10, num9, color3);
								CrtacBoja.DrawLine(new Vector2(vector10.x - 2f, (float)Screen.height - vector10.y), new Vector2(vector10.x + 2f, (float)Screen.height - vector10.y), color3);
								CrtacBoja.DrawLine(new Vector2(vector10.x, (float)Screen.height - vector10.y - 2f), new Vector2(vector10.x, (float)Screen.height - vector10.y + 2f), color3);
								GUI.Label(new Rect(vector.x - vector12.x / 2f, (float)Screen.height - num8 - 20f, 300f, 50f), text8);
								GUI.Label(new Rect(vector.x - vector13.x / 2f, (float)Screen.height - num8 + num9 + 1f, 300f, 50f), text9);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				File.WriteAllText(Class52.smethod_0(-1339804717), ex.ToString());
			}
		}

		// Token: 0x0600B87A RID: 47226 RVA: 0x003B2D88 File Offset: 0x003B0F88
		public void DrawESPMenu()
		{
			if (!this.meucolor)
			{
				GUI.color = Color.cyan;
			}
			if (this.meucolor)
			{
				this.meniboja.a = 1f;
				this.meniboja.r = this.mcr;
				this.meniboja.g = this.mcg;
				this.meniboja.b = this.mcb;
				GUI.color = this.meniboja;
			}
			GUI.Box(new Rect(0f, 0f, 400f, 60f), Class52.smethod_0(-1339804691));
			if (GUI.Button(new Rect(20f, 20f, 80f, 30f), Class52.smethod_0(-1339804674)))
			{
				this.aimTab = !this.aimTab;
			}
			if (GUI.Button(new Rect(110f, 20f, 80f, 30f), Class52.smethod_0(-1339804787)))
			{
				this.espTab = !this.espTab;
			}
			if (GUI.Button(new Rect(200f, 20f, 80f, 30f), Class52.smethod_0(-1339804777)))
			{
				this.miscTab = !this.miscTab;
			}
			if (GUI.Button(new Rect(290f, 20f, 80f, 30f), Class52.smethod_0(-1339804768)))
			{
				this.friendsTab = !this.friendsTab;
			}
			if (this.aimTab)
			{
				if (this.espTab)
				{
					this.espTab = false;
				}
				if (this.miscTab)
				{
					this.miscTab = false;
				}
				if (this.friendsTab)
				{
					this.friendsTab = false;
				}
				GUI.Box(new Rect(0f, 61f, 400f, 90f), Class52.smethod_0(-1339804753));
				CPlayer.bDrawSkeleton = GUI.Toggle(new Rect(20f, 80f, 100f, 30f), CPlayer.bDrawSkeleton, Class52.smethod_0(-1339804864));
				this.aim = GUI.Toggle(new Rect(20f, 100f, 100f, 30f), this.aim, Class52.smethod_0(-1339804848));
				GUI.Label(new Rect(20f, 120f, 100f, 20f), Class52.smethod_0(-1339804827) + Convert.ToInt32(this.float_5));
				this.float_5 = GUI.HorizontalSlider(new Rect(20f, 140f, 100f, 20f), this.float_5, 1f, 60f);
			}
			if (this.espTab)
			{
				if (this.aimTab)
				{
					this.aimTab = false;
				}
				if (this.miscTab)
				{
					this.miscTab = false;
				}
				if (this.friendsTab)
				{
					this.friendsTab = false;
				}
				GUI.Box(new Rect(0f, 61f, 400f, 150f), Class52.smethod_0(-1339804787));
				this.bool_2 = GUI.Toggle(new Rect(20f, 80f, 100f, 50f), this.bool_2, Class52.smethod_0(-1339804818));
				this.bool_4 = GUI.Toggle(new Rect(20f, 100f, 100f, 50f), this.bool_4, Class52.smethod_0(-1339804804));
				this.bool_5 = GUI.Toggle(new Rect(20f, 120f, 100f, 50f), this.bool_5, Class52.smethod_0(-1339804915));
				this.bool_3 = GUI.Toggle(new Rect(20f, 140f, 100f, 50f), this.bool_3, Class52.smethod_0(-1339804899));
			}
			if (this.miscTab)
			{
				if (this.aimTab)
				{
					this.aimTab = false;
				}
				if (this.espTab)
				{
					this.espTab = false;
				}
				if (this.friendsTab)
				{
					this.friendsTab = false;
				}
				GUI.Box(new Rect(0f, 61f, 400f, 150f), Class52.smethod_0(-1339804777));
				this.bool_7 = GUI.Toggle(new Rect(20f, 80f, 120f, 50f), this.bool_7, Class52.smethod_0(-1339804883));
				this.peder = GUI.Toggle(new Rect(20f, 100f, 120f, 50f), this.peder, Class52.smethod_0(-1339804992));
				this.bool_8 = GUI.Toggle(new Rect(20f, 120f, 120f, 50f), this.bool_8, Class52.smethod_0(-1339804974));
				this.bool_6 = GUI.Toggle(new Rect(20f, 140f, 120f, 50f), this.bool_6, Class52.smethod_0(-1339804949));
				this._plusnaekranu = GUI.Toggle(new Rect(20f, 160f, 120f, 50f), this._plusnaekranu, Class52.smethod_0(-1339804933));
			}
			if (this.friendsTab)
			{
				if (this.aimTab)
				{
					this.aimTab = false;
				}
				if (this.espTab)
				{
					this.espTab = false;
				}
				if (this.miscTab)
				{
					this.miscTab = false;
				}
				GUI.Box(new Rect(0f, 61f, 400f, 150f), Class52.smethod_0(-1339805045));
				this.meucolor = GUI.Toggle(new Rect(20f, 140f, 100f, 30f), this.meucolor, Class52.smethod_0(-1339805034));
				this.medoboja = GUI.Toggle(new Rect(20f, 80f, 100f, 30f), this.medoboja, Class52.smethod_0(-1339809725));
				this.usecboja = GUI.Toggle(new Rect(20f, 100f, 100f, 30f), this.usecboja, Class52.smethod_0(-1339809716));
				this.scavboja = GUI.Toggle(new Rect(20f, 120f, 100f, 30f), this.scavboja, Class52.smethod_0(-1339805015));
				this.crosscolor = GUI.Toggle(new Rect(20f, 160f, 100f, 30f), this.crosscolor, Class52.smethod_0(-1339804933));
				if (this.crosscolor)
				{
					GUI.Box(new Rect(0f, 220f, 300f, 150f), Class52.smethod_0(-1339805006));
					GUI.Label(new Rect(30f, 240f, 100f, 30f), Class52.smethod_0(-1339805112));
					this.cr = GUI.HorizontalSlider(new Rect(20f, 260f, 100f, 30f), this.cr, 0f, 1f);
					GUI.Label(new Rect(30f, 270f, 100f, 30f), Class52.smethod_0(-1339805099));
					this.cg = GUI.HorizontalSlider(new Rect(20f, 280f, 100f, 30f), this.cg, 0f, 1f);
					GUI.Label(new Rect(30f, 290f, 100f, 30f), Class52.smethod_0(-1339805088));
					this.cb = GUI.HorizontalSlider(new Rect(20f, 300f, 100f, 30f), this.cb, 0f, 1f);
				}
				if (this.medoboja)
				{
					GUI.Box(new Rect(410f, 0f, 300f, 150f), Class52.smethod_0(-1339805076));
					GUI.Label(new Rect(430f, 15f, 100f, 30f), Class52.smethod_0(-1339805112));
					this.r = GUI.HorizontalSlider(new Rect(420f, 30f, 100f, 30f), this.r, 0f, 1f);
					GUI.Label(new Rect(430f, 35f, 100f, 30f), Class52.smethod_0(-1339805099));
					this.g = GUI.HorizontalSlider(new Rect(420f, 50f, 100f, 30f), this.g, 0f, 1f);
					GUI.Label(new Rect(430f, 55f, 100f, 30f), Class52.smethod_0(-1339805088));
					this.b = GUI.HorizontalSlider(new Rect(420f, 70f, 100f, 30f), this.b, 0f, 1f);
				}
				if (this.usecboja)
				{
					GUI.Box(new Rect(820f, 0f, 300f, 150f), Class52.smethod_0(-1339805057));
					GUI.Label(new Rect(840f, 15f, 100f, 30f), Class52.smethod_0(-1339805112));
					this.rm = GUI.HorizontalSlider(new Rect(830f, 30f, 100f, 30f), this.rm, 0f, 1f);
					GUI.Label(new Rect(840f, 35f, 100f, 30f), Class52.smethod_0(-1339805099));
					this.gm = GUI.HorizontalSlider(new Rect(830f, 50f, 100f, 30f), this.gm, 0f, 1f);
					GUI.Label(new Rect(840f, 55f, 100f, 30f), Class52.smethod_0(-1339805088));
					this.bm = GUI.HorizontalSlider(new Rect(830f, 70f, 100f, 30f), this.bm, 0f, 1f);
				}
				if (this.scavboja)
				{
					GUI.Box(new Rect(1230f, 0f, 300f, 150f), Class52.smethod_0(-1339805168));
					GUI.Label(new Rect(1250f, 15f, 100f, 30f), Class52.smethod_0(-1339805112));
					this.rs = GUI.HorizontalSlider(new Rect(1240f, 30f, 100f, 30f), this.rs, 0f, 1f);
					GUI.Label(new Rect(1250f, 35f, 100f, 30f), Class52.smethod_0(-1339805099));
					this.gs = GUI.HorizontalSlider(new Rect(1240f, 50f, 100f, 30f), this.gs, 0f, 1f);
					GUI.Label(new Rect(1250f, 55f, 100f, 30f), Class52.smethod_0(-1339805088));
					this.bs = GUI.HorizontalSlider(new Rect(1240f, 70f, 100f, 30f), this.bs, 0f, 1f);
				}
				if (this.meucolor)
				{
					GUI.Box(new Rect(1650f, 0f, 300f, 150f), Class52.smethod_0(-1339805034));
					GUI.Label(new Rect(1670f, 15f, 100f, 30f), Class52.smethod_0(-1339805112));
					this.mcr = GUI.HorizontalSlider(new Rect(1660f, 30f, 100f, 30f), this.mcr, 0f, 1f);
					GUI.Label(new Rect(1670f, 35f, 100f, 30f), Class52.smethod_0(-1339805099));
					this.mcg = GUI.HorizontalSlider(new Rect(1660f, 50f, 100f, 30f), this.mcg, 0f, 1f);
					GUI.Label(new Rect(1670f, 55f, 100f, 30f), Class52.smethod_0(-1339805088));
					this.mcb = GUI.HorizontalSlider(new Rect(1670f, 70f, 100f, 30f), this.mcb, 0f, 1f);
				}
			}
		}

		// Token: 0x0600B87B RID: 47227 RVA: 0x003B3A9C File Offset: 0x003B1C9C
		public void CrtanjeMenijaZaBoje()
		{
			if (this.drugeboje)
			{
				GUI.Box(new Rect(600f, 110f, 150f, 20f), Class52.smethod_0(-1339804768));
				this.medoboja = GUI.Toggle(new Rect(610f, 130f, 150f, 20f), this.medoboja, Class52.smethod_0(-1339809725));
				this.usecboja = GUI.Toggle(new Rect(610f, 160f, 150f, 20f), this.usecboja, Class52.smethod_0(-1339809716));
				this.scavboja = GUI.Toggle(new Rect(610f, 190f, 150f, 20f), this.scavboja, Class52.smethod_0(-1339805015));
				if (this.medoboja)
				{
					GUI.Box(new Rect(910f, 0f, 200f, 120f), Class52.smethod_0(-1339805076));
					GUI.Label(new Rect(930f, 15f, 100f, 30f), Class52.smethod_0(-1339805112));
					this.r = GUI.HorizontalSlider(new Rect(920f, 30f, 100f, 30f), this.r, 0f, 1f);
					GUI.Label(new Rect(930f, 35f, 100f, 30f), Class52.smethod_0(-1339805099));
					this.g = GUI.HorizontalSlider(new Rect(920f, 50f, 100f, 30f), this.g, 0f, 1f);
					GUI.Label(new Rect(930f, 55f, 100f, 30f), Class52.smethod_0(-1339805088));
					this.b = GUI.HorizontalSlider(new Rect(920f, 70f, 100f, 30f), this.b, 0f, 1f);
				}
				if (this.usecboja)
				{
					GUI.Box(new Rect(1120f, 0f, 200f, 120f), Class52.smethod_0(-1339805149));
					GUI.Label(new Rect(1140f, 15f, 100f, 30f), Class52.smethod_0(-1339805112));
					this.rm = GUI.HorizontalSlider(new Rect(1130f, 30f, 100f, 30f), this.rm, 0f, 1f);
					GUI.Label(new Rect(1140f, 35f, 100f, 30f), Class52.smethod_0(-1339805099));
					this.gm = GUI.HorizontalSlider(new Rect(1130f, 50f, 100f, 30f), this.gm, 0f, 1f);
					GUI.Label(new Rect(1140f, 55f, 100f, 30f), Class52.smethod_0(-1339805088));
					this.bm = GUI.HorizontalSlider(new Rect(1130f, 70f, 100f, 30f), this.bm, 0f, 1f);
				}
				if (this.scavboja)
				{
					GUI.Box(new Rect(1330f, 0f, 200f, 120f), Class52.smethod_0(-1339805168));
					GUI.Label(new Rect(1350f, 15f, 100f, 30f), Class52.smethod_0(-1339805112));
					this.rs = GUI.HorizontalSlider(new Rect(1340f, 30f, 100f, 30f), this.rs, 0f, 1f);
					GUI.Label(new Rect(1350f, 35f, 100f, 30f), Class52.smethod_0(-1339805099));
					this.gs = GUI.HorizontalSlider(new Rect(1340f, 50f, 100f, 30f), this.gs, 0f, 1f);
					GUI.Label(new Rect(1350f, 55f, 100f, 30f), Class52.smethod_0(-1339805088));
					this.bs = GUI.HorizontalSlider(new Rect(1340f, 70f, 100f, 30f), this.bs, 0f, 1f);
				}
			}
		}

		// Token: 0x0600B87C RID: 47228 RVA: 0x003B3F50 File Offset: 0x003B2150
		private Color method_9(EPlayerSide eplayerSide_0, Player player_1)
		{
			this.medobojaa.r = this.r;
			this.medobojaa.g = this.g;
			this.medobojaa.b = this.b;
			this.medobojaa.a = 1f;
			this.usecbojaa.r = this.rm;
			this.usecbojaa.g = this.gm;
			this.usecbojaa.b = this.bm;
			this.usecbojaa.a = 1f;
			this.scavbojaa.r = this.rs;
			this.scavbojaa.g = this.gs;
			this.scavbojaa.b = this.bs;
			this.scavbojaa.a = 1f;
			if (this.method_13(player_1.gameObject, this.getBonePos(player_1)))
			{
				return Color.red;
			}
			switch (eplayerSide_0)
			{
			case EPlayerSide.Usec:
				return this.usecbojaa;
			case EPlayerSide.Bear:
				return this.medobojaa;
			case EPlayerSide.Savage:
				return this.scavbojaa;
			}
			return Color.magenta;
		}

		// Token: 0x0600B87D RID: 47229 RVA: 0x00114FDB File Offset: 0x001131DB
		private double method_10(double double_0, double double_1, double double_2, double double_3)
		{
			return Math.Sqrt(Math.Pow(double_2 - double_0, 2.0) + Math.Pow(double_3 - double_1, 2.0));
		}

		// Token: 0x0600B87E RID: 47230 RVA: 0x003B4078 File Offset: 0x003B2278
		public void CiterskiPeder()
		{
			foreach (Player player in this.method_12().RegisteredPlayers)
			{
				if (!(player == null) && !(player == SisaKuracPicka.player_0) && player.HealthController != null && player.HealthController.IsAlive)
				{
					Vector3 bonePos = this.getBonePos(player);
					if (!(bonePos == Vector3.zero) && SisaKuracPicka.CalcInFov(bonePos) <= this.float_5 && this.method_13(player.gameObject, this.getBonePos(player)))
					{
						this.AimAtPos(bonePos);
					}
				}
			}
		}

		// Token: 0x0600B87F RID: 47231 RVA: 0x003B4134 File Offset: 0x003B2334
		private void method_11()
		{
			foreach (Player player in Object.FindObjectsOfType<Player>())
			{
				if (!(player == null) && player.PointOfView == EPointOfView.FirstPerson && player != null)
				{
					SisaKuracPicka.player_0 = player;
				}
			}
		}

		// Token: 0x0600B880 RID: 47232 RVA: 0x003B417C File Offset: 0x003B237C
		private GameWorld method_12()
		{
			if (Singleton<GameWorld>.Instantiated)
			{
				foreach (Player player in Singleton<GameWorld>.Instance.RegisteredPlayers)
				{
					if (player.gameObject.GetComponent<PlayerOwner>() != null)
					{
						SisaKuracPicka.player_0 = player;
					}
				}
				return Singleton<GameWorld>.Instance;
			}
			return null;
		}

		// Token: 0x0600B881 RID: 47233 RVA: 0x003B41F4 File Offset: 0x003B23F4
		private bool method_13(GameObject gameObject_1, Vector3 vector3_0)
		{
			RaycastHit raycastHit;
			return Physics.Linecast(SisaKuracPicka.GetShootPos(), vector3_0, ref raycastHit) && raycastHit.collider && raycastHit.collider.gameObject.transform.root.gameObject == gameObject_1.transform.root.gameObject;
		}

		// Token: 0x0600B882 RID: 47234 RVA: 0x003B4250 File Offset: 0x003B2450
		public static Vector3 GetShootPos()
		{
			if (SisaKuracPicka.player_0 == null)
			{
				return Vector3.zero;
			}
			Player.FirearmController firearmController = SisaKuracPicka.player_0.HandsController as Player.FirearmController;
			if (firearmController == null)
			{
				return Vector3.zero;
			}
			return firearmController.Fireport.position + Camera.main.transform.forward * 1f;
		}

		// Token: 0x0600B883 RID: 47235 RVA: 0x003B42B8 File Offset: 0x003B24B8
		public static Vector3 SkeletonBonePos(Skeleton sko, int id)
		{
			return sko.Bones.ElementAt(id).Value.position;
		}

		// Token: 0x0600B884 RID: 47236 RVA: 0x003B42E0 File Offset: 0x003B24E0
		public Vector3 GetBonePosByID(Player p, int id)
		{
			Vector3 result;
			try
			{
				result = SisaKuracPicka.SkeletonBonePos(p.PlayerBones.AnimatedTransform.Original.gameObject.GetComponent<PlayerBody>().SkeletonRootJoint, id);
			}
			catch (Exception)
			{
				result = Vector3.zero;
			}
			return result;
		}

		// Token: 0x0600B885 RID: 47237 RVA: 0x00115006 File Offset: 0x00113206
		public int idtobid(SisaKuracPicka.ibid bid)
		{
			switch (bid)
			{
			case SisaKuracPicka.ibid.Neck:
				return 132;
			case SisaKuracPicka.ibid.Chest:
				return 36;
			case SisaKuracPicka.ibid.Stomach:
				return 29;
			default:
				return 133;
			}
		}

		// Token: 0x0600B886 RID: 47238 RVA: 0x003B4330 File Offset: 0x003B2530
		public Vector3 getBonePos(Player inP)
		{
			int id = this.idtobid(SisaKuracPicka.ibid.Head);
			return this.GetBonePosByID(inP, id);
		}

		// Token: 0x0600B887 RID: 47239 RVA: 0x003B4350 File Offset: 0x003B2550
		public static float CalcInFov(Vector3 Position)
		{
			Vector3 position = Camera.main.transform.position;
			Vector3 forward = Camera.main.transform.forward;
			Vector3 normalized = (Position - position).normalized;
			return Mathf.Acos(Mathf.Clamp(Vector3.Dot(forward, normalized), -1f, 1f)) * 57.29578f;
		}

		// Token: 0x0600B888 RID: 47240 RVA: 0x003B43AC File Offset: 0x003B25AC
		public void AimAtPos(Vector3 pos)
		{
			Vector2 rotation = SisaKuracPicka.player_0.MovementContext.Rotation;
			Vector3 shootPos = SisaKuracPicka.GetShootPos();
			Vector3 eulerAngles = Quaternion.LookRotation((pos - shootPos).normalized).eulerAngles;
			if (eulerAngles.x > 180f)
			{
				eulerAngles.x -= 360f;
			}
			SisaKuracPicka.player_0.MovementContext.Rotation = new Vector2(eulerAngles.y, eulerAngles.x);
		}

		// Token: 0x0400A892 RID: 43154
		private GameObject gameObject_0;

		// Token: 0x0400A893 RID: 43155
		private IEnumerable<Player> ienumerable_0;

		// Token: 0x0400A894 RID: 43156
		private IEnumerable<ExfiltrationPoint> ienumerable_1;

		// Token: 0x0400A895 RID: 43157
		private IEnumerable<LootItem> ienumerable_2;

		// Token: 0x0400A896 RID: 43158
		private CGameWorld cgameWorld_0;

		// Token: 0x0400A897 RID: 43159
		private CPlayer cplayer_0;

		// Token: 0x0400A898 RID: 43160
		public bool peder;

		// Token: 0x0400A899 RID: 43161
		private float float_0;

		// Token: 0x0400A89A RID: 43162
		private float float_1;

		// Token: 0x0400A89B RID: 43163
		private float float_2 = 5f;

		// Token: 0x0400A89C RID: 43164
		private float float_3 = 10f;

		// Token: 0x0400A89D RID: 43165
		private float float_4;

		// Token: 0x0400A89E RID: 43166
		public bool _pokaziskeleton;

		// Token: 0x0400A89F RID: 43167
		private static Player player_0;

		// Token: 0x0400A8A0 RID: 43168
		public bool meucolor;

		// Token: 0x0400A8A1 RID: 43169
		public bool menuActive;

		// Token: 0x0400A8A2 RID: 43170
		public bool crosshair;

		// Token: 0x0400A8A3 RID: 43171
		public bool norecoil;

		// Token: 0x0400A8A4 RID: 43172
		public bool aimTab;

		// Token: 0x0400A8A5 RID: 43173
		public bool aim;

		// Token: 0x0400A8A6 RID: 43174
		public bool espTab;

		// Token: 0x0400A8A7 RID: 43175
		public Transform target;

		// Token: 0x0400A8A8 RID: 43176
		public bool esp;

		// Token: 0x0400A8A9 RID: 43177
		public bool yeetmenu;

		// Token: 0x0400A8AA RID: 43178
		public bool miscTab;

		// Token: 0x0400A8AB RID: 43179
		public bool friendsTab;

		// Token: 0x0400A8AC RID: 43180
		public bool crosscolor;

		// Token: 0x0400A8AD RID: 43181
		public bool menibojaa;

		// Token: 0x0400A8AE RID: 43182
		private float float_5;

		// Token: 0x0400A8AF RID: 43183
		public bool _teleportacijastvari;

		// Token: 0x0400A8B0 RID: 43184
		private static readonly Color color_0 = Color.green;

		// Token: 0x0400A8B1 RID: 43185
		private bool bool_0;

		// Token: 0x0400A8B2 RID: 43186
		private bool bool_1;

		// Token: 0x0400A8B3 RID: 43187
		private bool bool_2;

		// Token: 0x0400A8B4 RID: 43188
		private bool bool_3;

		// Token: 0x0400A8B5 RID: 43189
		private bool bool_4;

		// Token: 0x0400A8B6 RID: 43190
		private bool bool_5;

		// Token: 0x0400A8B7 RID: 43191
		public bool _plusnaekranu;

		// Token: 0x0400A8B8 RID: 43192
		public bool scavboja;

		// Token: 0x0400A8B9 RID: 43193
		public bool usecboja;

		// Token: 0x0400A8BA RID: 43194
		public bool medoboja;

		// Token: 0x0400A8BB RID: 43195
		public Color CrossColor;

		// Token: 0x0400A8BC RID: 43196
		public Color medobojaa;

		// Token: 0x0400A8BD RID: 43197
		public Color usecbojaa;

		// Token: 0x0400A8BE RID: 43198
		public Color scavbojaa;

		// Token: 0x0400A8BF RID: 43199
		public Color Usec;

		// Token: 0x0400A8C0 RID: 43200
		public Color Bear;

		// Token: 0x0400A8C1 RID: 43201
		public Color meniboja;

		// Token: 0x0400A8C2 RID: 43202
		public bool drugeboje;

		// Token: 0x0400A8C3 RID: 43203
		public float r;

		// Token: 0x0400A8C4 RID: 43204
		public float g;

		// Token: 0x0400A8C5 RID: 43205
		public float b;

		// Token: 0x0400A8C6 RID: 43206
		public float rs;

		// Token: 0x0400A8C7 RID: 43207
		public float gs;

		// Token: 0x0400A8C8 RID: 43208
		public float bs;

		// Token: 0x0400A8C9 RID: 43209
		public float rm;

		// Token: 0x0400A8CA RID: 43210
		public float gm;

		// Token: 0x0400A8CB RID: 43211
		public float bm;

		// Token: 0x0400A8CC RID: 43212
		public float mcr = 1f;

		// Token: 0x0400A8CD RID: 43213
		public float mcg;

		// Token: 0x0400A8CE RID: 43214
		public float mcb;

		// Token: 0x0400A8CF RID: 43215
		public float cr;

		// Token: 0x0400A8D0 RID: 43216
		public float cg;

		// Token: 0x0400A8D1 RID: 43217
		public float cb;

		// Token: 0x0400A8D2 RID: 43218
		public float ca = 1f;

		// Token: 0x0400A8D3 RID: 43219
		public float dr = 1f;

		// Token: 0x0400A8D4 RID: 43220
		public float dg = 0.5f;

		// Token: 0x0400A8D5 RID: 43221
		public float db = 0.1f;

		// Token: 0x0400A8D6 RID: 43222
		public float da = 1f;

		// Token: 0x0400A8D7 RID: 43223
		public float mr = 0.8f;

		// Token: 0x0400A8D8 RID: 43224
		public float mg = 0.3f;

		// Token: 0x0400A8D9 RID: 43225
		public float mb = 0.9f;

		// Token: 0x0400A8DA RID: 43226
		public float ma = 1f;

		// Token: 0x0400A8DB RID: 43227
		private float float_6 = 400f;

		// Token: 0x0400A8DC RID: 43228
		private float float_7 = 1500f;

		// Token: 0x0400A8DD RID: 43229
		private bool bool_6;

		// Token: 0x0400A8DE RID: 43230
		private bool bool_7;

		// Token: 0x0400A8DF RID: 43231
		private bool bool_8;

		// Token: 0x02002180 RID: 8576
		[Serializable]
		private sealed class Class57
		{
			// Token: 0x0600B88B RID: 47243 RVA: 0x000B058E File Offset: 0x000AE78E
			internal bool method_0(Player player_0)
			{
				return player_0 != null;
			}

			// Token: 0x0400A8E0 RID: 43232
			public static readonly SisaKuracPicka.Class57 class57_0 = new SisaKuracPicka.Class57();

			// Token: 0x0400A8E1 RID: 43233
			public static Func<Player, bool> func_0;
		}

		// Token: 0x02002181 RID: 8577
		public enum ibid
		{
			// Token: 0x0400A8E3 RID: 43235
			Head,
			// Token: 0x0400A8E4 RID: 43236
			Neck,
			// Token: 0x0400A8E5 RID: 43237
			Chest,
			// Token: 0x0400A8E6 RID: 43238
			Stomach
		}
	}
}
