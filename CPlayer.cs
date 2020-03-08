using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EFT.HideOut
{
	// Token: 0x02002104 RID: 8452
	public class CPlayer : MonoBehaviour
	{
		// Token: 0x0600B512 RID: 46354 RVA: 0x003A4E24 File Offset: 0x003A3024
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

		// Token: 0x0600B513 RID: 46355 RVA: 0x003A4E64 File Offset: 0x003A3064
		public void OnGUI()
		{
			try
			{
				if (Event.current.type == 7)
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
											if (num <= this.\u0002)
											{
												string arg = (player.Profile.Info.RegistrationDate == 0) ? player.Profile.Info.Settings.Role.ToString(\u0003\u2000__2.\u0002(872575272)) : player.Profile.Info.Nickname;
												if (CPlayer.bDrawInformation)
												{
													GUIHelper2.DrawFont(new Vector2(vector.x, vector.y), string.Format(\u0003\u2000__2.\u0002(872575280), arg, num), Color.red);
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

		// Token: 0x0600B514 RID: 46356 RVA: 0x003A50A4 File Offset: 0x003A32A4
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
					if (!(transform == null) && CPlayer.\u0003.Contains((EHumanBones)i))
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

		// Token: 0x0600B515 RID: 46357 RVA: 0x003A51A0 File Offset: 0x003A33A0
		public void DrawSkeleton(Dictionary<EHumanBones, Vector3> bones)
		{
			try
			{
				if (bones.Count != 0)
				{
					CPlayer.\u0002(bones, EHumanBones.HumanPelvis, EHumanBones.HumanLThigh1);
					CPlayer.\u0002(bones, EHumanBones.HumanLThigh1, EHumanBones.HumanLThigh2);
					CPlayer.\u0002(bones, EHumanBones.HumanLThigh2, EHumanBones.HumanLCalf);
					CPlayer.\u0002(bones, EHumanBones.HumanLCalf, EHumanBones.HumanLFoot);
					CPlayer.\u0002(bones, EHumanBones.HumanLFoot, EHumanBones.HumanLToe);
					CPlayer.\u0002(bones, EHumanBones.HumanPelvis, EHumanBones.HumanRThigh1);
					CPlayer.\u0002(bones, EHumanBones.HumanRThigh1, EHumanBones.HumanRThigh2);
					CPlayer.\u0002(bones, EHumanBones.HumanRThigh2, EHumanBones.HumanRCalf);
					CPlayer.\u0002(bones, EHumanBones.HumanRCalf, EHumanBones.HumanRFoot);
					CPlayer.\u0002(bones, EHumanBones.HumanRFoot, EHumanBones.HumanRToe);
					CPlayer.\u0002(bones, EHumanBones.HumanPelvis, EHumanBones.HumanSpine1);
					CPlayer.\u0002(bones, EHumanBones.HumanSpine1, EHumanBones.HumanSpine2);
					CPlayer.\u0002(bones, EHumanBones.HumanSpine2, EHumanBones.HumanSpine3);
					CPlayer.\u0002(bones, EHumanBones.HumanSpine3, EHumanBones.HumanNeck);
					CPlayer.\u0002(bones, EHumanBones.HumanNeck, EHumanBones.HumanHead);
					CPlayer.\u0002(bones, EHumanBones.HumanSpine3, EHumanBones.HumanLCollarbone);
					CPlayer.\u0002(bones, EHumanBones.HumanLCollarbone, EHumanBones.HumanLForearm1);
					CPlayer.\u0002(bones, EHumanBones.HumanLForearm1, EHumanBones.HumanLForearm2);
					CPlayer.\u0002(bones, EHumanBones.HumanLForearm2, EHumanBones.HumanLForearm3);
					CPlayer.\u0002(bones, EHumanBones.HumanLForearm3, EHumanBones.HumanLPalm);
					CPlayer.\u0002(bones, EHumanBones.HumanLPalm, EHumanBones.HumanLDigit11);
					CPlayer.\u0002(bones, EHumanBones.HumanLDigit11, EHumanBones.HumanLDigit12);
					CPlayer.\u0002(bones, EHumanBones.HumanLDigit12, EHumanBones.HumanLDigit13);
					CPlayer.\u0002(bones, EHumanBones.HumanSpine3, EHumanBones.HumanRCollarbone);
					CPlayer.\u0002(bones, EHumanBones.HumanRCollarbone, EHumanBones.HumanRForearm1);
					CPlayer.\u0002(bones, EHumanBones.HumanRForearm1, EHumanBones.HumanRForearm2);
					CPlayer.\u0002(bones, EHumanBones.HumanRForearm2, EHumanBones.HumanRForearm3);
					CPlayer.\u0002(bones, EHumanBones.HumanRForearm3, EHumanBones.HumanRPalm);
					CPlayer.\u0002(bones, EHumanBones.HumanRPalm, EHumanBones.HumanRDigit11);
					CPlayer.\u0002(bones, EHumanBones.HumanRDigit11, EHumanBones.HumanRDigit12);
					CPlayer.\u0002(bones, EHumanBones.HumanRDigit12, EHumanBones.HumanRDigit13);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B516 RID: 46358 RVA: 0x003A531C File Offset: 0x003A351C
		private static void \u0002(Dictionary<EHumanBones, Vector3> \u0002, EHumanBones \u0003, EHumanBones \u0005)
		{
			try
			{
				if (\u0002.ContainsKey(\u0003) && \u0002.ContainsKey(\u0005))
				{
					Vector3 vector = \u0002[\u0003];
					if (vector.z >= 0.01f)
					{
						Vector3 vector2 = \u0002[\u0005];
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

		// Token: 0x0600B517 RID: 46359 RVA: 0x003A539C File Offset: 0x003A359C
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
						if (!(transform == null) && CPlayer.\u0003.Contains((EHumanBones)i))
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

		// Token: 0x0600B518 RID: 46360 RVA: 0x003A5BD0 File Offset: 0x003A3DD0
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

		// Token: 0x0600B519 RID: 46361 RVA: 0x003A5C54 File Offset: 0x003A3E54
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

		// Token: 0x0400A5E8 RID: 42472
		public static List<Player> Players = new List<Player>();

		// Token: 0x0400A5E9 RID: 42473
		public static Player LocalPlayer = null;

		// Token: 0x0400A5EA RID: 42474
		private float \u0002 = 400f;

		// Token: 0x0400A5EB RID: 42475
		public static bool bDraw = true;

		// Token: 0x0400A5EC RID: 42476
		public static bool bDrawLines = false;

		// Token: 0x0400A5ED RID: 42477
		public static bool bDrawInformation = false;

		// Token: 0x0400A5EE RID: 42478
		public static bool bDraw2DBox = false;

		// Token: 0x0400A5EF RID: 42479
		public static bool bDraw3DBox = false;

		// Token: 0x0400A5F0 RID: 42480
		public static bool bDrawSkeleton = true;

		// Token: 0x0400A5F1 RID: 42481
		public static Vector2 vec2DrawLine = new Vector2((float)(Screen.width / 2), (float)Screen.height);

		// Token: 0x0400A5F2 RID: 42482
		private static List<EHumanBones> \u0003 = new List<EHumanBones>
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
