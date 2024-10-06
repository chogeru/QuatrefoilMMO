using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AbubuResouse.Log;

namespace AbubuResouse.MVP
{
    public class TitleMGView : MonoBehaviour
    {
        [SerializeField, Header("ボタンの参照")]
        private Button m_ShowButton;
        [SerializeField, Header("表示するオブジェクトのリスト")]
        private List<GameObject> m_ObjectsToDisplay;
        [SerializeField, Header("非表示にするオブジェクトのリスト")]
        private List<GameObject> m_ObjectsToHide;


        public event System.Action OnShowButtonPressed;
        public event System.Action OnHideButtonPressed;

        private void Start()
        {
            if (m_ShowButton == null)
            {
                DebugUtility.LogError("ボタンがインスペクターに設定されてない！");
                return;
            }

            m_ShowButton.onClick.AddListener(() => OnShowButtonPressed?.Invoke());
            m_ShowButton.onClick.AddListener(() => OnHideButtonPressed?.Invoke());
        }

        /// <summary>
        /// Model側にリストを渡すためのアクセサ
        /// </summary>
        /// <returns></returns>
        public List<GameObject> GetObjectsToDisplay()
        {
            if (m_ObjectsToDisplay == null || m_ObjectsToDisplay.Count == 0)
            {
                DebugUtility.LogWarning("表示するオブジェクトがインスペクターに設定されていない");
            }
            return m_ObjectsToDisplay;
        }

        public List<GameObject> GetObjectsToHide()
        {
            if (m_ObjectsToHide == null || m_ObjectsToHide.Count == 0)
            {
                DebugUtility.LogWarning("非表示にするオブジェクトがインスペクターに設定されていない");
            }
            return m_ObjectsToHide;
        }
    }
}