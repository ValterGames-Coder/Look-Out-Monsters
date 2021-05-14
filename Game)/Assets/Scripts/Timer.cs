using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
public class Timer : MonoBehaviour
{
    public float startTime = 0f;
    public Text timerText, ScoreText, HighScoreText, text;
    public float score, highScore, starttimer;

    [SerializeField] private const string leaderBoard = "CgkIpYS97KMdEAIQAQ";
    bool yes = false;
    string texty;
    float textynum;

    public static Timer instance;

    private void Awake()
    {
        instance = this;
        highScore = PlayerPrefs.GetFloat("Save");
    }
    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(succes => {
            if(succes){
                Debug.Log("Connect!");
            }else{
                Debug.LogError("Not Connect");
            }
        });
        timerText.text = startTime.ToString("F1");
    }
    void Update()
    {
        starttimer -= Time.deltaTime;
        if(starttimer <= 0)
        {
            yes = true;
        }

        if(yes == true)
        {
            score = startTime;
            startTime += Time.deltaTime;
            Social.ReportScore((long)score, leaderBoard, (bool succes) => { });
        }
        HigeScore();
        timerText.text = startTime.ToString("F1");
        ScoreText.text = score.ToString("F1");
        HighScoreText.text = highScore.ToString("F1");
    }
    void HigeScore()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("Save", highScore);
        }
    }
}
