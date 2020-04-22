using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_zako5 : base_enemy
{
    
    [Header("視界")]
    public SearchPlayer searchPlayer;
  
    // Update is called once per frame
    private void FixedUpdate()
    {
        
        if (sr.isVisible == true)
        {
            if (isDead == false)
            {
                //行動関数
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
        //落ちるフラグがたっていたら重力を有効化する
        if (searchPlayer != null && searchPlayer.isfall == true)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

    }
}
