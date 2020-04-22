using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_zako4 : base_enemy
{
    #region//インスペクターで設定する
    [Header("移動速度")]
    public float speed;
    [Header("画面外でも行動する")]
    public bool nonVisibleAct;
    [Header("動く幅")]
    public float moveDis = 6.0f;
    #endregion

    #region//プライベート変数
    private bool returnPoint = true;       //オブジェクトの向きを表現
    private Vector3 defaltMovePoint;       //オブジェクト移動の始点
    private Vector3 endMovePoint;          //オブジェクト移動の終点
    private Vector3 targetPoint;           //目標座標 
    #endregion

    private void Start()
    {
        base.Start();
        if (defaltMovePoint != null && endMovePoint!= null && rb != null)
        {
            //座標の初期設定
            defaltMovePoint = this.transform.position;
            rb.position = defaltMovePoint;
            endMovePoint = defaltMovePoint + Vector3.up * moveDis;
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
      
            if (sr.isVisible == true || nonVisibleAct == true)
            {
                if (isDead == false)
                {
                
                    if(returnPoint == true)
                    {
                        //オブジェクトの向き設定
                        transform.localScale = new Vector3(1, 1, 1);
                        targetPoint = endMovePoint;
                        //行動の設定(行き)
                        Action();
                    }
                    else
                    {
                         //オブジェクトの向き設定
                        transform.localScale = new Vector3(1, -1, 1);
                        targetPoint = defaltMovePoint;
                        //行動の設定(帰り)
                        Action();
                    }
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
        //目標ポイントとの誤差がわずかになるまで移動
        if (Vector2.Distance(this.transform.position, targetPoint) > 0.1f)
        {
            //現在地から次のポイントへのベクトルを作成
            Vector2 toVector = Vector2.MoveTowards(this.transform.position, targetPoint, speed * Time.deltaTime);

            //次のポイントへ移動
            rb.MovePosition(toVector);
        }
        else
        {
            returnPoint = !returnPoint;
        }

    }

}
