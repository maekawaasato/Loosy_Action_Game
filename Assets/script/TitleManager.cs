using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleManager : MonoBehaviour {

    //スタートボタンが押されたら
    public void PressStart()
    {
        Debug.Log("Go Next Scene!");
        SceneManager.LoadScene("stage1");
    }
}
