using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject startGameScreen;
    [SerializeField] GameObject endGameScreen;
    [SerializeField] GameObject WarpEffect;

     private void OnEnable()
    {
        PlayerInput.OnPlayerStartsToPlay += HideStartScreen;
        PlayerInput.OnPlayerDropsToPlay += ShowEndGameScreen;
        PlayerCollisions.OnPlayerHitTheWall += ShowEndGameScreen;
    }   

    private void OnDisable()
    {
         PlayerInput.OnPlayerStartsToPlay -= HideStartScreen;
        PlayerInput.OnPlayerDropsToPlay -= ShowEndGameScreen;
        PlayerCollisions.OnPlayerHitTheWall -= ShowEndGameScreen;
    } 

    private void HideStartScreen()
    {
        WarpEffect.SetActive(true);
        startGameScreen.SetActive(false);

    }
    private void ShowEndGameScreen()
    {
        WarpEffect.SetActive(false);
        endGameScreen.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
