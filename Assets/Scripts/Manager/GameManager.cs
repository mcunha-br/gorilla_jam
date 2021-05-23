using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public enum GameState {WAIT, INGAME, FINISH}

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public static GameState state = GameState.WAIT;

    [Header("Settings Countdown Fight")]
    public Animator countdownFight;
    public Text txtCountdownFight;
    public AudioClip[] clips;

    [Header("Settings Countdown Game")]
    public Text txtCoutdownGame;

    private AudioSource audioSource;
    private int countdownGame = 99;

    public GameObject loseAndWinnerPanel;
    public Text txtLoseAndWinner;

    private void Awake()
    {
        Instance = this;
    }


    private void Start() {
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();
        // Time.timeScale = 0;
        StartCoroutine("CountdownFight");
    }


    private void Update() {
        
    }

    private IEnumerator CountdownFight() {
        yield return new WaitForSeconds(0.5f);

        for (int i = 3; i > 0; i--)  {
            txtCountdownFight.text = i.ToString();
            countdownFight.Play("Countdown");
            audioSource.PlayOneShot(clips[i]);
            yield return new WaitForSeconds(1f);
        }        

        audioSource.PlayOneShot(clips[0]);
        txtCountdownFight.text = "Fight";
        countdownFight.Play("Fight");

        yield return new WaitForSeconds(1f);
        state = GameState.INGAME;

        InvokeRepeating("CountdownGame", 3, 2);
    }

    private void CountdownGame() {
        countdownGame--;
        txtCoutdownGame.text = countdownGame.ToString("00");
    }

    public void WinAndLoseGame(string messenge)
    {
        state = GameState.FINISH;
        loseAndWinnerPanel.SetActive(true);
        txtLoseAndWinner.text = messenge;
    }
     public void SetButtons(string value)
    {
        switch(value)
        {
            case "RESTART":
                SceneManager.LoadScene("GamePlay");               
             
            break;                    

            case "MENU":
                SceneManager.LoadScene("GameMenu");                
            break;
        }
    }
}
