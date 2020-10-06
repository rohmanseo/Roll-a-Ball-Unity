using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rigidBody;
    private float movementX;
    private float movementY;
    private int score;
    private int enemiesCollided;
    private bool isGameOver;

    public TextMeshProUGUI scoreText;
    public GameObject winText;
    public GameObject loseText;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        score = 0;
        enemiesCollided = 0;
        UpdateScore();
        winText.SetActive(false);
        loseText.SetActive(false);
        isGameOver = false;
    }

    void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isGameOver)
        {
            bool isPickUp = other.gameObject.CompareTag("PickUp");
            bool isEnemy = other.gameObject.CompareTag("Enemy");
            if (isPickUp)
            {
                other.gameObject.SetActive(false);
                score += 1;
                UpdateScore();
            }
            else if (isEnemy)
            {
                other.gameObject.SetActive(false);
                score -= 1;
                enemiesCollided += 1;
                UpdateScore();
            }

            if(score < 0)
            {
                LoseGame();
            }

            if (score == 10)
            {
                WinGame();
            }
            if (enemiesCollided == 3)
            {
                LoseGame();
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX,0.0f,movementY);
        rigidBody.AddForce(movement * speed);
    }

    void WinGame()
    {
        winText.SetActive(true);
        isGameOver = true;
    }

    void LoseGame()
    {
        loseText.SetActive(true);
        isGameOver = true;
    }

    void UpdateScore()
    {
           scoreText.text = "Score : " + score.ToString();
    }

}
