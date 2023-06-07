using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class IntroManager : MonoBehaviour
{
    // can ignore the update, it's just to make the coroutines get called for example
    
    [SerializeField] RawImage intro1 = null;
    [SerializeField] RawImage intro2 = null;
    [SerializeField] RawImage intro3 = null;
    [SerializeField] RawImage intro4 = null;
    [SerializeField] RawImage intro5 = null;
    [SerializeField] RawImage intro6 = null;
    [SerializeField] RawImage intro7 = null;
    [SerializeField] RawImage intro8 = null;
    [SerializeField] RawImage intro9 = null;
    [SerializeField] RawImage intro10 = null;
    [SerializeField] RawImage intro11 = null;
    [SerializeField] RawImage intro12 = null;

    void Start()
    {
        StartCoroutine(FadeTextToFullAlpha(1.0f, intro1, intro2, intro3, intro4, intro5, intro6, intro7, intro8, intro9, intro10, intro11
            , intro12));
    }

    void Update()
    {
    }

    public IEnumerator FadeTextToFullAlpha(float t, RawImage intro1, RawImage intro2, RawImage intro3, RawImage intro4, RawImage intro5, RawImage intro6
        , RawImage intro7, RawImage intro8, RawImage intro9, RawImage intro10, RawImage intro11, RawImage intro12)
    {
        RawImage[] arr = { intro1, intro2, intro3, intro4, intro5, intro6, intro7, intro8, intro9, intro10, intro11, intro12};

        for (int i=0; i<12; i++)
        {
            arr[i].color = new Color(arr[i].color.r, arr[i].color.g, arr[i].color.b, 0);
        }

        // intro1 ~ intro15 까지 순차적으로 화면에 띄움
        for (int i=0; i<12; i++)
        {
            while (arr[i].color.a < 4.0f)
            {
                arr[i].color = new Color(arr[i].color.r, arr[i].color.g, arr[i].color.b, arr[i].color.a + (Time.deltaTime / t));
                yield return null;
            }

            arr[i].color = new Color(arr[i].color.r, arr[i].color.g, arr[i].color.b, 1);
            while (arr[i].color.a > 0.0f)
            {
                arr[i].color = new Color(arr[i].color.r, arr[i].color.g, arr[i].color.b, arr[i].color.a - (Time.deltaTime / t));
                yield return null;
            }
        }

        SceneManager.LoadScene("Scenes/Main_Scene");
    }
}