using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class MegaControl : MonoBehaviour
{
    public GameObject spawner;
    public GameObject liveSpawner;
    public RawImage menu;
    public RawImage gameOver;
    public Button play;
    public Button retry;
    public GameObject playObject;
    public GameObject retryObject;
    public RawImage score;
    public RawImage best;
    public TMP_Text scoreText;
    public TMP_Text bestText;
    public GameObject phoneHitbox;
    public int bestScore;
    private bool wait;
    // Start is called before the first frame update
    void Start()
    {
        menu.enabled = true;
        play.onClick.AddListener(onPlay);
        bestScore = 0;
        retry.onClick.AddListener(onRetry);
        retryObject.SetActive(false);
        wait = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((phoneHitbox.GetComponent<CameraCollision>().hasCollided == true) && wait == false)
        {
            AudioSource temp = GetComponent<AudioSource>();
            temp.Play();
            wait = true;
            Destroy(liveSpawner);
            score.enabled = false;
            if (int.Parse(scoreText.text) > bestScore)
            {
                bestScore = int.Parse(scoreText.text);
            }
            scoreText.enabled = false;
            bestText.text = bestScore.ToString();
            gameOver.enabled = true;
            best.enabled = true;
            bestText.enabled = true;
            retryObject.SetActive(true);
        }
    }

    void onPlay()
    {
        menu.enabled = false;
        Instantiate(spawner);
        liveSpawner = GameObject.Find("SpawnManager(Clone)");
        playObject.SetActive(false);
        score.enabled = true;
        scoreText.enabled = true;
        scoreText.text = "0";
    }

    void onRetry()
    {
        Instantiate(spawner);
        liveSpawner = GameObject.Find("SpawnManager(Clone)");
        best.enabled = false;
        bestText.enabled = false;
        retryObject.SetActive(false);
        gameOver.enabled = false;
        score.enabled = true;
        scoreText.enabled = true;
        scoreText.GetComponent<ScoreController>().score = 0;
        scoreText.text = "0";
        phoneHitbox.GetComponent<CameraCollision>().hasCollided = false;
        wait = false;
    }

}
