using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public float TempPlayerHP = 100; // temp until player health assigned
    public int TempPlayerScore = 0; // temp until player health assigned
    public int TempPlayerBullets = 100; // temp until player health assigned
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
    private float _maxHealth = 100f;

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
        CurrentHealth = TempPlayerHP; // change temp player to HP amount from character
        HpBarSlider.fillAmount = CurrentHealth / _maxHealth;
    }
    public void Score()
    {
        if (TempPlayerScore != CurrentScore) // change temp player to Score from character
        {
            CurrentScore = TempPlayerScore;
            ScoreText.text = TempPlayerScore.ToString();
        }
    }
    public void BulletsStack()
    {
        BulletsText.text = TempPlayerBullets.ToString(); // change temp player to bullet amount from character
        if (TempPlayerBullets <= 0)
            NeedToReload();
    }
    public void NeedToReload()
    {
        BulletImageGO.SetActive(false);
        ReloadImageGO.SetActive(true);
    }
    public void Reloaded() // assign to a key/button you reload
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
        GameHUDGO.SetActive(false);
        PauseScreenGO.SetActive(true);
    }
    public void ContinueBtn()
    {
        PauseScreenGO.SetActive(false);
        GameHUDGO.SetActive(true);

    }
    public void ExitBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void ReplayBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // change that  it will start from the beggining on the game
    }

}