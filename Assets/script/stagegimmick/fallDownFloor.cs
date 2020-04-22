using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallDownFloor : MonoBehaviour
{
    #region//パブリック変数
    [Header("プレイヤーの判定をするスクリプト")]
    public playerTriggerIn trigger;
    [Header("振動幅")]
    public float vibrationWidth = 0.05f;
    [Header("振動速度")]
    public float vibrationSpeed = 30.0f;
    [Header("落ちるまでの時間")]
    public float fallTime = 1.0f;
    [Header("落ちていく速さ")]
    public float fallSpeed = 10.0f;
    [Header("落ちてから戻ってくる時間")]
    public float returnTime = 5.0f;
    #endregion

    #region//プライベート変数
    //オブジェクトの状態を表す変数
    private bool isOn;              //プレイヤーが乗っているかを示す
    private bool isFall;            //オブジェクトが落下中か示す
    private bool isReturn;          //オブジェクトが再生中か示す

    //オブジェクトのコンポーネント群
    private BoxCollider2D col;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    //位置や速度に関するパラメータ
    private Vector3 floorDefaultPos;    //デフォルト座標
    private Vector2 fallVelocity;       //落下速度

    //時間に関するパラメータ
    private float timer = 0.0f;
    private float fallingTimer = 0.0f;
    private float returnTimer = 0.0f;
    private float blinkTimer = 0.0f;
    #endregion

    private void Start()
    {
        //コンポーネントのインスタンス取得
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        //パラメータ初期化
        fallVelocity = new Vector2(0, -fallSpeed);
        floorDefaultPos = this.transform.position;
      
    }

    private void Update()
    {
        //プレイヤーが1回でも乗ったらフラグをオンに
        if (trigger !=null && trigger.IsPlayerIn() == true && col.enabled == true)
        {
            isOn = true;
        }

        //プレイヤーがのってから落ちるまでの間
        if (isOn == true && isFall == false)
        {
            //オブジェクトの初期動作
            MoveDown();
            
        }

        //一定時間たつと明滅して戻ってくる
        if (isReturn == true)
        {
            //明滅処理
            Damageshow();
        }
    }

    private void FixedUpdate()
    {
        //落下中
        if (isFall == true)
        {
            FallDown();
        }
    }

    /// <summary>
    /// 初期動作関数
    /// </summary>
    private void MoveDown()
    {
        //震動する(transform sinは正弦波-1~1) 
        this.transform.position = floorDefaultPos + new Vector3(Mathf.Sin(timer * vibrationSpeed) * vibrationWidth, 0, 0);

        //一定時間たったら落ちる
        if (timer > fallTime)
        {
            isFall = true;
            isOn = false;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
    /// <summary>
    /// 明滅処理用関数
    /// </summary>
    private void Damageshow()
    {
        //明滅　ついている時に戻る
        if (blinkTimer > 0.2f)
        {
            sr.enabled = true;
            blinkTimer = 0.0f;
        }
        //明滅　消えているとき
        else if (blinkTimer > 0.1f)
        {
            sr.enabled = false;
        }
        
        //1秒たったら明滅終わり
        if (returnTimer > 1.0f)
        {
            isReturn = false;
            blinkTimer = 0.0f;
            returnTimer = 0.0f;
            sr.enabled = true;
            col.enabled = true;
        }
        else
        {
            blinkTimer += Time.deltaTime;
            returnTimer += Time.deltaTime;
        }
    }

    /// <summary>
    /// 落下中の動作関数
    /// </summary>
    private void FallDown()
    {
        rb.velocity = fallVelocity;

        //一定時間たつと元の位置に戻る
        if (fallingTimer > fallTime)
        {
            isReturn = true;
            this.transform.position = floorDefaultPos;
            rb.velocity = Vector2.zero;
            isFall = false;
            col.enabled = false;
            timer = 0.0f;
            fallingTimer = 0.0f;
            
        }
        else
        {
            fallingTimer += Time.deltaTime;
        }
    }
}
