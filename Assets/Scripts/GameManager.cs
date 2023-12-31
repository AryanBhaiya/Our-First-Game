using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool isGameStarted;

    public GameObject platformSpawner;

    [Header("GameOver")]
    public GameObject GameOverPanel;
    public Text lastScoreText;

    [Header("Score")]
    public Text scoreText;
    public Text bestText;
    public Text diamondText;
    public Text starText;

    int score = 0;
    int bestScore, totalDiamond, totalStar;
    bool countScore;

    [Header("ForPlayer")]
    public GameObject[] player;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {   //total rupees
        totalDiamond = PlayerPrefs.GetInt("totalDiamond");
        diamondText.text = totalDiamond.ToString();
        //total coins
        totalStar = PlayerPrefs.GetInt("totalStar");
        starText.text = totalStar.ToString();
        //bestscore
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestText.text = bestScore.ToString();
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
        GameOverPanel.SetActive(true);
        lastScoreText.text = score.ToString();
        countScore = false;
        platformSpawner.SetActive(false);

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
    }

    IEnumerator UpdateScore()
    {
        while(countScore)
        {
            yield return new WaitForSeconds(1f);
            score++;
            if (score > bestScore)
            {
                bestText.text = score.ToString();
            }
                
                scoreText.text = score.ToString();
            
            
        }
        
    }//updateScoer

    public void ReplayGame()
    {
        SceneManager.LoadScene("level");
    }

    public void GetStar()
    {
        int newStar = totalStar++;
        PlayerPrefs.SetInt("totalStar", newStar);
        starText.text = totalStar.ToString();
    }

    public void GetDiamond()
    {
        int newDiamond= totalDiamond++;
        PlayerPrefs.SetInt("totalDiamond", newDiamond);
        diamondText.text =  totalDiamond.ToString();
    }

}

