using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WeaponData))]
public class WeaponDataEditor : Editor
{
    private GUIStyle headerStyle;
    private bool weaponInfoFoldout = true;
    private bool statusFoldout = true;
    private bool typeAndAttributeFoldout = true;
    private bool descriptionFoldout = true;

    private void OnEnable()
    {
        // �J�X�^���X�^�C����������
        headerStyle = new GUIStyle
        {
            alignment = TextAnchor.MiddleLeft,
            fontSize = 14,
            fixedHeight = 20,
            padding = new RectOffset(10, 0, 0, 0),
            contentOffset = new Vector2(0, 0)
        };

        // �O���f�[�V�����w�i��ݒ�
        headerStyle.normal.background = MakeTex(1, 20, Color.black, Color.gray);
        headerStyle.normal.textColor = Color.white;
        headerStyle.onNormal.background = MakeTex(1, 20, Color.black, Color.gray);
        headerStyle.onNormal.textColor = Color.white;
    }

    public override void OnInspectorGUI()
    {
        WeaponData weaponData = (WeaponData)target;

        serializedObject.Update();

        EditorGUILayout.BeginVertical("box");

        weaponInfoFoldout = DrawFoldoutHeader(" ������", weaponInfoFoldout);
        if (weaponInfoFoldout)
        {
            DrawPropertyField("_weaponID", "����Id", "d_UnityEditor.InspectorWindow");
            DrawPropertyField("_weaponName", "����̖��O", "d_UnityEditor.ProjectWindow");
        }

        statusFoldout = DrawFoldoutHeader(" �X�e�[�^�X", statusFoldout);
        if (statusFoldout)
        {
            DrawPropertyField("_attackPower", "�U����", "d_UnityEditor.AnimationWindow");
            DrawPropertyField("_attackSpeed", "�U�����x", "d_UnityEditor.ProfilerWindow");
            DrawPropertyField("_weaponWeight", "����d��", "d_UnityEditor.GameView");
        }

        typeAndAttributeFoldout = DrawFoldoutHeader(" �^�C�v�Ƒ���", typeAndAttributeFoldout);
        if (typeAndAttributeFoldout)
        {
            DrawPropertyField("_weaponType", "����̃^�C�v", "d_UnityEditor.SceneView", true);
            DrawPropertyField("_weaponAttribute", "����̑���", "d_UnityEditor.HierarchyWindow", true);
        }

        descriptionFoldout = DrawFoldoutHeader(" ������", descriptionFoldout);
        if (descriptionFoldout)
        {
            DrawPropertyField("_weaponDescription", "���������", "d_UnityEditor.ConsoleWindow", false, true);
        }

        EditorGUILayout.EndVertical();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(weaponData);
        }

        serializedObject.ApplyModifiedProperties();
    }

    private bool DrawFoldoutHeader(string title, bool foldout)
    {
        GUILayout.Space(20);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(10);
        foldout = EditorGUILayout.Foldout(foldout, title, true, headerStyle);
        EditorGUILayout.EndHorizontal();
        GUILayout.Space(20);
        return foldout;
    }

    private void DrawPropertyField(string propertyName, string label, string icon, bool isEnum = false, bool isTextArea = false)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label(EditorGUIUtility.IconContent(icon), GUILayout.Width(20), GUILayout.Height(20));
        EditorGUILayout.LabelField(label, GUILayout.Width(100));

        SerializedProperty property = serializedObject.FindProperty(propertyName);

        if (isEnum)
        {
            EditorGUILayout.PropertyField(property, GUIContent.none);
        }
        else if (isTextArea)
        {
            property.stringValue = EditorGUILayout.TextArea(property.stringValue, GUILayout.Height(60));
        }
        else
        {
            EditorGUILayout.PropertyField(property, GUIContent.none);
        }

        EditorGUILayout.EndHorizontal();
    }

    private Texture2D MakeTex(int width, int height, Color col1, Color col2)
    {
        Color[] pix = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            Color lerpedColor = Color.Lerp(col1, col2, (float)y / height);
            for (int x = 0; x < width; x++)
            {
                pix[y * width + x] = lerpedColor;
            }
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}
