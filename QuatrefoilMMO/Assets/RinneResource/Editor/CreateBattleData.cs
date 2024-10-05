using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RinneResourceStateMachineAI
{
    public class CreateBattleData : MonoBehaviour
    {
        [MenuItem("Assets/Create/CreateBattleData")]
        public static void CreateAsset()
        {
            EnemyManager enemy = ScriptableObject.CreateInstance<EnemyManager>();

            //アセットを保存するパス
            string path = AssetDatabase.GenerateUniqueAssetPath("Assets/RinneResource/QuestBattleData/" + typeof(QuestBattleData) + ".asset");

            AssetDatabase.CreateAsset(enemy, path);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = enemy;
        }
    }
}

