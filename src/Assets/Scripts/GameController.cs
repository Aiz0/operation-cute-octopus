using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    private Spawner spawner;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Vector2 direction = Vector2.down;
    [SerializeField]
    public float speed = 1;
    [SerializeField]
    private float increaseSpeedBy;
    [SerializeField]
    private int maxInk = 1;
    [SerializeField]
    private float reloadTime;

    private float scoreInterval;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text starText;
    [SerializeField]
    private Text inkText;

    public int finalScore;
    public int finalStars;

    private Score scores;

    private int score;
    private int stars;
    private int health = 1;
    // ink that can be fired
    private int ink = 1;

    private bool isReloading = false;
    private bool gameRunning = false;

    void Awake(){
        instance = this;
        scoreInterval = spawner.distanceBetweenPatterns / speed;
        StartGame();
        scores = GameObject.FindWithTag("HighScore").GetComponent<Score>();
    }

    private void StartGame() {
        gameRunning = true;
        gameOverPanel.SetActive(false);

        SetScore(0);
        SetStars(0);
        SetInk(maxInk);

        StartCoroutine(ScoreLoop());
    }

    private IEnumerator ScoreLoop() {
        // Could alternatly use time.deltaTime instead
        while(IsRunning()) {
            yield return new WaitForSeconds(scoreInterval);
            IncrementScore(1);
            scoreInterval = spawner.distanceBetweenPatterns / speed;
        }
    }


    public Vector2 GetDirection() {
        return direction;
    }

    public float GetSpeed() {
        return speed;
    }

    private void SetScore(int value) {
        score = value;
        scoreText.text = score.ToString();
    }

    public int getScore()
    {
        return score;
    }

    public int getStars()
    {
        return stars;
    }

    public void IncrementScore(int value) {
        SetScore(score + value);
    }

    private void SetStars(int value) {
        stars = value;
        starText.text = stars.ToString();
    }

    public void IncrementStars(int value) {
        SetStars(stars + value);
    }

    private void SetHealth(int value) {
        health = value;
        if(health <= 0) {
            EndGame();
        }
    }

    public void DecrementHealth(int value) {
        SetHealth(health - value);
    }

    private void SetInk(int value) {
        ink = value;
        inkText.text = ink.ToString();
    }

    public bool DecrementInk(int value) {
        if (ink - value >= 0){
            SetInk(ink - value);
            if (ink == 0) {
                ReloadInk();
            }
            return true;
        }
        return false;
    }

    public int GetInk() {
        return ink;
    }

    private void ReloadInk() {
        if (!isReloading) {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload() {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        SetInk(maxInk);
        isReloading = false;
    }

    public bool IsRunning() {
        return gameRunning;
    }

    private void EndGame() {
        Debug.Log("Game Over!");
        gameRunning = false;
        gameOverPanel.SetActive(true);
        Destroy(player);
        finalScore = getScore();
        finalStars = getStars();
        print(finalScore);

        PlayerPrefs.SetInt("Score", finalScore);
        PlayerPrefs.SetInt("Stars",finalStars);
        PlayerPrefs.Save();

        
        scores.UpdateHighScore();
        scores.UpdateTotalStars();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void increaseSpeed()
    {
        speed += increaseSpeedBy;
    }

    public void Restart() {
        Debug.Log("Restarting Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
