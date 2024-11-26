using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRinneDamageProcess : MonoBehaviour
{
    private Parameters parameters;
    void Start()
    {
        //自分自身のパラメータ取得
        parameters = GetComponentInParent<Parameters>();
    }

    //接触した瞬間
    private void OnTriggerEnter(Collider other)
    {
        //パラメータを持ったオブジェクト
        if (other.GetComponent<Parameters>())
        {
            Parameters parameters = other.GetComponent<Parameters>();
            //接触したオブジェクトのパラメータタイプがプレイヤー
            if(parameters.GetParameterType() == "Enemy")
            {
                
                //ダメージ処理
                parameters.AttackHit(parameters.m_status.ATK);
                Debug.Log("ダメージが入りました。");
            }
        }
    }
}
