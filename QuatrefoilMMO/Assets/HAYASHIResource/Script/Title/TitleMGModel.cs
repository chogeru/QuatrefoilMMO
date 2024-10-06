using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbubuResouse.Log;
namespace AbubuResouse.MVP
{
    public class TitleMGModel : MonoBehaviour
    {
        public List<GameObject> m_ObjectsToShow { get; private set; }
        public List<GameObject> m_ObjectsToHide { get; private set; }

        public TitleMGModel(List<GameObject> objectsToShow, List<GameObject> objectsToHide)
        {
            if (objectsToShow == null || objectsToShow.Count == 0)
            {
                DebugUtility.LogError("表示するオブジェクトのリストがnull");
            }

            if (objectsToHide == null || objectsToHide.Count == 0)
            {
                DebugUtility.LogError("非表示にするオブジェクトのリストがnull");
            }

            m_ObjectsToShow = objectsToShow ?? new List<GameObject>();
            m_ObjectsToHide = objectsToHide ?? new List<GameObject>();
        }
    }
}