using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject circle1, circle2, circle3, circle4, circle1long, circle2long, circle3long, circle4long;
    public float beatInterval = 1f;
    [SerializeField] private float beat;
    private AudioSource audioSource;
    [SerializeField] private Vector3 spawnerPosition;
    // Start is called before the first frame update
    void Start()
    {
        beatInterval = 1/((GameManagerRhythm.Instance.getBPM()) / 60);
        beat = 0;
        spawnerPosition = new Vector3(1, (float)((8*beatInterval* GameManagerRhythm.Instance.getSpeed()) -3.5), 0);
        transform.position = spawnerPosition;
        SpawnRandomObject();
        InvokeRepeating("nextBeat", beatInterval, beatInterval);
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnRandomObject()
    {
        float length = 1;
        int randomNum = Random.Range(1, 5);
        if (randomNum > 4)
        {
            length =2*(GameManagerRhythm.Instance.getSpeed()*beatInterval+1);
        }
        
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
            case 5:
                Vector3 spawnPosition5 = new Vector3(-3, transform.position.y, transform.position.z);
                GameObject instantiatedObject1 = Instantiate(circle1long, spawnPosition5, transform.rotation);
                LongBlockScript longBlockScript1 = instantiatedObject1.GetComponent<LongBlockScript>();
                if (longBlockScript1 != null)
                {
                    longBlockScript1.setLength(length);
                }
                else
                {
                    Debug.LogWarning("LongBlockScript component not found on the instantiated object.");
                }
                break;
            case 6:
                Vector3 spawnPosition6 = new Vector3(-1, transform.position.y, transform.position.z);
                GameObject instantiatedObject2 = Instantiate(circle2long, spawnPosition6, transform.rotation);
                LongBlockScript longBlockScript2 = instantiatedObject2.GetComponent<LongBlockScript>();
                if (longBlockScript2 != null)
                {
                    longBlockScript2.setLength(length);
                }
                else
                {
                    Debug.LogWarning("LongBlockScript component not found on the instantiated object.");
                }
                break;
            case 7:
                Vector3 spawnPosition7 = new Vector3(1, transform.position.y, transform.position.z);
                GameObject instantiatedObject3 = Instantiate(circle3long, spawnPosition7, transform.rotation);
                LongBlockScript longBlockScript3 = instantiatedObject3.GetComponent<LongBlockScript>();
                if (longBlockScript3 != null)
                {
                    longBlockScript3.setLength(length);
                }
                else
                {
                    Debug.LogWarning("LongBlockScript component not found on the instantiated object.");
                }
                break;
            case 8:
                Vector3 spawnPosition8 = new Vector3(3, transform.position.y, transform.position.z);
                GameObject instantiatedObject4 = Instantiate(circle4long, spawnPosition8, transform.rotation);
                LongBlockScript longBlockScript4 = instantiatedObject4.GetComponent<LongBlockScript>();
                if (longBlockScript4 != null)
                {
                    longBlockScript4.setLength(length);
                }
                else
                {
                    Debug.LogWarning("LongBlockScript component not found on the instantiated object.");
                }
                break;
            default:
                Debug.LogError("Invalid random number");
                break;
        }
        
    }

    public void nextBeat()
    {
        beat++;
        SpawnRandomObject();
        audioSource.Play();
    }
}
