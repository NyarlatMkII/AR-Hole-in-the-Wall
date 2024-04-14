using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalls : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    private Vector3 startPos;
    public GameObject sText;
    private bool passed;
    void Start()
    {
        passed = false;
        startPos = transform.position;
        sText = GameObject.Find("Score Text");
    }

    // Update is called once per frame
    void Update()
    {
        var movement = speed * Time.deltaTime;
        transform.Translate(Vector3.left * movement);
        if ((Vector3.Distance(startPos, transform.position) >= 15f) && passed == false)
        {
            passed = true;
            sText.GetComponent<ScoreController>().score += 1;
            AudioSource temp = GetComponent<AudioSource>();
            temp.Play();
        }
        if (Vector3.Distance(startPos, transform.position) >= 18f)
        {
            Destroy(gameObject);
        }
    }
}
