using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeActiveUGUI : MonoBehaviour
{
    #region//パブリック変数
    [Header("フェードスピード")]
    public float speed = 1.0f;
    [Header("上昇量")]
    public float moveDis = 10.0f;
    [Header("上昇時間")]
    public float moveTime = 1.0f;
    [Header("キャンバスグループ")]
    public CanvasGroup cg;
    [Header("プレイヤー判定")]
    public playerTriggerIn trigger;
    #endregion

    private Vector3 defaltPos;      //デフォルト座標
    private float timer = 0.0f;

    private void Start()
    {
        //初期化
        if(cg != null)
        {
            cg.alpha = 0.0f;
            defaltPos = cg.transform.position;
            cg.transform.position = defaltPos - Vector3.up * moveDis;
        }
       
    }

    
    private void Update()
    {
        
        //プレイヤーが範囲内に入った
        if (trigger.IsPlayerIn() == true)
        {
            //フェードイン関数
            FadeIn();
            
        }
        //プレイヤーが範囲内にいない
        else
        {
            //フェードアウト関数
            FadeOut();
        }
        
    }
    
    /// <summary>
    /// フェードイン関数
    /// </summary>
    private void FadeIn()
    {
        if (cg != null)
        {
            //上昇しながらフェードインする
            if (cg.transform.position.y < defaltPos.y || cg.alpha < 1.0f)
            {

                cg.alpha = timer / moveTime;
                cg.transform.position += Vector3.up * (moveDis / moveTime) * speed * Time.deltaTime;
                timer += speed * Time.deltaTime;
            }
            //フェードイン完了
            else
            {
                cg.alpha = 1.0f;
                cg.transform.position = defaltPos;
            }
        }
        
    }

    /// <summary>
    /// フェーアウト関数
    /// </summary>
    private void FadeOut()
    {
        if(cg != null)
        {
            //下降しながらフェードアウトする
            if (cg.transform.position.y > defaltPos.y - moveDis || cg.alpha > 0.0f)
            {
                cg.alpha = timer / moveTime;
                cg.transform.position -= Vector3.up * (moveDis / moveTime) * speed * Time.deltaTime;
                timer -= speed * Time.deltaTime;
            }
            //フェードアウト完了
            else
            {
                timer = 0.0f;
                cg.alpha = 0.0f;
                cg.transform.position = defaltPos - Vector3.up * moveDis;
            }
        }
        
    }
}