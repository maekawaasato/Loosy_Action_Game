using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    private string groundTag = "Ground";//Groundタグ
    private bool isGroundEnter;         //グラウンド(地面)に入ったか
    private bool isGroundStay;          //グラウンド(地面)に入っているか
    private bool isGround = false;      //グラウンド状態(プレイヤーが地面についている)ことを示す


    /// <summary>
    /// 接地しているかどうかの判定をとる
    /// </summary>
    /// <returns><c>true</c>, 接地している, <c>false</c> 接地していない</returns>
    public bool IsGround()
    {

        if (isGroundEnter == true || isGroundStay == true)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        //フラグを戻す
        isGroundEnter = false;
        isGroundStay = false;
      
        return isGround;
    }


    #region//接地判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }

    }

    #endregion
}
