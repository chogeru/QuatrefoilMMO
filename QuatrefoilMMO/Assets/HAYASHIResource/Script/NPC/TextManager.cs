using TMPro;
using UnityEngine;
using AbubuResouse.Log;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace AbubuResouse.Singleton
{
    /// <summary>
    /// テキスト表示を管理するクラス
    /// </summary>
    public class TextManager : SingletonMonoBehaviour<TextManager>
    {
        [SerializeField]
        private GameObject m_TextWindowUI;

        [SerializeField]
        private TextMeshProUGUI m_TextMeshPro;

        [SerializeField]
        private TextMeshProUGUI m_NameMeshPro;

        public bool isTextEnd = false;

        private CancellationTokenSource m_CTS;

        /// <summary>
        /// テキストを表示する処理
        /// </summary>
        /// <param name="characterName">キャラクターの名前</param>
        /// <param name="textToShow">表示するテキスト</param>
        public void ShowText(string characterName, string textToShow)
        {
            if (m_TextWindowUI == null || m_TextMeshPro == null)
            {
                DebugUtility.LogError("Textウィンドウがない");
                return;
            }

            isTextEnd = false;
            m_TextWindowUI.SetActive(true);
            m_TextMeshPro.gameObject.SetActive(true);
            m_NameMeshPro.gameObject.SetActive(true);
            StopManager.Instance.IsStopped = true;

            m_CTS?.Cancel();
            m_CTS = new CancellationTokenSource();
            m_NameMeshPro.text = characterName;
            TypeText(textToShow, m_CTS.Token).Forget();
        }

        /// <summary>
        /// テキストを1文字ずつ表示する関数
        /// </summary>
        /// <param name="textToShow">表示するテキスト</param>
        /// <param name="token">キャンセルトークン</param>
        private async UniTaskVoid TypeText(string textToShow, CancellationToken token)
        {
            m_TextMeshPro.text = "";
            foreach (char letter in textToShow.ToCharArray())
            {
                m_TextMeshPro.text += letter;
                await UniTask.Delay(1, cancellationToken: token);
                if (token.IsCancellationRequested)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// テキストを非表示にする処理
        /// </summary>
        public void HideText()
        {
            if (m_TextWindowUI == null)
            {
                return;
            }

            isTextEnd = true;
            StopManager.Instance.IsStopped = false;
            m_TextWindowUI.SetActive(false);
            m_TextMeshPro.gameObject.SetActive(false);
            m_NameMeshPro.gameObject.SetActive(false);
        }
    }

}