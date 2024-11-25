using System.Linq;
using UnityEngine;

namespace Core.Utils.Drawers
{
    public class KeyValueAttribute : PropertyAttribute
    {
        public readonly string Format;
        public readonly string[] FieldNames;

        public KeyValueAttribute(params string[] fieldNames)
        {
            FieldNames = fieldNames;
            Format = string.Join(" ", fieldNames.Select((s, i) => "{" + i + "}"));
        }

        public KeyValueAttribute(string format, string[] fieldNames)
        {
            FieldNames = fieldNames;
            Format = format;
        }
    }
}