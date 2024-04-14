using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text self;
    public int score;
    void Start()
    {
        self.enabled = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        self.text = score.ToString();
    }
}
