using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayerAttack : MonoBehaviour
{
    //シリアル化している　charadataのPlayer1の指定
    [SerializeField]
    private Mcharadata m_charadata;

    //AttackHitがゲームオブジェクトに侵入した瞬間に呼び出し
    private void OnTriggerEnter(Collider other)
    {
        //otherのゲームオブジェクトのインターフェースを呼び出す
        IDamageable damageable = other.GetComponent<IDamageable>();

        //damageableにnull値が入っていないかチェック
        if (damageable != null)
        {
            //damageableのダメージ処理メゾットを呼び出す　引数としてPlayer1のATKを指定
            damageable.Damage(m_charadata.ATK);
        }
    }
}
