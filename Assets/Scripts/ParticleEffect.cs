using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    public GameObject orangeEffectPrefab, yellowEffectPrefab, greenEffectPrefab, lightBlueEffectPrefab, darkBlueEffectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayParticleEffect(int prefabNumber, float spposition)
    {
        Vector3 spawnposition = new Vector3(spposition, -3.5f, 0.3f);
        switch(prefabNumber)
        {
            case 1:
                Instantiate(darkBlueEffectPrefab, spawnposition, Quaternion.Euler(270f, 0f, 0f));
                break;
            case 2:
                Instantiate(lightBlueEffectPrefab, spawnposition, Quaternion.Euler(270f, 0f, 0f));
                break;
            case 3:
                Instantiate(greenEffectPrefab, spawnposition, Quaternion.Euler(270f, 0f, 0f));
                break;
            case 4:
                Instantiate(yellowEffectPrefab, spawnposition, Quaternion.Euler(270f, 0f, 0f));
                break;
            case 5:
                Instantiate(orangeEffectPrefab, spawnposition, Quaternion.Euler(270f, 0f, 0f));
                break;
            default:
                Instantiate(greenEffectPrefab, spawnposition, Quaternion.Euler(270f, 0f, 0f));
                break;
        }
            
        
    }
}
