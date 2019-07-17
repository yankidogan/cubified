using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeBehaivour : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Camera;
    public GameObject WallCube;
    public GameObject Triggers;
    public GameObject GameMaster;
    public GameObject Counter;
    public int velocity;
    public int playerCubes;
    int wallCubes;
    int offset;
    int LevelCounter;
    public Canvas GOCanvas;

    void Start()
    {
        playerCubes = 0;
        wallCubes = 1;
        offset = 4;
        LevelCounter = 0;
        velocity = 2;
        Counter.GetComponent<TextMesh>().text = LevelCounter.ToString();
    }

    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * velocity);
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals("CreateTrigger"))
        {
            LevelCounter++;
            Counter.GetComponent<TextMesh>().text = LevelCounter.ToString();
            GameMaster.gameObject.GetComponent<GameMasterScript>().reset = true;
            playerCubes++;
            if (playerCubes == (wallCubes*wallCubes))
            {
                playerCubes = 0;
                wallCubes = wallCubes + 2;
                offset = offset - 1;
                SpawnWall();
            }
            else
            {
                SpawnObject(playerCubes);
                SpawnWall();
            }
        }

        if (collision.gameObject.name.Equals("CameraTrigger1"))
        {
            Camera.gameObject.GetComponent<CameraMove>().isMoveToTarget = true;
        }

        if (collision.gameObject.name.Equals("CameraTrigger2"))
        {
            Camera.gameObject.GetComponent<CameraMove>().isMoveToStart = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Destroyable"))
        {
            velocity = 0;
            GOCanvas.gameObject.SetActive(true);
        }
    }

    private void SpawnObject (int Counter)
    {
        float[,] AvPoints = new float[wallCubes, wallCubes];
        for(int x=0; x<wallCubes; x++)
        {
            for(int y=0; y<wallCubes; y++)
            {
                AvPoints[x, y] = 0;
            }
        }
        int midPoint = (wallCubes - 1) / 2;

        AvPoints[midPoint, midPoint] = 2;
        AvPoints[(midPoint+1), midPoint] = 1;
        AvPoints[(midPoint-1), midPoint] = 1;
        AvPoints[midPoint, (midPoint+1)] = 1;
        AvPoints[midPoint, (midPoint-1)] = 1;

        System.Random rnd = new System.Random();

        for (int i = 0; i < Counter; i++)
        {
            int x = rnd.Next(0, wallCubes);
            int y = rnd.Next(0, wallCubes);
            while(AvPoints[x, y] != 1)
            {
                x = rnd.Next(0, wallCubes);
                y = rnd.Next(0, wallCubes);
            }
            AvPoints[x, y] = 2;

            if ((y != 0))
            {
                if (AvPoints[x, y - 1] != 2)
                {
                    AvPoints[x, y - 1] = 1;
                }
            }

            if ((y != (wallCubes - 1)))
            {
                if ((AvPoints[x, y + 1] != 2))
                {
                    AvPoints[x, y + 1] = 1;
                }
            }

            if ((x != 0))
            {
                if (AvPoints[x - 1, y] != 2)
                {
                    AvPoints[x - 1, y] = 1;
                }
            }

            if ((x != (wallCubes - 1)))
            {
                if ((AvPoints[x + 1, y] != 2))
                {
                    AvPoints[x + 1, y] = 1;
                }
            }

            GameObject CubeClone = (GameObject)Instantiate(Cube, new Vector3((x + offset), (y + offset), transform.position.z), transform.rotation);
            CubeClone.transform.parent = gameObject.transform;
        }
    }

    private void SpawnWall()
    {
        for(int x = 0; x < wallCubes; x++)
        {
            for(int y = 0; y < wallCubes; y++)
            {
                GameObject WallClone = (GameObject)Instantiate(WallCube, new Vector3((x + offset), (y + offset), transform.position.z + 20), transform.rotation);
                
            }
        }
        GameObject TriggerClone = (GameObject)Instantiate(Triggers, new Vector3(0, 0, transform.position.z + 20), transform.rotation);
    }
}
