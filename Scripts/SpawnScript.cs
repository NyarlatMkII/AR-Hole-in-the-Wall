using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject wallOne;
    public GameObject wallTwo;
    public GameObject wallThree;
    public GameObject wallFour;
    public GameObject wallFive;
    public GameObject wallSix;
    public GameObject wallSeven;
    private GameObject wallToSpawn;
    public float fTimer;
    private float tTimer;
    public float bTimer;
    private int numWallsTillSpeed;
    public int numWallsTotal;
    void Start()
    {
        bTimer = 0f;
        tTimer = fTimer;
        wallOne.GetComponent<MoveWalls>().speed = 1;
        wallTwo.GetComponent<MoveWalls>().speed = 1;
        wallThree.GetComponent<MoveWalls>().speed = 1;
        wallFour.GetComponent<MoveWalls>().speed = 1;
        wallFive.GetComponent<MoveWalls>().speed = 1;
        wallSix.GetComponent<MoveWalls>().speed = 1;
        wallSeven.GetComponent<MoveWalls>().speed = 1;
        numWallsTillSpeed = 0;
        numWallsTotal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bTimer -= Time.deltaTime;
        if (bTimer <= 0f)
        {
            if(numWallsTillSpeed == 0)
            {
                AudioSource temp = GetComponent<AudioSource>();
                temp.Play();
            }
            int wallDesign = Random.Range(0,7);
            if (wallDesign == 0)
            {
                wallToSpawn = wallOne;
            }
            else if (wallDesign == 1)
            {
                wallToSpawn = wallTwo;
            }
            else if (wallDesign == 2)
            {
                wallToSpawn = wallThree;
            }
            else if (wallDesign == 3)
            {
                wallToSpawn = wallFour;
            }
            else if (wallDesign == 4)
            {
                wallToSpawn = wallFive;
            }
            else if (wallDesign == 5)
            {
                wallToSpawn = wallSix;
            }
            else if (wallDesign == 6)
            {
                wallToSpawn = wallSeven;
            }
            int position = Random.Range(0,4);
            if (position == 0)
            {
                Instantiate(wallToSpawn, new Vector3(0, 0, 15.0f), Quaternion.Euler(new Vector3(-90,180,90)));
            }
            else if (position == 1)
            {
                Instantiate(wallToSpawn, new Vector3(0, 0, -15.0f), Quaternion.Euler(new Vector3(-90, 0, 90)));
            }
            else if (position == 2)
            {
                Instantiate(wallToSpawn, new Vector3(15.0f, 0, 0), Quaternion.Euler(new Vector3(-90, 270, 90)));
            }
            else if (position == 3)
            {
                Instantiate(wallToSpawn, new Vector3(-15.0f, 0, 0), Quaternion.Euler(new Vector3(-90, 90, 90)));
            }
            numWallsTillSpeed++;
            numWallsTotal++;
            if (numWallsTillSpeed >= 2)
            {
                numWallsTillSpeed = 0;
                wallOne.GetComponent<MoveWalls>().speed += wallOne.GetComponent<MoveWalls>().speed * 0.2f;
                wallTwo.GetComponent<MoveWalls>().speed += wallTwo.GetComponent<MoveWalls>().speed * 0.2f;
                wallThree.GetComponent<MoveWalls>().speed += wallThree.GetComponent<MoveWalls>().speed * 0.2f;
                wallFour.GetComponent<MoveWalls>().speed += wallFour.GetComponent<MoveWalls>().speed * 0.2f;
                wallFive.GetComponent<MoveWalls>().speed += wallFive.GetComponent<MoveWalls>().speed * 0.2f;
                wallSix.GetComponent<MoveWalls>().speed += wallSix.GetComponent<MoveWalls>().speed * 0.2f;
                wallSeven.GetComponent<MoveWalls>().speed += wallSeven.GetComponent<MoveWalls>().speed * 0.2f;
                tTimer = 18 / wallOne.GetComponent<MoveWalls>().speed;
            }
            bTimer = fTimer;
            fTimer = tTimer;
        }
    }
}
