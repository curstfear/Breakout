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
    private Rigidbody2D _rb;

    int courrentScore = GameManagerScript.score;

    void Start()
    {
        
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
        
        // ����� ������ ����������� �� X ��� ������������ � ������ ������
        if (collision.collider.CompareTag("BlockOnSides"))
        {
            direction.x = -direction.x;
        }
        // ����� ������ ����������� �� Y ��� ������������ � ������� ����� ������ ��� ����������(��������)
        else if (collision.collider.CompareTag("BlockTop") || collision.collider.CompareTag("Platform"))
        {
            direction.y = -direction.y;
        }

        //������������� ����� ������� �����
        else if (collision.collider.CompareTag("RedScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            GameManagerScript.score = ++courrentScore;
        }
        else if (collision.collider.CompareTag("OrangeScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            GameManagerScript.score = courrentScore += 2;
        }
        else if (collision.collider.CompareTag("GreenScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            GameManagerScript.score = courrentScore += 3;
        }
        else if (collision.collider.CompareTag("PinkScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            GameManagerScript.score = courrentScore += 4;
        }
        else if (collision.collider.CompareTag("VioletScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            GameManagerScript.score = courrentScore += 5;
        }
        else if (collision.collider.CompareTag("BlueScoreBlock"))
        {
            direction.y = -direction.y;
            Destroy(collision.gameObject);
            GameManagerScript.score = courrentScore += 6;
        }
        //����������� ������ � ����������� ���� "��������" ��� ������������ � DeadZone
        else if (collision.collider.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
            loseScreen.SetActive(true);
        }
    }
}
