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
   [SerializeField] private bool cursor;

    public Sprite fullBullet;
    public Sprite emtyBulet;

    void Awake()
    {
        playerProperties.enemy = enemy;
        playerProperties.menu = false;
        playerProperties.menuPause = true;
        cursor = true;
   
    }

    
    void Update()
    {
      
        if (playerProperties.enemy <= 0)
        {
            cursor = false;
            victoryMemu.SetActive(true);          
            playerProperties.menuPause = false;
            playerProperties.menu = true;
            losingBool = false;
        }
        if(playerProperties.bullet == 0)
        {
            cursor = false;
            Invoke("LosingMenu", 2f);
            playerProperties.menuPause = false;
            playerProperties.menu = true;
        }
        if (playerProperties.menuPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!GameIsPaused)
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
        CursorFalse();

    }
    public void Continue()
    {
        if (playerProperties.menuPause)
        {
            cursor = true;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            StartCoroutine(ContinueCoroutine());
        }
    }
    IEnumerator ContinueCoroutine()
    {
        yield return new WaitForSeconds(2f);
        playerProperties.menu = false;
    }
    public void Pause()
    {

        if (playerProperties.menuPause)
        {
            cursor = false;
            playerProperties.menu = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

    }
    public void QuitGame()
    {
        Application.Quit();
        Time.timeScale = 1f;
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
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }
    public void CursorFalse()
    {
        if (cursor)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
    
}
