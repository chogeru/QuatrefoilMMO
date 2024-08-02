using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyData))]
public class EnemyDataEditor : Editor
{
    private GUIStyle headerStyle;
    private bool enemyInfoFoldout = true;
    private bool statsFoldout = true;
    private bool attributesFoldout = true;

    private void OnEnable()
    {
        // Initialize custom style
        headerStyle = new GUIStyle
        {
            alignment = TextAnchor.MiddleLeft,
            fontSize = 14,
            fixedHeight = 20,
            padding = new RectOffset(10, 0, 0, 0),
            contentOffset = new Vector2(0, 0)
        };

        // Set gradient background
        headerStyle.normal.background = MakeTex(1, 20, Color.black, Color.gray);
        headerStyle.normal.textColor = Color.white;
        headerStyle.onNormal.background = MakeTex(1, 20, Color.black, Color.gray);
        headerStyle.onNormal.textColor = Color.white;
    }

    public override void OnInspectorGUI()
    {
        EnemyData enemyData = (EnemyData)target;

        serializedObject.Update();

        EditorGUILayout.BeginVertical("box");

        enemyInfoFoldout = DrawFoldoutHeader("�G�̏��", enemyInfoFoldout);
        if (enemyInfoFoldout)
        {
            DrawPropertyField("enemyID", "�GID", "d_UnityEditor.InspectorWindow");
            DrawPropertyField("enemyName", "�G�̖��O", "d_UnityEditor.ProjectWindow");
        }

        statsFoldout = DrawFoldoutHeader("�X�e�[�^�X", statsFoldout);
        if (statsFoldout)
        {
            DrawPropertyField("health", "�̗�", "d_UnityEditor.AnimationWindow");
            DrawPropertyField("moveSpeed", "�ړ����x", "d_UnityEditor.ProfilerWindow");
            DrawPropertyField("detectionRange", "���G�͈�", "d_UnityEditor.GameView");
            DrawPropertyField("visionRange", "���씻��", "d_UnityEditor.GameView");
            DrawPropertyField("attackRange", "�U������", "d_UnityEditor.GameView");
            DrawPropertyField("attackCooldown", "�U���Ԋu", "d_UnityEditor.GameView");
            DrawPropertyField("dropItemPrefab", "�h���b�v�A�C�e���̃v���n�u", "d_UnityEditor.SceneView");
            DrawPropertyField("dropItemCount", "�h���b�v�A�C�e���̐�", "d_UnityEditor.HierarchyWindow");
        }

        attributesFoldout = DrawFoldoutHeader("�^�C�v", attributesFoldout);
        if (attributesFoldout)
        {
            DrawPropertyField("enemyAttribute", "����", "d_UnityEditor.ConsoleWindow", true);
            DrawPropertyField("enemyType", "�G�^�C�v", "d_UnityEditor.HierarchyWindow", true);
            DrawPropertyField("behaviorType", "�s���^�C�v", "d_UnityEditor.HierarchyWindow", true);
            BehaviorType behaviorType = (BehaviorType)serializedObject.FindProperty("behaviorType").enumValueIndex;
            if (behaviorType == BehaviorType.Patrol)
            {
                DrawPropertyField("patrolPointWaitTime", "�p�j�|�C���g��~����", "d_UnityEditor.ProfilerWindow");
            }
            DrawPropertyField("weaponType", "�퓬������", "d_UnityEditor.SceneView", true);
            WeaponType weaponType = (WeaponType)serializedObject.FindProperty("weaponType").enumValueIndex;
            if (weaponType == WeaponType.Sword || weaponType == WeaponType.Axe || weaponType == WeaponType.Hammer)
            {
                DrawPropertyField("meleeAttackPower", "�ߐڍU����", "d_UnityEditor.AnimationWindow");
            }
            else if (weaponType == WeaponType.Bow || weaponType == WeaponType.Gun)
            {
                DrawPropertyField("projectileSpeed", "�e��", "d_UnityEditor.ProjectWindow");
                DrawPropertyField("projectilePower", "�e�̈З�", "d_UnityEditor.GameView");
                DrawPropertyField("projectileCount", "�e��", "d_UnityEditor.HierarchyWindow");
            }
            else if (weaponType == WeaponType.Magic)
            {
                DrawPropertyField("magicPower", "����", "d_UnityEditor.ConsoleWindow");
                DrawPropertyField("magicAttackInterval", "���@�U���Ԋu", "d_UnityEditor.InspectorWindow");
            }
        }

        EditorGUILayout.EndVertical();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(enemyData);
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
