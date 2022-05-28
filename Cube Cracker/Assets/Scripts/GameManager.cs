using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int lives;
    public int cubes = 20;
    public float resetDelay = 5f;
    public Text livesText;
    public GameObject gameOverText;
    public GameObject winText;
    public GameObject cubePrefab;
    public GameObject paddlePrefab;
    public GameObject deathParticles;
    public AudioSource deathSound;
    private bool levelComplete = false;
    private GameObject clonePaddle;

    void Start()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
            Setup();
    }

    void Setup()
    {
        clonePaddle = Instantiate(paddlePrefab, transform.position, Quaternion.identity) as GameObject;
        Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }


    void CheckGameOver()
    {
        if (cubes < 1)
        {
            levelComplete = true;
            winText.SetActive(true);
            Time.timeScale = 2.5f;
            Invoke("LoadNextLevel", resetDelay);
        }

        if (lives < 1)
        {
            if (levelComplete == true)
            {
                gameOverText.SetActive(false);
                Time.timeScale = 2.5f;
                Invoke("Reset", resetDelay);
            }
            else
            {
                gameOverText.SetActive(true);
                Time.timeScale = 2.5f;
                Invoke("Reset", resetDelay);
            }

        }
    }


    private void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        deathSound.Play();
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }


    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddlePrefab, transform.position, Quaternion.identity) as GameObject;
    }


    public void DestroyCube()
    {
        cubes--;
        CheckGameOver();
    }
}
