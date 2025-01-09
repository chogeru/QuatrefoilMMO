using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 首を動かすためのクラス
/// </summary>

namespace RinneResourceStateMachineAI
{
    public class EnemyNeck_Control : MonoBehaviour
    {
        [SerializeField]
        private EnemyAI m_enemyai;
        [SerializeField,Header("首が動く最大と最小の値")]
        private float m_neckrotangle = 30;
        [SerializeField,Header("首を動かす時間")]
        public float m_neckrottime = 2f;
        //現在の時間
        private float m_elapsedtime;
        //首の回転フラグ
        private bool m_iswaitrot = false;
        private void Start()
        {
            m_enemyai.GetComponent<EnemyAI>();
        }

        //private void LateUpdate()
        //{
        //    NeckControl(true);
        //}

        //void NeckControl(bool flag)
        //{
        //    //フラグ検知
        //    if (!flag) return;

        //    if (m_enemyai.m_neck != null)
        //    {
        //        if (!m_iswaitrot)
        //        {
        //            float per = m_elapsedtime / m_neckrottime;
        //            if (per < 1f)
        //            {
        //                float alpha = Mathf.Sin(Mathf.PI * 2f * per);
        //                float angle = m_neckrotangle * alpha;
        //                //m_neck.localRotation *= Quaternion.Euler(angle, 0f, 0f);
        //                Vector3 euler = m_enemyai.m_neck.localRotation.eulerAngles;
        //                euler.x = angle;
        //                m_enemyai.m_neck.localRotation = Quaternion.Euler(euler);

        //            }
        //            else
        //            {
        //                m_elapsedtime -= m_neckrottime;
        //                m_iswaitrot = true;
        //            }
        //        }
        //        else
        //        {
        //            if (m_elapsedtime >= 2f)
        //            {
        //                m_elapsedtime -= 2f;
        //                m_iswaitrot = false;
        //            }
        //        }
        //        m_elapsedtime += Time.deltaTime;
        //        //m_neck.rotation = Quaternion.Euler(0f, 0f, -1f);
        //    }

        //}
    }
}

