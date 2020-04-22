using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    //プレイヤーのコンポーネント群
    private Player player = null;
    private Animator anim = null;

    // Start is called before the first frame update
    private void Start()
    {
        //コンポーネントのインスタンス取得
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    private void Update()
    {
        //アニメーション設定
        SetAnimation();
    }

    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        if(player != null && anim != null)
        {
            anim.SetBool("jump", player.IsJump);
            anim.SetBool("Ground", player.IsGround);
            anim.SetBool("run", player.IsRun);

            if(GManager.instance.IsClear == true) anim.Play("player_clear");
            if(player.IsDown == true) anim.Play("player_damage");
           
        }
    }

    /// <summary>
    /// ダウンアニメーションが終わっているかどうか
    /// </summary>
    /// <returns><c>true</c>, if down animation was end, <c>false</c> otherwise.</returns> 
    public bool IsDownAnimEnd()
    {
        //アニメーションが終わるとfalse それ以外 true
        if (player != null && player.IsDown == true && anim != null)
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

            if (currentState.IsName("player_damage"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    anim.Play("player_stand");
                    return true;
                }
            }

        }
        return false;
    }
    
}
