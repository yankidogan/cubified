using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    int DestroyCounter;
    public GameObject Cube;
    public bool reset;

    void Start()
    {
        DestroyCounter = 0;
        reset = false;
    }

    void Update()
    {
        if (reset)
        {
            DestroyCounter = 0;
            reset = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                int CubeCount = Cube.gameObject.GetComponent<CubeBehaivour>().playerCubes;
                if (hit.collider.gameObject.tag.Equals("Destroyable")&&(DestroyCounter<=CubeCount))
                {
                    DestroyCounter++;
                    Destroy(hit.collider.gameObject);
                }
            }
        }

    }
}
