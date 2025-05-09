using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMeneger : MonoBehaviour
{
    public static ScoreMeneger Instance;

    public TextMeshProUGUI scoreText;

    float score = 0;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void AddPoint()
    {
        score += 10;
        scoreText.text = "Score: " + score.ToString();
    }
}
