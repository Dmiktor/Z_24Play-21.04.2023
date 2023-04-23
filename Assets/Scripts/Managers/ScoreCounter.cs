using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] GameObject scoreText;
    private TextMeshProUGUI _scoreText;
    private int score = 0;
    private void Awake()
    {
        _scoreText = scoreText.GetComponent<TextMeshProUGUI>();
    }
   private void OnEnable()
    {
        BlockCollision.OnBlockPikeUp += addToScore;
    }

    private void OnDisable()
    {
        BlockCollision.OnBlockPikeUp -= addToScore;
    }

    private void addToScore()
    {
        score += 1;
        _scoreText.SetText("Your score: " + score);
    }
}
