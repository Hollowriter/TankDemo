using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : Singleton<UIPause>
{
    [SerializeField] private Image pauseBackground;
    [SerializeField] private TMPro.TextMeshProUGUI pauseText;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Toggle audioToggle;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button pauseButton;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        pauseBackground.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        audioToggle.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        PauseManager.instance.Paused += PauseToggled;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    private void PauseToggled() 
    {
        pauseBackground.gameObject.SetActive(PauseManager.instance.GetPaused());
        pauseText.gameObject.SetActive(PauseManager.instance.GetPaused());
        resumeButton.gameObject.SetActive(PauseManager.instance.GetPaused());
        audioToggle.gameObject.SetActive(PauseManager.instance.GetPaused());
        mainMenuButton.gameObject.SetActive(PauseManager.instance.GetPaused());
        pauseButton.gameObject.SetActive(!PauseManager.instance.GetPaused());
    }

}
