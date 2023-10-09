using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePaperStack : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseScore()
    {
        score++;
        textMeshPro.text = score.ToString();
    }
}
