﻿using System.Linq;
using System.Reflection;

namespace GuildWars2Guild.Classes
{
    public static class Reflection
    {
        public static T1 CopyFrom<T1, T2>(this T1 obj, T2 otherObject)  where T1 : class where T2 : class {
            PropertyInfo[] srcFields = otherObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
            PropertyInfo[] destFields = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

            foreach(var property in srcFields) {
                var dest = destFields.FirstOrDefault(x => x.Name.Equals(property.Name));

                if(dest != null && dest.CanWrite)
                    dest.SetValue(obj, property.GetValue(otherObject, null), null);
            }
            return obj;
        }
    }
}