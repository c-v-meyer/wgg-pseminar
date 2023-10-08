using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float speed_factor;
    public float speed_start;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * (speed_factor * (Time.timeSinceLevelLoad * Time.timeSinceLevelLoad) + speed_start) * Time.deltaTime;
    }
}
