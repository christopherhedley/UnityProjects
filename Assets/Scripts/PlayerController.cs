using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;


    private Rigidbody rb;
    private int count;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetCountText ();
        SetScoreText ();
        winText.text = "";
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
            count = count + 1;
            SetCountText();
        }

        else if (other.gameObject.CompareTag("Enemy Pick Up"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetScoreText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 12)
        {
            winText.text = "Congratulations! You won with a score of " + score.ToString();
        }
    }

   void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}