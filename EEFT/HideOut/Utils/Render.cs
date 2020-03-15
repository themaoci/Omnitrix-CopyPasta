using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EEFT.HideOut.Utils
{
	// Token: 0x02002175 RID: 8565
	public static class Render
	{
		// Token: 0x170016BF RID: 5823
		// (get) Token: 0x0600B822 RID: 47138 RVA: 0x00114D03 File Offset: 0x00112F03
		// (set) Token: 0x0600B823 RID: 47139 RVA: 0x00114D0A File Offset: 0x00112F0A
		public static GUIStyle StringStyle
		{
			[CompilerGenerated]
			get
			{
				return Render.guistyle_0;
			}
			[CompilerGenerated]
			set
			{
				Render.guistyle_0 = value;
			}
		}

		// Token: 0x170016C0 RID: 5824
		// (get) Token: 0x0600B824 RID: 47140 RVA: 0x00114D12 File Offset: 0x00112F12
		// (set) Token: 0x0600B825 RID: 47141 RVA: 0x00114D19 File Offset: 0x00112F19
		public static Color Color
		{
			get
			{
				return GUI.color;
			}
			set
			{
				GUI.color = value;
			}
		}

		// Token: 0x0600B826 RID: 47142 RVA: 0x00114D21 File Offset: 0x00112F21
		public static void DrawLine(Vector2 from, Vector2 to, float thickness, Color color)
		{
			Render.Color = color;
			Render.DrawLine(from, to, thickness);
		}

		// Token: 0x0600B827 RID: 47143 RVA: 0x003ADB28 File Offset: 0x003ABD28
		public static void DrawLine(Vector2 from, Vector2 to, float thickness)
		{
			Vector2 normalized = (to - from).normalized;
			float num = Mathf.Atan2(normalized.y, normalized.x) * 57.29578f;
			GUIUtility.RotateAroundPivot(num, from);
			Render.DrawBox(from, Vector2.right * (from - to).magnitude, thickness, false);
			GUIUtility.RotateAroundPivot(-num, from);
		}

		// Token: 0x0600B828 RID: 47144 RVA: 0x003ADB8C File Offset: 0x003ABD8C
		public static void DrawBox(float x, float y, float w, float h, Color color)
		{
			Render.DrawLine(new Vector2(x, y), new Vector2(x + w, y), 1f, color);
			Render.DrawLine(new Vector2(x, y), new Vector2(x, y + h), 1f, color);
			Render.DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), 1f, color);
			Render.DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), 1f, color);
		}

		// Token: 0x0600B829 RID: 47145 RVA: 0x00114D31 File Offset: 0x00112F31
		public static void DrawBox(Vector2 position, Vector2 size, float thickness, Color color, bool centered = true)
		{
			Render.Color = color;
			Render.DrawBox(position, size, thickness, centered);
		}

		// Token: 0x0600B82A RID: 47146 RVA: 0x003ADC14 File Offset: 0x003ABE14
		public static void DrawBox(Vector2 position, Vector2 size, float thickness, bool centered = true)
		{
			if (centered)
			{
				position - size / 2f;
			}
			GUI.DrawTexture(new Rect(position.x, position.y, size.x, thickness), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x, position.y, thickness, size.y), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x + size.x, position.y, thickness, size.y), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x, position.y + size.y, size.x + thickness, thickness), Texture2D.whiteTexture);
		}

		// Token: 0x0600B82B RID: 47147 RVA: 0x00114D43 File Offset: 0x00112F43
		public static void DrawCross(Vector2 position, Vector2 size, float thickness, Color color)
		{
			Render.Color = color;
			Render.DrawCross(position, size, thickness);
		}

		// Token: 0x0600B82C RID: 47148 RVA: 0x003ADCD0 File Offset: 0x003ABED0
		public static void DrawCross(Vector2 position, Vector2 size, float thickness)
		{
			GUI.DrawTexture(new Rect(position.x - size.x / 2f, position.y, size.x, thickness), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x, position.y - size.y / 2f, thickness, size.y), Texture2D.whiteTexture);
		}

		// Token: 0x0600B82D RID: 47149 RVA: 0x00114D53 File Offset: 0x00112F53
		public static void DrawDot(Vector2 position, Color color)
		{
			Render.Color = color;
			Render.DrawDot(position);
		}

		// Token: 0x0600B82E RID: 47150 RVA: 0x00114D61 File Offset: 0x00112F61
		public static void DrawDot(Vector2 position)
		{
			Render.DrawBox(position - Vector2.one, Vector2.one * 2f, 1f, true);
		}

		// Token: 0x0600B82F RID: 47151 RVA: 0x00114D88 File Offset: 0x00112F88
		public static void DrawString(Vector2 position, string label, Color color, bool centered = true)
		{
			Render.Color = color;
			Render.DrawString(position, label, centered);
		}

		// Token: 0x0600B830 RID: 47152 RVA: 0x003ADD3C File Offset: 0x003ABF3C
		public static void DrawString(Vector2 position, string label, bool centered = true)
		{
			GUIContent content = new GUIContent(label);
			Vector2 vector = Render.StringStyle.CalcSize(content);
			GUI.Label(new Rect(centered ? (position - vector / 2f) : position, vector), content);
		}

		// Token: 0x0600B831 RID: 47153 RVA: 0x00114D98 File Offset: 0x00112F98
		public static void DrawCircle(Vector2 position, float radius, int numSides, bool centered = true, float thickness = 1f)
		{
			Render.DrawCircle(position, radius, numSides, Color.white, centered, thickness);
		}

		// Token: 0x0600B832 RID: 47154 RVA: 0x003ADD80 File Offset: 0x003ABF80
		public static void DrawCircle(Vector2 position, float radius, int numSides, Color color, bool centered = true, float thickness = 1f)
		{
			Render.Class55 @class;
			if (Render.dictionary_0.ContainsKey(numSides))
			{
				@class = Render.dictionary_0[numSides];
			}
			else
			{
				@class = (Render.dictionary_0[numSides] = new Render.Class55(numSides));
			}
			Vector2 vector = centered ? position : (position + Vector2.one * radius);
			for (int i = 0; i < numSides - 1; i++)
			{
				Render.DrawLine(vector + @class.method_0()[i] * radius, vector + @class.method_0()[i + 1] * radius, thickness, color);
			}
			Render.DrawLine(vector + @class.method_0()[0] * radius, vector + @class.method_0()[@class.method_0().Length - 1] * radius, thickness, color);
		}

		// Token: 0x0400A7F3 RID: 42995
		private static GUIStyle guistyle_0 = new GUIStyle(GUI.skin.label);

		// Token: 0x0400A7F4 RID: 42996
		private static Dictionary<int, Render.Class55> dictionary_0 = new Dictionary<int, Render.Class55>();

		// Token: 0x02002176 RID: 8566
		private sealed class Class55
		{
			// Token: 0x0600B833 RID: 47155 RVA: 0x003ADE60 File Offset: 0x003AC060
			public Class55(int int_0)
			{
				this.method_1(new Vector2[int_0]);
				float num = 360f / (float)int_0;
				for (int i = 0; i < int_0; i++)
				{
					float num2 = 0.0174532924f * num * (float)i;
					this.method_0()[i] = new Vector2(Mathf.Sin(num2), Mathf.Cos(num2));
				}
			}

			// Token: 0x0600B834 RID: 47156 RVA: 0x00114DAA File Offset: 0x00112FAA
			public Vector2[] method_0()
			{
				return this.vector2_0;
			}

			// Token: 0x0600B835 RID: 47157 RVA: 0x00114DB2 File Offset: 0x00112FB2
			private void method_1(Vector2[] vector2_1)
			{
				this.vector2_0 = vector2_1;
			}

			// Token: 0x0400A7F5 RID: 42997
			private Vector2[] vector2_0;
		}
	}
}
