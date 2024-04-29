using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManage : MonoBehaviour
{
  public void LoadNext()
    {
        int num = SceneManager.loadedSceneCount+1;
        SceneManager.LoadScene(num);
    }
    public void LoadLast()
    {
        int num= SceneManager.loadedSceneCount-1;
        SceneManager.LoadScene(num);
    }
}
