using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アニメーションのStateを管理するStateMachineBehaviour
public class MAttackCombo : StateMachineBehaviour
{
    //始めの状態はisAttackをfalseにする
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttack", false);
    }

    //もしマウスの左クリックを押した時isAttackのアニメーションをtrueにする
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttack", true);
        }
    }

    //それ以外の状態ではisAttackのアニメーションをfalseにする
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttack", false);
    }
}
