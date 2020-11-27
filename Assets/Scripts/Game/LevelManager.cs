using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to generate platforms for player to jump on
public class LevelManager : MonoBehaviour
{
    public GameObject platformPrefab;

    [Header ("Level set up calibration")]
    [SerializeField]
    private int numberOfPlatforms;
    [SerializeField]
    private float levelWidth = 10f;
    [SerializeField]
    private float minY = 2f;
    [SerializeField]
    private float maxY = 1.5f;

    // loop through set amount of platforms
    // generate randomly sized platforms inbetween given parametres
    // instantiate platform prefabs accordinly
    void Start()
    {

        Vector3 spawnPoint = new Vector3();
        
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPoint.y += Random.Range(minY, maxY);
            spawnPoint.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
