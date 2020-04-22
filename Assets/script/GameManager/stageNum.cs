using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageNum : MonoBehaviour
{
    private Text stageText;
    private int oldStageNum;

    // Start is called before the first frame update
    private void Start()
    {
        stageText = GetComponent<Text>();

        if (stageText != null && GManager.instance != null)
        {
            //ステージ数に関するデータの初期化
            SetData();
        }
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (stageText != null && GManager.instance != null)
        {
            // ステージ数が更新されたら表記の更新をおこなう
            if (oldStageNum != GManager.instance.StageNum)
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
        stageText.text = "Stage " + GManager.instance.StageNum.ToString();
        oldStageNum = GManager.instance.StageNum;
    }

}
