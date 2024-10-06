using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbubuResouse.Log;

namespace AbubuResouse.MVP
{
    public class TitleMGManager : MonoBehaviour
    {
        [SerializeField]
        private TitleMGView m_View;
        private TitleMGModel m_Model;

        private void Start()
        {
            if (m_View == null)
            {
                DebugUtility.LogError("ビューがインスペクターに設定されてないよ！");
                return;
            }

            m_Model = new TitleMGModel(m_View.GetObjectsToDisplay(), m_View.GetObjectsToHide());
            m_View.OnShowButtonPressed += OnShowButtonPressed;
            m_View.OnHideButtonPressed += OnHideButtonPressed;
        }

        private void OnDestroy()
        {
            m_View.OnShowButtonPressed -= OnShowButtonPressed;
            m_View.OnHideButtonPressed -= OnHideButtonPressed;
        }

        /// <summary>
        /// ボタンが押されたときにオブジェクトを表示する
        /// </summary>
        private void OnShowButtonPressed()
        {
            ShowObjects();
        }

        /// <summary>
        /// ボタンが押されたときにオブジェクトを非表示にする
        /// </summary>
        private void OnHideButtonPressed()
        {
            HideObjects();
        }

        /// <summary>
        /// オブジェクト表示処理
        /// </summary>
        private void ShowObjects()
        {
            foreach (GameObject obj in m_Model.m_ObjectsToShow)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
                else
                {
                    DebugUtility.LogWarning("リスト内のオブジェクトがnull");
                }
            }
        }

        /// <summary>
        /// オブジェクト非表示処理
        /// </summary>
        private void HideObjects()
        {
            foreach (GameObject obj in m_Model.m_ObjectsToHide)  // 修正: m_ObjectsToShow -> m_ObjectsToHide
            {
                if (obj != null)
                {
                    obj.SetActive(false);  // オブジェクトを非表示にする
                }
                else
                {
                    DebugUtility.LogWarning("リスト内のオブジェクトがnull");
                }
            }
        }
    }
}