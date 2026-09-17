using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : TienMonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;

    [SerializeField] protected Button playButton;
    [SerializeField] protected Transform GameOverPanel;
    [SerializeField] protected Button reloadButton;
    [SerializeField] protected GameObject EventSystem;

    protected override void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 UIManager allows to exist!");
        else instance = this;
        base.Awake();
    }

    protected override void LoadComponents()
    {
        LoadPlayButton();
        LoadGameOverPanel();
        LoadReloadButton();
        LoadEventSystem();
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(EventSystem);
    }

    private void LoadEventSystem()
    {
        if (EventSystem != null) return;
        EventSystem = GameObject.Find("EventSystem");
    }

    private void OnEnable()
    {
        AddOnClickEventForPlayButton();
        AddOnClickEventForReloadButton();
    }

    private void AddOnClickEventForReloadButton()
    {
        reloadButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
            GameOverPanel.gameObject.SetActive(false);
            Debug.Log("Added");
        });
    }

    private void AddOnClickEventForPlayButton()
    {
        playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            playButton.gameObject.SetActive(false);
            Debug.Log("Added");
        });
    }

    public virtual void GameOver()
    {
        GameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void LoadGameOverPanel()
    {
        if (GameOverPanel != null) return;
        GameOverPanel = transform.Find("GameOverPanel");
        GameOverPanel.gameObject.SetActive(false);
    }

    protected virtual void LoadReloadButton()
    {
        if (reloadButton != null) return;
        reloadButton = GameOverPanel.Find("Reload_Button").GetComponent<Button>();
    }

    protected virtual void LoadPlayButton()
    {
        if (playButton != null) return;
        playButton = transform.Find("Play_Button").GetComponent<Button>();
    }
}
