using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_zako1 : base_enemy
{
    #region//インスペクターで設定する
    [Header("移動速度")]
    public float speed;
    [Header("重力")]
    public float gravity;
    [Header("接触判定")]
    public EnemyCollisionCheck checkCollision;
    #endregion

    #region//プライベート変数
    //オブジェクトの状態を表すパラメータ
    private bool rightTleftF = false;
    #endregion

    private void FixedUpdate()
    {
        
        if (sr.isVisible  == true )
        {
            if(isDead == false)
            {
                //何かにぶつかったら向きを変える
                if (checkCollision != null && checkCollision.isOn == true)
                {
                    rightTleftF = !rightTleftF;

                }

                //向きの設定
                DefineDirection(rightTleftF);

                //行動の設定
                Action();

            }
            else
            {
                //死後処理関数
                AfterDead();
            }
        }   
        else
        {
            anim.SetBool("walk", false);
        }
        
        
    }

    /// <summary>
    /// 向きの設定関数
    /// </summary>
    private void DefineDirection(bool rightTleftF)
    {
        if (rightTleftF == true)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    /// <summary>
    /// 行動関数
    /// </summary>
    protected override void Action()
    {
        int xVector = -1;

        if (rightTleftF == true)
        {
            xVector = 1;

        }

        //移動
        rb.velocity = new Vector2(xVector * speed, -gravity);
        anim.SetBool("walk", true);
    }

}
