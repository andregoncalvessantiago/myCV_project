using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crossfade : MonoBehaviour
{
    public Animator transition;
    public float trasiontTime = 1f;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Presentation"))
        {
          LoadMenu();
        }
    }
    public void LoadMenu()
    {
      StartCoroutine(LoadMenu_delay(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadMenu_delay(int LevelIndex)
    {
      // Play animation
      transition.SetTrigger("Start");
      // Wait
      yield return new WaitForSeconds(trasiontTime);
      // load scene
      SceneManager.LoadScene(LevelIndex);
    }
}
