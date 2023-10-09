using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksScript : MonoBehaviour
{
    public float speed; // The desired speed of the object

    public float minY = -25f;

    public ParticleEffect particleEffect;

    private Rigidbody2D rb;
    [SerializeField] private string key;
    private float spposition;
    private bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        minY = -25f;
        speed = GameManagerRhythm.Instance.getSpeed();
        particleEffect = FindObjectOfType<ParticleEffect>();
        rb = GetComponent<Rigidbody2D>();
        // Get the current velocity of the object
        Vector2 velocity = rb.velocity;

        // Set the desired speed
        velocity.y = speed * -1;

        // Apply the new velocity to the object
        rb.velocity = velocity;
        GameObject attachedGameObject = gameObject;
        
        switch (attachedGameObject.name)
        {
            case "Circle 1(Clone)":
                key = "First Button";
                spposition = -3f;
                break;
            case "Circle 2(Clone)":
                key = "Second Button";
                spposition = -1f;
                break;
            case "Circle 3(Clone)":
                key = "Third Button";
                spposition = 1f;
                break;
            case "Circle 4(Clone)":
                key = "Fourth Button";
                spposition = 3f;
                break;
            default:
                Debug.Log("Something went wrong " + attachedGameObject.name);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -4.5f&&!clicked)
        {
            GameManagerRhythm.Instance.ResetCombo();
            Destroy(gameObject);
        }
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
        float diff = objY + 3.5f;
        
        if (diff >= -0.75f && diff <= 0.75f)
        {
            if(diff >= -0.75f && diff < -0.55f)
            {
                GameManagerRhythm.Instance.IncreaseScore(1);
                particleEffect.PlayParticleEffect(5, spposition);
            }
            else if (diff >= -0.55f && diff < -0.25f)
            {
                GameManagerRhythm.Instance.IncreaseScore(3);
                particleEffect.PlayParticleEffect(4, spposition);
            }
            else if (diff >= -0.25f && diff <= 0.25f)
            {
                GameManagerRhythm.Instance.IncreaseScore(5);
                particleEffect.PlayParticleEffect(3, spposition);
            }
            else if (diff > 0.25f && diff <= 0.55f)
            {
                GameManagerRhythm.Instance.IncreaseScore(3);
                particleEffect.PlayParticleEffect(2, spposition);
            }
            else if (diff > 0.55f && diff <= 0.75f)
            {
                GameManagerRhythm.Instance.IncreaseScore(1);
                particleEffect.PlayParticleEffect(1, spposition);
            }

            GameManagerRhythm.Instance.IncreaseCombo(1);
            Renderer renderer = GetComponent<Renderer>();
            Material material = renderer.material;

            Color originalColor = material.color;
            Color darkerColor = originalColor * 0.8f; // Reduce brightness by multiplying with a factor

            material.color = darkerColor;
            clicked = true;
        }
    }
}
