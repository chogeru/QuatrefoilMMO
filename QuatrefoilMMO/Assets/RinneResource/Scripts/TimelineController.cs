using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RinneResource
{
    public class TimelineController : MonoBehaviour
    {
        public PlayableDirector playabledirector;

        //タイムライン起動
        public void StartTimeLine()
        {
            if (playabledirector != null)
            {
                playabledirector.Play();
            }
        }

        //タイムライン停止
        public void PauseTimeline()
        {
            if (playabledirector != null)
            {
                playabledirector.Pause();
            }
        }

        //タイムライン再開
        public void ResumeTimeLine()
        {
            if(playabledirector != null) 
            {
                playabledirector.Resume();
            }
        }
    }
}

