using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//UIを使用するので記述
using UnityEngine.UI;

public class MCharaDamage : MonoBehaviour, IDamageable
{
    //シリアル化している　MplayerdataのPlayerを指定
    [SerializeField]
    private Mplayerdata m_playerdata;

    //シリアル化している　charadataの自身を指定
    [SerializeField]
    private Mcharadata m_charadata2;

    //シリアル化している　MLvdataのMLvdata1を指定
    [SerializeField]
    private MLvdata m_lvdata;

    //シリアル化　SliderのHPゲージ指定
    [SerializeField]
    private Slider m_slider;

    private int m_HP;

    private void Start()
    {
        //Mcharadataがnullでないことを確認
        if (m_charadata2 != null)
        {
            //valueのHPゲージのスライダーを最大の1に
            m_slider.value = 1;

            //Mcharadataの最大HPを代入
            m_HP = m_charadata2.MAXHP;
        }
    }

    //ダメージ処理のメソッド　valueには敵のATKの値が入っている
    public void Damage(int value)
    {
        //Mcharadataがnullでないかをチェック
        if(m_charadata2 != null)
        {
            //敵のATKから自身のDEFを引いた値をHPから引く
            m_HP -= value - m_charadata2.DEF;
            //HPゲージに反映
            m_slider.value = (float)m_HP / (float)m_charadata2.MAXHP;
        }

        //HPが0以下ならDeath()メソッドを呼び出す
        if (m_HP <= 0)
        {
            Death();
        }
    }

    //死亡処理のメソッド
    public void Death()
    {
        //獲得経験値があるなら経験値処理
        if (m_charadata2.GETEXP > 0)
        {
            m_playerdata.EXP = m_playerdata.EXP + m_charadata2.GETEXP;
            var a = m_lvdata.playerExpTable[m_playerdata.LV];

            if (m_playerdata.EXP >= a.exp)
            {
                m_playerdata.LV = m_playerdata.LV + 1;
            }
        }

        //獲得賞金があるなら金処理
        if (m_charadata2.GETGOLD > 0)
        {
            m_playerdata.GOLD = m_playerdata.GOLD + m_charadata2.GETGOLD;
        }

        //ゲームオブジェクトを破壊
        Destroy(gameObject);
    }

    public void Recovery(int value)
    {

    }
}
