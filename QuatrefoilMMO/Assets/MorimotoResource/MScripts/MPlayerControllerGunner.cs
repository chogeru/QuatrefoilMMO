using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class MPlayerControllerGunner : MonoBehaviour
{
    //歩き移動速度
    [SerializeField]
    private float m_moveWalkSeed = 2f;

    //走り移動速度
    [SerializeField]
    private float m_moveRunSeed = 4f;

    private Animator m_animator = null;
    private Rigidbody m_rigidbody = null;
    private Camera m_mainCamera = null;

    //移動用横方向入力
    private float m_horizontalKeyInput = 0f;
    //移動用縦方向入力
    private float m_verticalKeyInput = 0f;

    //接地フラグ
    bool m_isGround = false;

    protected void Awake()
    {
        //メインカメラを取得
        m_mainCamera = Camera.main;
        //プレイヤーのGameObjectにアタッチされているAnimatorコンポーネントを取得
        m_animator = GetComponent<Animator>();
        //Rigidbobyコンポーネントを取得
        m_rigidbody = GetComponent<Rigidbody>();
    }

    //移動方向ベクトルを算出
    private Vector3 CalcMoveDir(float moveX, float moveZ)
    {
        //指定された移動値から移動ベクトルを求める
        Vector3 moveVec = new Vector3(moveX, 0f, moveZ).normalized;

        //キャラクターの向きに合わせて移動するベクトルに変換して、返す
        Vector3 moveDir = m_mainCamera.transform.rotation * moveVec;
        moveDir.y = 0f;
        return moveDir.normalized;
    }

    private void Update()
    {
        m_horizontalKeyInput = 0f;
        m_verticalKeyInput = 0f;

        m_horizontalKeyInput = Input.GetAxis("Horizontal");
        m_verticalKeyInput = Input.GetAxis("Vertical");

        //移動キーが入力されているかどうか
        bool isKeyInput = m_horizontalKeyInput != 0f || m_verticalKeyInput != 0f;
        if (isKeyInput)
        {
            //プレイヤーを移動方向へ向ける
            Vector3 moveDir = CalcMoveDir(m_horizontalKeyInput, m_verticalKeyInput);
            transform.forward = moveDir.normalized;

            //アニメーションの走るフラグを立てる
            m_animator.SetBool("isWalk", true);
        }
        //移動キーに入力がされていない
        else
        {
            //アニメーションの走るフラグを下げる
            m_animator.SetBool("isWalk", false);
        }
    }

    private void FixedUpdate()
    {
        //キー入力による移動量を求める
        Vector3 move = CalcMoveDir(m_horizontalKeyInput, m_verticalKeyInput) * m_moveWalkSeed;
        //現在の移動量を取得
        Vector3 current = m_rigidbody.velocity;
        current.y = 0f;

        //現在の移動量との差分だけプレイヤーに力を加える
        m_rigidbody.AddForce(move - current, ForceMode.VelocityChange);
    }
}