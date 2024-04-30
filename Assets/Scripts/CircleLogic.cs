using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CircleLogic : MonoBehaviour
{
    
    
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction = new Vector2(0.5f, 0.5f);
    int courrentScore = GameManagerScript.score;

    [SerializeField] GameObject loseScreen;
    public AudioSource circleHitsPlatform;
    public AudioSource circleHitsBlock;
    private Rigidbody2D _rb;
    public static bool _heroDead;

    void Start()
    {
        direction = new Vector2(Random.Range(-0.5f, 0.5f), -0.5f);
        _heroDead = false;
        _rb = GetComponent<Rigidbody2D>();
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JumpLogic();
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
            circleHitsPlatform.Play();
        }
        // Шарик меняет направление по Y при столкновении с верхним краем экрана или платформой(ракеткой)
        else if (collision.collider.CompareTag("BlockTop") || collision.collider.CompareTag("Platform"))
        {
            direction.y = -direction.y;
            circleHitsPlatform.Play();
        }

        //Распределение очков каждому блоку
        else if (collision.collider.CompareTag("RedScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            GameManagerScript.score = ++courrentScore;
            circleHitsBlock.Play();
            circleHitsBlock.pitch = 1;
        }
        else if (collision.collider.CompareTag("OrangeScoreBlock"))
        {
            int i = 2;
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            GameManagerScript.score = courrentScore += i;
            circleHitsBlock.Play();
            circleHitsBlock.pitch = i;
        }
        else if (collision.collider.CompareTag("GreenScoreBlock"))
        {
            int i = 3;
            circleHitsBlock.Play();
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            GameManagerScript.score = courrentScore += i;
            circleHitsBlock.Play();
            circleHitsBlock.pitch = i;
        }
        else if (collision.collider.CompareTag("PinkScoreBlock"))
        {
            int i = 4;
            circleHitsBlock.Play();
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            GameManagerScript.score = courrentScore += i;
            circleHitsBlock.Play();
            circleHitsBlock.pitch = i;
        }
        else if (collision.collider.CompareTag("VioletScoreBlock"))
        {
            int i = 5;
            circleHitsBlock.Play();
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            GameManagerScript.score = courrentScore += i;
            circleHitsBlock.Play();
            circleHitsBlock.pitch = i;
        }
        else if (collision.collider.CompareTag("BlueScoreBlock"))
        {
            int i = 6;
            circleHitsBlock.Play();
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            GameManagerScript.score = courrentScore += i;
            circleHitsBlock.Play();
            circleHitsBlock.pitch = i;
        }
        //Уничтожение шарика и отображение окна "Проигрыш" при столкновении с DeadZone
        else if (collision.collider.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
            loseScreen.SetActive(true);
            _heroDead = true;
        }
    }
}
