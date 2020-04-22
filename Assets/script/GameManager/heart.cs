using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heart : MonoBehaviour
{
    private Text heartText;
    private int oldHeartNum;

    // Start is called before the first frame update
    private void Start()
    {
        heartText = GetComponent<Text>();

        if (heartText != null && GManager.instance != null)
        {
            //ハート(体力)数に関するデータの初期化
            SetData();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (heartText != null && GManager.instance != null)
        {
            //ハート(体力)数が更新されたら表記の更新を行う
            if (oldHeartNum != GManager.instance.HeartNum)
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
        heartText.text = "× " + GManager.instance.HeartNum.ToString();
        oldHeartNum = GManager.instance.HeartNum;
    }
}
