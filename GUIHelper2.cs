using System;
using UnityEngine;

namespace EFT.HideOut
{
	// Token: 0x02002109 RID: 8457
	public static class GUIHelper2
	{
		// Token: 0x0600B52E RID: 46382 RVA: 0x003A611C File Offset: 0x003A431C
		public static void DrawFont(Vector2 Point, string txt, Color color)
		{
			try
			{
				GUIHelper2.DrawOutline(Point, txt, Color.black, color, 1f);
			}
			catch
			{
			}
		}

		// Token: 0x0600B52F RID: 46383 RVA: 0x003A6150 File Offset: 0x003A4350
		public static void DrawOutline(Vector2 position, string text, Color outColor, Color inColor, float size)
		{
			try
			{
				float num = size * 0.5f;
				GUIStyle style = GUI.skin.GetStyle(string.Empty);
				Color color = GUI.color;
				Vector2 vector = style.CalcSize(new GUIContent(text));
				Rect rect = new Rect(position.x, position.y, vector.x + 10f, vector.y + 10f);
				style.normal.textColor = outColor;
				GUI.color = outColor;
				rect.x -= num;
				GUI.Label(rect, text, style);
				rect.x += size;
				GUI.Label(rect, text, style);
				rect.x -= num;
				rect.y -= num;
				GUI.Label(rect, text, style);
				rect.y += size;
				GUI.Label(rect, text, style);
				rect.y -= num;
				style.normal.textColor = inColor;
				GUI.color = color;
				GUI.Label(rect, text, style);
			}
			catch
			{
			}
		}

		// Token: 0x0600B530 RID: 46384 RVA: 0x00112F28 File Offset: 0x00111128
		public static void DrawLine(Vector2 pointA, Vector2 pointB, float width, Color color)
		{
			GUIHelper2.DrawLineStretched(pointA, pointB, (int)width, color);
		}

		// Token: 0x0600B531 RID: 46385 RVA: 0x003A6270 File Offset: 0x003A4470
		public static void Draw3DBox(Bounds bounds, int width, Color color)
		{
			try
			{
				Camera main = Camera.main;
				float num = (float)Screen.height;
				Vector3 vector = bounds.min + new Vector3(bounds.size.x, 0f, 0f);
				Vector3 position = vector + new Vector3(0f, bounds.size.y, 0f);
				Vector3 position2 = vector + new Vector3(0f, 0f, bounds.size.z);
				Vector3 max = bounds.max;
				Vector3 min = bounds.min;
				Vector3 position3 = bounds.min + new Vector3(0f, bounds.size.y, 0f);
				Vector3 vector2 = bounds.min + new Vector3(0f, 0f, bounds.size.z);
				Vector3 position4 = vector2 + new Vector3(0f, bounds.size.y, 0f);
				Vector3 vector3 = main.WorldToScreenPoint(vector);
				vector3.y = num - vector3.y;
				Vector3 vector4 = main.WorldToScreenPoint(position);
				vector4.y = num - vector4.y;
				Vector3 vector5 = main.WorldToScreenPoint(position2);
				vector5.y = num - vector5.y;
				Vector3 vector6 = main.WorldToScreenPoint(max);
				vector6.y = num - vector6.y;
				Vector3 vector7 = main.WorldToScreenPoint(min);
				vector7.y = num - vector7.y;
				Vector3 vector8 = main.WorldToScreenPoint(position3);
				vector8.y = num - vector8.y;
				Vector3 vector9 = main.WorldToScreenPoint(vector2);
				vector9.y = num - vector9.y;
				Vector3 vector10 = main.WorldToScreenPoint(position4);
				vector10.y = num - vector10.y;
				bool[] array = new bool[]
				{
					vector3.z >= 0.01f,
					vector4.z >= 0.01f,
					vector5.z >= 0.01f,
					vector6.z >= 0.01f,
					vector7.z >= 0.01f,
					vector8.z >= 0.01f,
					vector9.z >= 0.01f,
					vector10.z >= 0.01f
				};
				if (array[0] && array[1])
				{
					GUIHelper2.DrawLine(vector3, vector4, (float)width, color);
				}
				if (array[0] && array[2])
				{
					GUIHelper2.DrawLine(vector3, vector5, (float)width, color);
				}
				if (array[0] && array[4])
				{
					GUIHelper2.DrawLine(vector3, vector7, (float)width, color);
				}
				if (array[1] && array[3])
				{
					GUIHelper2.DrawLine(vector4, vector6, (float)width, color);
				}
				if (array[1] && array[5])
				{
					GUIHelper2.DrawLine(vector4, vector8, (float)width, color);
				}
				if (array[2] && array[3])
				{
					GUIHelper2.DrawLine(vector5, vector6, (float)width, color);
				}
				if (array[2] && array[6])
				{
					GUIHelper2.DrawLine(vector5, vector9, (float)width, color);
				}
				if (array[4] && array[5])
				{
					GUIHelper2.DrawLine(vector7, vector8, (float)width, color);
				}
				if (array[4] && array[6])
				{
					GUIHelper2.DrawLine(vector7, vector9, (float)width, color);
				}
				if (array[7] && array[3])
				{
					GUIHelper2.DrawLine(vector10, vector6, (float)width, color);
				}
				if (array[7] && array[5])
				{
					GUIHelper2.DrawLine(vector10, vector8, (float)width, color);
				}
				if (array[7] && array[6])
				{
					GUIHelper2.DrawLine(vector10, vector9, (float)width, color);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B532 RID: 46386 RVA: 0x003A6690 File Offset: 0x003A4890
		public static void DrawLineStretched(Vector2 lineStart, Vector2 lineEnd, int thickness, Color color)
		{
			try
			{
				if (!GUIHelper2.\u0002)
				{
					GUIHelper2.\u0002 = new Texture2D(1, 1);
					GUIHelper2.\u0002.filterMode = FilterMode.Point;
				}
				Matrix4x4 matrix = GUI.matrix;
				Color color2 = GUI.color;
				GUI.color = color;
				Vector2 vector = lineEnd - lineStart;
				float num = (float)(57.295779513082323 * (double)Mathf.Atan(vector.y / vector.x));
				if (vector.x < 0f)
				{
					num += 180f;
				}
				if (thickness < 1)
				{
					thickness = 1;
				}
				int num2 = (int)Mathf.Ceil((float)(thickness / 2));
				GUIUtility.RotateAroundPivot(num, lineStart);
				GUI.DrawTexture(new Rect(lineStart.x, lineStart.y - (float)num2, vector.magnitude, (float)thickness), GUIHelper2.\u0002);
				GUIUtility.RotateAroundPivot(-num, lineStart);
				GUI.color = color2;
				GUI.matrix = matrix;
			}
			catch
			{
			}
		}

		// Token: 0x0400A682 RID: 42626
		private static Texture2D \u0002;
	}
}
