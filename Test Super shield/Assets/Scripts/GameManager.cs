using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public int enemy;
    public GameObject victoryMemu;
    public GameObject losingMenu;
    public GameObject pauseMenu;
    public PlayerProperties playerProperties;
    public bool losingBool;
    public static bool GameIsPaused;
    public int numberOfButton;
    public Image[] bulets;

    public Sprite fullBullet;
    public Sprite emtyBulet;

    void Awake()
    {
        playerProperties.enemy = enemy;
        playerProperties.menu = false;
        playerProperties.menuPause = true;
    }

    
    void Update()
    {
      
        if (playerProperties.enemy <= 0)
        {
            victoryMemu.SetActive(true);
            playerProperties.menuPause = false;
            playerProperties.menu = true;
            losingBool = false;
        }
        if(playerProperties.bullet == 0)
        {
            Invoke("LosingMenu", 2f);
            playerProperties.menuPause = false;
            playerProperties.menu = true;
        }
        if (playerProperties.menuPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Continue();
                }
                else
                {
                    Pause();
                }
            }
        }
        if(playerProperties.bullet > numberOfButton)
        {
            playerProperties.bullet = numberOfButton;
        }
        for (int i = 0; i < bulets.Length; i++)
        { 
            if(i < playerProperties.bullet)
            {
                bulets[i].sprite = fullBullet;
            }
            else
            {
                bulets[i].sprite = emtyBulet;
            }
            if(i < numberOfButton)
            {
                bulets[i].enabled = true;
            }
            else
            {
                bulets[i].enabled = false;
            }
        }

    }
    public void Continue()
    {
        if (playerProperties.menuPause)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            StartCoroutine(ContinueCoroutine());
        }
    }
    IEnumerator ContinueCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        playerProperties.menu = false;
    }
    public void Pause()
    {

        if (playerProperties.menuPause)
        {
            playerProperties.menu = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    public void LosingMenu()
    {
        if (losingBool)
        {
            losingMenu.SetActive(true);
        }
    }
    
}
