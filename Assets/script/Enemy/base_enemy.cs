using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class base_enemy : MonoBehaviour, IDamagable
{
    #region//インスペクターで設定する
    [Header("加算スコア")]
    public int myScore;
    [Header("体力")]
    public int myHp;
    #endregion

    #region//プライベート変数
    //オブジェクトのコンポーネント群
    protected Rigidbody2D rb = null;
    protected SpriteRenderer sr = null;
    protected Animator anim = null;
    private BoxCollider2D col = null;

    //オブジェクトの状態を表すパラメータ
    protected bool isDead = false;

    //オブジェクト破棄に使用
    private float deadTimer = 0.0f;
    #endregion

    // Start is called before the first frame update
    protected void Start()
    {
        //コンポーネントのインスタンス取得
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }


    /// <summary>
    /// オブジェクト破棄関数
    /// </summary>
    private void Dead()
    {

        //deadアニメーション再生、当たり判定をきる
        anim.SetBool("dead", true);
        rb.velocity = new Vector2(0, -3.5f);
        col.enabled = false;
        AddScore();
        
    }

    /// <summary>
    /// スコア加算関数
    /// </summary>
    private void AddScore()
    {
        
        if (GManager.instance != null)
        {
            GManager.instance.Score += myScore;
        }
    }

    /// <summary>
    /// オブジェクト破棄後関数
    /// </summary>
    protected void AfterDead()
    {
        //回転
        transform.Rotate(new Vector3(0, 0, 5));

        //2,0fたったらオブジェクト破棄
        if (deadTimer > 2.0f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            deadTimer += Time.deltaTime;
        }
    }


    /// <summary>
    /// ダメージ関数
    /// </summary>
    public void Damage(int value)
    {
        myHp -= value;

        //HPがなくなったら
        if (myHp <= 0)
        {
            isDead = true;
            Dead();

        }
    }
    /// <summary>
    /// 敵の種類に応じて行動方法を変更
    /// </summary>
    protected abstract void Action();

}