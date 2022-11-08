using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ball : MonoBehaviour
{
    ConstantForce2D force;
    Rigidbody2D rb;

    int[] array = { -1, 1 };
    float maxVelocity = 15;
    public TMP_Text scoreText;
    int score = 0;

    void Start()
    {
        force = GetComponent<ConstantForce2D>();
        force.force = new Vector2(array[Random.Range(0, 2)], 0);
        rb = GetComponent<Rigidbody2D>();

        if (rb.velocity.x < 0)
        {
            force.force = new Vector2(-1, 0);
        }
        else
        {
            force.force = new Vector2(1, 0);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            print("GAME OVER!");
            Invoke("ResetGame", 1);
        }
        else if (collision.gameObject.name == "Player")
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
