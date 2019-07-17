using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeRotate : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(0, 1, 0, Space.Self);
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
