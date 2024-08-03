using UnityEngine;
using AbubuResouse.Editor;
using AbubuResouse.Singleton;

namespace AbubuResouse
{
    /// <summary>
    /// NPCの会話システムを管理するクラス
    /// </summary>
    public class NPCSpeakSystem : MonoBehaviour
    {
        public enum NPCType
        {
            NPC,
            ShopNPC
        }
        [SerializeField, Header("NPCのタイプ")]
        public NPCType m_NpcType;

        [SerializeField, ReadOnly, Header("プレイヤーのトランスフォーム")]
        private Transform m_Player;

        [SerializeField, Header("ショップ用のCanvas")]
        private GameObject m__ShopCanvas;

        [SerializeField, Header("距離で表示するUI")]
        public GameObject m_SpeakCanvas;


        [SerializeField, Header("UI表示用の距離")]
        public float m_TriggerDistance = 10f;

        [SerializeField, Header("会話時のボタン")]
        private KeyCode m_KeyCode;

        [SerializeField, Header("テキストトリガー")]
        public TextTrigger m_TextTrigger;

        [SerializeField, Header("回転速度")]
        private float m_RotationSpeed = 20f;

        private bool isCanvasActive = false;

        private bool isTalking = false;

        private Quaternion OriginalRotation;

        private void Start()
        {
            m_Player = GameObject.FindGameObjectWithTag("Player").transform;
            OriginalRotation = transform.rotation;
        }
        private void Update()
        {
            HandleNPCInteraction();
            HandleCanvasVisibility();
        }

        /// <summary>
        /// NPCとのインタラクション処理
        /// </summary
        private void HandleNPCInteraction()
        {
            if (isTalking)
            {
                RotateTowardsPlayer();
                HandleShopNPC();
            }
            else
            {
                ReturnToOriginalRotation();
            }
        }

        /// <summary>
        /// プレイヤーの方向に向く処理
        /// </summary>
        private void RotateTowardsPlayer()
        {
            Vector3 direction = (m_Player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * m_RotationSpeed);
        }

        /// <summary>
        /// ShopNPCの場合の処理
        /// テキストが終了したらショップキャンバスを表示
        /// </summary>
        private void HandleShopNPC()
        {
            if (m_NpcType == NPCType.ShopNPC && TextManager.Instance.isTextEnd)
            {
                Cursor.visible = true;
                StopManager.Instance.IsStopped = true;
                m__ShopCanvas.SetActive(true);
            }
        }

        /// <summary>
        /// 元の回転に戻る処理
        /// </summary>
        private void ReturnToOriginalRotation()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, OriginalRotation, Time.deltaTime * m_RotationSpeed);
        }

        /// <summary>
        /// キャンバスの表示・非表示を処理
        /// </summary>
        private void HandleCanvasVisibility()
        {
            float distance = Vector3.Distance(transform.position, m_Player.position);

            if (distance <= m_TriggerDistance)
            {
                ShowCanvas();
                if (Input.GetKeyDown(m_KeyCode))
                {
                    m_TextTrigger.TriggerTextDisplay();
                    isTalking = true;
                }
            }
            else if (isCanvasActive)
            {
                ResetText();
                isCanvasActive = false;
            }
        }

        /// <summary>
        /// キャンバスを表示する処理
        /// </summary>
        private void ShowCanvas()
        {
            m_SpeakCanvas.SetActive(true);
            Vector3 uiPosition = transform.position;
            uiPosition.y += 2;
            m_SpeakCanvas.transform.position = uiPosition;
            isCanvasActive = true;
        }

        /// <summary>
        /// キャンバスを閉じる処理
        /// </summary>
        public void CanvasClose()
        {
            Cursor.visible = false;
            StopManager.Instance.IsStopped = false;
            m__ShopCanvas.SetActive(false);
            TextManager.Instance.isTextEnd = false;
            isTalking = false;
        }

        /// <summary>
        /// テキストをリセットする処理
        /// </summary>
        public void ResetText()
        {
            m_SpeakCanvas.SetActive(false);
            m_TextTrigger.ResetTextIndex();
            TextManager.Instance.isTextEnd = false;
            isTalking = false;
        }
    }
}
