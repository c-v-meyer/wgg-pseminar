using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocity;
    public Color32 color;
    public SpriteRenderer paper;
    public Paper_Schnitt paperschnitt;
    public Spawner spawner;
    public DataManager dataManager;
    public ScorePaperStack score;
    public float borderLocationx;
    public float borderLocationy;
    public float velocityScale;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        paper = GetComponent<SpriteRenderer>();
        dataManager = FindObjectOfType<DataManager>();
        paperschnitt = FindObjectOfType<Paper_Schnitt>();
        spawner = FindObjectOfType<Spawner>();
        score = FindObjectOfType<ScorePaperStack>();
        gameManager = FindObjectOfType<GameManager>();

        transform.localScale = paperschnitt.getSize();

    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Return)) & Time.timeScale == 1)
        {
            switch(dataManager.getDirection())
            {
                case 1:
                    if(!paperschnitt.moveAndResizeX(transform.position.x, paper.bounds.size.x))
                    {
                        gameManager.GameOver();
                        return;
                    }
                    score.IncreaseScore();
                    Destroy(gameObject);
                    spawner.Spawn();
                break;

                case 2:
                    if(!paperschnitt.moveAndResizeY(transform.position.y, paper.bounds.size.y))
                    {
                        gameManager.GameOver();
                        return;
                    }
                    score.IncreaseScore();
                    Destroy(gameObject);
                    spawner.Spawn();
                break;

                case 3:
                    if(!paperschnitt.moveAndResizeX(transform.position.x, paper.bounds.size.x))
                    {
                        gameManager.GameOver();
                        return;
                    }
                    score.IncreaseScore();
                    Destroy(gameObject);
                    spawner.Spawn();
                break;

                case 4:
                    if(!paperschnitt.moveAndResizeY(transform.position.y, paper.bounds.size.y))
                    {
                        gameManager.GameOver();
                        return;
                    }
                    score.IncreaseScore();
                    Destroy(gameObject);
                    spawner.Spawn();
                break;
            }
        }

        switch(dataManager.getDirection())
        {
            case 1:
                rb.velocity = Vector3.right * velocity;
                if(amount(transform.position.x) > borderLocationx)
                {
                    dataManager.setDirection(3);
                    newxPosition(borderLocationx - 0.05f);
                    if(amount(velocity) < 60)
                    { 
                        velocity = (velocity*velocityScale);
                    }
                }
            break;


            case 2:
                rb.velocity = Vector3.down * velocity;
                if(amount(transform.position.y) > borderLocationy)
                {
                    dataManager.setDirection(4);
                    newyPosition(-borderLocationy + 0.05f);
                    if(amount(velocity) < 60)
                    {
                        
                        velocity = (velocity*velocityScale);
                    }
                }

            break;

            case 3:
                rb.velocity = Vector3.left * velocity;
                if(amount(transform.position.x) > borderLocationx)
                {
                    dataManager.setDirection(1);
                    newxPosition(-borderLocationx + 0.05f);
                    if(amount(velocity) < 60)
                    {
                        velocity = (velocity*velocityScale);
                    }
                }
            break;

            case 4:
                rb.velocity = Vector3.up * velocity;
                if(amount(transform.position.y) > borderLocationy)
                {
                    dataManager.setDirection(2);
                    newyPosition(borderLocationx - 0.05f);
                    if(amount(velocity) < 60)
                    {
                        
                        velocity = (velocity*velocityScale);
                    }
                }
            break;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision");
        
        if(velocity < 60 && velocity > -60)
        {
                
            velocity = -(velocity*2);
        }
        else
        {
            velocity = -velocity;
        }
    }

    float amount(float value)
    {
       if(value <= 0)
        {
            return value * -1;
        }
        return value;
    }

    public void newxPosition(float newxPosition)
    {
        transform.position = new Vector3(newxPosition, transform.position.y, 0f);
    }

    public void newyPosition(float newyPosition)
    {
        transform.position = new Vector3(transform.position.x, newyPosition, 0f);
    }
}
