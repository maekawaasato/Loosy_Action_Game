using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBalletControler : base_ballet
{   
   
    [Header("弾丸の攻撃力")]
    public int power;

    /// <summary>
    /// 移動関数
    /// </summary>
    protected override void Move()
    {
        float xSpeed = 0.0f;//横軸の速さ

        //見えている間は弾を加速
        if (sr.isVisible == true)
        {
            //オブジェクトにplayerの方に向かって速度を与える
            if (dis > 0.0f)
            {
                xSpeed = -speed;
            }
            else
            {
                xSpeed = speed;
            }
        }
        else  //オブジェクト破棄
        {
            Destroy(this.gameObject);
        }

        //速度設定
        rb.velocity = new Vector2(xSpeed, 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //衝突したオブジェクトにセットされたオブジェクトから、IDamagable を呼ぶ
        var damageTarget = collision.gameObject.GetComponent<IDamagable>();

        //衝突したオブジェクトにIDamagebleがあれば
        if (damageTarget != null)
        {
            //衝突したオブジェクトのDamage関数を呼ぶ
            damageTarget.Damage(power);
        }

        //何かに当たったらオブジェクト破棄
        Destroy(this.gameObject);
    }

}
