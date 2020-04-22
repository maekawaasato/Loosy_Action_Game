using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_ballet : MonoBehaviour
{
    [Header("弾丸の速度")]
    public float speed;

    //balletのコンポーネント群
    protected SpriteRenderer sr = null;
    protected Rigidbody2D rb = null;

    private GameObject player;      //playerオブジェクト

    //座標系パラメータ
    private Vector3 playerPosition; //playerの座標
    private Vector3 balletPosition; //balletの座標
    protected float dis = 0.0f;     //playerとballetの距離

    // Start is called before the first frame update
    private void Start()
    {
        //このオブジェクトに関する初期化
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        balletPosition = this.transform.position;

        //Player情報の取得
        if(GameObject.Find("player") != null)
        {
            player = GameObject.Find("player");
            playerPosition = player.transform.position;

            //距離計算
            dis = playerPosition.x - balletPosition.x;
        }
        
    }

    private void FixedUpdate()
    {
        //移動関数
        Move();

    }

    /// <summary>
    /// 移動関数
    /// </summary>
    protected virtual void Move()
    {
        float xSpeed = 0.0f;//横軸の速さ

        //見えている間は弾を加速
        if (sr.isVisible == true)
        {
            //オブジェクトにplayerの方に向かって速度を与える
            if (dis < 0.0f)
            {
                xSpeed = -speed;
            }
            else
            {
                xSpeed = speed;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }

        rb.velocity = new Vector2(xSpeed, 0.0f);
    }


}
