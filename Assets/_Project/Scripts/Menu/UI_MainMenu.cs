using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _chooseCharacter;
    [SerializeField] private GameObject _gameOver;
    public void ChooseCharacter()
    {
        _chooseCharacter.SetActive(true);
    }

    public void SelectCharacter(int index)
    {
        PlayerPrefs.SetInt("SelectedCharacter", index);
        PlayGame();
    }

    public void PlayGame()
    {

        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Esci dal gioco");
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        _gameOver.SetActive(true);
    }
}
