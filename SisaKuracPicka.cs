using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Comfort.Common;
using Diz.Skinning;
using EFT.HideOut.Hooks;
using EFT.Interactive;
using UnityEngine;

namespace EFT.HideOut
{
	// Token: 0x0200210E RID: 8462
	public class SisaKuracPicka : MonoBehaviour
	{
		// Token: 0x0600B54A RID: 46410 RVA: 0x0009EF8C File Offset: 0x0009D18C
		private void Start()
		{
		}

		// Token: 0x0600B54B RID: 46411 RVA: 0x00112FFA File Offset: 0x001111FA
		public void Load()
		{
			this.\u0002 = new GameObject();
			this.\u0002.AddComponent<SisaKuracPicka>();
			UnityEngine.Object.DontDestroyOnLoad(this.\u0002);
		}

		// Token: 0x0600B54C RID: 46412 RVA: 0x0011301E File Offset: 0x0011121E
		public void Unload()
		{
			UnityEngine.Object.Destroy(this.\u0002);
			UnityEngine.Object.Destroy(this);
		}

		// Token: 0x0600B54D RID: 46413 RVA: 0x003A6ACC File Offset: 0x003A4CCC
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.F11))
			{
				this.\u000E\u2000 = !this.\u000E\u2000;
				if (this.\u000F\u2000)
				{
					this.\u000F\u2000 = false;
				}
			}
			if (Input.GetKeyUp(KeyCode.F7))
			{
				this.\u0005\u2001 = !this.\u0005\u2001;
			}
			if (Input.GetKeyUp(KeyCode.F8))
			{
				this.\u0008\u2001 = !this.\u0008\u2001;
			}
			if (Input.GetKeyDown(KeyCode.F9))
			{
				this.\u0003\u2001 = !this.\u0003\u2001;
			}
			if (Input.GetKeyDown(KeyCode.F1))
			{
				SAimbot.RedirectBullets = !SAimbot.RedirectBullets;
			}
			if (Input.GetKeyDown(KeyCode.F6))
			{
				CPlayer.bDrawSkeleton = !CPlayer.bDrawSkeleton;
			}
			if (Input.GetKeyDown(KeyCode.F10))
			{
				this.\u0002\u2002 = !this.\u0002\u2002;
			}
			if (Input.GetKeyDown(KeyCode.F2))
			{
				this.\u000F\u2001 = !this.\u000F\u2001;
			}
		}

		// Token: 0x0600B54E RID: 46414 RVA: 0x003A6BBC File Offset: 0x003A4DBC
		private void Awake()
		{
			try
			{
				this.\u0006 = base.gameObject.AddComponent<CGameWorld>();
				this.\u000E = base.gameObject.AddComponent<CPlayer>();
			}
			catch
			{
			}
		}

		// Token: 0x0600B54F RID: 46415 RVA: 0x003A6C00 File Offset: 0x003A4E00
		private void OnGUI()
		{
			if (this.\u000E\u2000)
			{
				this.DrawESPMenu();
			}
			GUI.Label(new Rect(0f, 0f, 1000f, 500f), \u0003\u2000__2.\u0002(872575357));
			if (this.\u0002\u2001 && Time.time >= this.\u000F)
			{
				this.\u0003 = UnityEngine.Object.FindObjectsOfType<Player>();
				this.\u000F = Time.time + this.\u0003\u2000;
			}
			if (this.\u0002\u2001)
			{
				this.\u0006();
			}
			if (this._pokaziskeleton)
			{
				if (Time.time >= this.\u000F)
				{
					this.\u000F = Time.time + this.\u0003\u2000;
				}
				this.\u0003();
			}
			if (this.\u0003\u2001 && Time.time >= this.\u0002\u2000)
			{
				this.\u0005 = UnityEngine.Object.FindObjectsOfType<ExfiltrationPoint>();
				this.\u0002\u2000 = Time.time + this.\u0003\u2000;
			}
			if (this.\u0003\u2001)
			{
				this.\u0002();
			}
			if (this._plusnaekranu)
			{
				this.Nisanusredini();
			}
			if (this.\u0005\u2001)
			{
				if (Time.time >= this.\u0008\u2000)
				{
					this.\u0008\u2000 = Time.time + this.\u0005\u2000;
				}
				this.\u0005();
			}
			if (this.\u0008\u2001)
			{
				if (Time.time >= this.\u0008\u2000)
				{
					this.\u0008\u2000 = Time.time + this.\u0005\u2000;
				}
				this.\u0008();
			}
			if (this.\u000F\u2000)
			{
				this.CrtanjeMenijaZaBoje();
			}
		}

		// Token: 0x0600B550 RID: 46416 RVA: 0x003A6D68 File Offset: 0x003A4F68
		private void \u0002()
		{
			foreach (ExfiltrationPoint exfiltrationPoint in this.\u0005)
			{
				if (!(exfiltrationPoint == null) && !(Camera.main == null))
				{
					float num = Vector3.Distance(Camera.main.transform.position, exfiltrationPoint.transform.position);
					Vector3 vector = Camera.main.WorldToScreenPoint(exfiltrationPoint.transform.position);
					if ((double)vector.z > 0.01)
					{
						string name = exfiltrationPoint.name;
						string arg = this.\u0002(name);
						string content = string.Format(\u0003\u2000__2.\u0002(872575015), arg, (int)num);
						CrtacBoja.Text(new Rect(vector.x - 50f, (float)Screen.height - vector.y, 100f, 50f), content, Color.green);
					}
				}
			}
		}

		// Token: 0x0600B551 RID: 46417 RVA: 0x003A6E78 File Offset: 0x003A5078
		private string \u0002(string \u0002)
		{
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575028)))
			{
				return \u0003\u2000__2.\u0002(872575047);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575049)))
			{
				return \u0003\u2000__2.\u0002(872575064);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575085)))
			{
				return \u0003\u2000__2.\u0002(872575100);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575873)))
			{
				return \u0003\u2000__2.\u0002(872575064);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575899)))
			{
				return \u0003\u2000__2.\u0002(872575925);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575950)))
			{
				return \u0003\u2000__2.\u0002(872575961);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575978)))
			{
				return \u0003\u2000__2.\u0002(872575998);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575758)))
			{
				return \u0003\u2000__2.\u0002(872575781);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575795)))
			{
				return \u0003\u2000__2.\u0002(872575831);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575843)))
			{
				return \u0003\u2000__2.\u0002(872575622);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575636)))
			{
				return \u0003\u2000__2.\u0002(872575660);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575686)))
			{
				return \u0003\u2000__2.\u0002(872575718);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575728)))
			{
				return \u0003\u2000__2.\u0002(872575510);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575526)))
			{
				return \u0003\u2000__2.\u0002(872575548);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575565)))
			{
				return \u0003\u2000__2.\u0002(872575589);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872575600)))
			{
				return \u0003\u2000__2.\u0002(872576402);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576428)))
			{
				return \u0003\u2000__2.\u0002(872576462);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576475)))
			{
				return \u0003\u2000__2.\u0002(872576493);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576263)))
			{
				return \u0003\u2000__2.\u0002(872576274);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576293)))
			{
				return \u0003\u2000__2.\u0002(872576312);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576329)))
			{
				return \u0003\u2000__2.\u0002(872576375);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576140)))
			{
				return \u0003\u2000__2.\u0002(872576180);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576195)))
			{
				return \u0003\u2000__2.\u0002(872576235);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576006)))
			{
				return \u0003\u2000__2.\u0002(872576039);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576060)))
			{
				return \u0003\u2000__2.\u0002(872576095);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576118)))
			{
				return \u0003\u2000__2.\u0002(872576918);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576923)))
			{
				return \u0003\u2000__2.\u0002(872576959);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576970)))
			{
				return \u0003\u2000__2.\u0002(872576984);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577012)))
			{
				return \u0003\u2000__2.\u0002(872576773);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576796)))
			{
				return \u0003\u2000__2.\u0002(872576800);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576830)))
			{
				return \u0003\u2000__2.\u0002(872576847);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576858)))
			{
				return \u0003\u2000__2.\u0002(872576873);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576647)))
			{
				return \u0003\u2000__2.\u0002(872576660);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576675)))
			{
				return \u0003\u2000__2.\u0002(872576698);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576727)))
			{
				return \u0003\u2000__2.\u0002(872576739);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576767)))
			{
				return \u0003\u2000__2.\u0002(872576524);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576541)))
			{
				return \u0003\u2000__2.\u0002(872576570);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576595)))
			{
				return \u0003\u2000__2.\u0002(872576630);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576632)))
			{
				return \u0003\u2000__2.\u0002(872577455);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577477)))
			{
				return \u0003\u2000__2.\u0002(872576524);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577500)))
			{
				return \u0003\u2000__2.\u0002(872577531);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577311)))
			{
				return \u0003\u2000__2.\u0002(872577341);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577361)))
			{
				return \u0003\u2000__2.\u0002(872577396);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577163)))
			{
				return \u0003\u2000__2.\u0002(872577193);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577223)))
			{
				return \u0003\u2000__2.\u0002(872577243);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577256)))
			{
				return \u0003\u2000__2.\u0002(872577031);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577043)))
			{
				return \u0003\u2000__2.\u0002(872577075);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577099)))
			{
				return \u0003\u2000__2.\u0002(872577130);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577926)))
			{
				return \u0003\u2000__2.\u0002(872577944);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577973)))
			{
				return \u0003\u2000__2.\u0002(872577992);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578018)))
			{
				return \u0003\u2000__2.\u0002(872578041);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577810)))
			{
				return \u0003\u2000__2.\u0002(872577841);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577868)))
			{
				return \u0003\u2000__2.\u0002(872577891);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872576263)))
			{
				return \u0003\u2000__2.\u0002(872577918);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577675)))
			{
				return \u0003\u2000__2.\u0002(872577918);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577709)))
			{
				return \u0003\u2000__2.\u0002(872577746);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577771)))
			{
				return \u0003\u2000__2.\u0002(872577536);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577556)))
			{
				return \u0003\u2000__2.\u0002(872577575);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577587)))
			{
				return \u0003\u2000__2.\u0002(872577602);
			}
			return \u0002;
		}

		// Token: 0x0600B552 RID: 46418 RVA: 0x003A7538 File Offset: 0x003A5738
		public void Nisanusredini()
		{
			this.CrossColor.r = this.cr;
			this.CrossColor.g = this.cg;
			this.CrossColor.b = this.cb;
			this.CrossColor.a = this.ca;
			CrtacBoja.DrawBox((float)Screen.width / 2f, (float)Screen.height / 2f - 5f, 1f, 11f, this.CrossColor);
			CrtacBoja.DrawBox((float)Screen.width / 2f - 5f, (float)Screen.height / 2f, 11f, 1f, this.CrossColor);
		}

		// Token: 0x0600B553 RID: 46419 RVA: 0x003A75F0 File Offset: 0x003A57F0
		private void \u0003()
		{
			foreach (Player player in this.\u0002().RegisteredPlayers)
			{
				if (!(player == SisaKuracPicka.\u0006\u2000) && player.IsVisible)
				{
					Vector3 vector = new Vector3(Camera.main.WorldToScreenPoint(player.PlayerBones.RightPalm.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.RightPalm.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.RightPalm.position).z);
					Vector3 vector2 = new Vector3(Camera.main.WorldToScreenPoint(player.PlayerBones.LeftPalm.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.LeftPalm.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.LeftPalm.position).z);
					Vector3 vector3 = new Vector3(Camera.main.WorldToScreenPoint(player.PlayerBones.LeftShoulder.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.LeftShoulder.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.LeftShoulder.position).z);
					Vector3 vector4 = new Vector3(Camera.main.WorldToScreenPoint(player.PlayerBones.RightShoulder.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.RightShoulder.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.RightShoulder.position).z);
					Vector3 vector5 = new Vector3(Camera.main.WorldToScreenPoint(player.PlayerBones.Neck.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.Neck.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.Neck.position).z);
					Vector3 vector6 = new Vector3(Camera.main.WorldToScreenPoint(player.PlayerBones.Pelvis.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.Pelvis.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.Pelvis.position).z);
					new Vector3(Camera.main.WorldToScreenPoint(player.PlayerBones.RightThigh2.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.RightThigh2.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.RightThigh2.position).z);
					new Vector3(Camera.main.WorldToScreenPoint(player.PlayerBones.LeftThigh2.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.LeftThigh2.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.LeftThigh2.position).z);
					Vector3 vector7 = new Vector3(Camera.main.WorldToScreenPoint(player.PlayerBones.KickingFoot.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.KickingFoot.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.KickingFoot.position).z);
					Vector3 vector8 = new Vector3(Camera.main.WorldToScreenPoint(player.Transform.position).x, Camera.main.WorldToScreenPoint(player.Transform.position).y, Camera.main.WorldToScreenPoint(player.Transform.position).z);
					Vector3 vector9 = new Vector3(Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position).x, Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position).y, Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position).z);
					Vector3 vector10 = new Vector3(Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 18)).x, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 18)).y, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 18)).z);
					Vector3 vector11 = new Vector3(Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 91)).x, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 91)).y, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 91)).z);
					Vector3 vector12 = new Vector3(Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 112)).x, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 112)).y, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 112)).z);
					Vector3 vector13 = new Vector3(Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 17)).x, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 17)).y, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 17)).z);
					Vector3 vector14 = new Vector3(Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 22)).x, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 22)).y, Camera.main.WorldToScreenPoint(this.GetBonePosByID(player, 22)).z);
					Color color = player.HealthController.IsAlive ? this.\u0002(player.Side, player) : Color.gray;
					if (Vector3.Distance(Camera.main.transform.position, player.Transform.position) <= this.\u0006\u2001 && (double)vector8.z > 0.01 && vector8.x > -5f && vector8.y > -5f && vector8.x < 1920f && vector8.y < 1080f && (double)vector8.z > 0.01)
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

		// Token: 0x0600B554 RID: 46420 RVA: 0x003A7FBC File Offset: 0x003A61BC
		private string \u0003(string \u0002)
		{
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577627)))
			{
				return \u0003\u2000__2.\u0002(872577653);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872577659)))
			{
				return \u0003\u2000__2.\u0002(872578445);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578463)))
			{
				return \u0003\u2000__2.\u0002(872578467);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578487)))
			{
				return \u0003\u2000__2.\u0002(872578490);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578497)))
			{
				return \u0003\u2000__2.\u0002(872578515);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578533)))
			{
				return \u0003\u2000__2.\u0002(872578546);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578553)))
			{
				return \u0003\u2000__2.\u0002(872578320);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578343)))
			{
				return \u0003\u2000__2.\u0002(872578354);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578369)))
			{
				return \u0003\u2000__2.\u0002(872578386);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578407)))
			{
				return \u0003\u2000__2.\u0002(872578419);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578191)))
			{
				return \u0003\u2000__2.\u0002(872578193);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578211)))
			{
				return \u0003\u2000__2.\u0002(872578224);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578255)))
			{
				return \u0003\u2000__2.\u0002(872578273);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578298)))
			{
				return \u0003\u2000__2.\u0002(872578076);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578089)))
			{
				return \u0003\u2000__2.\u0002(872578124);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578138)))
			{
				return \u0003\u2000__2.\u0002(872578175);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578955)))
			{
				return \u0003\u2000__2.\u0002(872578991);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872579002)))
			{
				return \u0003\u2000__2.\u0002(872579039);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872579051)))
			{
				return \u0003\u2000__2.\u0002(872578822);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578837)))
			{
				return \u0003\u2000__2.\u0002(872578852);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578871)))
			{
				return \u0003\u2000__2.\u0002(872578892);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578905)))
			{
				return \u0003\u2000__2.\u0002(872578923);
			}
			return \u0002;
		}

		// Token: 0x0600B555 RID: 46421 RVA: 0x003A8248 File Offset: 0x003A6448
		private void \u0005()
		{
			try
			{
				foreach (GInterface7 ginterface in this.\u0002().LootList)
				{
					LootItem lootItem = (LootItem)ginterface;
					float num = Vector3.Distance(Camera.main.transform.position, lootItem.transform.position);
					Vector3 vector = new Vector3(Camera.main.WorldToScreenPoint(lootItem.transform.position).x, Camera.main.WorldToScreenPoint(lootItem.transform.position).y, Camera.main.WorldToScreenPoint(lootItem.transform.position).z);
					if ((double)vector.z > 0.01 && num <= this.\u000E\u2001 && (lootItem.name.Contains(\u0003\u2000__2.\u0002(872577627)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578533)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578553)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578343)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578369)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578407)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872577659)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578497)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578487)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578191)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578463)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578211)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578255)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578298)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578089)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578138)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578955)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872579002)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872579051)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578837)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578871)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578905))) && (double)vector.z > 0.01)
					{
						int num2 = (int)num;
						string arg;
						try
						{
							arg = this.\u0003(lootItem.name);
						}
						catch
						{
							arg = \u0003\u2000__2.\u0002(872578692);
						}
						GUIStyle guistyle = new GUIStyle
						{
							fontSize = 12
						};
						guistyle.normal.textColor = Color.red;
						string text = string.Format(\u0003\u2000__2.\u0002(872578696), arg, num2);
						GUI.Label(new Rect(vector.x - 50f, (float)Screen.height - vector.y, 100f, 50f), text, guistyle);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B556 RID: 46422 RVA: 0x003A864C File Offset: 0x003A684C
		private string \u0005(string \u0002)
		{
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578713)))
			{
				return \u0003\u2000__2.\u0002(872578743);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578757)))
			{
				return \u0003\u2000__2.\u0002(872578772);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578791)))
			{
				return \u0003\u2000__2.\u0002(872578803);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578575)))
			{
				return \u0003\u2000__2.\u0002(872578585);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578611)))
			{
				return \u0003\u2000__2.\u0002(872578627);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872578643)))
			{
				return \u0003\u2000__2.\u0002(872578669);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571271)))
			{
				return \u0003\u2000__2.\u0002(872571286);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571289)))
			{
				return \u0003\u2000__2.\u0002(872571304);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571323)))
			{
				return \u0003\u2000__2.\u0002(872571341);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571359)))
			{
				return \u0003\u2000__2.\u0002(872571360);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571381)))
			{
				return \u0003\u2000__2.\u0002(872571142);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571147)))
			{
				return \u0003\u2000__2.\u0002(872571162);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571181)))
			{
				return \u0003\u2000__2.\u0002(872571187);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571193)))
			{
				return \u0003\u2000__2.\u0002(872571209);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571225)))
			{
				return \u0003\u2000__2.\u0002(872571241);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571257)))
			{
				return \u0003\u2000__2.\u0002(872571031);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571045)))
			{
				return \u0003\u2000__2.\u0002(872571063);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571065)))
			{
				return \u0003\u2000__2.\u0002(872571080);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571099)))
			{
				return \u0003\u2000__2.\u0002(872571117);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872571133)))
			{
				return \u0003\u2000__2.\u0002(872570901);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872570904)))
			{
				return \u0003\u2000__2.\u0002(872570928);
			}
			if (\u0002.Contains(\u0003\u2000__2.\u0002(872570950)))
			{
				return \u0003\u2000__2.\u0002(872570975);
			}
			return \u0002;
		}

		// Token: 0x0600B557 RID: 46423 RVA: 0x003A88D8 File Offset: 0x003A6AD8
		private void \u0008()
		{
			try
			{
				foreach (GInterface7 ginterface in this.\u0002().LootList)
				{
					LootItem lootItem = (LootItem)ginterface;
					float num = Vector3.Distance(Camera.main.transform.position, lootItem.transform.position);
					Vector3 vector = new Vector3(Camera.main.WorldToScreenPoint(lootItem.transform.position).x, Camera.main.WorldToScreenPoint(lootItem.transform.position).y, Camera.main.WorldToScreenPoint(lootItem.transform.position).z);
					if ((double)vector.z > 0.01 && num <= this.\u000E\u2001 && (lootItem.name.Contains(\u0003\u2000__2.\u0002(872578713)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578757)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578791)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578575)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578611)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872578643)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571271)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571289)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571323)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571359)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571381)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571147)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571181)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571193)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571225)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571257)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571045)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571065)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571099)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872571133)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872570904)) || lootItem.name.Contains(\u0003\u2000__2.\u0002(872570950))) && (double)vector.z > 0.01)
					{
						int num2 = (int)num;
						string arg;
						try
						{
							arg = this.\u0005(lootItem.name);
						}
						catch
						{
							arg = \u0003\u2000__2.\u0002(872578692);
						}
						GUIStyle guistyle = new GUIStyle
						{
							fontSize = 12
						};
						guistyle.normal.textColor = Color.magenta;
						string text = string.Format(\u0003\u2000__2.\u0002(872578696), arg, num2);
						GUI.Label(new Rect(vector.x - 50f, (float)Screen.height - vector.y, 100f, 50f), text, guistyle);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B558 RID: 46424 RVA: 0x003A8CDC File Offset: 0x003A6EDC
		private void \u0006()
		{
			try
			{
				foreach (Player player in this.\u0003.Where(new Func<Player, bool>(SisaKuracPicka.\u0002.\u0002.\u0002)))
				{
					if (!(player == null) && player.Transform != null && !(Camera.main == null))
					{
						float num = Vector3.Distance(Camera.main.transform.position, player.Transform.position);
						Vector3 vector = new Vector3(Camera.main.WorldToScreenPoint(player.Transform.position).x, Camera.main.WorldToScreenPoint(player.Transform.position).y, Camera.main.WorldToScreenPoint(player.Transform.position).z);
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
								Color color = this.\u0002(player.Side, player);
								string text;
								if (!player.HealthController.IsAlive)
								{
									text = \u0003\u2000__2.\u0002(872570986);
								}
								else
								{
									GStruct184 bodyPartHealth = player.HealthController.GetBodyPartHealth(7, false);
									text = bodyPartHealth.Current.ToString();
								}
								string str = text;
								string str2 = (player.Profile.Info.RegistrationDate <= 0) ? \u0003\u2000__2.\u0002(872570994) : player.Profile.Info.Nickname;
								int level = player.Profile.Info.Level;
								if (player.Profile.Info.Nickname == \u0003\u2000__2.\u0002(872571001))
								{
									this.Usec.r = this.dr;
									this.Usec.g = this.dg;
									this.Usec.b = this.db;
									this.Usec.a = this.da;
									CrtacBoja.DrawLine(new Vector2(vector2.x - 10f, (float)Screen.height - vector2.y), new Vector2(vector2.x + 10f, (float)Screen.height - vector2.y), this.Usec);
								}
								if (player.Profile.Info.Nickname == \u0003\u2000__2.\u0002(872571788))
								{
									this.Bear.r = this.mr;
									this.Bear.g = this.mg;
									this.Bear.b = this.mb;
									this.Bear.a = this.ma;
									CrtacBoja.DrawLine(new Vector2(vector2.x - 10f, (float)Screen.height - vector2.y), new Vector2(vector2.x + 10f, (float)Screen.height - vector2.y), this.Bear);
								}
								string text2 = string.Format(\u0003\u2000__2.\u0002(872571795), (int)num, level);
								string text3 = str2 + \u0003\u2000__2.\u0002(872571809) + str;
								Vector2 vector4 = GUI.skin.GetStyle(text2).CalcSize(new GUIContent(text2));
								Vector2 vector5 = GUI.skin.GetStyle(text3).CalcSize(new GUIContent(text3));
								CrtacBoja.DrawBox(x - num4 / 2f, (float)Screen.height - num2, num4, num3, color);
								CrtacBoja.DrawLine(new Vector2(vector2.x - 2f, (float)Screen.height - vector2.y), new Vector2(vector2.x + 2f, (float)Screen.height - vector2.y), color);
								CrtacBoja.DrawLine(new Vector2(vector2.x, (float)Screen.height - vector2.y - 2f), new Vector2(vector2.x, (float)Screen.height - vector2.y + 2f), color);
								GUI.Label(new Rect(vector.x - vector4.x / 2f, (float)Screen.height - num2 - 20f, 300f, 50f), text2);
								GUI.Label(new Rect(vector.x - vector5.x / 2f, (float)Screen.height - num2 + num3 + 1f, 300f, 50f), text3);
							}
							else if (player.Profile.Info.RegistrationDate <= 0 && this.\u000F\u2001 && player.HealthController.IsAlive)
							{
								Vector3 vector6 = Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position);
								Vector3 vector7 = Camera.main.WorldToScreenPoint(player.Transform.position);
								float x2 = vector7.x;
								float num5 = vector6.y + 10f;
								float num6 = Math.Abs(vector6.y - vector7.y) + 10f;
								float num7 = num6 * 0.65f;
								Color color2 = this.\u0002(player.Side, player);
								string text4;
								if (!player.HealthController.IsAlive)
								{
									text4 = \u0003\u2000__2.\u0002(872570986);
								}
								else
								{
									GStruct184 bodyPartHealth = player.HealthController.GetBodyPartHealth(7, false);
									text4 = bodyPartHealth.Current.ToString();
								}
								string str3 = text4;
								string str4 = (player.Profile.Info.RegistrationDate <= 0) ? \u0003\u2000__2.\u0002(872570994) : player.Profile.Info.Nickname;
								int level2 = player.Profile.Info.Level;
								if (player.Profile.Info.Nickname == \u0003\u2000__2.\u0002(872571001))
								{
									this.Usec.r = this.dr;
									this.Usec.g = this.dg;
									this.Usec.b = this.db;
									this.Usec.a = this.da;
									CrtacBoja.DrawLine(new Vector2(vector6.x - 10f, (float)Screen.height - vector6.y), new Vector2(vector6.x + 10f, (float)Screen.height - vector6.y), this.Usec);
								}
								if (player.Profile.Info.Nickname == \u0003\u2000__2.\u0002(872571788))
								{
									this.Bear.r = this.mr;
									this.Bear.g = this.mg;
									this.Bear.b = this.mb;
									this.Bear.a = this.ma;
									CrtacBoja.DrawLine(new Vector2(vector6.x - 10f, (float)Screen.height - vector6.y), new Vector2(vector6.x + 10f, (float)Screen.height - vector6.y), this.Bear);
								}
								string text5 = string.Format(\u0003\u2000__2.\u0002(872571795), (int)num, level2);
								string text6 = str4 + \u0003\u2000__2.\u0002(872571809) + str3;
								Vector2 vector8 = GUI.skin.GetStyle(text5).CalcSize(new GUIContent(text5));
								Vector2 vector9 = GUI.skin.GetStyle(text6).CalcSize(new GUIContent(text6));
								CrtacBoja.DrawBox(x2 - num7 / 2f, (float)Screen.height - num5, num7, num6, color2);
								CrtacBoja.DrawLine(new Vector2(vector6.x - 2f, (float)Screen.height - vector6.y), new Vector2(vector6.x + 2f, (float)Screen.height - vector6.y), color2);
								CrtacBoja.DrawLine(new Vector2(vector6.x, (float)Screen.height - vector6.y - 2f), new Vector2(vector6.x, (float)Screen.height - vector6.y + 2f), color2);
								GUI.Label(new Rect(vector.x - vector8.x / 2f, (float)Screen.height - num5 - 20f, 300f, 50f), text5);
								GUI.Label(new Rect(vector.x - vector9.x / 2f, (float)Screen.height - num5 + num6 + 1f, 300f, 50f), text6);
							}
							else if (!player.HealthController.IsAlive && this.\u0002\u2002)
							{
								Vector3 vector10 = Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position);
								Vector3 vector11 = Camera.main.WorldToScreenPoint(player.Transform.position);
								float x3 = vector11.x;
								float num8 = vector10.y + 10f;
								float num9 = Math.Abs(vector10.y - vector11.y) + 10f;
								float num10 = num9 * 0.65f;
								Color color3 = player.HealthController.IsAlive ? this.\u0002(player.Side, player) : Color.gray;
								string text7 = (player.Profile.Info.RegistrationDate <= 0) ? \u0003\u2000__2.\u0002(872570994) : player.Profile.Info.Nickname;
								int level3 = player.Profile.Info.Level;
								if (player.Profile.Info.Nickname == \u0003\u2000__2.\u0002(872571001))
								{
									this.Usec.r = this.dr;
									this.Usec.g = this.dg;
									this.Usec.b = this.db;
									this.Usec.a = this.da;
									CrtacBoja.DrawLine(new Vector2(vector10.x - 10f, (float)Screen.height - vector10.y), new Vector2(vector10.x + 10f, (float)Screen.height - vector10.y), this.Usec);
								}
								if (player.Profile.Info.Nickname == \u0003\u2000__2.\u0002(872571788))
								{
									this.Bear.r = this.mr;
									this.Bear.g = this.mg;
									this.Bear.b = this.mb;
									this.Bear.a = this.ma;
									CrtacBoja.DrawLine(new Vector2(vector10.x - 10f, (float)Screen.height - vector10.y), new Vector2(vector10.x + 10f, (float)Screen.height - vector10.y), this.Bear);
								}
								string text8 = string.Format(\u0003\u2000__2.\u0002(872571795), (int)num, level3);
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
				File.WriteAllText(\u0003\u2000__2.\u0002(872571831), ex.ToString());
			}
		}

		// Token: 0x0600B559 RID: 46425 RVA: 0x003A9A58 File Offset: 0x003A7C58
		public void DrawESPMenu()
		{
			if (!this.meucolor)
			{
				GUI.color = Color.red;
			}
			if (this.meucolor)
			{
				this.meniboja.a = 1f;
				this.meniboja.r = this.mcr;
				this.meniboja.g = this.mcg;
				this.meniboja.b = this.mcb;
				GUI.color = this.meniboja;
			}
			GUI.Box(new Rect(0f, 0f, 400f, 60f), \u0003\u2000__2.\u0002(872571853));
			if (GUI.Button(new Rect(20f, 20f, 80f, 30f), \u0003\u2000__2.\u0002(872571864)))
			{
				this.aimTab = !this.aimTab;
			}
			if (GUI.Button(new Rect(110f, 20f, 80f, 30f), \u0003\u2000__2.\u0002(872571885)))
			{
				this.espTab = !this.espTab;
			}
			if (GUI.Button(new Rect(200f, 20f, 80f, 30f), \u0003\u2000__2.\u0002(872571891)))
			{
				this.miscTab = !this.miscTab;
			}
			if (GUI.Button(new Rect(290f, 20f, 80f, 30f), \u0003\u2000__2.\u0002(872571654)))
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
				GUI.Box(new Rect(0f, 61f, 400f, 90f), \u0003\u2000__2.\u0002(872571659));
				SAimbot.RedirectBullets = GUI.Toggle(new Rect(20f, 80f, 100f, 30f), SAimbot.RedirectBullets, \u0003\u2000__2.\u0002(872571686));
				CPlayer.bDrawSkeleton = GUI.Toggle(new Rect(20f, 100f, 100f, 30f), CPlayer.bDrawSkeleton, \u0003\u2000__2.\u0002(872571698));
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
				GUI.Box(new Rect(0f, 61f, 400f, 150f), \u0003\u2000__2.\u0002(872571885));
				this.\u0002\u2001 = GUI.Toggle(new Rect(20f, 80f, 100f, 50f), this.\u0002\u2001, \u0003\u2000__2.\u0002(872571714));
				this.\u0005\u2001 = GUI.Toggle(new Rect(20f, 100f, 100f, 50f), this.\u0005\u2001, \u0003\u2000__2.\u0002(872571732));
				this.\u0008\u2001 = GUI.Toggle(new Rect(20f, 120f, 100f, 50f), this.\u0008\u2001, \u0003\u2000__2.\u0002(872571751));
				this.\u0003\u2001 = GUI.Toggle(new Rect(20f, 140f, 100f, 50f), this.\u0003\u2001, \u0003\u2000__2.\u0002(872571767));
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
				GUI.Box(new Rect(0f, 61f, 400f, 150f), \u0003\u2000__2.\u0002(872571891));
				this.\u0002\u2002 = GUI.Toggle(new Rect(20f, 80f, 120f, 50f), this.\u0002\u2002, \u0003\u2000__2.\u0002(872571527));
				this.\u000F\u2001 = GUI.Toggle(new Rect(20f, 100f, 120f, 50f), this.\u000F\u2001, \u0003\u2000__2.\u0002(872571550));
				this._plusnaekranu = GUI.Toggle(new Rect(20f, 120f, 120f, 50f), this._plusnaekranu, \u0003\u2000__2.\u0002(872571566));
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
				GUI.Box(new Rect(0f, 61f, 400f, 150f), \u0003\u2000__2.\u0002(872571582));
				this.meucolor = GUI.Toggle(new Rect(20f, 140f, 100f, 30f), this.meucolor, \u0003\u2000__2.\u0002(872571587));
				this.medoboja = GUI.Toggle(new Rect(20f, 80f, 100f, 30f), this.medoboja, \u0003\u2000__2.\u0002(872571788));
				this.usecboja = GUI.Toggle(new Rect(20f, 100f, 100f, 30f), this.usecboja, \u0003\u2000__2.\u0002(872571001));
				this.scavboja = GUI.Toggle(new Rect(20f, 120f, 100f, 30f), this.scavboja, \u0003\u2000__2.\u0002(872571600));
				this.crosscolor = GUI.Toggle(new Rect(20f, 160f, 100f, 30f), this.crosscolor, \u0003\u2000__2.\u0002(872571566));
				if (this.crosscolor)
				{
					GUI.Box(new Rect(0f, 220f, 300f, 150f), \u0003\u2000__2.\u0002(872571623));
					GUI.Label(new Rect(30f, 240f, 100f, 30f), \u0003\u2000__2.\u0002(872571633));
					this.cr = GUI.HorizontalSlider(new Rect(20f, 260f, 100f, 30f), this.cr, 0f, 1f);
					GUI.Label(new Rect(30f, 270f, 100f, 30f), \u0003\u2000__2.\u0002(872571396));
					this.cg = GUI.HorizontalSlider(new Rect(20f, 280f, 100f, 30f), this.cg, 0f, 1f);
					GUI.Label(new Rect(30f, 290f, 100f, 30f), \u0003\u2000__2.\u0002(872571401));
					this.cb = GUI.HorizontalSlider(new Rect(20f, 300f, 100f, 30f), this.cb, 0f, 1f);
				}
				if (this.medoboja)
				{
					GUI.Box(new Rect(410f, 0f, 300f, 150f), \u0003\u2000__2.\u0002(872571421));
					GUI.Label(new Rect(430f, 15f, 100f, 30f), \u0003\u2000__2.\u0002(872571633));
					this.r = GUI.HorizontalSlider(new Rect(420f, 30f, 100f, 30f), this.r, 0f, 1f);
					GUI.Label(new Rect(430f, 35f, 100f, 30f), \u0003\u2000__2.\u0002(872571396));
					this.g = GUI.HorizontalSlider(new Rect(420f, 50f, 100f, 30f), this.g, 0f, 1f);
					GUI.Label(new Rect(430f, 55f, 100f, 30f), \u0003\u2000__2.\u0002(872571401));
					this.b = GUI.HorizontalSlider(new Rect(420f, 70f, 100f, 30f), this.b, 0f, 1f);
				}
				if (this.usecboja)
				{
					GUI.Box(new Rect(820f, 0f, 300f, 150f), \u0003\u2000__2.\u0002(872571434));
					GUI.Label(new Rect(840f, 15f, 100f, 30f), \u0003\u2000__2.\u0002(872571633));
					this.rm = GUI.HorizontalSlider(new Rect(830f, 30f, 100f, 30f), this.rm, 0f, 1f);
					GUI.Label(new Rect(840f, 35f, 100f, 30f), \u0003\u2000__2.\u0002(872571396));
					this.gm = GUI.HorizontalSlider(new Rect(830f, 50f, 100f, 30f), this.gm, 0f, 1f);
					GUI.Label(new Rect(840f, 55f, 100f, 30f), \u0003\u2000__2.\u0002(872571401));
					this.bm = GUI.HorizontalSlider(new Rect(830f, 70f, 100f, 30f), this.bm, 0f, 1f);
				}
				if (this.scavboja)
				{
					GUI.Box(new Rect(1230f, 0f, 300f, 150f), \u0003\u2000__2.\u0002(872571449));
					GUI.Label(new Rect(1250f, 15f, 100f, 30f), \u0003\u2000__2.\u0002(872571633));
					this.rs = GUI.HorizontalSlider(new Rect(1240f, 30f, 100f, 30f), this.rs, 0f, 1f);
					GUI.Label(new Rect(1250f, 35f, 100f, 30f), \u0003\u2000__2.\u0002(872571396));
					this.gs = GUI.HorizontalSlider(new Rect(1240f, 50f, 100f, 30f), this.gs, 0f, 1f);
					GUI.Label(new Rect(1250f, 55f, 100f, 30f), \u0003\u2000__2.\u0002(872571401));
					this.bs = GUI.HorizontalSlider(new Rect(1240f, 70f, 100f, 30f), this.bs, 0f, 1f);
				}
				if (this.meucolor)
				{
					GUI.Box(new Rect(1650f, 0f, 300f, 150f), \u0003\u2000__2.\u0002(872571587));
					GUI.Label(new Rect(1670f, 15f, 100f, 30f), \u0003\u2000__2.\u0002(872571633));
					this.mcr = GUI.HorizontalSlider(new Rect(1660f, 30f, 100f, 30f), this.mcr, 0f, 1f);
					GUI.Label(new Rect(1670f, 35f, 100f, 30f), \u0003\u2000__2.\u0002(872571396));
					this.mcg = GUI.HorizontalSlider(new Rect(1660f, 50f, 100f, 30f), this.mcg, 0f, 1f);
					GUI.Label(new Rect(1670f, 55f, 100f, 30f), \u0003\u2000__2.\u0002(872571401));
					this.mcb = GUI.HorizontalSlider(new Rect(1670f, 70f, 100f, 30f), this.mcb, 0f, 1f);
				}
			}
		}

		// Token: 0x0600B55A RID: 46426 RVA: 0x003AA690 File Offset: 0x003A8890
		public void CrtanjeMenijaZaBoje()
		{
			if (this.drugeboje)
			{
				GUI.Box(new Rect(600f, 110f, 150f, 20f), \u0003\u2000__2.\u0002(872571654));
				this.medoboja = GUI.Toggle(new Rect(610f, 130f, 150f, 20f), this.medoboja, \u0003\u2000__2.\u0002(872571788));
				this.usecboja = GUI.Toggle(new Rect(610f, 160f, 150f, 20f), this.usecboja, \u0003\u2000__2.\u0002(872571001));
				this.scavboja = GUI.Toggle(new Rect(610f, 190f, 150f, 20f), this.scavboja, \u0003\u2000__2.\u0002(872571600));
				if (this.medoboja)
				{
					GUI.Box(new Rect(910f, 0f, 200f, 120f), \u0003\u2000__2.\u0002(872571421));
					GUI.Label(new Rect(930f, 15f, 100f, 30f), \u0003\u2000__2.\u0002(872571633));
					this.r = GUI.HorizontalSlider(new Rect(920f, 30f, 100f, 30f), this.r, 0f, 1f);
					GUI.Label(new Rect(930f, 35f, 100f, 30f), \u0003\u2000__2.\u0002(872571396));
					this.g = GUI.HorizontalSlider(new Rect(920f, 50f, 100f, 30f), this.g, 0f, 1f);
					GUI.Label(new Rect(930f, 55f, 100f, 30f), \u0003\u2000__2.\u0002(872571401));
					this.b = GUI.HorizontalSlider(new Rect(920f, 70f, 100f, 30f), this.b, 0f, 1f);
				}
				if (this.usecboja)
				{
					GUI.Box(new Rect(1120f, 0f, 200f, 120f), \u0003\u2000__2.\u0002(872571478));
					GUI.Label(new Rect(1140f, 15f, 100f, 30f), \u0003\u2000__2.\u0002(872571633));
					this.rm = GUI.HorizontalSlider(new Rect(1130f, 30f, 100f, 30f), this.rm, 0f, 1f);
					GUI.Label(new Rect(1140f, 35f, 100f, 30f), \u0003\u2000__2.\u0002(872571396));
					this.gm = GUI.HorizontalSlider(new Rect(1130f, 50f, 100f, 30f), this.gm, 0f, 1f);
					GUI.Label(new Rect(1140f, 55f, 100f, 30f), \u0003\u2000__2.\u0002(872571401));
					this.bm = GUI.HorizontalSlider(new Rect(1130f, 70f, 100f, 30f), this.bm, 0f, 1f);
				}
				if (this.scavboja)
				{
					GUI.Box(new Rect(1330f, 0f, 200f, 120f), \u0003\u2000__2.\u0002(872571449));
					GUI.Label(new Rect(1350f, 15f, 100f, 30f), \u0003\u2000__2.\u0002(872571633));
					this.rs = GUI.HorizontalSlider(new Rect(1340f, 30f, 100f, 30f), this.rs, 0f, 1f);
					GUI.Label(new Rect(1350f, 35f, 100f, 30f), \u0003\u2000__2.\u0002(872571396));
					this.gs = GUI.HorizontalSlider(new Rect(1340f, 50f, 100f, 30f), this.gs, 0f, 1f);
					GUI.Label(new Rect(1350f, 55f, 100f, 30f), \u0003\u2000__2.\u0002(872571401));
					this.bs = GUI.HorizontalSlider(new Rect(1340f, 70f, 100f, 30f), this.bs, 0f, 1f);
				}
			}
		}

		// Token: 0x0600B55B RID: 46427 RVA: 0x003AAB44 File Offset: 0x003A8D44
		private Color \u0002(EPlayerSide \u0002, Player \u0003)
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
			if (this.\u0002(\u0003.gameObject, this.getBonePos(\u0003)))
			{
				return Color.red;
			}
			switch (\u0002)
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

		// Token: 0x0600B55C RID: 46428 RVA: 0x00113031 File Offset: 0x00111231
		private double \u0002(double \u0002, double \u0003, double \u0005, double \u0008)
		{
			return Math.Sqrt(Math.Pow(\u0005 - \u0002, 2.0) + Math.Pow(\u0008 - \u0003, 2.0));
		}

		// Token: 0x0600B55D RID: 46429 RVA: 0x003AAC6C File Offset: 0x003A8E6C
		private void \u000E()
		{
			foreach (Player player in UnityEngine.Object.FindObjectsOfType<Player>())
			{
				if (!(player == null) && player.PointOfView == EPointOfView.FirstPerson && player != null)
				{
					SisaKuracPicka.\u0006\u2000 = player;
				}
			}
		}

		// Token: 0x0600B55E RID: 46430 RVA: 0x003AACB4 File Offset: 0x003A8EB4
		private GameWorld \u0002()
		{
			if (Singleton<GameWorld>.Instantiated)
			{
				foreach (Player player in Singleton<GameWorld>.Instance.RegisteredPlayers)
				{
					if (player.gameObject.GetComponent<PlayerOwner>() != null)
					{
						SisaKuracPicka.\u0006\u2000 = player;
					}
				}
				return Singleton<GameWorld>.Instance;
			}
			return null;
		}

		// Token: 0x0600B55F RID: 46431 RVA: 0x003AAD2C File Offset: 0x003A8F2C
		private bool \u0002(GameObject \u0002, Vector3 \u0003)
		{
			RaycastHit raycastHit;
			return Physics.Linecast(SisaKuracPicka.GetShootPos(), \u0003, out raycastHit) && raycastHit.collider && raycastHit.collider.gameObject.transform.root.gameObject == \u0002.transform.root.gameObject;
		}

		// Token: 0x0600B560 RID: 46432 RVA: 0x003AAD88 File Offset: 0x003A8F88
		public Vector3 getBonePos(Player inP)
		{
			int id = this.idtobid(SisaKuracPicka.ibid.Neck);
			return this.GetBonePosByID(inP, id);
		}

		// Token: 0x0600B561 RID: 46433 RVA: 0x003AADA8 File Offset: 0x003A8FA8
		public static Vector3 GetShootPos()
		{
			if (SisaKuracPicka.\u0006\u2000 == null)
			{
				return Vector3.zero;
			}
			Player.FirearmController firearmController = SisaKuracPicka.\u0006\u2000.HandsController as Player.FirearmController;
			if (firearmController == null)
			{
				return Vector3.zero;
			}
			return firearmController.Fireport.position;
		}

		// Token: 0x0600B562 RID: 46434 RVA: 0x003AADF4 File Offset: 0x003A8FF4
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

		// Token: 0x0600B563 RID: 46435 RVA: 0x003AAE44 File Offset: 0x003A9044
		public static Vector3 SkeletonBonePos(Skeleton sko, int id)
		{
			return sko.Bones.ElementAt(id).Value.position;
		}

		// Token: 0x0600B564 RID: 46436 RVA: 0x0011305C File Offset: 0x0011125C
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

		// Token: 0x0400A68C RID: 42636
		private GameObject \u0002;

		// Token: 0x0400A68D RID: 42637
		private IEnumerable<Player> \u0003;

		// Token: 0x0400A68E RID: 42638
		private IEnumerable<ExfiltrationPoint> \u0005;

		// Token: 0x0400A68F RID: 42639
		private IEnumerable<LootItem> \u0008;

		// Token: 0x0400A690 RID: 42640
		private CGameWorld \u0006;

		// Token: 0x0400A691 RID: 42641
		private CPlayer \u000E;

		// Token: 0x0400A692 RID: 42642
		private float \u000F;

		// Token: 0x0400A693 RID: 42643
		private float \u0002\u2000;

		// Token: 0x0400A694 RID: 42644
		private float \u0003\u2000 = 5f;

		// Token: 0x0400A695 RID: 42645
		private float \u0005\u2000 = 10f;

		// Token: 0x0400A696 RID: 42646
		private float \u0008\u2000;

		// Token: 0x0400A697 RID: 42647
		public bool _pokaziskeleton;

		// Token: 0x0400A698 RID: 42648
		private static Player \u0006\u2000;

		// Token: 0x0400A699 RID: 42649
		public bool meucolor;

		// Token: 0x0400A69A RID: 42650
		public bool l33t;

		// Token: 0x0400A69B RID: 42651
		public bool menuActive;

		// Token: 0x0400A69C RID: 42652
		public bool instamag;

		// Token: 0x0400A69D RID: 42653
		public bool crosshair;

		// Token: 0x0400A69E RID: 42654
		public bool norecoil;

		// Token: 0x0400A69F RID: 42655
		public bool aimTab;

		// Token: 0x0400A6A0 RID: 42656
		public bool aim;

		// Token: 0x0400A6A1 RID: 42657
		public bool espTab;

		// Token: 0x0400A6A2 RID: 42658
		public Transform target;

		// Token: 0x0400A6A3 RID: 42659
		public bool esp;

		// Token: 0x0400A6A4 RID: 42660
		public bool yeetmenu;

		// Token: 0x0400A6A5 RID: 42661
		public bool miscTab;

		// Token: 0x0400A6A6 RID: 42662
		public bool friendsTab;

		// Token: 0x0400A6A7 RID: 42663
		public bool crosscolor;

		// Token: 0x0400A6A8 RID: 42664
		public bool menibojaa;

		// Token: 0x0400A6A9 RID: 42665
		public bool _teleportacijastvari;

		// Token: 0x0400A6AA RID: 42666
		private bool \u000E\u2000;

		// Token: 0x0400A6AB RID: 42667
		private bool \u000F\u2000;

		// Token: 0x0400A6AC RID: 42668
		private bool \u0002\u2001;

		// Token: 0x0400A6AD RID: 42669
		private bool \u0003\u2001;

		// Token: 0x0400A6AE RID: 42670
		private bool \u0005\u2001;

		// Token: 0x0400A6AF RID: 42671
		private bool \u0008\u2001;

		// Token: 0x0400A6B0 RID: 42672
		public bool _plusnaekranu;

		// Token: 0x0400A6B1 RID: 42673
		public bool scavboja;

		// Token: 0x0400A6B2 RID: 42674
		public bool usecboja;

		// Token: 0x0400A6B3 RID: 42675
		public bool medoboja;

		// Token: 0x0400A6B4 RID: 42676
		public Color CrossColor;

		// Token: 0x0400A6B5 RID: 42677
		public Color medobojaa;

		// Token: 0x0400A6B6 RID: 42678
		public Color usecbojaa;

		// Token: 0x0400A6B7 RID: 42679
		public Color scavbojaa;

		// Token: 0x0400A6B8 RID: 42680
		public Color Usec;

		// Token: 0x0400A6B9 RID: 42681
		public Color Bear;

		// Token: 0x0400A6BA RID: 42682
		public Color meniboja;

		// Token: 0x0400A6BB RID: 42683
		public bool drugeboje;

		// Token: 0x0400A6BC RID: 42684
		public float r;

		// Token: 0x0400A6BD RID: 42685
		public float g;

		// Token: 0x0400A6BE RID: 42686
		public float b;

		// Token: 0x0400A6BF RID: 42687
		public float rs;

		// Token: 0x0400A6C0 RID: 42688
		public float gs;

		// Token: 0x0400A6C1 RID: 42689
		public float bs;

		// Token: 0x0400A6C2 RID: 42690
		public float rm;

		// Token: 0x0400A6C3 RID: 42691
		public float gm;

		// Token: 0x0400A6C4 RID: 42692
		public float bm;

		// Token: 0x0400A6C5 RID: 42693
		public float mcr = 1f;

		// Token: 0x0400A6C6 RID: 42694
		public float mcg;

		// Token: 0x0400A6C7 RID: 42695
		public float mcb;

		// Token: 0x0400A6C8 RID: 42696
		public float cr;

		// Token: 0x0400A6C9 RID: 42697
		public float cg;

		// Token: 0x0400A6CA RID: 42698
		public float cb;

		// Token: 0x0400A6CB RID: 42699
		public float ca = 1f;

		// Token: 0x0400A6CC RID: 42700
		public float dr = 1f;

		// Token: 0x0400A6CD RID: 42701
		public float dg = 0.5f;

		// Token: 0x0400A6CE RID: 42702
		public float db = 0.1f;

		// Token: 0x0400A6CF RID: 42703
		public float da = 1f;

		// Token: 0x0400A6D0 RID: 42704
		public float mr = 0.8f;

		// Token: 0x0400A6D1 RID: 42705
		public float mg = 0.3f;

		// Token: 0x0400A6D2 RID: 42706
		public float mb = 0.9f;

		// Token: 0x0400A6D3 RID: 42707
		public float ma = 1f;

		// Token: 0x0400A6D4 RID: 42708
		private float \u0006\u2001 = 400f;

		// Token: 0x0400A6D5 RID: 42709
		private float \u000E\u2001 = 1500f;

		// Token: 0x0400A6D6 RID: 42710
		private bool \u000F\u2001;

		// Token: 0x0400A6D7 RID: 42711
		private bool \u0002\u2002;

		// Token: 0x0200210F RID: 8463
		[Serializable]
		private sealed class \u0002
		{
			// Token: 0x0600B567 RID: 46439 RVA: 0x000B02A3 File Offset: 0x000AE4A3
			internal bool \u0002(Player \u0002)
			{
				return \u0002 != null;
			}

			// Token: 0x0400A6D8 RID: 42712
			public static readonly SisaKuracPicka.\u0002 \u0002 = new SisaKuracPicka.\u0002();

			// Token: 0x0400A6D9 RID: 42713
			public static Func<Player, bool> \u0003;
		}

		// Token: 0x02002110 RID: 8464
		public enum ibid
		{
			// Token: 0x0400A6DB RID: 42715
			Head,
			// Token: 0x0400A6DC RID: 42716
			Neck,
			// Token: 0x0400A6DD RID: 42717
			Chest,
			// Token: 0x0400A6DE RID: 42718
			Stomach
		}
	}
}
