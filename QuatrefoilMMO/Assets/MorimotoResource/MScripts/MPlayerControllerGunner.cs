using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class MPlayerControllerGunner : MonoBehaviour
{
    //歩き移動速度
    [SerializeField]
    private float m_moveWalkSpeed = 2f;

    //走り移動速度
    [SerializeField]
    private float m_moveRunSpeed = 8f;

    //ジャンプ力
    [SerializeField]
    private float m_jumpPower = 20f;

    //攻撃判定用オブジェクト
    [SerializeField]
    private GameObject m_attackHit = null;

    //攻撃判定用ColliderCall
    [SerializeField]
    private MColliderCallReceiver m_attackHitCall = null;

    //接地判定用ColliderCall
    //[SerializeField]
    //private ColliderCallReceiver m_footColliderCall = null;

    private float m_moveSpeed = 0f;

    private int m_isRunModeCnt = 1;
    private bool m_isRunMode = false;

    private Animator m_animator = null;
    private Rigidbody m_rigidbody = null;
    private Camera m_mainCamera = null;

    //移動用横方向入力
    private float m_horizontalKeyInput = 0f;
    //移動用縦方向入力
    private float m_verticalKeyInput = 0f;

    //攻撃中フラグ
    bool m_isAttack = false;
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
        //攻撃判定用オブジェクトをオフにする
        m_attackHit.SetActive(false);
        m_isRunModeCnt = 1;

        //攻撃判定用コライダに衝突イベントのコールバックを設定
        m_attackHitCall.TriggerEnterEvent.AddListener(OnAttackHitTriggerEnter);

        ////FootSphereのイベント登録
        //m_footColliderCall.TriggerStayEvent.AddListener(OnFootTriggerStay);
        //m_footColliderCall.TriggerExitEvent.AddListener(OnFootTriggerExit);
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
        //左クリックで攻撃開始
        if (Input.GetMouseButtonDown(0))
        {
            OnAttackButtonClicked();
        }

        //Spaceキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpButtonClicked();
        }

        //攻撃中でなければ、//移動キー入力取得
        m_horizontalKeyInput = 0f;
        m_verticalKeyInput = 0f;
        if (!m_isAttack)
        {
            m_horizontalKeyInput = Input.GetAxis("Horizontal");
            m_verticalKeyInput = Input.GetAxis("Vertical");
        }

        //Shift切り替え用
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_isRunModeCnt++;
            if (m_isRunModeCnt % 2 == 0)
            {
                m_isRunMode = true;
                m_moveSpeed = m_moveRunSpeed;
            }
            else
            {
                m_isRunMode = false;
                m_moveSpeed = m_moveWalkSpeed;
            }
        }

        //移動キーが入力されているかどうか
        bool isKeyInput = m_horizontalKeyInput != 0f || m_verticalKeyInput != 0f;
        if (isKeyInput)
        {
            //プレイヤーを移動方向へ向ける
            Vector3 moveDir = CalcMoveDir(m_horizontalKeyInput, m_verticalKeyInput);
            transform.forward = moveDir.normalized;

            if (m_isRunMode)
            {
                //アニメーションの走るフラグを立てる
                m_animator.SetBool("isRun", true);
                //アニメーションの走るフラグを下げる
                m_animator.SetBool("isWalk", false);
            }
            else
            {
                //アニメーションの走るフラグを立てる
                m_animator.SetBool("isRun", false);
                //アニメーションの走るフラグを立てる
                m_animator.SetBool("isWalk", true);
            }
        }
        //移動キーに入力がされていない
        else
        {
            //アニメーションの走るフラグを下げる
            m_animator.SetBool("isWalk", false);
            //アニメーションの走るフラグを立てる
            m_animator.SetBool("isRun", false);
        }
    }

    private void FixedUpdate()
    {
        //キー入力による移動量を求める
        Vector3 move = CalcMoveDir(m_horizontalKeyInput, m_verticalKeyInput) * m_moveSpeed;
        //現在の移動量を取得
        Vector3 current = m_rigidbody.velocity;
        current.y = 0f;

        //現在の移動量との差分だけプレイヤーに力を加える
        m_rigidbody.AddForce(move - current, ForceMode.VelocityChange);
    }

    //ジャンプボタンクリック時に呼び出されるコールバック
    public void OnJumpButtonClicked()
    {
        //攻撃中はジャンプしない
        if (m_isAttack) return;
        //接地していなければ、ジャンプしない
        //if (!m_isGround) return;
        m_rigidbody.AddForce(Vector3.up * m_jumpPower, ForceMode.Impulse);
    }

    //攻撃判定用コライダのトリガーのEnterコールバック
    public void OnAttackHitTriggerEnter(Collider col)
    {

        //2重にヒットしないように1度ヒットしたら
        //攻撃判定用コライダをオフにする
        //m_attackHit.SetActive(false);
    }

    //FootShereトリガーのStayコールバック
    //private void OnFootTriggerStay(Collider col)
    //{
    //    if (col.gameObject.tag == "Ground")
    //    {
    //        m_isGround = true;
    //        m_animator.SetBool("isGround", m_isGround);
    //    }
    //}

    //FootSphereトリガーのExitコールバック
    //private void OnFootTriggerExit(Collider col)
    //{
    //    if (col.gameObject.tag == "Ground")
    //    {
    //        m_isGround = false;
    //        m_animator.SetBool("isGround", m_isGround);
    //    }
    //}

    //攻撃ボタンクリック時に呼び出されるコールバック
    public void OnAttackButtonClicked()
    {
        //接地していなければ、攻撃を開始しない
        //if (!m_isGround) return;
        //既に攻撃中の場合は、再度攻撃を開始しない
        if (m_isAttack) return;
        m_isAttack = true;

        //攻撃用トリガーを起動
        m_animator.SetTrigger("isAttack");
    }

    //攻撃アニメーションのヒット時のイベント関数
    private void Anim_AttackHit()
    {
        //攻撃判定用オブジェクトをオンにする
        m_attackHit.SetActive(true);
    }

    //攻撃アニメーションに終了時のイベント関数
    private void Anim_AttackEnd()
    {
        //攻撃判定用オブジェクトをオフにする
        m_attackHit.SetActive(false);
        //攻撃終了
        m_isAttack = false;
    }

}

