using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CircleLogic : MonoBehaviour
{


    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction = new Vector2(0.5f, 0.5f);
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;
    private Rigidbody2D _rb;

    public Text scoreText;
    private int score = 0;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JumpLogic();
        UpdateScoreText();
        ConditionForWin();
    }

    void JumpLogic()
    {
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Шарик меняет направление по X при столкновении с краями экрана
        if (collision.collider.CompareTag("BlockOnSides"))
        {
            direction.x = -direction.x;
        }
        // Шарик меняет направление по Y при столкновении с верхним краем экрана или платформой(ракеткой)
        else if (collision.collider.CompareTag("BlockTop") || collision.collider.CompareTag("Platform"))
        {
            direction.y = -direction.y;
        }

        //Распределение очков каждому блоку
        else if (collision.collider.CompareTag("RedScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            ++score;
        }
        else if (collision.collider.CompareTag("OrangeScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            score += 2;
        }
        else if (collision.collider.CompareTag("GreenScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            score += 3;
        }
        else if (collision.collider.CompareTag("PinkScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            score += 4;
        }
        else if (collision.collider.CompareTag("VioletScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            score += 5;
        }
        else if (collision.collider.CompareTag("BlueScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            score += 6;
        }
        //Уничтожение шарика и отображение окна "Проигрыш" при столкновении с DeadZone
        else if (collision.collider.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
            loseScreen.SetActive(true);
        }
    }
    
    //Отображение очков на экране
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    private void ConditionForWin()
    {
        string level = SceneManager.GetActiveScene().name;
        if (level == "Level1" && score == 231)
        {
            Destroy(gameObject);
            winScreen.SetActive(true);
        }
    }
}
