using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    private float distanceBetweenPatterns;
    [field: SerializeField]
    public GameObject BaseObstacle
    { get; private set; }
    [field: SerializeField]
    public GameObject[] OtherObstacles
    { get; private set; }
    [field: SerializeField]
    public float RiskToSpawnOther
    { get; private set; }
    [field: SerializeField]
    public GameObject[] RockObstacles
    { get; private set; }
    [field: SerializeField]
    public float RiskToSpawnRock
    { get; private set;}
    [field: SerializeField]
    public bool AllowOtherSpawns
    { get; private set;}

    [SerializeField]
    private Vector2 direction = Vector2.down;
    [field: SerializeField]
    public float Speed
    { get; private set; }
    [field: SerializeField]
    public float MaxSpeed
    { get; private set; }
    [field: SerializeField]
    public float SpawnDistanceInterval
    { get; private set; }
    [field: SerializeField]
    public float SpeedMultiplier
    { get; private set; }
    [field: SerializeField]
    public int MaxInk
    { get; private set; }
    [field: SerializeField]
    public float ReloadTime
    { get; private set; }



    public delegate void GameOver();
    public event GameOver OnGameOver;


    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text starText;
    [SerializeField]
    private Text inkText;

    private int score;
    private int stars;
    private int health = 1;
    // ink that can be fired
    private int ink = 1;

    public bool IsReloading
    { get; private set; }
    public bool GameRunning
    { get; private set; }

    public Vector2 Direction {
        get => direction;
    }

    public float GetSpawnInterval(){
        return SpawnDistanceInterval / Speed;
    }

    private void SetScore(int value) {
        score = value;
        scoreText.text = score.ToString();
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
        Score.Instance.Stars = stars;
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

    void Awake(){
        instance = this;
        StartGame();
    }

    private void StartGame() {
        GameRunning = true;
        SetScore(0);
        SetStars(Score.Instance.Stars);
        SetInk(MaxInk);

        StartCoroutine(ScoreLoop());
        StartCoroutine(IncreaseSpeedLoop());
    }

    private IEnumerator ScoreLoop() {
        while(GameRunning) {
            yield return new WaitForSeconds(0.2f * GetSpawnInterval());
            IncrementScore(1);
        }
    }


    private void ReloadInk() {
        if (!IsReloading) {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload() {
        IsReloading = true;
        yield return new WaitForSeconds(ReloadTime);
        SetInk(MaxInk);
        IsReloading = false;
    }



    private IEnumerator IncreaseSpeedLoop() {
        while(GameRunning && Speed < MaxSpeed) {
            yield return new WaitForSeconds(5);
            Speed *= SpeedMultiplier;
        }
    }

    private void EndGame() {
        Debug.Log("Game Over!");

        OnGameOver();
        GameRunning = false;

        Score.Instance.HighScore = score;

        StartCoroutine(SlowDown());
    }

    private IEnumerator SlowDown()
    {
        while(Speed > 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            Speed *= 0.8f;
        }
        Speed = 0;
    }

    public void Restart() {
        Debug.Log("Restarting Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
