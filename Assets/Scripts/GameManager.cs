using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public static int divEventInt = 0;
    public static int stringOption = 1;
    public static int stringEndingOption = 0;

    public static int eventListId = 0;
    // 2020 - 08 -28
    public static int eventRightListId = 0;
    public static int eventLeftListId = 0;
    public static int optionPlusNum = 0;

    public static int eventFirEndingListId = 0;
    public static int eventSecEndingListId = 7;
    public static int eventThrEndingListId = 14;

    public static int eventFirEndingListGroup = 1;
    public static int eventSecEndingListGroup = 2;
    public static int eventThrEndingListGroup = 3;

    string[,] eventListArr;
    // 2020 - 08 -28
    string[,] eventRightArr;
    string[,] eventLeftArr;
    string[,] eventEndingArr;

    public Image stringEventTextImage;
    public Text stringEventText;

    public Image cgImage;
    public Image cgImageBg;


    void Start()
    {
        eventListArr = new string[CsvRead.eventTableId, 5];
        // 2020 - 08 -28
        eventRightArr = new string[CsvRead.eventRightTableId, 5];
        eventLeftArr = new string[CsvRead.eventLeftTableId, 5];
        eventEndingArr = new string[CsvRead.eventEndingTableId, 5];
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

        for (int eventRightId = 0; eventRightId < CsvRead.eventRightTableId; eventRightId++)
        {
            for (int eventRightTxt = 0; eventRightTxt < 5; eventRightTxt++)
            {
                eventRightArr[eventRightId, eventRightTxt] = CsvRead.doubleEventRightList[eventRightId, eventRightTxt];
            }
        }

        for (int eventLeftId = 0; eventLeftId < CsvRead.eventLeftTableId; eventLeftId++)
        {
            for (int eventLeftTxt = 0; eventLeftTxt < 5; eventLeftTxt++)
            {
                eventLeftArr[eventLeftId, eventLeftTxt] = CsvRead.doubleEventLeftList[eventLeftId, eventLeftTxt];
            }
        }

        for (int eventEndingId = 0; eventEndingId < CsvRead.eventEndingTableId; eventEndingId++)
        {
            for (int eventEndingTxt = 0; eventEndingTxt < 5; eventEndingTxt++)
            {
                eventEndingArr[eventEndingId, eventEndingTxt] = CsvRead.doubleEventEndingList[eventEndingId, eventEndingTxt];
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
                if (Save.stringEventOption.ToString() == eventRightArr[eventRightListId, 1] || Save.stringEventOption.ToString() == eventLeftArr[eventLeftListId, 1] || Save.stringEventOption == 5)
                {
                    //string endTypeStr = eventListArr[eventListId, 4];
                    //int endTypeInt = int.Parse(endTypeStr);

                    string endRightTypeStr = eventRightArr[eventRightListId, 4];
                    int endRightTypeInt = int.Parse(endRightTypeStr);

                    string endLeftTypeStr = eventLeftArr[eventLeftListId, 4];
                    int endLeftTypeInt = int.Parse(endLeftTypeStr);

                    string endEndingFirTypeStr = eventEndingArr[eventFirEndingListId, 4];
                    int endEndingFirTypeInt = int.Parse(endEndingFirTypeStr);

                    string endEndingSecTypeStr = eventEndingArr[eventSecEndingListId, 4];
                    int endEndingSecTypeInt = int.Parse(endEndingSecTypeStr);

                    string endEndingThrTypeStr = eventEndingArr[eventThrEndingListId, 4];
                    int endEndingThrTypeInt = int.Parse(endEndingThrTypeStr);

                    if (Save.stringEventOption == 5)
                    {
                        stringEventTextImage.gameObject.SetActive(true);
                        stringEventText.gameObject.SetActive(true);
                        cgImage.gameObject.SetActive(true);
                        cgImageBg.gameObject.SetActive(true);

                        if (stringEndingOption.ToString() == eventEndingArr[eventFirEndingListId, 1])
                        {
                            if (Save.optionPoint == 1)
                            {
                                if (eventEndingArr[eventFirEndingListId, 2] == "text_print" && endEndingFirTypeInt == 2)
                                {
                                    GameObject.Find("EventSystem").GetComponent<TextPrint>().EventEndingTextPrint();      // 2020 - 08 - 28 , 여기 바꿔야함

                                    eventFirEndingListId++;

                                    yield return new WaitForSeconds(3f);
                                }

                                if (eventEndingArr[eventFirEndingListId, 2] == "cg_play" && endEndingFirTypeInt == 2)
                                {
                                    GameObject.Find("EventSystem").GetComponent<CGPlay>().EventEndingCgPlay();

                                    eventFirEndingListId++;

                                    yield return new WaitForSeconds(3f);
                                }
                            }
                            // 2020 - 09 -12
                            Save.eventUIFirEnding = 1;  // 이벤트 UI 해당 이벤트 씬 재실행 버튼
                        }
                        else if (stringEndingOption.ToString() == eventEndingArr[eventSecEndingListId, 1])
                        {
                            if (Save.optionPoint == 3)
                            {
                                if (eventEndingArr[eventSecEndingListId, 2] == "text_print" && endEndingSecTypeInt == 2)
                                {
                                    GameObject.Find("EventSystem").GetComponent<TextPrint>().EventEndingTextPrint();      // 2020 - 08 - 28 , 여기 바꿔야함

                                    eventSecEndingListId++;

                                    yield return new WaitForSeconds(3f);
                                }

                                if (eventEndingArr[eventSecEndingListId, 2] == "cg_play" && endEndingSecTypeInt == 2)
                                {
                                    GameObject.Find("EventSystem").GetComponent<CGPlay>().EventEndingCgPlay();

                                    eventSecEndingListId++;

                                    yield return new WaitForSeconds(3f);
                                }
                            }

                            // 2020 - 09 -12
                            Save.eventUISecEnding = 1;  // 이벤트 UI 해당 이벤트 씬 재실행 버튼
                        }
                        else if (stringEndingOption.ToString() == eventEndingArr[eventThrEndingListId, 1])
                        {
                            if (Save.optionPoint == 5)
                            {
                                if (eventEndingArr[eventThrEndingListId, 2] == "text_print" && endEndingThrTypeInt == 2)
                                {
                                    GameObject.Find("EventSystem").GetComponent<TextPrint>().EventEndingTextPrint();      // 2020 - 08 - 28 , 여기 바꿔야함

                                    eventThrEndingListId++;

                                    yield return new WaitForSeconds(3f);
                                }

                                if (eventEndingArr[eventThrEndingListId, 2] == "cg_play" && endEndingThrTypeInt == 2)
                                {
                                    GameObject.Find("EventSystem").GetComponent<CGPlay>().EventEndingCgPlay();

                                    eventThrEndingListId++;

                                    yield return new WaitForSeconds(3f);
                                }
                            }

                            // 2020 - 09 -12
                            Save.eventUIThrEnding = 1;  // 이벤트 UI 해당 이벤트 씬 재실행 버튼
                        }
                        else
                        {
                            Save.stringEventOption++;
                        }
                    }
                    else
                    {
                        if (divEventInt == 1)    //////////////////////////////////////// 첫번째 버튼 클릭 /////////////////////////////////////////////////////////
                        {
                            if (Save.stringEventOption.ToString() == eventRightArr[eventRightListId, 1])
                            {
                                if (eventRightArr[eventRightListId, 2] == "text_print" && endRightTypeInt == 0)
                                {
                                    GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();      // 2020 - 08 - 28 , 여기 바꿔야함

                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                                else if (eventRightArr[eventRightListId, 2] == "text_print" && endRightTypeInt == 1)
                                {
                                    GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();

                                    yield return new WaitForSeconds(3f);
                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                                else if (eventRightArr[eventRightListId, 2] == "text_print" && endRightTypeInt == 2)
                                {
                                    GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();

                                    yield return new WaitForSeconds(2f);

                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                                else if (eventRightArr[eventRightListId, 2] == "text_print" && endRightTypeInt == 3)
                                {
                                    GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();
                                }
                            }


                            if (Save.stringEventOption.ToString() == eventRightArr[eventRightListId, 1])
                            {
                                // ---------------------cg 이벤트--------------------------
                                if (eventRightArr[eventRightListId, 2] == "cg_play" && endRightTypeInt == 0)
                                {
                                    GameObject.Find("EventSystem").GetComponent<CGPlay>().EventCgPlay();

                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                                else if (eventRightArr[eventRightListId, 2] == "cg_play" && endRightTypeInt == 1)
                                {
                                    GameObject.Find("EventSystem").GetComponent<CGPlay>().EventCgPlay();

                                    yield return new WaitForSeconds(3f);
                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                                else if (eventRightArr[eventRightListId, 2] == "cg_play" && endRightTypeInt == 2)
                                {
                                    GameObject.Find("EventSystem").GetComponent<CGPlay>().EventCgPlay();

                                    eventRightListId++;
                                    eventLeftListId++;
                                    yield return new WaitForSeconds(2f);
                                }
                                else if (eventRightArr[eventRightListId, 2] == "cg_play" && endRightTypeInt == 3)
                                {
                                    cgImageBg.gameObject.SetActive(false);

                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                            }
                        }
                        else if (divEventInt == 2)   /////////////////////////////////////// 두번째 버튼 클릭   /////////////////////////////////////////////////////////////////////////////////////////////////////
                        {
                            if (Save.stringEventOption.ToString() == eventLeftArr[eventLeftListId, 1])
                            {
                                if (eventLeftArr[eventLeftListId, 2] == "text_print" && endLeftTypeInt == 0)
                                {
                                    GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();

                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                                else if (eventLeftArr[eventLeftListId, 2] == "text_print" && endLeftTypeInt == 1)
                                {
                                    GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();

                                    yield return new WaitForSeconds(3f);
                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                                else if (eventLeftArr[eventLeftListId, 2] == "text_print" && endLeftTypeInt == 2)
                                {
                                    Debug.Log("text");
                                    GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();

                                    yield return new WaitForSeconds(3f);
                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                                else if (eventLeftArr[eventLeftListId, 2] == "text_print" && endLeftTypeInt == 3)
                                {
                                    GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrint();
                                }
                            }

                            if (Save.stringEventOption.ToString() == eventLeftArr[eventLeftListId, 1])
                            {
                                // ---------------------cg 이벤트--------------------------
                                if (eventLeftArr[eventLeftListId, 2] == "cg_play" && endLeftTypeInt == 0)
                                {
                                    GameObject.Find("EventSystem").GetComponent<CGPlay>().EventCgPlay();

                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                                else if (eventLeftArr[eventLeftListId, 2] == "cg_play" && endLeftTypeInt == 1)
                                {
                                    GameObject.Find("EventSystem").GetComponent<CGPlay>().EventCgPlay();

                                    yield return new WaitForSeconds(3f);

                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                                else if (eventLeftArr[eventLeftListId, 2] == "cg_play" && endLeftTypeInt == 2)
                                {
                                    Debug.Log("cg");
                                    GameObject.Find("EventSystem").GetComponent<CGPlay>().EventCgPlay();

                                    yield return new WaitForSeconds(3f);

                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                                else if (eventLeftArr[eventLeftListId, 2] == "cg_play" && endLeftTypeInt == 3)
                                {
                                    cgImageBg.gameObject.SetActive(false);

                                    eventRightListId++;
                                    eventLeftListId++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Debug.Log("이벤트 종료");
                    //GameObject.Find("EventSystem").GetComponent<CGPlay>().EventCgClose();
                    //GameObject.Find("EventSystem").GetComponent<TextPrint>().EventTextPrintClose();

                    stringEventTextImage.gameObject.SetActive(false);
                    stringEventText.gameObject.SetActive(false);
                    cgImage.gameObject.SetActive(false);
                    cgImageBg.gameObject.SetActive(false);

                    divEventInt = 0;
                    Save.eventStartPoint = 0;
                    //Save.stringEventOption = 0;             // TextAndFace 에서 게임 매니저로 이동. 이벤트 진행중 클릭 시 이벤트 종료 방지를 위함
                }
            }
            yield return null;
        }
    }
}