using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject circle1, circle2, circle3, circle4;
    public float spawnInterval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
        InvokeRepeating("SpawnObject", 0f, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnObject()
    {
        int randomNum = Random.Range(1, 5);
        
        switch (randomNum)
        {
            case 1:
                Vector3 spawnPosition1 = new Vector3(-3, transform.position.y, transform.position.z);
                Instantiate(circle1, spawnPosition1, transform.rotation);
                break;
            case 2:
                Vector3 spawnPosition2 = new Vector3(-1, transform.position.y, transform.position.z);
                Instantiate(circle2, spawnPosition2, transform.rotation);
                break;
            case 3:
                Vector3 spawnPosition3 = new Vector3(1, transform.position.y, transform.position.z);
                Instantiate(circle3, spawnPosition3, transform.rotation);
                break;
            case 4:
                Vector3 spawnPosition4 = new Vector3(3, transform.position.y, transform.position.z);
                Instantiate(circle4, spawnPosition4, transform.rotation);
                break;
            default:
                Debug.LogError("Invalid random number");
                break;
        }
        
    }
}
