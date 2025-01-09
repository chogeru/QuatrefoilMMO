using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageProcess : MonoBehaviour
{
    private Parameters m_parameters;
    void Start()
    {
        //自分自身のパラメータ取得
        m_parameters = GetComponentInParent<Parameters>();
    }

    //接触した瞬間
    private void OnTriggerEnter(Collider other)
    {
        //パラメータを持ったオブジェクト
        if (other.GetComponent<Parameters>())
        {
            Parameters parameters = other.GetComponent<Parameters>();
            //接触したオブジェクトのパラメータタイプがプレイヤー
            if(parameters.GetParameterType() == "Player")
            {
                //ダメージ処理
                parameters.AttackHit(m_parameters.m_status.ATK);
                Debug.Log("ダメージが入りました。");
                //発見状態に変更
                parameters.m_status.IsFlag = true;
            }
        }
    }
}
