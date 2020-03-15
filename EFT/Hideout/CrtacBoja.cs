using System;
using UnityEngine;

namespace EFT.HideOut
{
	// Token: 0x02002179 RID: 8569
	public static class CrtacBoja
	{
		// Token: 0x0600B845 RID: 47173 RVA: 0x003AEFC4 File Offset: 0x003AD1C4
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

		// Token: 0x0600B846 RID: 47174 RVA: 0x00114DCE File Offset: 0x00112FCE
		public static void Text(Rect rect, string content)
		{
			CrtacBoja.Text(rect, content, Color.white);
		}

		// Token: 0x0600B847 RID: 47175 RVA: 0x00114DDC File Offset: 0x00112FDC
		public static void Text(Rect rect, string content, Color txtColor)
		{
			CrtacBoja.DrawShadow(rect, new GUIContent(content), new GUIStyle(), txtColor, new Color(0f, 0f, 0f, 1f), new Vector2(1f, 1f));
		}

		// Token: 0x0600B848 RID: 47176 RVA: 0x003AF028 File Offset: 0x003AD228
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

		// Token: 0x0600B849 RID: 47177 RVA: 0x00114E18 File Offset: 0x00113018
		public static void DrawLine(Rect rect)
		{
			CrtacBoja.DrawLine(rect, GUI.contentColor, 1f);
		}

		// Token: 0x0600B84A RID: 47178 RVA: 0x00114E2A File Offset: 0x0011302A
		public static void DrawLine(Rect rect, Color color)
		{
			CrtacBoja.DrawLine(rect, color, 1f);
		}

		// Token: 0x0600B84B RID: 47179 RVA: 0x00114E38 File Offset: 0x00113038
		public static void DrawLine(Rect rect, float width)
		{
			CrtacBoja.DrawLine(rect, GUI.contentColor, width);
		}

		// Token: 0x0600B84C RID: 47180 RVA: 0x00114E46 File Offset: 0x00113046
		public static void DrawLine(Rect rect, Color color, float width)
		{
			CrtacBoja.DrawLine(new Vector2(rect.x, rect.y), new Vector2(rect.x + rect.width, rect.y + rect.height), color, width);
		}

		// Token: 0x0600B84D RID: 47181 RVA: 0x00114E85 File Offset: 0x00113085
		public static void DrawLine(Vector2 pointA, Vector2 pointB)
		{
			CrtacBoja.DrawLine(pointA, pointB, GUI.contentColor, 1f);
		}

		// Token: 0x0600B84E RID: 47182 RVA: 0x00114E98 File Offset: 0x00113098
		public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color)
		{
			CrtacBoja.DrawLine(pointA, pointB, color, 1f);
		}

		// Token: 0x0600B84F RID: 47183 RVA: 0x00114EA7 File Offset: 0x001130A7
		public static void DrawLine(Vector2 pointA, Vector2 pointB, float width)
		{
			CrtacBoja.DrawLine(pointA, pointB, GUI.contentColor, width);
		}

		// Token: 0x0600B850 RID: 47184 RVA: 0x003AF0B8 File Offset: 0x003AD2B8
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

		// Token: 0x0600B851 RID: 47185 RVA: 0x003AF184 File Offset: 0x003AD384
		public static void DrawBox(float x, float y, float w, float h, Color color)
		{
			CrtacBoja.DrawLine(new Vector2(x, y), new Vector2(x + w, y), color);
			CrtacBoja.DrawLine(new Vector2(x, y), new Vector2(x, y + h), color);
			CrtacBoja.DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), color);
			CrtacBoja.DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), color);
		}

		// Token: 0x0400A802 RID: 43010
		public static Texture2D lineTex;
	}
}
