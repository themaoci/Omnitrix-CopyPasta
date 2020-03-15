using System;
using UnityEngine;

namespace EFT.HideOut
{
	// Token: 0x0200217D RID: 8573
	public static class GUIHelper2
	{
		// Token: 0x0600B859 RID: 47193 RVA: 0x003AF448 File Offset: 0x003AD648
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

		// Token: 0x0600B85A RID: 47194 RVA: 0x003AF47C File Offset: 0x003AD67C
		public static void DrawOutline(Vector2 position, string text, Color outColor, Color inColor, float size)
		{
			try
			{
				float num = size * 0.5f;
				GUIStyle style = GUI.skin.GetStyle(string.Empty);
				Color color = GUI.color;
				Vector2 vector = style.CalcSize(new GUIContent(text));
				Rect position2;
				position2..ctor(position.x, position.y, vector.x + 10f, vector.y + 10f);
				style.normal.textColor = outColor;
				GUI.color = outColor;
				position2.x -= num;
				GUI.Label(position2, text, style);
				position2.x += size;
				GUI.Label(position2, text, style);
				position2.x -= num;
				position2.y -= num;
				GUI.Label(position2, text, style);
				position2.y += size;
				GUI.Label(position2, text, style);
				position2.y -= num;
				style.normal.textColor = inColor;
				GUI.color = color;
				GUI.Label(position2, text, style);
			}
			catch
			{
			}
		}

		// Token: 0x0600B85B RID: 47195 RVA: 0x00114ECD File Offset: 0x001130CD
		public static void DrawLine(Vector2 pointA, Vector2 pointB, float width, Color color)
		{
			GUIHelper2.DrawLineStretched(pointA, pointB, (int)width, color);
		}

		// Token: 0x0600B85C RID: 47196 RVA: 0x003AF59C File Offset: 0x003AD79C
		public static void Draw3DBox(Bounds bounds, int width, Color color)
		{
			try
			{
				Camera main = Camera.main;
				float num = (float)Screen.height;
				Vector3 vector = bounds.min + new Vector3(bounds.size.x, 0f, 0f);
				Vector3 vector2 = vector + new Vector3(0f, bounds.size.y, 0f);
				Vector3 vector3 = vector + new Vector3(0f, 0f, bounds.size.z);
				Vector3 max = bounds.max;
				Vector3 min = bounds.min;
				Vector3 vector4 = bounds.min + new Vector3(0f, bounds.size.y, 0f);
				Vector3 vector5 = bounds.min + new Vector3(0f, 0f, bounds.size.z);
				Vector3 vector6 = vector5 + new Vector3(0f, bounds.size.y, 0f);
				Vector3 vector7 = main.WorldToScreenPoint(vector);
				vector7.y = num - vector7.y;
				Vector3 vector8 = main.WorldToScreenPoint(vector2);
				vector8.y = num - vector8.y;
				Vector3 vector9 = main.WorldToScreenPoint(vector3);
				vector9.y = num - vector9.y;
				Vector3 vector10 = main.WorldToScreenPoint(max);
				vector10.y = num - vector10.y;
				Vector3 vector11 = main.WorldToScreenPoint(min);
				vector11.y = num - vector11.y;
				Vector3 vector12 = main.WorldToScreenPoint(vector4);
				vector12.y = num - vector12.y;
				Vector3 vector13 = main.WorldToScreenPoint(vector5);
				vector13.y = num - vector13.y;
				Vector3 vector14 = main.WorldToScreenPoint(vector6);
				vector14.y = num - vector14.y;
				bool[] array = new bool[]
				{
					vector7.z >= 0.01f,
					vector8.z >= 0.01f,
					vector9.z >= 0.01f,
					vector10.z >= 0.01f,
					vector11.z >= 0.01f,
					vector12.z >= 0.01f,
					vector13.z >= 0.01f,
					vector14.z >= 0.01f
				};
				if (array[0] && array[1])
				{
					GUIHelper2.DrawLine(vector7, vector8, (float)width, color);
				}
				if (array[0] && array[2])
				{
					GUIHelper2.DrawLine(vector7, vector9, (float)width, color);
				}
				if (array[0] && array[4])
				{
					GUIHelper2.DrawLine(vector7, vector11, (float)width, color);
				}
				if (array[1] && array[3])
				{
					GUIHelper2.DrawLine(vector8, vector10, (float)width, color);
				}
				if (array[1] && array[5])
				{
					GUIHelper2.DrawLine(vector8, vector12, (float)width, color);
				}
				if (array[2] && array[3])
				{
					GUIHelper2.DrawLine(vector9, vector10, (float)width, color);
				}
				if (array[2] && array[6])
				{
					GUIHelper2.DrawLine(vector9, vector13, (float)width, color);
				}
				if (array[4] && array[5])
				{
					GUIHelper2.DrawLine(vector11, vector12, (float)width, color);
				}
				if (array[4] && array[6])
				{
					GUIHelper2.DrawLine(vector11, vector13, (float)width, color);
				}
				if (array[7] && array[3])
				{
					GUIHelper2.DrawLine(vector14, vector10, (float)width, color);
				}
				if (array[7] && array[5])
				{
					GUIHelper2.DrawLine(vector14, vector12, (float)width, color);
				}
				if (array[7] && array[6])
				{
					GUIHelper2.DrawLine(vector14, vector13, (float)width, color);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600B85D RID: 47197 RVA: 0x003AF9BC File Offset: 0x003ADBBC
		public static void DrawLineStretched(Vector2 lineStart, Vector2 lineEnd, int thickness, Color color)
		{
			try
			{
				if (!GUIHelper2.texture2D_0)
				{
					GUIHelper2.texture2D_0 = new Texture2D(1, 1);
					GUIHelper2.texture2D_0.filterMode = 0;
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
				GUI.DrawTexture(new Rect(lineStart.x, lineStart.y - (float)num2, vector.magnitude, (float)thickness), GUIHelper2.texture2D_0);
				GUIUtility.RotateAroundPivot(-num, lineStart);
				GUI.color = color2;
				GUI.matrix = matrix;
			}
			catch
			{
			}
		}

		// Token: 0x0400A891 RID: 43153
		private static Texture2D texture2D_0;
	}
}
