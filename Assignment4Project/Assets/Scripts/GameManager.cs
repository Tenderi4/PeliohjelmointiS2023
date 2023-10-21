using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverHUD;
    public GameObject GamePausedHUD;
    public float gameSpeed = 1.0f;
    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        GameOverHUD.SetActive(false);
        GamePausedHUD.SetActive(false);
        Time.timeScale = gameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GamePausedHUD.activeSelf && !GameOverHUD.activeSelf)
        {
            float maxTime = 15f;
            timer += Time.deltaTime;
            if (timer > maxTime)
            {
                gameSpeed *= 1.1f;
                timer = 0f;
            }
            Time.timeScale = gameSpeed;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        Physics.autoSimulation = false;
        GamePausedHUD.SetActive(true);
    }

    public void Resume()
    {
        GamePausedHUD.SetActive(false);
        Physics.autoSimulation = true;
        Time.timeScale = gameSpeed;
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        GameOverHUD.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Prototype 3");
    }
}
