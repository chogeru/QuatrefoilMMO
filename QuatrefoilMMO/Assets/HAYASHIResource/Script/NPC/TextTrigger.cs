using UnityEngine;
using AbubuResouse.Log;
using AbubuResouse.Singleton;

[System.Serializable]
public class Dialogue
{
    public string characterName;
    [TextArea(3, 10)]
    public string message;
    public string seName;
    public float seVolume = 1.0f;
}

/// <summary>
/// テキスト表示をトリガーするクラス
/// </summary>
public class TextTrigger : MonoBehaviour
{
    public Dialogue[] m_Dialogues;
    [SerializeField]
    public int m_CurrentIndex = 0;
    [SerializeField, Header("サウンド名")]
    private string m_SeName;
    [SerializeField,Header("SE音量")]
    private float m_SeVolume;

    /// <summary>
    /// テキスト表示をトリガーする処理
    /// </summary>
    public void TriggerTextDisplay()
    {
        if (TextManager.Instance == null || m_Dialogues == null || m_Dialogues.Length == 0)
        {
            DebugUtility.LogError("テキストの要素がない");
            SEManager.Instance.PlaySound(this.m_SeName, this.m_SeVolume);
            TextManager.Instance?.HideText();
            ResetTextIndex();
            return;
        }

        if (m_CurrentIndex < m_Dialogues.Length)
        {
            var currentDialogue = m_Dialogues[m_CurrentIndex];
            TextManager.Instance.ShowText(currentDialogue.characterName, currentDialogue.message);
            PlaySoundEffect(currentDialogue.seName, currentDialogue.seVolume);
            SEManager.Instance.PlaySound(this.m_SeName, this.m_SeVolume);
            m_CurrentIndex++;
        }
        else
        {
            DebugUtility.Log("テキストがない");
            TextManager.Instance.HideText();
            ResetTextIndex();
        }

        if (m_CurrentIndex > m_Dialogues.Length)
        {
            TextManager.Instance.HideText();
            ResetTextIndex();
        }
    }

    /// <summary>
    /// 効果音を再生する処理
    /// </summary>
    /// <param name="seName">再生する効果音の名前</param>
    /// <param name="seVolume">再生する効果音の音量</param>
    private void PlaySoundEffect(string seName, float seVolume)
    {
        if (!string.IsNullOrEmpty(seName))
        {
            VoiceManager.Instance.PlaySound(seName, seVolume);
        }
    }

    /// <summary>
    /// テキストインデックスをリセットする処理
    /// </summary>
    public void ResetTextIndex()
    {
        m_CurrentIndex = 0;
    }
}
