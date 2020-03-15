using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EFT.HideOut
{
	// Token: 0x02002178 RID: 8568
	public class CPlayer : MonoBehaviour
	{
		// Token: 0x0600B83D RID: 47165 RVA: 0x003AE11C File Offset: 0x003AC31C
		public void Update()
		{
			try
			{
				if (CGameWorld.activeGameworld)
				{
					CPlayer.Players = CGameWorld.activeGameworld.RegisteredPlayers;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B83E RID: 47166 RVA: 0x003AE15C File Offset: 0x003AC35C
		public void OnGUI()
		{
			try
			{
				if (Event.current.type == EventType.Repaint)
				{
					if (CGameWorld.activeGameworld)
					{
						Camera main = Camera.main;
						if (main)
						{
							CPlayer.LocalPlayer != null;
							foreach (Player player in CPlayer.Players)
							{
								if (player)
								{
									if (player.GetComponent<PlayerOwner>() != null)
									{
										CPlayer.LocalPlayer = player;
									}
									else
									{
										if (!CPlayer.bDraw)
										{
											break;
										}
										Vector3 vector = main.WorldToScreenPoint(player.Transform.position);
										if (vector.z >= 0.01f)
										{
											vector.y = (float)Screen.height - vector.y;
											float num = (float)Math.Floor((double)Vector3.Distance(player.Transform.position, main.transform.position));
											if (num <= this.float_0)
											{
												string arg = (player.Profile.Info.RegistrationDate == 0) ? player.Profile.Info.Settings.Role.ToString(Class52.smethod_0(-1339809425)) : player.Profile.Info.Nickname;
												if (CPlayer.bDrawInformation)
												{
													GUIHelper2.DrawFont(new Vector2(vector.x, vector.y), string.Format(Class52.smethod_0(-1339809417), arg, num), Color.red);
												}
												if (CPlayer.bDrawLines)
												{
													this.DrawLine(player, CPlayer.vec2DrawLine);
												}
												if (CPlayer.bDraw2DBox || CPlayer.bDraw3DBox || CPlayer.bDrawSkeleton)
												{
													Dictionary<EHumanBones, Vector3> bones = CPlayer.GetBones(player);
													if (bones.Count != 0)
													{
														if (CPlayer.bDraw2DBox || CPlayer.bDraw3DBox)
														{
															this.DrawBoxes(player);
														}
														if (CPlayer.bDrawSkeleton && num <= 300f)
														{
															this.DrawSkeleton(bones);
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B83F RID: 47167 RVA: 0x003AE3A0 File Offset: 0x003AC5A0
		public static Dictionary<EHumanBones, Vector3> GetBones(Player player)
		{
			try
			{
				Dictionary<EHumanBones, Vector3> dictionary = new Dictionary<EHumanBones, Vector3>();
				if (!player || player.PlayerBody == null || player.PlayerBody.SkeletonRootJoint == null)
				{
					return dictionary;
				}
				List<Transform> list = player.PlayerBody.SkeletonRootJoint.Bones.Values.ToList<Transform>();
				if (list.Count == 0)
				{
					return dictionary;
				}
				Camera main = Camera.main;
				if (main == null)
				{
					return dictionary;
				}
				for (int i = 0; i < list.Count; i++)
				{
					Transform transform = list[i];
					if (!(transform == null) && CPlayer.list_0.Contains((EHumanBones)i))
					{
						Vector3 vector = main.WorldToScreenPoint(transform.position);
						vector.y = (float)Screen.height - vector.y;
						dictionary[(EHumanBones)i] = vector;
					}
				}
				return dictionary;
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x0600B840 RID: 47168 RVA: 0x003AE4A4 File Offset: 0x003AC6A4
		public void DrawSkeleton(Dictionary<EHumanBones, Vector3> bones)
		{
			try
			{
				if (bones.Count != 0)
				{
					CPlayer.smethod_0(bones, EHumanBones.HumanPelvis, EHumanBones.HumanLThigh1);
					CPlayer.smethod_0(bones, EHumanBones.HumanLThigh1, EHumanBones.HumanLThigh2);
					CPlayer.smethod_0(bones, EHumanBones.HumanLThigh2, EHumanBones.HumanLCalf);
					CPlayer.smethod_0(bones, EHumanBones.HumanLCalf, EHumanBones.HumanLFoot);
					CPlayer.smethod_0(bones, EHumanBones.HumanLFoot, EHumanBones.HumanLToe);
					CPlayer.smethod_0(bones, EHumanBones.HumanPelvis, EHumanBones.HumanRThigh1);
					CPlayer.smethod_0(bones, EHumanBones.HumanRThigh1, EHumanBones.HumanRThigh2);
					CPlayer.smethod_0(bones, EHumanBones.HumanRThigh2, EHumanBones.HumanRCalf);
					CPlayer.smethod_0(bones, EHumanBones.HumanRCalf, EHumanBones.HumanRFoot);
					CPlayer.smethod_0(bones, EHumanBones.HumanRFoot, EHumanBones.HumanRToe);
					CPlayer.smethod_0(bones, EHumanBones.HumanPelvis, EHumanBones.HumanSpine1);
					CPlayer.smethod_0(bones, EHumanBones.HumanSpine1, EHumanBones.HumanSpine2);
					CPlayer.smethod_0(bones, EHumanBones.HumanSpine2, EHumanBones.HumanSpine3);
					CPlayer.smethod_0(bones, EHumanBones.HumanSpine3, EHumanBones.HumanNeck);
					CPlayer.smethod_0(bones, EHumanBones.HumanNeck, EHumanBones.HumanHead);
					CPlayer.smethod_0(bones, EHumanBones.HumanSpine3, EHumanBones.HumanLCollarbone);
					CPlayer.smethod_0(bones, EHumanBones.HumanLCollarbone, EHumanBones.HumanLForearm1);
					CPlayer.smethod_0(bones, EHumanBones.HumanLForearm1, EHumanBones.HumanLForearm2);
					CPlayer.smethod_0(bones, EHumanBones.HumanLForearm2, EHumanBones.HumanLForearm3);
					CPlayer.smethod_0(bones, EHumanBones.HumanLForearm3, EHumanBones.HumanLPalm);
					CPlayer.smethod_0(bones, EHumanBones.HumanLPalm, EHumanBones.HumanLDigit11);
					CPlayer.smethod_0(bones, EHumanBones.HumanLDigit11, EHumanBones.HumanLDigit12);
					CPlayer.smethod_0(bones, EHumanBones.HumanLDigit12, EHumanBones.HumanLDigit13);
					CPlayer.smethod_0(bones, EHumanBones.HumanSpine3, EHumanBones.HumanRCollarbone);
					CPlayer.smethod_0(bones, EHumanBones.HumanRCollarbone, EHumanBones.HumanRForearm1);
					CPlayer.smethod_0(bones, EHumanBones.HumanRForearm1, EHumanBones.HumanRForearm2);
					CPlayer.smethod_0(bones, EHumanBones.HumanRForearm2, EHumanBones.HumanRForearm3);
					CPlayer.smethod_0(bones, EHumanBones.HumanRForearm3, EHumanBones.HumanRPalm);
					CPlayer.smethod_0(bones, EHumanBones.HumanRPalm, EHumanBones.HumanRDigit11);
					CPlayer.smethod_0(bones, EHumanBones.HumanRDigit11, EHumanBones.HumanRDigit12);
					CPlayer.smethod_0(bones, EHumanBones.HumanRDigit12, EHumanBones.HumanRDigit13);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B841 RID: 47169 RVA: 0x003AE620 File Offset: 0x003AC820
		private static void smethod_0(Dictionary<EHumanBones, Vector3> dictionary_0, EHumanBones ehumanBones_0, EHumanBones ehumanBones_1)
		{
			try
			{
				if (dictionary_0.ContainsKey(ehumanBones_0) && dictionary_0.ContainsKey(ehumanBones_1))
				{
					Vector3 vector = dictionary_0[ehumanBones_0];
					if (vector.z >= 0.01f)
					{
						Vector3 vector2 = dictionary_0[ehumanBones_1];
						if (vector2.z >= 0.01f)
						{
							GUIHelper2.DrawLine(vector, vector2, 1f, Color.red);
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B842 RID: 47170 RVA: 0x003AE6A0 File Offset: 0x003AC8A0
		public void DrawBoxes(Player player)
		{
			try
			{
				List<Transform> list = player.PlayerBody.SkeletonRootJoint.Bones.Values.ToList<Transform>();
				if (list.Count != 0)
				{
					Vector3 vector = list[0].position;
					Vector3 vector2 = vector;
					list.RemoveAt(0);
					for (int i = 0; i < list.Count; i++)
					{
						Transform transform = list[i];
						if (!(transform == null) && CPlayer.list_0.Contains((EHumanBones)i))
						{
							Vector3 position = transform.position;
							if (vector.x > position.x)
							{
								vector.x = position.x;
							}
							if (vector.y > position.y)
							{
								vector.y = position.y;
							}
							if (vector.z > position.z)
							{
								vector.z = position.z;
							}
							if (vector2.x < position.x)
							{
								vector2.x = position.x;
							}
							if (vector2.y < position.y)
							{
								vector2.y = position.y;
							}
							if (vector2.z < position.z)
							{
								vector2.z = position.z;
							}
						}
					}
					Vector3[] array = new Vector3[]
					{
						new Vector3(vector.x, vector.y, vector.z),
						new Vector3(vector2.x, vector.y, vector.z),
						new Vector3(vector.x, vector.y, vector2.z),
						new Vector3(vector2.x, vector.y, vector2.z),
						new Vector3(vector.x, vector2.y, vector.z),
						new Vector3(vector2.x, vector2.y, vector.z),
						new Vector3(vector.x, vector2.y, vector2.z),
						new Vector3(vector2.x, vector2.y, vector2.z)
					};
					Camera main = Camera.main;
					Vector3[] array2 = new Vector3[8];
					for (int j = 0; j < 8; j++)
					{
						array2[j] = main.WorldToScreenPoint(array[j]);
						array2[j].y = (float)Screen.height - array2[j].y;
					}
					if (CPlayer.bDraw3DBox)
					{
						if (array2[0].z > 0.01f && array2[1].z > 0.01f)
						{
							GUIHelper2.DrawLine(array2[0], array2[1], 2f, Color.red);
						}
						if (array2[0].z > 0.01f && array2[2].z > 0.01f)
						{
							GUIHelper2.DrawLine(array2[0], array2[2], 2f, Color.red);
						}
						if (array2[1].z > 0.01f && array2[3].z > 0.01f)
						{
							GUIHelper2.DrawLine(array2[1], array2[3], 2f, Color.red);
						}
						if (array2[2].z > 0.01f && array2[3].z > 0.01f)
						{
							GUIHelper2.DrawLine(array2[2], array2[3], 2f, Color.red);
						}
						if (array2[4].z > 0.01f && array2[5].z > 0.01f)
						{
							GUIHelper2.DrawLine(array2[4], array2[5], 2f, Color.red);
						}
						if (array2[4].z > 0.01f && array2[6].z > 0.01f)
						{
							GUIHelper2.DrawLine(array2[4], array2[6], 2f, Color.red);
						}
						if (array2[5].z > 0.01f && array2[7].z > 0.01f)
						{
							GUIHelper2.DrawLine(array2[5], array2[7], 2f, Color.red);
						}
						if (array2[6].z > 0.01f && array2[7].z > 0.01f)
						{
							GUIHelper2.DrawLine(array2[6], array2[7], 2f, Color.red);
						}
						if (array2[0].z > 0.01f && array2[4].z > 0.01f)
						{
							GUIHelper2.DrawLine(array2[0], array2[4], 2f, Color.red);
						}
						if (array2[1].z > 0.01f && array2[5].z > 0.01f)
						{
							GUIHelper2.DrawLine(array2[1], array2[5], 2f, Color.red);
						}
						if (array2[2].z > 0.01f && array2[6].z > 0.01f)
						{
							GUIHelper2.DrawLine(array2[2], array2[6], 2f, Color.red);
						}
						if (array2[3].z > 0.01f && array2[7].z > 0.01f)
						{
							GUIHelper2.DrawLine(array2[3], array2[7], 2f, Color.red);
						}
					}
					if (CPlayer.bDraw2DBox)
					{
						vector = array2[0];
						vector2 = vector;
						for (int k = 1; k < 8; k++)
						{
							if (array2[k].z >= 0.01f)
							{
								if (vector.x > array2[k].x)
								{
									vector.x = array2[k].x;
								}
								if (vector.y > array2[k].y)
								{
									vector.y = array2[k].y;
								}
								if (vector2.x < array2[k].x)
								{
									vector2.x = array2[k].x;
								}
								if (vector2.y < array2[k].y)
								{
									vector2.y = array2[k].y;
								}
							}
						}
						Vector2[] array3 = new Vector2[]
						{
							new Vector3(vector.x, vector.y),
							new Vector3(vector2.x, vector.y),
							new Vector3(vector.x, vector2.y),
							new Vector3(vector2.x, vector2.y)
						};
						GUIHelper2.DrawLine(array3[0], array3[1], 2f, Color.red);
						GUIHelper2.DrawLine(array3[0], array3[2], 2f, Color.red);
						GUIHelper2.DrawLine(array3[2], array3[3], 2f, Color.red);
						GUIHelper2.DrawLine(array3[3], array3[1], 2f, Color.red);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B843 RID: 47171 RVA: 0x003AEED4 File Offset: 0x003AD0D4
		public void DrawLine(Player player, Vector2 screen)
		{
			try
			{
				Vector3 vector = Camera.main.WorldToScreenPoint(player.PlayerBones.RootJoint.position);
				if (vector.z >= 0.01f)
				{
					GUIHelper2.DrawLine(screen, new Vector2(vector.x, (float)Screen.height - vector.y), 2f, player.IsVisible ? Color.green : Color.red);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B844 RID: 47172 RVA: 0x003AEF58 File Offset: 0x003AD158
		public static Bounds CalculateWorldBounds(Player player)
		{
			try
			{
				Bounds result = default(Bounds);
				foreach (BodyPartCollider bodyPartCollider in player.PlayerBones.BodyPartColliders)
				{
					result.Encapsulate(bodyPartCollider.Collider.bounds);
				}
				return result;
			}
			catch
			{
			}
			return default(Bounds);
		}

		// Token: 0x0400A7F7 RID: 42999
		public static List<Player> Players = new List<Player>();

		// Token: 0x0400A7F8 RID: 43000
		public static Player LocalPlayer = null;

		// Token: 0x0400A7F9 RID: 43001
		private float float_0 = 400f;

		// Token: 0x0400A7FA RID: 43002
		public static bool bDraw = true;

		// Token: 0x0400A7FB RID: 43003
		public static bool bDrawLines = false;

		// Token: 0x0400A7FC RID: 43004
		public static bool bDrawInformation = false;

		// Token: 0x0400A7FD RID: 43005
		public static bool bDraw2DBox = false;

		// Token: 0x0400A7FE RID: 43006
		public static bool bDraw3DBox = false;

		// Token: 0x0400A7FF RID: 43007
		public static bool bDrawSkeleton = true;

		// Token: 0x0400A800 RID: 43008
		public static Vector2 vec2DrawLine = new Vector2((float)(Screen.width / 2), (float)Screen.height);

		// Token: 0x0400A801 RID: 43009
		private static List<EHumanBones> list_0 = new List<EHumanBones>
		{
			EHumanBones.HumanPelvis,
			EHumanBones.HumanLThigh1,
			EHumanBones.HumanLThigh2,
			EHumanBones.HumanLCalf,
			EHumanBones.HumanLFoot,
			EHumanBones.HumanLToe,
			EHumanBones.HumanPelvis,
			EHumanBones.HumanRThigh1,
			EHumanBones.HumanRThigh2,
			EHumanBones.HumanRCalf,
			EHumanBones.HumanRFoot,
			EHumanBones.HumanRToe,
			EHumanBones.HumanSpine1,
			EHumanBones.HumanSpine2,
			EHumanBones.HumanSpine3,
			EHumanBones.HumanNeck,
			EHumanBones.HumanHead,
			EHumanBones.HumanLCollarbone,
			EHumanBones.HumanLForearm1,
			EHumanBones.HumanLForearm2,
			EHumanBones.HumanLForearm3,
			EHumanBones.HumanLPalm,
			EHumanBones.HumanLDigit11,
			EHumanBones.HumanLDigit12,
			EHumanBones.HumanLDigit13,
			EHumanBones.HumanRCollarbone,
			EHumanBones.HumanRForearm1,
			EHumanBones.HumanRForearm2,
			EHumanBones.HumanRForearm3,
			EHumanBones.HumanRPalm,
			EHumanBones.HumanRDigit11,
			EHumanBones.HumanRDigit12,
			EHumanBones.HumanRDigit13
		};
	}
}
