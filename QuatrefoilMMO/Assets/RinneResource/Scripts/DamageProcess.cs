using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageProcess : MonoBehaviour
{
    [SerializeField]
    private EnemyParameters enemyparameters;
    void Start()
    {
        //自分自身のパラメータ取得
        enemyparameters = GetComponentInParent<EnemyParameters>();
    }

    //接触した瞬間
    private void OnTriggerEnter(Collider other)
    {
        //パラメータを持ったオブジェクト
        if (other.GetComponent<EnemyParameters>())
        {
            EnemyParameters parameters = other.GetComponent<EnemyParameters>();
            //接触したオブジェクトのパラメータタイプがプレイヤー
            if(parameters.m_parameters.type == "プレイヤー")
            {
                
                //ダメージ処理
                parameters.AttackHit(enemyparameters.m_parameters.ATK);
                Debug.Log("ダメージが入りました。");
            }
        }
    }
}
