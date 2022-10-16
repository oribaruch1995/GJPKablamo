using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public CharacterBehaviour Player; // TODO:assign Player
    public ScoreManager scoreManager;
    public TextMeshProUGUI ScoreText;// assigned in inspetor
    public TextMeshProUGUI BulletsText;// assigned in inspetor
    public Image HpBarSlider; // assigned in inspetor
    public GameObject BulletImageGO; // assigned in inspetor
    public GameObject ReloadImageGO; // assigned in inspetor
    public GameObject MuteImageGO; // assigned in inspetor
    public GameObject UnMuteImageGO; // assigned in inspetor
    public GameObject StartScreenGO; // assigned in inspetor
    public GameObject GameHUDGO; // assigned in inspetor
    public GameObject PauseScreenGO; // assigned in inspetor
    public float CurrentHealth;
    public float CurrentScore = 0;
    private float _maxHealth;
    void Awake()
    {
        Blackboard.UIManager = this;
    }
    void Start()
    {
        _maxHealth = Player.playerCharacter.MaxHitPoints;
        scoreManager = Blackboard.ScoreManager;
    }
    void Update()
    {
        HpBar();
        BulletsStack();
        Score();
    }

    public void StartPlay()
    {
        // change to camera above player
        StartScreenGO.SetActive(false);
        GameHUDGO.SetActive(true);
    }
    public void HpBar()
    {
        CurrentHealth = Player.playerCharacter.CurHitPoints; // change temp player to HP amount from character
        HpBarSlider.fillAmount = CurrentHealth / _maxHealth;
    }
    public void Score()
    {
        if (scoreManager.CurrentPoints != CurrentScore) // change temp player to Score from character
        {
            CurrentScore = scoreManager.CurrentPoints;
            ScoreText.text = scoreManager.CurrentPoints.ToString();
        }
    }
    public void BulletsStack()
    {
        BulletsText.text = Player.bulletsRemaining.ToString(); // change temp player to bullet amount from character
        if (Player.bulletsRemaining <= 0)
            NeedToReload();
    }
    public void NeedToReload()
    {
        BulletImageGO.SetActive(false);
        ReloadImageGO.SetActive(true);
    }
    public void Reloaded() 
    {
        BulletImageGO.SetActive(true);
        ReloadImageGO.SetActive(false);
    }
    public void Mute()
    {
        // mute sound
        MuteImageGO.SetActive(false);
        UnMuteImageGO.SetActive(true);
    }
    public void UnMure()
    {
        // unmute sound
        MuteImageGO.SetActive(true);
        UnMuteImageGO.SetActive(false);
    }
    public void PauseBtn()
    {
        Time.timeScale = 0;
        GameHUDGO.SetActive(false);
        PauseScreenGO.SetActive(true);
    }
    public void ContinueBtn()
    {
        Time.timeScale = 1;
        PauseScreenGO.SetActive(false);
        GameHUDGO.SetActive(true);

    }
    public void ExitBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}