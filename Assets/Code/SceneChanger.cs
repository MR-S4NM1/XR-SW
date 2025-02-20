using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeSceneTo(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
