using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper_Schnitt : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform spriteTransform;
    public SpriteRenderer paper;
    public GameManager gameManager;

    void Start()
    {
        spriteTransform = GetComponent<Transform>();
        gameManager = FindObjectOfType<GameManager>();
        paper = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //changes the xsize and xPosition after button press
    public bool moveAndResizeX(float xlocation, float xsize)
    {
        if(calculateDistance(xlocation, transform.position.x) > xsize)
        {
            return false;
        }

        //creates a factor for the downscaling of the SchnittPaper
        float scaledown = (xsize - calculateDistance(xlocation, transform.position.x)) / paper.bounds.size.x;

        Vector3 currentScale = transform.localScale;
        transform.localScale = new Vector3(currentScale.x * scaledown, currentScale.y, currentScale.z);

        newxPosition((xlocation + transform.position.x)/2);

        return true;
    }

    //changes the ysize and yPosition after button press
    public bool moveAndResizeY(float ylocation, float ysize)
    {
        if(calculateDistance(ylocation, transform.position.y) > ysize)
        {
            return false;
        }

        //creates a factor for the downscaling of the SchnittPaper
        float scaledown = (ysize - calculateDistance(ylocation, transform.position.y)) / paper.bounds.size.y;

        Vector3 currentScale = transform.localScale;
        transform.localScale = new Vector3(currentScale.x, currentScale.y * scaledown, currentScale.z);

        newyPosition((ylocation + transform.position.y)/2);

        return true;
    }

    public void newxPosition(float newxPosition)
    {
        transform.position = new Vector3(newxPosition, transform.position.y, 0f);
    }

    public void newyPosition(float newyPosition)
    {
        transform.position = new Vector3(transform.position.x, newyPosition, 0f);
    }

    public Vector3 getSize()
    {
        return transform.localScale;
    }

    public float getxPosition()
    {
        return transform.position.x;
    }

    public float getyPosition()
    {
        return transform.position.y;
    }
    
    public float calculateDistance(float value1, float value2)
    {
        if((value1 >= 0 && value2 >= 0) || (value1 <= 0 && value2 <= 0))
        {
            if(value1 > value2)
            {
                return (value1 - value2);
            }
            else
            {
                return (value2 - value1);
            }
        }
        else
        {
            return amount(value1) + amount(value2);
        }
        
        float amount(float value)
        {
            if(value <= 0)
            {
                return value * -1;
            }
            return value;
        }
    }
}
