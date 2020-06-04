using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeChatOption : MonoBehaviour
{
    int liking = 0;
    int optionPoint = 0;
    int loveIntFir = 0;
    int pointIntFir = 0;
    string loveStringFir = "0";
    string pointStringFir = "0";
    int loveIntSec = 0;
    int pointIntSec = 0;
    string loveStringSec = "0";
    string pointStringSec = "0";
    int num = 0;
    public Button optionButtonFir;
    public Button optionButtonSec;
    int loveBarCur = 0;


    void Start()
    {
        StartCoroutine("OptionButton");
    }

    /*
    void Update()
    {
        liking = Save.Liking;

        Debug.Log("2");
        Debug.Log(liking);

        if (liking == 100 && liking == 200 && liking == 300 && liking == 400 && liking == 500)
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
    }
    */

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


    /*
    public void OnClickFirOptionButton()        // 1번째 버튼 클릭 시 발생해야 하는 상황
    {
        liking = Save.Liking;
        optionPoint = Save.optionPoint;

        Debug.Log("1");
        loveStringFir = CsvRead.doubleChatOptionList[num, 3];
        Debug.Log(loveStringFir);
        Debug.Log("2");
        loveIntFir = int.Parse(loveStringFir);
        Debug.Log(loveIntFir);

        Debug.Log("3");
        pointStringFir = CsvRead.doubleChatOptionList[num, 5];
        Debug.Log(pointStringFir);
        Debug.Log("4");
        pointIntFir = int.Parse(pointStringFir);
        Debug.Log(pointIntFir);

        liking += loveIntFir;
        Debug.Log(liking);
        optionPoint += pointIntFir;

        num++;

        optionButtonFir.gameObject.SetActive(false);
        optionButtonSec.gameObject.SetActive(false);

        //Time.timeScale = 1.0f;
    }
    public void OnClickSecOptionButton()       // 2번째 버튼 클릭 시 발생해야 하는 상황
    {
        liking = Save.Liking;
        optionPoint = Save.optionPoint;

        loveStringSec = CsvRead.doubleChatOptionList[num, 4];
        loveIntSec = int.Parse(loveStringSec);

        pointStringSec = CsvRead.doubleChatOptionList[num, 6];
        pointIntSec = int.Parse(pointStringSec);

        liking += loveIntSec;
        optionPoint += pointIntSec;

        num++;

        optionButtonFir.gameObject.SetActive(false);
        optionButtonSec.gameObject.SetActive(false);

        //Time.timeScale = 1.0f;
    }
    */
}