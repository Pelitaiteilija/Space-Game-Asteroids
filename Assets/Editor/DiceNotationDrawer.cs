using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;

[CustomPropertyDrawer(typeof(DiceNotation))]
public class DiceNotationDrawer : PropertyDrawer {

    // IMGUI implementation
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        // base.OnGUI(position, property, label);
        //EditorGUI.BeginChangeCheck();

        SerializedProperty diceRollProperty = property.FindPropertyRelative("diceRoll");
        EditorGUI.BeginChangeCheck();
        string diceRoll = diceRollProperty.stringValue;

        //        diceRoll = Regex.Replace(diceRoll, "[^0-9].*[^d|D][^0-9].*[^+|-][^0-9].*", "");
        //        diceRoll = Regex.Replace(diceRoll, ".*[^0-9d+-].*", "");
        // if string isn't of the format 1d2, 1D2 1d2(+/-)3 and (-)123
        if (!Regex.IsMatch(diceRoll, "^[1-9]\\d*(d|D)?[1-9]\\d*([-+][1-9]\\d*)?$") && !Regex.IsMatch(diceRoll, "^-?[0-9]+$") ) {
            diceRollProperty.stringValue = "";
        }
        EditorGUI.EndChangeCheck();


        EditorGUI.BeginProperty(position, label, property);

        // label
        label.text = DiceNotation.GetValueRange(diceRoll);
        position = EditorGUI.PrefixLabel(position, label);
        // don't intend child fields
        var previousIndent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // calculate rects
        var diceRollRect = new Rect(position.x, position.y, position.width, position.height);

        // Draw fields, pass GUIContent.none to hide fields
        EditorGUI.PropertyField(diceRollRect, diceRollProperty);

        // reset indent 
        EditorGUI.indentLevel = previousIndent;
        EditorGUI.EndProperty();
    }
}
