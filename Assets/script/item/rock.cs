using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour, IDamagable
{
    [Header("体力")]
    public int myHp;

    /// <summary>
    /// ダメージ関数
    /// </summary>
    public void Damage(int value)
    {
        myHp -= value;

        //HPがなくなったら
        if (myHp <= 0)
        {
            Destroy(this.gameObject);

        }
    }
}
