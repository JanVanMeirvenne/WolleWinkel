using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WolleWinkel.CrossCutting.Infrastructure
{
    public abstract class EnumObject : IComparable
    {
        public string Name { get; private set; }

        public int Id { get; private set; }

        protected EnumObject(int id, string name) 
        {
            Id = id; 
            Name = name; 
        }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : EnumObject
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | 
                                             BindingFlags.Static | 
                                             BindingFlags.DeclaredOnly); 

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as EnumObject;

            if (otherValue == null) 
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => Id.CompareTo(((EnumObject)other).Id); 

        // Other utility methods ... 
        public static bool TryParse<T>(int id, out T enumObject) where T:EnumObject
        {
            var all = GetAll<T>();
            var obj = all.FirstOrDefault(o => o.Id.Equals(id));
            enumObject = null;
            if (obj != null)
            {
                enumObject = obj as T;
                return true;
            }

            return false;

        }
        
        public static bool TryParse<T>(string name, out T enumObject) where T:EnumObject
        {
            var all = GetAll<T>();
            var obj = all.FirstOrDefault(o => o.Name.Equals(name,StringComparison.OrdinalIgnoreCase));
            enumObject = null;
            if (obj != null)
            {
                enumObject = obj as T;
                return true;
            }

            return false;

        }

        public static T Parse<T>(string name) where T:EnumObject
        {
            if(!TryParse<T>(name,out T enumValue))
            {
                throw new InvalidOperationException($"Item is not a '{nameof(T)}'");
            }
            else
            {
                return enumValue;
            }
        }
    }
}