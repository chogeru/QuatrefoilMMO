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
        //otherのゲームオブジェクトのインターフェースを呼び出す
        Parameters parameters = other.GetComponent<Parameters>();

        parameters.AttackHit(m_charadata.ATK);
    }
}
