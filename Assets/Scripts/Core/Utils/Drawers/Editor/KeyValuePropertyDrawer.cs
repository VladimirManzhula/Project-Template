using System;
using System.Globalization;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Core.Utils.Drawers.Editor
{
    [CustomPropertyDrawer(typeof(KeyValueAttribute))]
	public class KeyValuePropertyDrawer : PropertyDrawer
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
			=> EditorGUI.GetPropertyHeight(property, label, true);

		protected virtual KeyValueAttribute Attribute => (KeyValueAttribute)attribute;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var args = Attribute.FieldNames.Select(s => property.propertyPath + "." + s)
				.Select(s => property.serializedObject.FindProperty(s))
				.Select(GetTitle)
				.ToArray();
			var newLabel = string.Format(Attribute.Format, args);
			if (string.IsNullOrEmpty(newLabel))
				newLabel = label.text;
			EditorGUI.PropertyField(position, property, new GUIContent(newLabel, label.tooltip), true);
		}

		private static string GetTitle(SerializedProperty titleNameProp)
		{
			if (titleNameProp == null)
				return "KeyValue -> Null";

			try
			{
				switch (titleNameProp.propertyType)
				{
					case SerializedPropertyType.Integer:
						return titleNameProp.intValue.ToString();
					case SerializedPropertyType.Boolean:
						return titleNameProp.boolValue.ToString();
					case SerializedPropertyType.Float:
						return titleNameProp.floatValue.ToString(CultureInfo.InvariantCulture);
					case SerializedPropertyType.String:
						return titleNameProp.stringValue;
					case SerializedPropertyType.Color:
						return titleNameProp.colorValue.ToString();
					case SerializedPropertyType.ObjectReference:
						return titleNameProp.objectReferenceValue.ToString();
					case SerializedPropertyType.Enum:
						return titleNameProp.enumNames[titleNameProp.enumValueIndex];
					case SerializedPropertyType.Vector2:
						return titleNameProp.vector2Value.ToString();
					case SerializedPropertyType.Vector3:
						return titleNameProp.vector3Value.ToString();
					case SerializedPropertyType.Vector4:
						return titleNameProp.vector4Value.ToString();
					default:
						return $"{titleNameProp.propertyType} Key not Implemented";
				}
			}
			catch (Exception e)
			{
				UnityEngine.Debug.LogError($"[{nameof(KeyValuePropertyDrawer)}] {e}");
				return "KeyValue -> Exception";
			}
		}
	}
}