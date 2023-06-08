using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksScript : MonoBehaviour
{
    public float speed = 5f; // The desired speed of the object

    public float minY = -10f;

    private Rigidbody2D rb;
    private string key;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Get the current velocity of the object
        Vector2 velocity = rb.velocity;

        // Set the desired speed
        velocity.y = speed * -1;

        // Apply the new velocity to the object
        rb.velocity = velocity;
        GameObject attachedGameObject = gameObject;
        Debug.Log("Attached GameObject: " + attachedGameObject.name);
        switch (attachedGameObject.name)
        {
            case "Circle 1(Clone)":
                key = "First Button";
                break;
            case "Circle 2(Clone)":
                key = "Second Button";
                break;
            case "Circle 3(Clone)":
                key = "Third Button";
                break;
            case "Circle 4(Clone)":
                key = "Fourth Button";
                break;
            default:
                Debug.Log("Something went wrong");
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
        if (Input.GetButtonDown(key))
        {
            
            CheckAndDeleteObject();

        }
    }

    private void CheckAndDeleteObject()
    {
        float objY = transform.position.y;
        if (objY >= -4.25f && objY <= -2.75f)
        {
            GameManager.Instance.IncreaseScore(1);
            Destroy(gameObject);
        }
    }
}
