using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_zako3 : base_enemy
{
    #region//インスペクターで設定する
    [Header("魔法アイコン")]
    public GameObject originObject;
    #endregion

    #region//プライベート変数
    private GameObject player;          //playerオブジェクト
    private float timeElapsed = 0.0f;   //攻撃間隔
    private bool isAttack = false;      //攻撃状態を示す
    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        base.Start();
        if(GameObject.Find("player") != null)
        {
            player = GameObject.Find("player");
        }
     
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (sr.isVisible == true)
        {
            if(isDead == false)
            {
                //3.0f毎に弾を発射する
                if (timeElapsed >= 3.0f)
                {
                    isAttack = true;
                        
                }
                else
                {
                    timeElapsed += Time.deltaTime;
                        
                }

                if (isAttack == true)
                {
                    //行動関数
                   Action();
                        
                }

            }
            else
            {
                //行動関数
                AfterDead();
            }
        
        }
   
    }
    
    /// <summary>
    /// 行動関数
    /// </summary>
    protected override void Action()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;

            float dis = playerPosition.x - this.transform.position.x;

            if (originObject != null)
            {
                if (dis < 0.0f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    GameObject cloneObject = Instantiate(originObject, new Vector3(this.transform.position.x - 1.0f, this.transform.position.y + 1.0f, 0.0f), Quaternion.identity) as GameObject;

                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    GameObject cloneObject = Instantiate(originObject, new Vector3(this.transform.position.x + 1.0f, this.transform.position.y + 1.0f, 0.0f), Quaternion.identity) as GameObject;
                }
            }

        }

        timeElapsed = 0.0f;
        isAttack = false;
    }
}
