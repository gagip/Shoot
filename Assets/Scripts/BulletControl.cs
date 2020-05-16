using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    int bulletAttack;
    
    // 총알의 공격력 설정
    public void SetAttack(int num)
    {
        bulletAttack = num;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 총알이 앞으로 나가는 기능
        transform.Translate(Vector3.right * 5.0f * Time.deltaTime);
    }

    // 총알이 화면 밖으로 나가면 삭제(제거)
    // 화면상 보이지 않는 경우에 실행
    private void OnBecameInvisible()
    {
        //총알 삭제
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 어떤 물체와 충돌을 했을 때
        Destroy(gameObject);
        // 어떤 물체의 태그가 enemy라면
        if (collision.gameObject.tag == "Enemy")
        {
            // enemy 체력 깎이는
            collision.gameObject.GetComponent<EnemyControl>().Ondamaged(bulletAttack);
            GameManager.gm.score += 100; // 점수 +
        }

    }

}
