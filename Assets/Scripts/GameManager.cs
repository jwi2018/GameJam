using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public static int eventListId = 0;
    string[,] eventListArr;

    void Start()
    {
        eventListArr = new string[CsvRead.eventTableId, 5];
        StartCoroutine("EventListArr");
        StartCoroutine("StartEvent");
    }

    IEnumerator EventListArr()      // 이벤트 리스트의 모든 배열을 임의의 배열에다가 전부 복사해둔거
    {
        for (int eventId = 0; eventId < CsvRead.eventTableId; eventId++)
        {
            for (int eventTxt = 0; eventTxt < 5; eventTxt++)
            {
                eventListArr[eventId, eventTxt] = CsvRead.doubleEventList[eventId, eventTxt];
            }
        }
        yield return null;
    }

    IEnumerator StartEvent()
    {
        while (true)
        {
            if (Save.eventStartPoint == 1) // 1일때 실행 . 0일 때 종료
            {
                if (Save.stringEventOption.ToString() == eventListArr[eventListId, 1])
                {
                    string endTypeStr = eventListArr[eventListId, 4];
                    int endTypeInt = int.Parse(endTypeStr);
                    
                    // 해당 옵션 값과 이벤트 리스트의 그룹 값이 동일할때까지만 돌아가게끔 하면 됨.


                     // ----------------------텍스트 이벤트----------------------------

                    if (eventListArr[eventListId, 2] == "text_Print" && endTypeInt == 0)
                    {
                        GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();

                        eventListId++;
                    }
                    else if (eventListArr[eventListId, 2] == "text_Print" && endTypeInt == 1)
                    {
                        GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();

                        yield return new WaitForSeconds(13f);
                        eventListId++;
                    }
                    else if (eventListArr[eventListId, 2] == "text_Print" && endTypeInt == 2)
                    {
                        GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();
                    }
                    else if (eventListArr[eventListId, 2] == "text_Print" && endTypeInt == 3)
                    {
                        GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();
                    }


                     // ---------------------cg 이벤트--------------------------

                    if (eventListArr[eventListId, 2] == "cg_Play" && endTypeInt == 0)
                    {
                        GameObject.Find("EventSystem").GetComponent<CGPlay>().EventCgPlay();

                        eventListId++;
                    }
                    else if (eventListArr[eventListId, 2] == "cg_Play" && endTypeInt == 1)
                    {
                        GameObject.Find("EventSystem").GetComponent<CGPlay>().EventCgPlay();

                        yield return new WaitForSeconds(13f);
                        eventListId++;
                    }
                    else if (eventListArr[eventListId, 2] == "cg_Play" && endTypeInt == 2)
                    {
                        GameObject.Find("EventSystem").GetComponent<CGPlay>().EventCgPlay();
                    }
                    else if (eventListArr[eventListId, 2] == "cg_Play" && endTypeInt == 3)
                    {
                        GameObject.Find("EventSystem").GetComponent<CGPlay>().EventCgPlay();
                    }
                }
                else
                {
                    GameObject.Find("EventSystem").GetComponent<CGPlay>().EventCgClose();

                    Save.eventStartPoint = 0;
                }
            }
            yield return null;
        }
    }
}

//Debug.Log(eventListArr[eventListId, 4]);

/*
if (eventListArr[eventListId, 2] == "text_Print")
{
    GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();

    // endType
    if (eventListArr[eventListId, 4] == "0")
    {
        eventListId++;
    }
    else if (eventListArr[eventListId, 4] == "1")
    {
        yield return new WaitForSeconds(13f);
        eventListId++;
    }
    else if (eventListArr[eventListId, 4] == "2")
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                eventListId++;
                break;
            }
            yield return null;
        }
    }
    else if (eventListArr[eventListId, 4] == "3")
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                eventListId++;
                break;
            }
            yield return null;
        }
    }
}*/
