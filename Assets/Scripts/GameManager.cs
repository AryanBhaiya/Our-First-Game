using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool isGameStarted;

    public GameObject platformSpawner;

    [Header("Score")]
    public Text scoreText;
    public Text bestText;
    public Text diamondText;
    public Text startText;

    int score = 0;
    int bestScore, totalDiamond, totalStar;
    bool countScore;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted )
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    }

    public void GameStart()
    {
        isGameStarted = true;
        countScore = true;
        StartCoroutine(UpdateScore());
        platformSpawner.SetActive(true);
    }

    public void GameOver()
    {
        countScore = false;
        platformSpawner.SetActive(false);
    }

    IEnumerator UpdateScore()
    {
        while(countScore)
        {
            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = score.ToString();
        }
        
    }
}

