using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILogic : MonoBehaviour
{
    public TMPro.TextMeshProUGUI titletext;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void ConsoleTest()
    {
         Debug.Log("ConsoleTest Invoked");
    }
   
   public void StartGame()
   {
    StartCoroutine(FindPlayer());
   }
   

   IEnumerator FindPlayer()
   {
    AsyncOperation asyncOP = SceneManager.LoadSceneAsync("DemoScene");
    while (!asyncOP.isDone)
    {
        yield return null;
    }
    GameObject playerObj = GameObject.Find("Player");
    Debug.Log(playerObj);   
   }

    public void ReturnToMainMenuAfterDelay(float delay)
    {
        StartCoroutine(ReturnToMainMenuCoroutine(delay));
    }

    IEnumerator ReturnToMainMenuCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Credits()
{
    float delayInSeconds = 20f; // Adjust this value to your desired delay
    StartCoroutine(ShowCreditsAndReturn(delayInSeconds));
}

IEnumerator ShowCreditsAndReturn(float delay)
{
    // Load the credits scene
    SceneManager.LoadScene("CreditsScene");

    // Wait for the specified delay
    yield return new WaitForSeconds(delay);

    // Return to the main menu scene
    SceneManager.LoadScene("MainMenuScene");
}
}
