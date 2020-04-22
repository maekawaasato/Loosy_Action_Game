using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageCtrl : MonoBehaviour
{
    #region//パブリック変数
    [Header("プレイヤーゲームオブジェクト")]
    public GameObject playerObj;
    [Header("コンティニュー位置")]
    public GameObject[] continuePoint;
    [Header("ゲームオーバー")]
    public GameObject GameOverObj;
    #endregion

    
    private Player player;                      //Playerのplayerスクリプト
    private PlayerAnimator playeranimator;      //PlayerのPlayerAnimatorスクリプト
    private int nowContinueNum = 0;             //現時点のコンテニューポイントを保持

    // Start is called before the first frame update
    private void Start()
    {
        //プレイヤーの位置初期化
        if (playerObj != null && continuePoint != null && continuePoint.Length > 0)
        {
            playerObj.transform.position = continuePoint[0].transform.position;
            player = playerObj.GetComponent<Player>();
            playeranimator = playerObj.GetComponent<PlayerAnimator>();
        }

        //ゲームオーバーのオブジェクトを非表示に
        if (GameOverObj != null)
        {
            GameOverObj.SetActive(false);
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (GManager.instance != null)
        {
            //ゲームオーバーになったらゲームオーバーのゲームオブジェクト表示
            if (GManager.instance.IsGameOver == true)
            {
                GameOverObj.SetActive(true);
            }
            //コンティニュー処理
            else
            {   //プレイヤーのダウンアニメーションが終わったらコンテニューする
                if (playeranimator.IsDownAnimEnd() == true)
                {
                    //プレイヤーをコンテニューポイントへ戻す
                    PlayerSetContinuePoint();
                }
            }

            //ステージクリア処理
            if (GManager.instance.IsClear == true)
            {
                //ステージ情報更新
                SetNextStage();
            }
        }
    }

    //現コンテニューポイントset,get
    //セッター制限:0以上、コンテニューポイント数未満
    public int NowContinueNum
    {
        get { return nowContinueNum; } 
        set                         
        {   
            if (0 <= value && value < continuePoint.Length)
            {
                nowContinueNum = value;
            }
        }
    }

    /// <summary>
    /// プレイヤーをコンティニューポイントへ移動する
    /// </summary>
    public void PlayerSetContinuePoint()
    {
        if(playerObj != null && player != null)
        {
            playerObj.transform.position = continuePoint[nowContinueNum].transform.position;
            player.ContinuePlayer();
        }
        
    }

    /// <summary>
    /// 最初から始める(リトライボタンが押されたら)
    /// </summary>
    public void Retry()
    {
        //GManagerの初期化とシーン1への移行
        if(GManager.instance != null) GManager.instance.RetryGame();
        SceneManager.LoadScene("stage" + 1);
        nowContinueNum = 0;               
    }


    /// <summary>
    /// ステージを切り替える。
    /// </summary>
    private void ChangeScene(int nextStageNumber)
    {
        
        if (GManager.instance != null && nextStageNumber >= GManager.instance.MaxStageNum)
        {
            SceneManager.LoadScene("clear");
        }
        else
        {
            //GManagerのステージ数更新 コンテニューポイントリセット
            if(GManager.instance != null) GManager.instance.StageNum = nextStageNumber;
            SceneManager.LoadScene("stage" + nextStageNumber);
            nowContinueNum = 0;
        }
    }
    /// <summary>
    /// ステージ情報更新
    /// </summary>
    private void SetNextStage()
    {
        if(GManager.instance != null)
        {
            GManager.instance.StageNum = GManager.instance.StageNum + 1;
            GManager.instance.IsClear = false;
            ChangeScene(GManager.instance.StageNum);
        }
       
    }
}
