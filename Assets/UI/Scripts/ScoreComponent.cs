﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class ScoreComponent : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI currentScore;
    [Inject] private GameManager gameManager;

    private void Update()
    {
        currentScore.text = (gameManager as ModeSystemGameManager).Score + "";
    }

    //void Start()
    //{
    //    GameManager.updateScore += UpdateScore;
    //}

    //public void UpdateScore(int score)
    //{
    //    currentScore.text = score + "";
    //}

    //private void OnDestroy()
    //{
    //    GameManager.updateScore -= UpdateScore;
    //}
}
