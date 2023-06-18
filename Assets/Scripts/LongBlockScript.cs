using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBlockScript : MonoBehaviour
{
    public float speed; // The desired speed of the object

    public float minY = -5f;

    public ParticleEffect particleEffect;
    public GameObject square;
    public GameObject secCircle;

    private Rigidbody2D rb;
    [SerializeField] private string key;
    private float spposition;
    [SerializeField] private float length;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameManager.Instance.getSpeed();
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
        squareTransform.localScale = new Vector3(1f, 1f, 1f);
        GameObject attachedGameObject = gameObject;
        secCircle.transform.localPosition = new Vector3(0, length, 0);
        square.transform.localScale = new Vector3(1f, length, 1f);


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
        if (transform.position.y < minY)
        {
            GameManager.Instance.ResetCombo();
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
        Debug.Log("diff is: " + diff + "    while objY is:" + objY);
        if (diff >= -0.75f && diff <= 0.75f)
        {
            if (diff >= -0.75f && diff < -0.55f)
            {
                GameManager.Instance.IncreaseScore(1);
                particleEffect.PlayParticleEffect(5, spposition);
            }
            else if (diff >= -0.55f && diff < -0.25f)
            {
                GameManager.Instance.IncreaseScore(3);
                particleEffect.PlayParticleEffect(4, spposition);
            }
            else if (diff >= -0.25f && diff <= 0.25f)
            {
                GameManager.Instance.IncreaseScore(5);
                particleEffect.PlayParticleEffect(3, spposition);
            }
            else if (diff > 0.25f && diff <= 0.55f)
            {
                GameManager.Instance.IncreaseScore(3);
                particleEffect.PlayParticleEffect(2, spposition);
            }
            else if (diff > 0.55f && diff <= 0.75f)
            {
                GameManager.Instance.IncreaseScore(1);
                particleEffect.PlayParticleEffect(1, spposition);
            }

            GameManager.Instance.IncreaseCombo(1);
            Destroy(gameObject);
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
