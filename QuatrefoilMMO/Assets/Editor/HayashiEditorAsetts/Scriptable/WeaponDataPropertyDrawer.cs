using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(WeaponData))]
public class WeaponDataPropertyDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // �e�t�B�[���h�̃��C�A�E�g���J�X�^�}�C�Y
        var weaponIDRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        var weaponNameRect = new Rect(position.x, position.y + 20, position.width, EditorGUIUtility.singleLineHeight);
        var weaponTypeRect = new Rect(position.x, position.y + 40, position.width, EditorGUIUtility.singleLineHeight);
        var weaponAttributeRect = new Rect(position.x, position.y + 60, position.width, EditorGUIUtility.singleLineHeight);
        var weaponDescriptionRect = new Rect(position.x, position.y + 80, position.width, EditorGUIUtility.singleLineHeight * 3);
        var attackPowerRect = new Rect(position.x, position.y + 140, position.width, EditorGUIUtility.singleLineHeight);
        var attackSpeedRect = new Rect(position.x, position.y + 160, position.width, EditorGUIUtility.singleLineHeight);
        var weaponWeightRect = new Rect(position.x, position.y + 180, position.width, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(weaponIDRect, property.FindPropertyRelative("_weaponID"), new GUIContent("����Id"));
        EditorGUI.PropertyField(weaponNameRect, property.FindPropertyRelative("_weaponName"), new GUIContent("����̖��O"));
        EditorGUI.PropertyField(attackPowerRect, property.FindPropertyRelative("_attackPower"), new GUIContent("�U����"));
        EditorGUI.PropertyField(attackSpeedRect, property.FindPropertyRelative("_attackSpeed"), new GUIContent("�U�����x"));
        EditorGUI.PropertyField(weaponWeightRect, property.FindPropertyRelative("_weaponWeight"), new GUIContent("����d��"));
        EditorGUI.PropertyField(weaponTypeRect, property.FindPropertyRelative("_weaponType"), new GUIContent("����̃^�C�v"));
        EditorGUI.PropertyField(weaponAttributeRect, property.FindPropertyRelative("_weaponAttribute"), new GUIContent("����̑���"));
        EditorGUI.PropertyField(weaponDescriptionRect, property.FindPropertyRelative("_weaponDescription"), new GUIContent("���������"));


        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // �t�B�[���h�̍�����ݒ�
        return EditorGUIUtility.singleLineHeight * 10;
    }
}
