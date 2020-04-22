using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour, IEffectitem
{
    [Header("加算スコア")]
    public int myScore;

    /// <summary>
    /// オブジェクト取得関数
    /// </summary>
    public void GetItem()
    {
        if (GManager.instance != null)
        {
            GManager.instance.Score += myScore;
            Destroy(this.gameObject);
        }
    }
}
