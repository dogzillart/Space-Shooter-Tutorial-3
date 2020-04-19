using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public bool win;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Mover mover;
    public bool hardMode;
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;

    public Text scoreText;
    public Text hardText;
    public Text winText;
    public Text restartText;
    public Text gameOverText;
    private int score;
    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        win = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        musicSource.clip = musicClipOne;
        musicSource.Play();
        hardMode = false;
    }
    
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown("r"))
        {
            hardMode = true;
        }
        if (hardMode == true)
        {
            Mover.speed = -15;
            hardText.text = "Hard Mode: On";
        }
        if (Input.GetKeyDown("e"))
        {
            hardMode = false;
        }
        if (hardMode == false)
        {
            Mover.speed = -8;
            hardText.text = "Hard Mode: Off";
        }
        
        if (restart)
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                SceneManager.LoadScene("Final");
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'TAB' for Restart";
                restart = true;
                break;
            }
            
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score;

        if (score >= 100)
        {
            winText.text = "You win! Game created by Kyle London";
            musicSource.Stop();
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            win = true;
            gameOver = true;
            restart = true;
        }
    }
    public void GameOver()
    {
        gameOver = true;
        if (score < 100)
        {
            gameOverText.text = "Game Over";
            musicSource.Stop();
            musicSource.clip = musicClipThree;
            musicSource.Play();
            gameOver = true;
        }
        

       
    }
}