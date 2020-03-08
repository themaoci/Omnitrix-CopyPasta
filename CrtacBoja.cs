using System;
using UnityEngine;

namespace EFT.HideOut
{
	// Token: 0x02002105 RID: 8453
	public static class CrtacBoja
	{
		// Token: 0x0600B51A RID: 46362 RVA: 0x003A5CC0 File Offset: 0x003A3EC0
		public static void P(Vector2 Position, Color color, float thickness)
		{
			if (!CrtacBoja.lineTex)
			{
				CrtacBoja.lineTex = new Texture2D(1, 1);
			}
			float num = Mathf.Ceil(thickness / 2f);
			Color color2 = GUI.color;
			GUI.color = color;
			GUI.DrawTexture(new Rect(Position.x, Position.y - num, thickness, thickness), CrtacBoja.lineTex);
			GUI.color = color2;
		}

		// Token: 0x0600B51B RID: 46363 RVA: 0x00112E29 File Offset: 0x00111029
		public static void Text(Rect rect, string content)
		{
			CrtacBoja.Text(rect, content, Color.white);
		}

		// Token: 0x0600B51C RID: 46364 RVA: 0x00112E37 File Offset: 0x00111037
		public static void Text(Rect rect, string content, Color txtColor)
		{
			CrtacBoja.DrawShadow(rect, new GUIContent(content), new GUIStyle(), txtColor, new Color(0f, 0f, 0f, 1f), new Vector2(1f, 1f));
		}

		// Token: 0x0600B51D RID: 46365 RVA: 0x003A5D24 File Offset: 0x003A3F24
		public static void DrawShadow(Rect rect, GUIContent content, GUIStyle style, Color txtColor, Color shadowColor, Vector2 direction)
		{
			GUIStyle guistyle = style;
			style.normal.textColor = shadowColor;
			rect.x += direction.x;
			rect.y += direction.y;
			GUI.Label(rect, content, style);
			style.normal.textColor = txtColor;
			rect.x -= direction.x;
			rect.y -= direction.y;
			GUI.Label(rect, content, style);
			style = guistyle;
		}

		// Token: 0x0600B51E RID: 46366 RVA: 0x00112E73 File Offset: 0x00111073
		public static void DrawLine(Rect rect)
		{
			CrtacBoja.DrawLine(rect, GUI.contentColor, 1f);
		}

		// Token: 0x0600B51F RID: 46367 RVA: 0x00112E85 File Offset: 0x00111085
		public static void DrawLine(Rect rect, Color color)
		{
			CrtacBoja.DrawLine(rect, color, 1f);
		}

		// Token: 0x0600B520 RID: 46368 RVA: 0x00112E93 File Offset: 0x00111093
		public static void DrawLine(Rect rect, float width)
		{
			CrtacBoja.DrawLine(rect, GUI.contentColor, width);
		}

		// Token: 0x0600B521 RID: 46369 RVA: 0x00112EA1 File Offset: 0x001110A1
		public static void DrawLine(Rect rect, Color color, float width)
		{
			CrtacBoja.DrawLine(new Vector2(rect.x, rect.y), new Vector2(rect.x + rect.width, rect.y + rect.height), color, width);
		}

		// Token: 0x0600B522 RID: 46370 RVA: 0x00112EE0 File Offset: 0x001110E0
		public static void DrawLine(Vector2 pointA, Vector2 pointB)
		{
			CrtacBoja.DrawLine(pointA, pointB, GUI.contentColor, 1f);
		}

		// Token: 0x0600B523 RID: 46371 RVA: 0x00112EF3 File Offset: 0x001110F3
		public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color)
		{
			CrtacBoja.DrawLine(pointA, pointB, color, 1f);
		}

		// Token: 0x0600B524 RID: 46372 RVA: 0x00112F02 File Offset: 0x00111102
		public static void DrawLine(Vector2 pointA, Vector2 pointB, float width)
		{
			CrtacBoja.DrawLine(pointA, pointB, GUI.contentColor, width);
		}

		// Token: 0x0600B525 RID: 46373 RVA: 0x003A5DB4 File Offset: 0x003A3FB4
		public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
		{
			Matrix4x4 matrix = GUI.matrix;
			if (!CrtacBoja.lineTex)
			{
				CrtacBoja.lineTex = new Texture2D(1, 1);
			}
			Color color2 = GUI.color;
			GUI.color = color;
			float num = Vector3.Angle(pointB - pointA, Vector2.right);
			if (pointA.y > pointB.y)
			{
				num = -num;
			}
			GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));
			GUIUtility.RotateAroundPivot(num, pointA);
			GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), CrtacBoja.lineTex);
			GUI.matrix = matrix;
			GUI.color = color2;
		}

		// Token: 0x0600B526 RID: 46374 RVA: 0x003A5E80 File Offset: 0x003A4080
		public static void DrawBox(float x, float y, float w, float h, Color color)
		{
			CrtacBoja.DrawLine(new Vector2(x, y), new Vector2(x + w, y), color);
			CrtacBoja.DrawLine(new Vector2(x, y), new Vector2(x, y + h), color);
			CrtacBoja.DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), color);
			CrtacBoja.DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), color);
		}

		// Token: 0x0400A5F3 RID: 42483
		public static Texture2D lineTex;
	}
}
