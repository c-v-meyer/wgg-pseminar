using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject paper;
    public DataManager dataManager;
    public Paper_Schnitt paperschnitt;
    public PaperMove papermove;
    public GameObject GameOverCanvas;
    public GameObject newpaper;


    // Start is called before the first frame update
    void Start()
    {
        dataManager = FindObjectOfType<DataManager>();
        paperschnitt = FindObjectOfType<Paper_Schnitt>();
        papermove = FindObjectOfType<PaperMove>();


        dataManager.setDirection(1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        //Random Number 1-4; 1 left, 2 up, 3 right, 4 bottom

        

        switch(Random.Range(1, 5))
        {
            case 1:
                dataManager.setDirection(1);
                newpaper = Instantiate(paper, new Vector3 (-7f, paperschnitt.getyPosition(), 0f), Quaternion.identity);
            break;

            case 2:
                dataManager.setDirection(2);
                newpaper = Instantiate(paper, new Vector3 (paperschnitt.getxPosition(), 8f, 0f) , Quaternion.identity);
            break;

            case 3:
                dataManager.setDirection(3);
                newpaper = Instantiate(paper, new Vector3 (7f, paperschnitt.getyPosition(), 0f) , Quaternion.identity);
            break;

            case 4:
                dataManager.setDirection(4);
                newpaper = Instantiate(paper, new Vector3 (paperschnitt.getxPosition(), -8f, 0f) , Quaternion.identity);
            break;
        }
    }
}
