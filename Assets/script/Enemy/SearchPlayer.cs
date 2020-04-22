using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    
    private string playerTag = "Player";    //Playerタグ
    public bool isfall = false;             //落ちるフラグ
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Playerが視界に入ると落ちるフラグを立てる
        if (collision.tag == playerTag)
        {
            isfall = true;
        }
    }

}
