using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int score;
    float timer = 2.0f;
    
    public GameObject enemy;
    public int blockHp;

    public Text blockHpText;
    public Text scoreText;
    public Text gameOverText;

    private void Awake()
    {
        gm = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // blockHp를 blockHpText에 연결
        blockHpText.text = "X " + blockHp;
        // score를 scoreText에 연결
        scoreText.text = score.ToString();
        timer -= 1 * Time.deltaTime;
        if (timer < 0)
        {
            // 타이머 시간이 되면 적 생성
            CreateEnemy();
            timer = Random.Range(0, 2f);
        }
        // blockHp 가 0 이하면 게임오버
        if (blockHp <= 0)
        {
            GameOver();
        }
    }

    // 적들을 생성하는 기능
    void CreateEnemy()
    {
        // 생성
        Instantiate(enemy, new Vector3(Random.Range(7f, 8f), Random.Range(-3.5f, 4f), 0), Quaternion.identity);
    }

    // 게임 오버
    public void GameOver()
    {
        // UI Text를 이용해 플레이어에게 게임 오버라고 보여줄겁니다
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    // 재시작
    public void ReStart()
    {
        SceneManager.LoadScene("Game");
    }
}
