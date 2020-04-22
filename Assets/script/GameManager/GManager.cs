using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
   
    #region//プライベート変数
    //パラメータ群
    private const int defaultHeartNum = 5;  //デフォルトのハート数
    private const int maxStageNum = 4;      //最大ステージ数
    private int score = 0;                  //スコア(得点)
    private int stageNum = 1;               //現ステージ数
    private int heartNum = 5;               //現ハート(残機)数
    #endregion

    #region//パブリック変数
    //ゲームマネージャーのインスタンス
    public static GManager instance = null;

    //ゲームフラグ群
    private bool isGameOver = false;     //ゲームオーバーフラグ
    private bool isClear = false;        //ステージクリアフラグ
    #endregion

    //ゲームマネージャーはシングルトン
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    private void Update()
    {
        //ゲームオーバー判定
        if (heartNum < 0)
        {
            isGameOver = true;
        }
    }

    //スコアset,get
    //set制限:0以上
    public int Score
    {
        get { return score; }       
        set {                       
                if(0 <= value)
                {
                    score = value;
                }
            }      
    }

    //ステージ数set,get
    //set制限:0より大、最大ステージ数以下
    public int StageNum
    {       
        get { return stageNum; }    
        set {                       
                if(0 < value && value <= maxStageNum)
                {
                    stageNum = value;
                }
        }   
    }

    //ハート(残機)数set,get
    //セッター制限:最大ハート(残機)数以下
    public int HeartNum
    {
        get { return heartNum; }                                
        set{                        
                if (value <= defaultHeartNum)
                {
                    heartNum = value;
                }
            }
    }
    
    //最大ステージ数get
    public int MaxStageNum
    {
        get { return maxStageNum; }
    }

    //クリアフラグ get,set
    public bool IsClear
    {
        get { return isClear; }
        set { isClear = value; }
    }

    //クリアフラグ get,set
    public bool IsGameOver
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }

    /// <summary>
    /// 最初から始める時の処理
    /// </summary>
    public void RetryGame()
    {
        isGameOver = false;             //ゲームオーバーフラグをもどす
        heartNum = defaultHeartNum;     //現ハート(残機)数をデフォルトのハート数に設定する
        score = 0;                      //スコアを０に初期化する
        stageNum = 1;                   //ステージ1を設定
        
    }

}
