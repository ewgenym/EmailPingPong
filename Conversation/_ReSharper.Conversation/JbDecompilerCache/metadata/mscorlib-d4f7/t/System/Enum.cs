﻿// Type: System.Enum
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System
{
	/// <summary>
	/// Provides the base class for enumerations.
	/// </summary>
	/// <filterpriority>2</filterpriority>
	[ComVisible(true)]
	[Serializable]
	public abstract class Enum : ValueType, IComparable, IFormattable, IConvertible
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Enum"/> class.
		/// </summary>
		protected Enum();

		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object. The return value indicates whether the conversion succeeded.
		/// </summary>
		/// 
		/// <returns>
		/// true if the <paramref name="value"/> parameter was converted successfully; otherwise, false.
		/// </returns>
		/// <param name="value">The string representation of the enumeration name or underlying value to convert.</param><param name="result">When this method returns, contains an object of type <paramref name="TEnum"/> whose value is represented by <paramref name="value"/>. This parameter is passed uninitialized.</param><typeparam name="TEnum">The enumeration type to which to convert <paramref name="value"/>.</typeparam><exception cref="T:System.ArgumentException"><paramref name="TEnum"/> is not an enumeration type.</exception>
		[SecuritySafeCritical]
		public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct;

		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object. A parameter specifies whether the operation is case-sensitive. The return value indicates whether the conversion succeeded.
		/// </summary>
		/// 
		/// <returns>
		/// true if the <paramref name="value"/> parameter was converted successfully; otherwise, false.
		/// </returns>
		/// <param name="value">The string representation of the enumeration name or underlying value to convert.</param><param name="ignoreCase">true to ignore case; false to consider case.</param><param name="result">When this method returns, contains an object of type <paramref name="TEnum"/> whose value is represented by <paramref name="value"/>. This parameter is passed uninitialized.</param><typeparam name="TEnum">The enumeration type to which to convert <paramref name="value"/>.</typeparam><exception cref="T:System.ArgumentException"><paramref name="TEnum"/> is not an enumeration type.</exception>
		[SecuritySafeCritical]
		public static bool TryParse<TEnum>(string value, bool ignoreCase, out TEnum result) where TEnum : struct;

		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
		/// </summary>
		/// 
		/// <returns>
		/// An object of type <paramref name="enumType"/> whose value is represented by <paramref name="value"/>.
		/// </returns>
		/// <param name="enumType">An enumeration type. </param><param name="value">A string containing the name or value to convert. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> or <paramref name="value"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>.-or- <paramref name="value"/> is either an empty string or only contains white space.-or- <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration. </exception><exception cref="T:System.OverflowException"><paramref name="value"/> is outside the range of the underlying type of <paramref name="enumType"/>.</exception><filterpriority>1</filterpriority>
		[ComVisible(true)]
		public static object Parse(Type enumType, string value);

		/// <summary>
		/// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object. A parameter specifies whether the operation is case-sensitive.
		/// </summary>
		/// 
		/// <returns>
		/// An object of type <paramref name="enumType"/> whose value is represented by <paramref name="value"/>.
		/// </returns>
		/// <param name="enumType">An enumeration type. </param><param name="value">A string containing the name or value to convert. </param><param name="ignoreCase">true to ignore case; false to regard case. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> or <paramref name="value"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>.-or- <paramref name="value"/> is either an empty string ("") or only contains white space.-or- <paramref name="value"/> is a name, but not one of the named constants defined for the enumeration. </exception><exception cref="T:System.OverflowException"><paramref name="value"/> is outside the range of the underlying type of <paramref name="enumType"/>.</exception><filterpriority>1</filterpriority>
		[ComVisible(true)]
		public static object Parse(Type enumType, string value, bool ignoreCase);

		/// <summary>
		/// Returns the underlying type of the specified enumeration.
		/// </summary>
		/// 
		/// <returns>
		/// The underlying type of <paramref name="enumType"/>.
		/// </returns>
		/// <param name="enumType">An enumeration type. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>. </exception><filterpriority>1</filterpriority>
		[SecuritySafeCritical]
		[ComVisible(true)]
		public static Type GetUnderlyingType(Type enumType);

		/// <summary>
		/// Retrieves an array of the values of the constants in a specified enumeration.
		/// </summary>
		/// 
		/// <returns>
		/// An array that contains the values of the constants in <paramref name="enumType"/>. The elements of the array are sorted by the binary values of the enumeration constants.
		/// </returns>
		/// <param name="enumType">An enumeration type. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>. </exception><filterpriority>1</filterpriority>
		[ComVisible(true)]
		public static Array GetValues(Type enumType);

		/// <summary>
		/// Retrieves the name of the constant in the specified enumeration that has the specified value.
		/// </summary>
		/// 
		/// <returns>
		/// A string containing the name of the enumerated constant in <paramref name="enumType"/> whose value is <paramref name="value"/>; or null if no such constant is found.
		/// </returns>
		/// <param name="enumType">An enumeration type. </param><param name="value">The value of a particular enumerated constant in terms of its underlying type. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> or <paramref name="value"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>.-or- <paramref name="value"/> is neither of type <paramref name="enumType"/> nor does it have the same underlying type as <paramref name="enumType"/>. </exception><filterpriority>1</filterpriority>
		[ComVisible(true)]
		public static string GetName(Type enumType, object value);

		/// <summary>
		/// Retrieves an array of the names of the constants in a specified enumeration.
		/// </summary>
		/// 
		/// <returns>
		/// A string array of the names of the constants in <paramref name="enumType"/>.
		/// </returns>
		/// <param name="enumType">An enumeration type. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> parameter is not an <see cref="T:System.Enum"/>. </exception><filterpriority>1</filterpriority>
		[ComVisible(true)]
		public static string[] GetNames(Type enumType);

		/// <summary>
		/// Converts the specified object with an integer value to an enumeration member.
		/// </summary>
		/// 
		/// <returns>
		/// An enumeration object whose value is <paramref name="value"/>.
		/// </returns>
		/// <param name="enumType">The enumeration type to return. </param><param name="value">The value convert to an enumeration member. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>.-or- <paramref name="value"/> is not type <see cref="T:System.SByte"/>, <see cref="T:System.Int16"/>, <see cref="T:System.Int32"/>, <see cref="T:System.Int64"/>, <see cref="T:System.Byte"/>, <see cref="T:System.UInt16"/>, <see cref="T:System.UInt32"/>, or <see cref="T:System.UInt64"/>. </exception><filterpriority>1</filterpriority>
		[ComVisible(true)]
		public static object ToObject(Type enumType, object value);

		/// <summary>
		/// Returns an indication whether a constant with a specified value exists in a specified enumeration.
		/// </summary>
		/// 
		/// <returns>
		/// true if a constant in <paramref name="enumType"/> has a value equal to <paramref name="value"/>; otherwise, false.
		/// </returns>
		/// <param name="enumType">An enumeration type. </param><param name="value">The value or name of a constant in <paramref name="enumType"/>. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> or <paramref name="value"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an Enum.-or- The type of <paramref name="value"/> is an enumeration, but it is not an enumeration of type <paramref name="enumType"/>.-or- The type of <paramref name="value"/> is not an underlying type of <paramref name="enumType"/>. </exception><exception cref="T:System.InvalidOperationException"><paramref name="value"/> is not type <see cref="T:System.SByte"/>, <see cref="T:System.Int16"/>, <see cref="T:System.Int32"/>, <see cref="T:System.Int64"/>, <see cref="T:System.Byte"/>, <see cref="T:System.UInt16"/>, <see cref="T:System.UInt32"/>, or <see cref="T:System.UInt64"/>, or <see cref="T:System.String"/>. </exception><filterpriority>1</filterpriority>
		[ComVisible(true)]
		public static bool IsDefined(Type enumType, object value);

		/// <summary>
		/// Converts the specified value of a specified enumerated type to its equivalent string representation according to the specified format.
		/// </summary>
		/// 
		/// <returns>
		/// A string representation of <paramref name="value"/>.
		/// </returns>
		/// <param name="enumType">The enumeration type of the value to convert. </param><param name="value">The value to convert. </param><param name="format">The output format to use. </param><exception cref="T:System.ArgumentNullException">The <paramref name="enumType"/>, <paramref name="value"/>, or <paramref name="format"/> parameter is null. </exception><exception cref="T:System.ArgumentException">The <paramref name="enumType"/> parameter is not an <see cref="T:System.Enum"/> type.-or- The <paramref name="value"/> is from an enumeration that differs in type from <paramref name="enumType"/>.-or- The type of <paramref name="value"/> is not an underlying type of <paramref name="enumType"/>. </exception><exception cref="T:System.FormatException">The <paramref name="format"/> parameter contains an invalid value. </exception><exception cref="T:System.InvalidOperationException"><paramref name="format"/> equals "X", but the enumeration type is unknown.</exception><filterpriority>1</filterpriority>
		[ComVisible(true)]
		public static string Format(Type enumType, object value, string format);

		/// <summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		/// </summary>
		/// 
		/// <returns>
		/// true if <paramref name="obj"/> is an <see cref="T:System.Enum"/> with the same underlying type and value as this instance; otherwise, false.
		/// </returns>
		/// <param name="obj">An object to compare with this instance, or null. </param><filterpriority>2</filterpriority>
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public override bool Equals(object obj);

		/// <summary>
		/// Returns the hash code for the value of this instance.
		/// </summary>
		/// 
		/// <returns>
		/// A 32-bit signed integer hash code.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode();

		/// <summary>
		/// Converts the value of this instance to its equivalent string representation.
		/// </summary>
		/// 
		/// <returns>
		/// The string representation of the value of this instance.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override string ToString();

		/// <summary>
		/// This method overload is obsolete; use <see cref="M:System.Enum.ToString(System.String)"/>.
		/// </summary>
		/// 
		/// <returns>
		/// The string representation of the value of this instance as specified by <paramref name="format"/>.
		/// </returns>
		/// <param name="format">A format specification. </param><param name="provider">(Obsolete.)</param><exception cref="T:System.FormatException"><paramref name="format"/> does not contain a valid format specification. </exception><exception cref="T:System.InvalidOperationException"><paramref name="format"/> equals "X", but the enumeration type is unknown.</exception><filterpriority>2</filterpriority>
		[Obsolete("The provider argument is not used. Please use ToString(String).")]
		public string ToString(string format, IFormatProvider provider);

		/// <summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		/// </summary>
		/// 
		/// <returns>
		/// A signed number that indicates the relative values of this instance and <paramref name="target"/>.Value Meaning Less than zero The value of this instance is less than the value of <paramref name="target"/>. Zero The value of this instance is equal to the value of <paramref name="target"/>. Greater than zero The value of this instance is greater than the value of <paramref name="target"/>.-or- <paramref name="target"/> is null.
		/// </returns>
		/// <param name="target">An object to compare, or null. </param><exception cref="T:System.ArgumentException"><paramref name="target"/> and this instance are not the same type. </exception><exception cref="T:System.InvalidOperationException">This instance is not type <see cref="T:System.SByte"/>, <see cref="T:System.Int16"/>, <see cref="T:System.Int32"/>, <see cref="T:System.Int64"/>, <see cref="T:System.Byte"/>, <see cref="T:System.UInt16"/>, <see cref="T:System.UInt32"/>, or <see cref="T:System.UInt64"/>. </exception><exception cref="T:System.NullReferenceException">This instance is null.</exception><filterpriority>2</filterpriority>
		[SecuritySafeCritical]
		public int CompareTo(object target);

		/// <summary>
		/// Converts the value of this instance to its equivalent string representation using the specified format.
		/// </summary>
		/// 
		/// <returns>
		/// The string representation of the value of this instance as specified by <paramref name="format"/>.
		/// </returns>
		/// <param name="format">A format string. </param><exception cref="T:System.FormatException"><paramref name="format"/> contains an invalid specification. </exception><exception cref="T:System.InvalidOperationException"><paramref name="format"/> equals "X", but the enumeration type is unknown.</exception><filterpriority>2</filterpriority>
		[SecuritySafeCritical]
		public string ToString(string format);

		/// <summary>
		/// This method overload is obsolete; use <see cref="M:System.Enum.ToString"/>.
		/// </summary>
		/// 
		/// <returns>
		/// The string representation of the value of this instance.
		/// </returns>
		/// <param name="provider">(obsolete) </param><filterpriority>2</filterpriority>
		[Obsolete("The provider argument is not used. Please use ToString().")]
		public string ToString(IFormatProvider provider);

		/// <summary>
		/// Determines whether one or more bit fields are set in the current instance.
		/// </summary>
		/// 
		/// <returns>
		/// true if the bit field or bit fields that are set in <paramref name="flag"/> are also set in the current instance; otherwise, false.
		/// </returns>
		/// <param name="flag">An enumeration value.</param><exception cref="T:System.ArgumentException"><paramref name="flag"/> is a different type than the current instance.</exception>
		public bool HasFlag(Enum flag);

		/// <summary>
		/// Returns the underlying <see cref="T:System.TypeCode"/> for this instance.
		/// </summary>
		/// 
		/// <returns>
		/// The type for this instance.
		/// </returns>
		/// <exception cref="T:System.InvalidOperationException">The enumeration type is unknown.</exception><filterpriority>2</filterpriority>
		public TypeCode GetTypeCode();

		/// <summary>
		/// Converts the current value to a Boolean value based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// This member always throws an exception.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param><exception cref="T:System.InvalidCastException">In all cases. </exception>
		bool IConvertible.ToBoolean(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to a Unicode character based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// This member always throws an exception.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param><exception cref="T:System.InvalidCastException">In all cases. </exception>
		char IConvertible.ToChar(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to an 8-bit signed integer based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// The converted value.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		sbyte IConvertible.ToSByte(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to an 8-bit unsigned integer based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// The converted value.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		byte IConvertible.ToByte(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to a 16-bit signed integer based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// The converted value.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		short IConvertible.ToInt16(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to a 16-bit unsigned integer based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// The converted value.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		ushort IConvertible.ToUInt16(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to a 32-bit signed integer based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// The converted value.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		int IConvertible.ToInt32(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to a 32-bit unsigned integer based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// The converted value.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		uint IConvertible.ToUInt32(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to a 64-bit signed integer based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// The converted value.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		long IConvertible.ToInt64(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to a 64-bit unsigned integer based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// The converted value.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		ulong IConvertible.ToUInt64(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to a single-precision floating-point number based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// This member always throws an exception.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param><exception cref="T:System.InvalidCastException">In all cases. </exception>
		float IConvertible.ToSingle(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to a double-precision floating point number based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// This member always throws an exception.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param><exception cref="T:System.InvalidCastException">In all cases. </exception>
		double IConvertible.ToDouble(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to a <see cref="T:System.Decimal"/> based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// This member always throws an exception.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param><exception cref="T:System.InvalidCastException">In all cases. </exception>
		decimal IConvertible.ToDecimal(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to a <see cref="T:System.DateTime"/> based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// This member always throws an exception.
		/// </returns>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param><exception cref="T:System.InvalidCastException">In all cases. </exception>
		DateTime IConvertible.ToDateTime(IFormatProvider provider);

		/// <summary>
		/// Converts the current value to a specified type based on the underlying type.
		/// </summary>
		/// 
		/// <returns>
		/// The converted value.
		/// </returns>
		/// <param name="type">The type to convert to. </param><param name="provider">An object that supplies culture-specific formatting information.</param>
		object IConvertible.ToType(Type type, IFormatProvider provider);

		/// <summary>
		/// Converts the specified 8-bit signed integer value to an enumeration member.
		/// </summary>
		/// 
		/// <returns>
		/// An instance of the enumeration set to <paramref name="value"/>.
		/// </returns>
		/// <param name="enumType">The enumeration type to return. </param><param name="value">The value to convert to an enumeration member. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>. </exception><filterpriority>1</filterpriority>
		[ComVisible(true)]
		[SecuritySafeCritical]
		[CLSCompliant(false)]
		public static object ToObject(Type enumType, sbyte value);

		/// <summary>
		/// Converts the specified 16-bit signed integer to an enumeration member.
		/// </summary>
		/// 
		/// <returns>
		/// An instance of the enumeration set to <paramref name="value"/>.
		/// </returns>
		/// <param name="enumType">The enumeration type to return. </param><param name="value">The value to convert to an enumeration member. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>. </exception><filterpriority>1</filterpriority>
		[ComVisible(true)]
		[SecuritySafeCritical]
		public static object ToObject(Type enumType, short value);

		/// <summary>
		/// Converts the specified 32-bit signed integer to an enumeration member.
		/// </summary>
		/// 
		/// <returns>
		/// An instance of the enumeration set to <paramref name="value"/>.
		/// </returns>
		/// <param name="enumType">The enumeration type to return. </param><param name="value">The value to convert to an enumeration member. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>. </exception><filterpriority>1</filterpriority>
		[ComVisible(true)]
		[SecuritySafeCritical]
		public static object ToObject(Type enumType, int value);

		/// <summary>
		/// Converts the specified 8-bit unsigned integer to an enumeration member.
		/// </summary>
		/// 
		/// <returns>
		/// An instance of the enumeration set to <paramref name="value"/>.
		/// </returns>
		/// <param name="enumType">The enumeration type to return. </param><param name="value">The value to convert to an enumeration member. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>. </exception><filterpriority>1</filterpriority>
		[SecuritySafeCritical]
		[ComVisible(true)]
		public static object ToObject(Type enumType, byte value);

		/// <summary>
		/// Converts the specified 16-bit unsigned integer value to an enumeration member.
		/// </summary>
		/// 
		/// <returns>
		/// An instance of the enumeration set to <paramref name="value"/>.
		/// </returns>
		/// <param name="enumType">The enumeration type to return. </param><param name="value">The value to convert to an enumeration member. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>. </exception><filterpriority>1</filterpriority>
		[CLSCompliant(false)]
		[ComVisible(true)]
		[SecuritySafeCritical]
		public static object ToObject(Type enumType, ushort value);

		/// <summary>
		/// Converts the specified 32-bit unsigned integer value to an enumeration member.
		/// </summary>
		/// 
		/// <returns>
		/// An instance of the enumeration set to <paramref name="value"/>.
		/// </returns>
		/// <param name="enumType">The enumeration type to return. </param><param name="value">The value to convert to an enumeration member. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>. </exception><filterpriority>1</filterpriority>
		[SecuritySafeCritical]
		[CLSCompliant(false)]
		[ComVisible(true)]
		public static object ToObject(Type enumType, uint value);

		/// <summary>
		/// Converts the specified 64-bit signed integer to an enumeration member.
		/// </summary>
		/// 
		/// <returns>
		/// An instance of the enumeration set to <paramref name="value"/>.
		/// </returns>
		/// <param name="enumType">The enumeration type to return. </param><param name="value">The value to convert to an enumeration member. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>. </exception><filterpriority>1</filterpriority>
		[ComVisible(true)]
		[SecuritySafeCritical]
		public static object ToObject(Type enumType, long value);

		/// <summary>
		/// Converts the specified 64-bit unsigned integer value to an enumeration member.
		/// </summary>
		/// 
		/// <returns>
		/// An instance of the enumeration set to <paramref name="value"/>.
		/// </returns>
		/// <param name="enumType">The enumeration type to return. </param><param name="value">The value to convert to an enumeration member. </param><exception cref="T:System.ArgumentNullException"><paramref name="enumType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="enumType"/> is not an <see cref="T:System.Enum"/>. </exception><filterpriority>1</filterpriority>
		[CLSCompliant(false)]
		[ComVisible(true)]
		[SecuritySafeCritical]
		public static object ToObject(Type enumType, ulong value);
	}
}
