using System;
using System.Reflection;

namespace EFT.HideOut
{
	// Token: 0x0200210D RID: 8461
	public static class SecretFinder
	{
		// Token: 0x0600B540 RID: 46400 RVA: 0x00112F3B File Offset: 0x0011113B
		public static FieldInfo FindSecret<T>(this T classType, string fieldName)
		{
			return typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x0600B541 RID: 46401 RVA: 0x00112F4F File Offset: 0x0011114F
		public static FieldInfo FindFieldInfo<T>(string fieldName)
		{
			return typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x0600B542 RID: 46402 RVA: 0x00112F63 File Offset: 0x00111163
		public static void SetSecret<T>(this FieldInfo target, T value, object targetClass = null)
		{
			target.SetValue(targetClass, value);
		}

		// Token: 0x0600B543 RID: 46403 RVA: 0x00112F72 File Offset: 0x00111172
		public static T GetSecret<T>(this FieldInfo target, object targetClass = null)
		{
			return (T)((object)target.GetValue(targetClass));
		}

		// Token: 0x0600B544 RID: 46404 RVA: 0x003A69D4 File Offset: 0x003A4BD4
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

		// Token: 0x0600B545 RID: 46405 RVA: 0x00112F80 File Offset: 0x00111180
		public static void SetSecret<T>(this object target, string fieldName, T value)
		{
			target.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(target, value);
		}

		// Token: 0x0600B546 RID: 46406 RVA: 0x00112F9C File Offset: 0x0011119C
		public static void SetSecretProperty(this object target, string propertyName, object[] value)
		{
			target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetSetMethod(false).Invoke(target, value);
		}

		// Token: 0x0600B547 RID: 46407 RVA: 0x00112FBA File Offset: 0x001111BA
		public static T GetSecretProperty<T>(this object target, string propertyName)
		{
			return (T)((object)target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetGetMethod(false).Invoke(target, null));
		}

		// Token: 0x0600B548 RID: 46408 RVA: 0x00112FDC File Offset: 0x001111DC
		public static retType GetFieldValueToken<retType>(this object classObject, int token)
		{
			return (retType)((object)classObject.GetType().Module.ResolveField(token).GetValue(classObject));
		}
	}
}
