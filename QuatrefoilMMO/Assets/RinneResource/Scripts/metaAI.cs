using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RinneResourceStateMachineAI
{
    public class metaAI : MonoBehaviour
    {

        //スポーンポイントのリストデータ
        [SerializeField]
        List<GameObject> m_enemyspawn = new List<GameObject>();

        //プレイヤー、敵データのリスト
        [SerializeField]
        List<GameObject> m_character = new List<GameObject>();

        void Start()
        {
            foreach (GameObject obj in UnityEngine.Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            {
                // アセットからパスを取得.シーン上に存在するオブジェクトの場合,シーンファイル（.unity）のパスを取得.
                string path = AssetDatabase.GetAssetOrScenePath(obj);
                // シーン上に存在するオブジェクトかどうか文字列で判定.
                bool isScene = path.Contains(".unity");
                // シーン上に存在するオブジェクトならば処理.
                if (isScene)
                {
                    Debug.Log("存在してます");
                    //スポーンポイントコンポーネントを持っているオブジェクトのみリストに登録
                    if (obj.GetComponent<EnemySpawn>())
                    {
                        m_enemyspawn.Add(obj);
                    }
                    //パラメータコンポーネントを持っているオブジェクトのみリストに追加
                    else if(obj.GetComponent<EnemyParameters>())
                    {
                        m_character.Add(obj);   
                    }
                }
            }
        }

        void Update()
        {
            
        }

        //スポーン地点を機能させない
        void SpawnOff()
        {
            //m_enemyspawn
        }
    }
}

