using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPoint : MonoBehaviour
{
    [Header("ステージコントローラー")]
    public stageCtrl ctrl;

    
    private string playerTag = "Player";    //タグ:Player
    private string enemyTag = "enemy";      //タグ:enemy

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーと衝突したら
        if (collision.tag == playerTag)
        {
            //プレイヤーの再設定
            ReSetPlayer();
        }
        else if(collision.tag == enemyTag)//ゲーム外に出た敵オブジェクトは破棄
        {
            Destroy(collision.gameObject);
        }
       
    }

    //プレイヤーの再設定関数
    private void ReSetPlayer()
    {
        if (GManager.instance != null)
        {
            //残機を一減らす
            --GManager.instance.HeartNum;

            //ゲームオーバーフラグがたってなければ
            if (GManager.instance.IsGameOver == false)
            {
                if(ctrl != null)
                {
                    //プレイヤーをコンテニューポイントへ戻す
                    ctrl.PlayerSetContinuePoint();
                }
                
            }
        }
    }

}
