using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int hp;
    public GameObject bullet;
    public float enemySpeed;

    Animator animator;
    AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 적이 왼쪽으로 직진
        transform.Translate(Vector3.left * enemySpeed * Time.deltaTime);
    }

    // 공격이 들어왔을 때 체력을 잃는다 
    public void Ondamaged(int attack)
    {
        hp -= attack;
        // 만약 체력이 0이면 적 제거
        if (hp <= 0)
        {
            // 터지는 애니메이션 실행
            animator.SetBool("isDead", true);
            // 터지는 소리 실행
            audioSource.Play();
            // collider 비활성화
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject,3f);
        }
    }

    // 충돌했을 시 이벤트
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 벽이랑 충돌시
        if (collision.gameObject.tag == "Block")
        {
            // 터지는 애니메이션?
            // enemy 제거
            Destroy(gameObject);
            
            // blockHp 감소
            GameManager.gm.blockHp -= 1;
        }

    }
}
