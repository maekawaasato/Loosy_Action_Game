using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    [Header("始点")]
    public GameObject defaltPoint;
    [Header("終点")]
    public GameObject endPoint;
    [Header("速さ")]
    public float speed = 1.0f;

    private Rigidbody2D rb = null;
    private bool returnPoint = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (defaltPoint != null && endPoint != null && rb != null)
        {
            //始点設定
            rb.position = defaltPoint.transform.position;
        }

    }

    private void FixedUpdate()
    {
        if (defaltPoint != null && endPoint != null && rb != null)
        {
            //通常進行
            if (returnPoint == false)
            {

                //オブジェクト移動(行き)
                Move(defaltPoint.transform.position);
            }
            //折返し進行
            else
            {
                //オブジェクト移動(帰り)
                Move(endPoint.transform.position);
            }
        }
    }
    
    /// <summary>
    /// 移動関数(targetPoint:目標点)
    /// </summary>
    private void Move(Vector3 targetPoint)
    {

        //目標ポイントとの誤差がわずかになるまで移動
        if (Vector2.Distance(this.transform.position, targetPoint) > 0.1f)
        {
            //現在地から次のポイントへのベクトルを作成
            Vector2 toVector = Vector2.MoveTowards(this.transform.position, targetPoint, speed * Time.deltaTime);

            //次のポイントへ移動
            rb.MovePosition(toVector);
        }
        else
        {
            //returnPointフラグを反転する
            returnPoint = !returnPoint;
        }
    }
    
}
