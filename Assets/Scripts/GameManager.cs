using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public delegate void eventText();   // 이벤트 텍스트 델리게이트
    public event eventText text_Print;

    public delegate void eventCG();     // 이벤트 CG 델리게이트
    public event eventCG cg_Play;

    public static int eventListId = 0;

    string[,] eventListArr = new string[CsvRead.eventTableId, 5];       // 이벤트 리스트를 옮길 게임 매니저내의 2차 배열

    // 옵션값 불러와서 옵션값과 동일한 이벤트 리스트의 그룹을 동일한 2차배열에 옮기고
    // id를 증가시키면서 함수 이름을 분별 (if)문 사용함.  // 여기까지가 게임 매니저에 해당

    //텍스트 펑션 기능
    // ex) 텍스트 펑션일 경우 그 밸류값이 스트링 테이블의 id값과 동일하며 그 id값의 text를 출력한다.
    // 마지막에 end_type 구분별로 상황에 따라 종료

    void Start()
    {
        StartCoroutine("EventListArr");
        StartCoroutine("StartEvent");
    }

    IEnumerator EventListArr()
    {
        // 이벤트 리스트 테이블
        for (int eventId = 0; eventId < CsvRead.eventTableId; eventId++)
        {
            for (int eventTxt = 0; eventTxt < 5; eventTxt++)
            {
                if (Save.stringEventOption.ToString() == CsvRead.doubleEventList[eventId, 1])
                {
                    eventListArr[eventId, eventTxt] = CsvRead.doubleEventList[eventId, eventTxt];
                }
            }
        }
        yield return null;
    }

    IEnumerator StartEvent()
    {
        while (true)
        {
            if (Save.stringEventOption != 0)
            {
                if (eventListArr[eventListId, 2] == "text_print")
                {
                    text_Print();
                }
                else if(eventListArr[eventListId, 2] == "cg_play")
                {
                    cg_Play();
                }

                // endType
                if (eventListArr[eventListId, 4] == "0")
                {
                    eventListId++;
                }
                else if(eventListArr[eventListId, 4] == "1")
                {
                    yield return new WaitForSeconds(13f);
                    eventListId++;
                }
                else if(eventListArr[eventListId, 4] == "2")
                {
                    while(true)
                    {
                        if(Input.GetMouseButtonDown(0))
                        {
                            eventListId++;
                            break;
                        }
                        yield return null;
                    }
                }
                else if(eventListArr[eventListId, 4] == "3")
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
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
