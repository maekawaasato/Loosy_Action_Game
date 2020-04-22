using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearItem : MonoBehaviour, IEffectitem
{
    /// <summary>
    /// オブジェクト取得関数
    /// </summary>
    public void GetItem()
    {
        if (GManager.instance != null)
        {
            Debug.Log("Go to next stage");
            GManager.instance.IsClear = true;
        }
    }
}
