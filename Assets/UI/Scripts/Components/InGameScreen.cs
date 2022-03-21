﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScreen : UIComponent
{
    void Start() 
    {
        _fadeTime = 0.045F;
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        UIManager.executeStartGame += FadeIn;
        UIManager.executePauseButton += () => gameObject.SetActive(false);
        UIManager.executeResumeFromPause += () => gameObject.SetActive(true);
        UIManager.executeQuitGame += FadeOut;
        UIManager.executeGameOver += FadeOut;
    }

    void OnDestroy() 
    {
        UIManager.executeStartGame -= FadeIn;
        UIManager.executePauseButton -= () =>gameObject.SetActive(false);
        UIManager.executeResumeFromPause -= () =>gameObject.SetActive(true); ;
        UIManager.executeQuitGame -= FadeOut;
        UIManager.executeGameOver -= FadeOut;
    }

}
