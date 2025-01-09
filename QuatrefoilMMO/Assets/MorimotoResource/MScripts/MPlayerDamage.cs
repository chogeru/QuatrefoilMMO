using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//UIを使用するので記述
using UnityEngine.UI;

public class MPlayerDamage : MonoBehaviour, IDamageable
{
    //シリアル化している　playerdataの自身を指定
    [SerializeField]
    private Mplayerdata m_playerdata;

    //シリアル化している　MLvdataのMLvdata1を指定
    [SerializeField]
    private MLvdata m_lvdata;

    //シリアル化　SliderのHPゲージ指定
    [SerializeField]
    private Slider m_slider;

    private int m_HP;

    private void Start()
    {
        //Mplayerdataがnullでないことを確認
        if (m_playerdata != null)
        {
            //valueのHPゲージのスライダーを最大の1に
            m_slider.value = 1;

            //Mplayerdataの最大HPを代入
            m_HP = m_playerdata.MAXHP;
        }
    }

    public void Recovery(int value)
    {
        if (m_playerdata != null)
        {
            m_HP = Mathf.Min(m_HP + value, m_playerdata.MAXHP);
            //HPゲージに反映
            m_slider.value = (float)m_HP / (float)m_playerdata.MAXHP;
        }
    }

    //ダメージ処理のメソッド　valueには敵のATKの値が入っている
    public void Damage(int value)
    {
        //Mplayerdataがnullでないかをチェック
        if(m_playerdata != null)
        {
            //敵のATKから自身のDEFを引いた値をHPから引く
            m_HP -= value - m_playerdata.DEF;
            //HPゲージに反映
            m_slider.value = (float)m_HP / (float)m_playerdata.MAXHP;
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
        //ゲームオブジェクトを破壊
        Destroy(gameObject);
    }
}
