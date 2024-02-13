using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterByLetter : MonoBehaviour
{
    string textToType = "Hello, I'm Andre. Welcome to my CV.";
    TMP_Text title_presentation;

    void Awake()
    {
      title_presentation = GetComponent<TMP_Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(typetextco());
    }

    IEnumerator typetextco()
    {
      title_presentation.text = string.Empty;

      for (int i = 0; i < textToType.Length; i++)
      {
        title_presentation.text += textToType[i];
        yield return new WaitForSeconds(0.05f);
      }

      yield return null;
    }
}
