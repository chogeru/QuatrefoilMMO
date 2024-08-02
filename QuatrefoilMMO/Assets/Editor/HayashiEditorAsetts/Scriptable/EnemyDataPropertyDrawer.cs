using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyData))]
public class EnemyDataPropertyDrawer : Editor
{

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("enemyID"), new GUIContent("�GID"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("enemyName"), new GUIContent("�G�̖��O"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("health"), new GUIContent("�̗�"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("moveSpeed"), new GUIContent("�ړ����x"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("detectionRange"), new GUIContent("���G�͈�"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("visionRange"), new GUIContent("���씻��"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("attackRange"), new GUIContent("�U������"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("attackCooldown"), new GUIContent("�U���Ԋu"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("dropItemPrefab"), new GUIContent("�h���b�v�A�C�e���̃v���n�u"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("dropItemCount"), new GUIContent("�h���b�v�A�C�e���̐�"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("enemyAttribute"), new GUIContent("����"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("behaviorType"), new GUIContent("�s���^�C�v"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("enemyType"), new GUIContent("�G�^�C�v"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponType"), new GUIContent("�퓬������"));
        BehaviorType behaviorType = (BehaviorType)serializedObject.FindProperty("behaviorType").enumValueIndex;
        if (behaviorType == BehaviorType.Patrol)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("patrolPointWaitTime"), new GUIContent("�p�j�|�C���g��~����"));
        }

        WeaponType weaponType = (WeaponType)serializedObject.FindProperty("weaponType").enumValueIndex;
        if (weaponType == WeaponType.Sword || weaponType == WeaponType.Axe || weaponType == WeaponType.Hammer)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("meleeAttackPower"), new GUIContent("�ߐڍU����"));
        }
        else if (weaponType == WeaponType.Bow || weaponType == WeaponType.Gun)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("projectileSpeed"), new GUIContent("�e��"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("projectilePower"), new GUIContent("�e�̈З�"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("projectileCount"), new GUIContent("�e��"));
        }
        else if (weaponType == WeaponType.Magic)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("magicPower"), new GUIContent("����"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("magicAttackInterval"), new GUIContent("���@�U���Ԋu"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}
