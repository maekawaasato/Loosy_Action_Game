using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    #region//パブリック変数
    [Header("移動速度")]
    public float speed;
    [Header("重力")]
    public float gravity;
    [Header("ジャンプ速度")]
    public float jumpSpeed;
    [Header("ジャンプする高さ")]
    public float jumpHeight;
    [Header("ジャンプ制限時間")]
    public float jumpLimitTime;
    #endregion

    //プレイヤーのコンポーネント群
    private Player player = null;
    private Rigidbody2D rb = null;

    private float jumpTime = 0.0f;      //ジャンプしている時間
    private float jumpPos = 0.0f;       //ジャンプした高さ

    // Start is called before the first frame update
    private void Start()
    {
        //コンポーネントのインスタンス取得
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //もしダウン状態でなければ
        if (player.IsDown == false)
        {
            //速度設定
            rb.velocity = new Vector2(SetX(), SetY());
        }
    }

    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>The x.</returns>
    private float SetX()
    {
        float horizontalKey = Input.GetAxis("Horizontal");  //左右キーの入力値(押しっぱなしを検知 FixedUpdateでも大丈夫) 
        float xSpeed = 0.0f;                                //横軸の速さ

        //キー入力されたら行動する
        if (horizontalKey != 0)
        {
            if (horizontalKey > 0)
            {
                //向きとxSpeedの設定
                transform.localScale = new Vector3(1, 1, 1);
                xSpeed = speed;
            }
            else
            {
                //向きとxSpeedの設定
                transform.localScale = new Vector3(-1, 1, 1);
                xSpeed = -speed;

            }
            //ラン状態
            player.IsRun = true;
        }
        else
        {
            //ラン状態を解除しxSpeedに0を設定
            player.IsRun = false;
            xSpeed = 0.0f;
        }

        return xSpeed;
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>The y.</returns>
    private float SetY()
    {
        float verticalKey = Input.GetAxis("Vertical");  //上下キーの入力値(押しっぱなしを検知)
        float ySpeed = -gravity;                        //縦軸の速さ


        //グラウンド状態なら
        if (player.IsGround == true)
        {
            //上キーが押されたら && ジャンプ制限時間内なら
            if (verticalKey > 0 && jumpLimitTime > jumpTime)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y;　//ジャンプした位置を記録する
                player.IsJump = true;
                jumpTime = 0.0f;

            }
            else
            {
                player.IsJump = false;
            }
        }
        else if (player.IsJump == true) //ジャンプ中
        {

            //ジャンプの高さや時間の制限の設定
            if (verticalKey > 0 && jumpPos + jumpHeight > transform.position.y && jumpLimitTime > jumpTime)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                player.IsJump = false;
                jumpTime = 0.0f;
            }
        }

        return ySpeed;
    }
}
