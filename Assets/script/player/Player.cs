using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("接地判定")]
    public GroundCheck ground;

    #region//プライベート変数
    //プレイヤーのコンポーネント群
    private CapsuleCollider2D capcol = null;
    private SpriteRenderer sr = null;

    //プレーヤーと接触するタグ群
    private string enemyTag = "enemy";
    private string itemtag = "item";

    //プレイヤーの状態を表すパラメータ
    private bool isJump = false;        //ジャンプ状態
    private bool isRun = false;         //ラン状態
    private bool isDown = false;        //ダウン状態 
    private bool isContinue = false;    //コンテニュー状態
    private bool isGround = false;      //接地状態
    
    private float continueTime = 0.0f;  //明滅処理用
    private float blinkTime = 0.0f;     //明滅処理用
    #endregion

    //ジャンプ状態 get,set
    public bool IsJump
    {
        get { return isJump; }
        set { isJump = value; }
    }

    //ラン状態 get,set
    public bool IsRun
    {
        get { return isRun; }
        set { isRun = value; }
    }

    //ダウン状態 get
    public bool IsDown
    {
        get { return isDown; }
    }

    //接地状態 get
    public bool IsGround
    {
        get { return isGround; }
    }

    // Use this for initialization
    private void Start () {
        //コンポーネントのインスタンス取得
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }
	
    private void Update()
    {
        
        //もしコンテニュー状態なら
        if (isContinue == true)
        {
            //復帰した際の明滅処理
            DamageCheck();
        }
        
    }

	// Update is called once per frame
	private void FixedUpdate () {


        //もしダウン状態でなければ
        if (isDown == false)
        {
            //接地判定の取得
            isGround = ground.IsGround();

        }
       
    }

    /// <summary>
    /// ダメージを受けた時の明滅処理。
    /// </summary>
    private void DamageCheck()
    {
        
        //明滅　消えているときに戻る
        if (blinkTime > 0.2f)
        {
            sr.enabled = true;
            blinkTime = 0.0f;
        }
        //明滅　消える処理
        else if (blinkTime > 0.1f)
        {
            sr.enabled = false;
        }
        
        //1秒たったら明滅終わり
        if (continueTime > 1.0f)
        {
            //パラメータ初期化
            isContinue = false;
            blinkTime = 0.0f;
            continueTime = 0.0f;
            sr.enabled = true;
            
        }
        else
        {
            //タイム加算
            blinkTime += Time.deltaTime;
            continueTime += Time.deltaTime;
        }
        
    }
    
    /// <summary>
    /// コンティニューする(パラメータの初期化)
    /// </summary>
    public void ContinuePlayer()
    {
        isDown = false;
        isJump = false;
        isRun = false;
        isContinue = true;

    }

    /// <summary>
    /// ダメージ関数
    /// </summary>
    private void Damage()
    {
        //ダウン状態でなければ
        if (isDown == false)
        {
            //残機を一つ減らす
            isDown = true;
            --GManager.instance.HeartNum;
        }
    }

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーがenemyと衝突
        if (collision.collider.tag == enemyTag)
        {
            //ダメージ関数
            Damage();
        }
    }
    #endregion

    #region//アイテム取得判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ////プレイヤーがitemと衝突
        if (collision.tag == itemtag)
        {
            //衝突したオブジェクトにセットされたオブジェクトから、IEffectitemを呼ぶ
            var itemTarget = collision.gameObject.GetComponent<IEffectitem>();

            //衝突したオブジェクトにIEffectitemがあれば
            if (itemTarget != null)
            {
                //衝突したオブジェクトのGetItem関数を呼ぶ
                itemTarget.GetItem();
            }


        }
    }
    #endregion
}
