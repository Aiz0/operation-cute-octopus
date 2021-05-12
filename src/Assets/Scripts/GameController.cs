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
    private float distanceBetweenPatterns = 5.0f;
    [SerializeField]
    private GameObject baseObstacle;
    [SerializeField]
    private GameObject[] otherObstacles;
    [SerializeField]
    private float riskToSpawnOther = 10;
    [SerializeField]
    private GameObject[] rockObstacles;
    [SerializeField]
    private float riskToSpawnRock = 10;
    [SerializeField]
    private bool allowOtherSpawns = true;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private Vector2 direction = Vector2.down;
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float maxSpeed = 15;
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
    private int drillPowerUp;
    public GameObject drillObject;
    // ink that can be fired
    private int ink = 1;

    private bool isReloading = false;
    private bool gameRunning = false;

    void Awake(){
        instance = this;
        scoreInterval = distanceBetweenPatterns / speed;
        StartGame();
        scores = GameObject.FindWithTag("HighScore").GetComponent<Score>();
    }

    private void StartGame() {
        gameRunning = true;
        gameOverPanel.SetActive(false);

        SetScore(0);
        SetStars(0);
        SetInk(maxInk);
        SetDrillPowerUp(0);

        StartCoroutine(ScoreLoop());
    }

    private IEnumerator ScoreLoop() {
        // Could alternatly use time.deltaTime instead
        while(IsRunning()) {
            yield return new WaitForSeconds(scoreInterval);
            IncrementScore(1);
            scoreInterval = distanceBetweenPatterns / speed;
        }
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

    public Vector2 GetDirection()
    {
        return direction;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetInk()
    {
        return ink;
    }

    public float GetDistance()
    {
        return distanceBetweenPatterns;
    }

    public bool GetAllowOtherSpawns()
    {
        return allowOtherSpawns;
    }

    public float GetRiskToSpawnRock()
    {
        return riskToSpawnRock;
    }

    public float GetRiskToSpawnOther()
    {
        return riskToSpawnOther;
    }

    public GameObject GetBaseObstacle()
    {
        return baseObstacle;
    }

    public GameObject[] GetOtherObstacles()
    {
        return otherObstacles;
    }

    public GameObject[] GetRockObstacles()
    {
        return rockObstacles;
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
        InitiateDrillPowerUp(true); //har lagt drillPowerUp här temporärt, REMOVE när den har egen pickup
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

    public void InitiateDrillPowerUp(bool initiate)
    {
       drillObject.SetActive(initiate);
        SetDrillPowerUp(3); //skulle kunna vara en variabel med [SerializeField] för att enklare kunna ändra

    }

    private void SetDrillPowerUp(int value)
    {
        drillPowerUp = value;
      
        if (drillPowerUp == 3){
            drillObject.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        }
        if (drillPowerUp == 2){
            drillObject.transform.localScale = new Vector3(0.075f, 0.075f, 1f);
        }
        if (drillPowerUp == 1){
            drillObject.transform.localScale = new Vector3(0.05f, 0.05f, 1f);
        }
        if (drillPowerUp <= 0)
        {
            drillObject.SetActive (false);
        }
    }

    public void DecrementDrillPowerUp(int value)
    {
        SetDrillPowerUp(drillPowerUp - value);
    }

    public bool IsRunning() {
        return gameRunning;
    }

    private void EndGame() {
        Debug.Log("Game Over!");
        gameRunning = false;
        gameOverPanel.SetActive(true);
        Animator animator = player.GetComponent<Animator>();
        animator.SetBool("Dead", true);
        Destroy(player,1);
        finalScore = getScore();
        finalStars = getStars();
        print(finalScore);

        PlayerPrefs.SetInt("Score", finalScore);
        PlayerPrefs.SetInt("Stars",finalStars);
        PlayerPrefs.Save();


        scores.UpdateHighScore();
        scores.UpdateTotalStars();
        StartCoroutine(SlowDown());
    }

    private IEnumerator SlowDown()
    {
        while(speed > 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            speed *= 0.8f;
        }
        speed = 0;
    }

    public void IncreaseSpeed()
    {
        if (maxSpeed > speed) speed += increaseSpeedBy;
    }

    public void Restart() {
        Debug.Log("Restarting Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
