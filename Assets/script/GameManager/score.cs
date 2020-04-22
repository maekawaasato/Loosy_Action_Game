using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private Text scoreText;
    private int oldScore;

    // Start is called before the first frame update
    private void Start()
    {
        scoreText = GetComponent<Text>();

        if (scoreText != null && GManager.instance != null)
        {
            //スコアに関するデータの初期化
            SetData();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(scoreText != null && GManager.instance != null)
         {
            //スコアが更新されたら表記の更新を行う
            if (oldScore != GManager.instance.Score)
            {
                SetData();
            }
        }

    }

    /// <summary>
    /// データ設定関数
    /// </summary>
    private void SetData()
    {
        scoreText.text = "Score " + GManager.instance.Score.ToString();
        oldScore = GManager.instance.Score;
    }
}
