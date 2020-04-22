using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTriggerIn : MonoBehaviour
{
    private string playerTag = "Player";
    private bool isIn = false;

    /// <summary>
    /// プレイヤーが判定の範囲内にいるかどうか
    /// </summary>
  
    public bool IsPlayerIn()
    {
        return isIn;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isIn = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isIn = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isIn = false;
        }
    }
}