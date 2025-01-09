using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayerAttack : MonoBehaviour
{
    //シリアル化している　charadataのPlayer1の指定
    [SerializeField]
    private Mcharadata m_charadata;

    //AttackHitがゲームオブジェクトに侵入した瞬間に呼び出し
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Parameters>())
        {
            Parameters parameters = other.GetComponent<Parameters>();
            if (parameters.GetParameterType() =="Enemy")
            {
                parameters.AttackHit(m_charadata.ATK);
            }
        }
        
    }
}
