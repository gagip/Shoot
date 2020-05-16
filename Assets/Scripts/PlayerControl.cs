using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigid;
    float speed = 5.0f;
    float jumpSpeed = 10.0f;
    public GameObject bullet;

    int life = 3; // 적이나 적 총알에 맞으면
    public int playerAttack = 1;  // 공격력

    public Text playerHpText;

    Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // playerHp를 playerHpText에 연결
        playerHpText.text = "X " + life;
        // 자판키를 입력하면 캐릭터 이동
        if (Input.GetKey(KeyCode.LeftArrow)) // 왼쪽 방향키를 입력하면
        {
            // 왼쪽으로 캐릭터 이동
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        // 점프
        if (Input.GetKey(KeyCode.X))
        {
            rigid.AddForce(Vector3.up * jumpSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
        // 총알 발사
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 총알 발사하는 애니메이션
            animator.SetTrigger("shoot");
            // 총알 발사하는 소리
            audioSource.Play();

            // 총알 생성
            GameObject currBullet = Instantiate(bullet, new Vector3(transform.position.x + 0.7f, transform.position.y), Quaternion.identity);
            currBullet.GetComponent<BulletControl>().SetAttack(playerAttack);
        }
        // 만약에 hp가 0 이하면 게임오버
        if (life <= 0)
        {
            GameManager.gm.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // 적과 충돌할 때
            life -= 1;
            // 터지는 애니메이션
            collision.gameObject.GetComponent<Animator>().SetBool("isDead", true);
            // 터지는 소리
            collision.gameObject.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collision.gameObject, 3f);
        }
    }
}
