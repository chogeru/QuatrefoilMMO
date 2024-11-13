using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageProcess : MonoBehaviour
{
    //private Parameters m_parameters;
    void Start()
    {
        //自分自身のパラメータ取得
        //m_parameters = GetComponentInParent<Parameters>();
    }

    //接触した瞬間
    private void OnTriggerEnter(Collider other)
    {
        //パラメータを持ったオブジェクト
        if (other.GetComponent<Parameters>())
        {
            Parameters parameters = other.GetComponent<Parameters>();
            //接触したオブジェクトのパラメータタイプがプレイヤー
            if(parameters.m_status.type == "プレイヤー")
            {
                //ダメージ処理
                parameters.AttackHit(parameters.m_status.ATK);
                Debug.Log("ダメージが入りました。");
            }
        }
    }
}
