using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeChatOption : MonoBehaviour
{
    int liking = 0;
    public Button optionButtonFir;
    public Button optionButtonSec;

    void Start()
    {
        StartCoroutine("OptionButton");
    }

    IEnumerator OptionButton()
    {
        while (true)
        {
            liking = Save.Liking;

            if (liking == 100 || liking == 200 || liking == 300 || liking == 400 || liking == 500)
            {
                //Time.timeScale = 0.0f;
                optionButtonFir.gameObject.SetActive(true);
                optionButtonSec.gameObject.SetActive(true);
            }
            else
            {
                optionButtonFir.gameObject.SetActive(false);
                optionButtonSec.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}