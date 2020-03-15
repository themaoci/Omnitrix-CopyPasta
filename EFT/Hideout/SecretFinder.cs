using System;
using System.Reflection;

namespace EFT.HideOut
{
	// Token: 0x0200217E RID: 8574
	public static class SecretFinder
	{
		// Token: 0x0600B85E RID: 47198 RVA: 0x00114ED9 File Offset: 0x001130D9
		public static FieldInfo FindSecret<T>(this T classType, string fieldName)
		{
			return typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x0600B85F RID: 47199 RVA: 0x00114EED File Offset: 0x001130ED
		public static FieldInfo FindFieldInfo<T>(string fieldName)
		{
			return typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x0600B860 RID: 47200 RVA: 0x00114F01 File Offset: 0x00113101
		public static void SetSecret<T>(this FieldInfo target, T value, object targetClass = null)
		{
			target.SetValue(targetClass, value);
		}

		// Token: 0x0600B861 RID: 47201 RVA: 0x00114F10 File Offset: 0x00113110
		public static T GetSecret<T>(this FieldInfo target, object targetClass = null)
		{
			return (T)((object)target.GetValue(targetClass));
		}

		// Token: 0x0600B862 RID: 47202 RVA: 0x003AFAA0 File Offset: 0x003ADCA0
		public static T GetSecret<T>(this object target, string fieldName)
		{
			try
			{
				return (T)((object)target.GetType().GetField(fieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(target));
			}
			catch
			{
			}
			return default(T);
		}

		// Token: 0x0600B863 RID: 47203 RVA: 0x00114F1E File Offset: 0x0011311E
		public static void SetSecret<T>(this object target, string fieldName, T value)
		{
			target.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(target, value);
		}

		// Token: 0x0600B864 RID: 47204 RVA: 0x00114F3A File Offset: 0x0011313A
		public static void SetSecretProperty(this object target, string propertyName, object[] value)
		{
			target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetSetMethod(false).Invoke(target, value);
		}

		// Token: 0x0600B865 RID: 47205 RVA: 0x00114F58 File Offset: 0x00113158
		public static T GetSecretProperty<T>(this object target, string propertyName)
		{
			return (T)((object)target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetGetMethod(false).Invoke(target, null));
		}

		// Token: 0x0600B866 RID: 47206 RVA: 0x00114F7A File Offset: 0x0011317A
		public static retType GetFieldValueToken<retType>(this object classObject, int token)
		{
			return (retType)((object)classObject.GetType().Module.ResolveField(token).GetValue(classObject));
		}
	}
}
