using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RinneResourceStateMachineAI
{
    [System.Serializable]
    public class QuestBattleData : ScriptableObject
    {
        public List<EnemyManager> entryEnemy;
    }

    [System.Serializable]
    public class EnemyManager : ScriptableObject
    {
        public string m_name;
        public string[] m_state;
        public GameObject obj;
    }
}

