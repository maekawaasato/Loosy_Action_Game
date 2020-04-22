using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour, IEffectitem
{
    /// <summary>
    /// オブジェクト取得関数
    /// </summary>
    public void GetItem()
    {
        if (GManager.instance != null)
        {
            //現在のハートが4以下なら回復
            if (GManager.instance.HeartNum < 5)
            {
                GManager.instance.HeartNum = GManager.instance.HeartNum + 1;
                Destroy(this.gameObject);
            }
        }
    }    
}
