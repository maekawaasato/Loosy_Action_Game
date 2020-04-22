using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_zako2: base_enemy
{
    [Header("移動速度")]
    public float speed;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (sr.isVisible == true)
        {
            if (isDead == false)
            {
                //行動の設定
                Action();
            }
            else
            {
                //死後処理関数
                AfterDead();
            }

        }
    }

    /// <summary>
    /// 行動関数
    /// </summary>
    protected override void Action()
    {
        //左から右へ移動
        rb.velocity = new Vector2(-speed, 0.0f);

    }

}
