
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float x_val;
    private float speed;
    public float inputSpeed;

    Animator animator;
    public string stopAnime = "PlayerStop";
    public string goalAnime = "PlayerGoal";
    public string deadAnime = "PlayerOver";
    string nowAnime = "";
    string oldAnime = "";
    public static string gameState = "playing";

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        nowAnime = stopAnime;
        oldAnime = stopAnime;
        gameState = "playing";

    }
    void Update()
    {
        if(gameState != "playing")
        {
            return;
        }
        x_val = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if(gameState != "playing")
        {
            return;
        }
        //�ҋ@
        if (x_val == 0)
        {
            speed = 0;
        }
        //�E�Ɉړ�
        else if (x_val > 0)
        {
            speed = inputSpeed;
            //�E����������
            transform.localScale = new Vector3(1, 1, 1);
        }
        //���Ɉړ�
        else if (x_val < 0)
        {
            speed = inputSpeed * -1;
            //������������
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // �L�����N�^�[���ړ� Vextor2(x���X�s�[�h�Ay���X�s�[�h(���̂܂�))
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if(collision.gameObject.tag == "Dead")
        {
            GameOver();
        }
    }

    public void Goal()
    {
        animator.Play(goalAnime);

        gameState = "gameclear";
        GameStop();
    }
    public void GameOver()
    {
        animator.Play(deadAnime);

        gameState = "gameover";
        GameStop();

        GetComponent<CapsuleCollider2D>().enabled = false;
        rb2d.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    void GameStop()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(x_val, 0);
    }
}