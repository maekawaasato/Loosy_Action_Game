using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [Header("魔法アイコン")]
    public GameObject originObject;

    private Player player = null;

    // Start is called before the first frame update
    private void Start()
    {
        //コンポーネントのインスタンス取得
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        //もしダウン状態でなければ
        if (player.IsDown == false)
        {
            //攻撃判定
            AttackCheck();

        }
        
    }

    /// <summary>
    /// 攻撃しているかどうかの判定をとる
    /// </summary>
    /// <returns><c>true</c>, 攻撃している, <c>false</c> 攻撃していない</returns>
    private void AttackCheck()
    {
        if (originObject != null)
        {
            //Xキーが押されたら右方向に弾を発射
            if (Input.GetKeyDown(KeyCode.X))
            {
                GameObject cloneObject = Instantiate(originObject, new Vector3(this.transform.position.x + 1.0f, this.transform.position.y, 0.0f), Quaternion.identity) as GameObject;

            } //Zキーが押されたら左方向に弾が発射
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                GameObject cloneObject = Instantiate(originObject, new Vector3(this.transform.position.x - 1.0f, this.transform.position.y, 0.0f), Quaternion.identity) as GameObject;

            }
        }

    }

}
