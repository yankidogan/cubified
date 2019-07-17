using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddCubeScript : MonoBehaviour
{
    public Canvas GOCanvas;
    public GameObject mainCube;

    void Start()
    {
        GOCanvas.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Destroyable"))
        {
            mainCube.gameObject.GetComponent<CubeBehaivour>().velocity = 0;
            GOCanvas.gameObject.SetActive(true);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
