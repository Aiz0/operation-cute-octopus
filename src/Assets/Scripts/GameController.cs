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
    private float gameOverSpeed = 0.5f;
    [SerializeField]
    private float increaseSpeedBy;

    [SerializeField]
    private int maxInk = 1;

    [SerializeField]
    private float reloadTime;

    private float scoreInterval;

    [SerializeField]
    private Text newHighScoreText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text starText;
    [SerializeField]
    private Text inkText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Image reloadImage;

    private int finalScore;
    private int finalStars;

    private Score scores;

    //Variabler som rör DrillPowerUp
    private int maxDrill = 3; //maximalt antal användningar för DrillPowerup, skulle kunna sättas som SerializeField
    private int drillPowerUp;

    //Variabler som rör RocketPowerUp
    private bool rocketPowerUpActive = false;
    private float rocketTimer = 0f;
    private float rocketMaxTime = 15f; //maxtid för raket, skulle kunna sättas som SerializeField
    private float reduceSpeedby = 0f;
    private float rocketSpeedFactor = 10f; //hur mycket snabbare farten temporärt ökar med RocketPowerUp, skulle kunna sättas som SerializeField
    private bool rocketSlowingDown = false;

    //Objekt som powerups påverkar
    public GameObject drillObject;
    public Animator drillAnimator;
    public GameObject rocketObject;
    public SpriteRenderer playerSprite;
    public GameObject rocketParticles;
    public GameObject rocketParticlesDying;
    public ParticleSystem rocketPowerUpTransitionParticles;

    //Variabler som påverkar spelarens odödlighet efter mottagen skada
    private bool playerRecentlyHit = false;
    private float timeSinceLastHit;
    private int invincibilityFlashes = 10;
    private float flashIntervalTime = 0.1f;
    private float timeInvincible;

    private int score;
    private int stars;
    private int health;

    private bool playOnce = true;

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

    private void Start()
    {
        reloadImage.fillAmount = 0f;
    }

    private void Update()
    {
        if(isReloading)
        {
            reloadImage.fillAmount += 1 / reloadTime * Time.deltaTime;

            if (reloadImage.fillAmount >= 1)
            {
                reloadImage.fillAmount = 0f;
                isReloading = false;
            }
        }
        if (rocketPowerUpActive == true)
        {
            rocketTimer += Time.deltaTime;
            if ((rocketTimer / 7.5f) > (rocketMaxTime / 10f))
            {
                if (rocketSlowingDown == false)
                {
                    SlowDownRocket(true);
                }
            }
            if (rocketTimer >= rocketMaxTime)
            {
                DeactivateRocketPowerUp(true);
            }
        }
        if (playerRecentlyHit)
        {
            timeSinceLastHit += Time.deltaTime;
            if (timeSinceLastHit >= timeInvincible)
            {
                playerRecentlyHit = false;
            }
        }
    }

    private void StartGame() {
        gameRunning = true;
        gameOverPanel.SetActive(false);


        UpdateHealth();
        UpdateInk();

        SetScore(0);
        SetStars(0);

        StartCoroutine(ScoreLoop());
        timeInvincible = flashIntervalTime * invincibilityFlashes * 2;
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

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            newHighScoreText.gameObject.SetActive(true);

            if(playOnce == true)
            {
                SoundManager.soundFx.PlayHighScoreSound();
                playOnce = false;
            }
        }
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
        starText.text = (stars + PlayerPrefs.GetInt("TotalStars")).ToString();
    }

    public void IncrementStars(int value)
    {
        SoundManager.soundFx.PlayStarSound();
        SetStars(stars + value);
    }

    public void UpdateHealth()
    {
        if(PlayerPrefs.GetInt("Health") < 1)
        {
            PlayerPrefs.SetInt("Health", 1);
        }
        else
        {
            SetHealth(PlayerPrefs.GetInt("Health"));
        }
    }

    public void UpdateInk()
    {
        inkText.text = ink.ToString();

        if (PlayerPrefs.GetInt("Ink") < 1)
        {
            PlayerPrefs.SetInt("Ink", 1);
        }
        else
        {
            SetInk(PlayerPrefs.GetInt("Ink"));
        }
    }
    private void SetHealth(int value) {
        health = value;
        if (health <= 0) {
            health = 0;
            if (IsRunning())
            {
                EndGame();
            }
        }
        healthText.text = health.ToString();
    }

    public void DecrementHealth(int value)
    {
        if (playerRecentlyHit == false)
        {
            SetHealth(health - value);
            playerRecentlyHit = true;
            timeSinceLastHit = 0;
            if (health > 0)
            {
                StartCoroutine(characterFlashOnHit());
            }
        }
    }

    private void SetInk(int value) {
        ink = value;
        inkText.text = ink.ToString();
    }

    public bool DecrementInk(int value) {
        if (ink - value >= 0){
            SetInk(ink - value);
            if (ink < maxInk) {
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
        UpdateInk();
        isReloading = false;
    }


    private IEnumerator characterFlashOnHit()
    {
        Color originalColor = playerSprite.color;
        for (int i = 0; i < invincibilityFlashes; i++)
        {
            playerSprite.color = Color.red;
            yield return new WaitForSeconds(flashIntervalTime);
            playerSprite.color = originalColor;
            yield return new WaitForSeconds(flashIntervalTime);
        }
    }


    public void InitiateDrillPowerUp(bool initiate)
    {
        drillObject.SetActive(initiate);
        SetDrillPowerUp(maxDrill);
        drillAnimator.speed = 1;

    }

    private void SetDrillPowerUp(int value)
    {
        drillPowerUp = value;
        float drillRatio = UnityEngine.Mathf.Sqrt((float)value) / UnityEngine.Mathf.Sqrt((float)maxDrill) * 0.1f; // borrens storlek s�tts till en faktor av sqrt(anv�ndningar kvar) / sqrt(maxs anv�ndningar)
        if (drillPowerUp <= 0)
        {
            drillObject.SetActive(false);
        }
        else
        {
            drillObject.transform.localScale = new Vector3(drillRatio, drillRatio, 1f);
        }
        if (drillPowerUp == 1)
        {
            drillAnimator.speed = 3;

        }

    }



    public void DecrementDrillPowerUp(int value)
    {
        SetDrillPowerUp(drillPowerUp - value);
    }

    public void InitiateRocketPowerUp(bool initiate)
    {
        rocketPowerUpTransitionParticles.Play();
        rocketObject.SetActive(initiate);
        rocketParticles.SetActive(true);
        rocketParticlesDying.SetActive(false);
        playerSprite.enabled = false;
        rocketPowerUpActive = true;
    }

    public void DeactivateRocketPowerUp(bool initiate)
    {
        rocketPowerUpTransitionParticles.Play();
        rocketTimer = 0f;
        rocketObject.SetActive(false);
        rocketParticles.SetActive(true);
        rocketParticlesDying.SetActive(false);
        playerSprite.enabled = true;
        rocketPowerUpActive = false;
        speed = speed - reduceSpeedby;
        reduceSpeedby = 0;
        rocketSlowingDown = false;

    }

    public void SlowDownRocket(bool initiate)
    {
        speed = speed - (reduceSpeedby * 0.75f);
        reduceSpeedby = reduceSpeedby - (reduceSpeedby * 0.75f);
        rocketSlowingDown = true;
        rocketParticles.SetActive(false);
        rocketParticlesDying.SetActive(true);
        SoundManager.soundFx.PlayRocketEndSound();
    }

    public bool IsRunning() {
        return gameRunning;
    }

    private void EndGame() {
        Debug.Log("Game Over!");
        gameRunning = false;
        gameOverPanel.SetActive(true);
        Animator animator = player.GetComponent<Animator>();
        animator.SetBool("isDead", true);
        Destroy(player,1);
        finalScore = score;
        finalStars = stars;

        PlayerPrefs.SetInt("Score", finalScore);
        PlayerPrefs.SetInt("Stars",finalStars);
        PlayerPrefs.Save();
        scores.UpdateHighScore();
        scores.UpdateTotalStars();
        StartCoroutine(SlowDown());
    }

    private IEnumerator SlowDown()
    {
        while(speed > gameOverSpeed)
        {
            yield return new WaitForSeconds(0.1f);
            speed *= 0.8f;
        }
        speed = gameOverSpeed;
    }

    public void IncreaseSpeed()
    {
        if (maxSpeed > speed)
        {
            if (rocketPowerUpActive)
            {
                speed += (increaseSpeedBy * rocketSpeedFactor);
                reduceSpeedby += (increaseSpeedBy * rocketSpeedFactor);
            }
            else
            {
                speed += increaseSpeedBy;
            }
        }

    }

        public void Restart()
    {
        Debug.Log("Restarting Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
