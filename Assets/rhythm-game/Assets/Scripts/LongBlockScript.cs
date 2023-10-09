using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBlockScript : MonoBehaviour
{
    public float speed; // The desired speed of the object

    public float minY = -25f;

    public ParticleEffect particleEffect;
    public GameObject square;
    public GameObject secCircle;
    public GameObject secSquare;

    private Rigidbody2D rb;
    [SerializeField] private string key;
    private float spposition;
    [SerializeField] private float length;
    private bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameManagerRhythm.Instance.getSpeed();
        particleEffect = FindObjectOfType<ParticleEffect>();
        rb = GetComponent<Rigidbody2D>();
        // Get the current velocity of the object
        Vector2 velocity = rb.velocity;

        // Set the desired speed
        velocity.y = speed * -1;

        // Apply the new velocity to the object
        rb.velocity = velocity;
        Transform squareTransform = square.transform;
        Transform secCircleTransform = secCircle.transform;
        Transform secSquareTransform = secSquare.transform;
        squareTransform.localScale = new Vector3(1f, 1f, 1f);
        GameObject attachedGameObject = gameObject;
        secCircle.transform.localPosition = new Vector3(0, length, 0);
        square.transform.localScale = new Vector3(1f, length, 1f);
        secSquare.transform.localScale = new Vector3(1f, 0, 1f);


        switch (attachedGameObject.name)
        {
            case "Circle 1 (long)(Clone)":
                key = "First Button";
                spposition = -3f;
                break;
            case "Circle 2 (long)(Clone)":
                key = "Second Button";
                spposition = -1f;
                break;
            case "Circle 3 (long)(Clone)":
                key = "Third Button";
                spposition = 1f;
                break;
            case "Circle 4 (long)(Clone)":
                key = "Fourth Button";
                spposition = 3f;
                break;
            default:
                Debug.Log("Something went wrong");
                break;
               
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y< -4.5f-length && !started)
        {
            //GameManager.Instance.ResetCombo();
        }
        if (transform.position.y < minY)
        {
            
            Destroy(gameObject);
        }
        if (Input.GetButtonDown(key))
        {

            CheckAndDeleteObject();

        }
        if (Input.GetButton(key)&& started)
        {
            if (transform.position.y < -3.5f&&transform.position.y>-3.5f-length)
            {
                //float underLine = (-3.5f - transform.position.y+1);
                //float overLine = length - underLine;
                //float underLinePosition =  underLine/2;
                //float overLinePosition = underLine + overLine/2;
                //square.transform.localPosition = new Vector3(square.transform.localPosition.x, underLinePosition, square.transform.localPosition.z);
                //square.transform.localScale = new Vector3(1f, underLine, 1f);
                //secSquare.transform.localPosition = new Vector3(secSquare.transform.localPosition.x, overLinePosition, secSquare.transform.localPosition.z);
                //secSquare.transform.localScale = new Vector3(1f, overLine, 1f);

            }

        }
        else 
        {
            started = false;
        }
    }
    private void CheckAndDeleteObject()
    {
        float objY = transform.position.y;
        float diff = objY + 3.5f;
        
        if (diff >= -0.75f && diff <= 0.75f)
        {
            if (diff >= -0.75f && diff < -0.55f)
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
            started = true;
            
            
        }
    }
    public void setLength(float newLength)
    {
        length = newLength;
        square.transform.localScale = new Vector3(1f, length, 1f);
        square.transform.localPosition = new Vector3(0, length/2, 0);
        Debug.Log(length.ToString() + square.transform.localScale.y.ToString());

    }
}
