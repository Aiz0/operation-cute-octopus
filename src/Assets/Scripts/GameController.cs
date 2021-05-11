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
    public GameObject BaseObstacle { get; private set; }
    [field: SerializeField]
    public GameObject[] OtherObstacles { get; private set; }
    [field: SerializeField]
    public float RiskToSpawnOther { get; private set; }
    [field: SerializeField]
    public GameObject[] RockObstacles { get; private set; }
    [field: SerializeField]
    public float RiskToSpawnRock { get; private set;}
    [field: SerializeField]
    public bool AllowOtherSpawns { get; private set;}

    [SerializeField]
    private Vector2 direction = Vector2.down;
    [field: SerializeField]
    public float Speed { get; private set; }
    [field: SerializeField]
    public float MaxSpeed { get; private set; }
    [SerializeField]
    private float gameOverSpeed;

    [field: SerializeField]
    public float SpeedMultiplier { get; private set; }

    [field: SerializeField]
    public float SpawnDistanceInterval { get; private set; }
    [field: SerializeField]
    public int MaxInk { get; private set; }

    [field: SerializeField]
    public float ReloadTime { get; private set; }
    public bool IsReloading { get; private set; }
    public bool GameRunning { get; private set; }


    private int _score;
    private int _stars;
    private int _ink;
    private int _health = 1;

    public int Score {
        get => _score;
        set {
            _score = value;
            if (OnScoreUpdate != null ) OnScoreUpdate(_score);
        }
    }

    public int Stars {
        get => _stars;
        set {
            _stars = value;
            if (OnStarUpdate != null ) OnStarUpdate(_stars);
        }
    }

    public int Ink {
        get => _ink;
        set {
            _ink = value;
            if (OnInkUpdate != null) OnInkUpdate(_ink);
        }
    }

    public int Health {
        get => _health;
        set {
            _health = value;
            if(_health <= 0) {
                _health = 0;
                EndGame();
            }
            if (OnHealthUpdate != null) OnHealthUpdate(_health);
        }
    }

    public Vector2 Direction {
        get => direction;
    }

    public delegate void GameOver();
    public event GameOver OnGameOver;

    public delegate void ScoreUpdate(int score);
    public event ScoreUpdate OnScoreUpdate;

    public delegate void StarUpdate(int stars);
    public event StarUpdate OnStarUpdate;

    public delegate void InkUpdate(int ink);
    public event InkUpdate OnInkUpdate;

    public delegate void HealthUpdate(int health);
    public event HealthUpdate OnHealthUpdate;


    public float GetSpawnInterval(){
        return SpawnDistanceInterval / Speed;
    }

    public void IncrementScore(int value) {
        Score += value;
    }

    public void IncrementStars(int value) {
        Stars += value;
    }

    public void DecrementHealth(int value) {
        Health -= value;
    }

    public bool DecrementInk(int value) {
        if (Ink - value >= 0){
            Ink -= value;
            if (Ink > 0) {
                ReloadInk();
            }
            return true;
        }
        return false;
    }

    private void Awake(){
        instance = this;
    }

    private void Start(){
        StartGame();
    }

    private void StartGame() {
        GameRunning = true;
        Score = 0;
        Stars = PlayerStats.Instance.Stars;
        Ink = MaxInk;
        Health = 1;

        StartCoroutine(ScoreLoop());
        StartCoroutine(IncreaseSpeedLoop());
    }

    private IEnumerator ScoreLoop() {
        while(GameRunning) {
            yield return new WaitForSeconds(0.2f * GetSpawnInterval());
            Score++;
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
        Ink = MaxInk;
        IsReloading = false;
    }



    private IEnumerator IncreaseSpeedLoop() {
        while(GameRunning && Speed < MaxSpeed) {
            yield return new WaitForSeconds(5);
            Speed *= SpeedMultiplier;
        }
    }

    private void EndGame() {
        GameRunning = false;
        OnGameOver();
        UpdatePlayerStats();
        StartCoroutine(SlowDown());
    }

    private void UpdatePlayerStats(){
        PlayerStats.Instance.HighScore = Score;
        PlayerStats.Instance.Stars = Stars;

    }

    private IEnumerator SlowDown()
    {
        while(Speed > gameOverSpeed)
        {
            yield return new WaitForSeconds(0.1f);
            Speed *= 0.8f;
        }
        Speed = gameOverSpeed;
    }

    public void Restart() {
        LoadScene.instance.load("Main");
    }
}
