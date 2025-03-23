using System.Reflection;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace BasePage.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the Description Attribute of the enum.
        /// 
        /// http://wmwood.net/2015/12/18/quick-tip-enum-to-description-in-csharp/
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="enumerationValue">The enum to get the Description from.</param>
        /// <returns>The Description Attribute of the enum.</returns>
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString()!);
            if (memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return enumerationValue.ToString()!;
        }

        /// <summary>
        /// Gets an enum based on the Description rather than the value.
        /// </summary>
        /// <typeparam name="T">The Type of the returned value, must be an Enum.</typeparam>
        /// <param name="description">The enum description to search for.</param>
        /// <returns>The Enum value corresponding to the provided description.</returns>
        public static T GetEnumValueFromDescription<T>(this string description) where T : Enum
        {
            var field = typeof(T).GetFields().SelectMany(f => f.GetCustomAttributes(typeof(DescriptionAttribute), false), (f, a) => new { Field = f, Att = a }).SingleOrDefault(a => ((DescriptionAttribute)a.Att).Description == description);

            if (field == null)
            {
                throw new ArgumentOutOfRangeException(nameof(description), description, "Description string must map to a valid enum value.");
            }

            return (T)field.Field.GetRawConstantValue()!;
        }
    }
}