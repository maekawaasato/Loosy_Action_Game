using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePoint : MonoBehaviour
{
    #region//パブリック変数
    [Header("コンティニュー番号")]
    public int continueNum;
    [Header("プレイヤー判定")]
    public playerTriggerIn trigger;
    [Header("スピード")]
    public float speed = 3.0f;
    [Header("動く幅")]
    public float moveDis = 3.0f;
    [Header("ステージコントローラー")]
    public stageCtrl stageCtrl;
    #endregion

    #region//プライベート変数
    private bool on = false;        //プレイヤー取得フラグ
    private float kakudo = 0.0f;    //演出用
    private Vector3 defaultPos;     //オブジェクトデフォルト座標
    #endregion

    private void Start()
    {
        defaultPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        //プレイヤーが範囲内に入った
        if (trigger.IsPlayerIn() == true)
        {
            //コンテニューポイント更新
            if(stageCtrl != null){
                stageCtrl.NowContinueNum = continueNum;
                on = true;
            }
            
        }

        //コンテニューポイント取得処理
        
        if (on == true)
        {
            //コンテニューポイント取得演出関数
            GetontinuePoint();

        }
        
    }
    /// <summary>
    ///コンテニューポイント取得演出関数
    /// </summary>
    private void GetontinuePoint()
    {
        
        if (kakudo < 180.0f)
        {
            //sinカーブで振動させる(角度をラジアンに)
            transform.position = defaultPos + Vector3.up * moveDis * Mathf.Sin(kakudo * Mathf.Deg2Rad);
            kakudo += 180.0f * Time.deltaTime * speed;
           
        }
        else
        {
            gameObject.SetActive(false);
            on = false;
        }
    }
}