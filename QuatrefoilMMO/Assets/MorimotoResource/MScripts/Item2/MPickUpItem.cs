using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MPickUpItem : MonoBehaviour
{
    //playerの位置
    [SerializeField]
    private MPlayerControllerFencer Mplayerdata;

    //調べるボタンを押したら宝箱が開く距離を指定。
    [SerializeField]
    private float kidoukyori;

    //宝箱開いた時のメッセージを表示するtext(itemnyusyu)を指定
    [SerializeField]
    private TextMeshProUGUI itemnyusyubunnsyou;

    //宝箱の開いた時のitemnyusyuやimageをまとめたcanvasを指定。
    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private MInventory2 inventory;

    //宝箱を開いた時のメッセージを表示する時間を指定
    [SerializeField]
    private float moziteruzikan;

    private bool open = false;

    //Itemデータを入れる
    public MItemSourceData m_item2;

    void Update()
    {
        //プレイヤーと宝箱との距離を求める。
        Vector3 takarabakoposition = this.transform.position;
        Vector3 playerposition = Mplayerdata.transform.position;
        Vector3 kyori = playerposition - takarabakoposition;


        //宝箱とプレイヤー間の距離ベクトルが指定した起動距離以下かどうか
        if (kidoukyori > kyori.magnitude && !open)
        {
            //この状態で調べるボタンが押された場合に宝箱を開ける処理を行う。
            if (Input.GetButtonDown("check"))
            {
                //指定した宝箱のアイテムの名前を代入
                string itemname = m_item2.Getitemname;

                //指定した宝箱のアイテムの名前を表示
                canvas.SetActive(true);

                //コルーチンで待機処理を行う。
                StartCoroutine(mozideruzikan());

                //出すメッセージ
                itemnyusyubunnsyou.text = ($"{itemname}を手に入れた。");

                if (!open)
                {
                    //宝箱にいれたアイテムのMItemSourceDataのリストに追加。
                    MInventory2.m_instance.Add(m_item2);
                }
                open = true;
            }
        }

        IEnumerator mozideruzikan()
        {
            // 文字が出る時間だけ待機  
            yield return new WaitForSeconds(moziteruzikan);
            //追加可能だった場合にはメッセージを消す。
            canvas.SetActive(false);
            Destroy(gameObject);
        }
    }

    //元PICKUP
    //public void OnTriggerEnter(Collider other)
    //{
    //    PickUp();
    //}

    ////インベントリにアイテムを追加
    //public void PickUp()
    //{
    //    MInventory2.m_instance.Add(m_item2);
    //    Debug.Log(m_item2.name + "を入手しました");
    //    Destroy(gameObject);
    //}
}
