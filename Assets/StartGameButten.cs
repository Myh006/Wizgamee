using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButten : MonoBehaviour
{
  //bulld number of scene to start when butten is pressed
  public int gameStartScene;

  public void StartGame(){
    SceneManager.LoadScene(gameStartScene);
  }
}
