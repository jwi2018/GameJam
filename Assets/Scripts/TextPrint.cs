using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrint : MonoBehaviour
{
    //텍스트 펑션 기능
    // ex) 텍스트 펑션일 경우 그 밸류값이 스트링 테이블의 id값과 동일하며 그 id값의 text를 출력한다.
    public static TextPrint textPrint;

    public Image stringEventTextImage;
    public Text stringEventText;
    //string[,] eventTextListArr = new string[CsvRead.eventTextTableId, 5];
    string[,] eventTextListArr = new string[107, 6];

    void Start()
    {
        stringEventText.gameObject.SetActive(false);
        stringEventTextImage.gameObject.SetActive(false);
        StartCoroutine("EventTextListArr");
    }

    IEnumerator EventTextListArr()
    {
        // 이벤트 전용 스트링 테이블
        for (int eventTextId = 0; eventTextId < CsvRead.eventTextTableId; eventTextId++)
        {
            for (int eventTextTxt = 0; eventTextTxt < 6; eventTextTxt++)
            {
                eventTextListArr[eventTextId, eventTextTxt] = CsvRead.doubleEventTextList[eventTextId, eventTextTxt];
            }
        }
        yield return null;
    }

    public void EventTextPrint()
    {
        if (GameManager.divEventInt == 1)
        {
            string eventRightTextArrId = CsvRead.doubleEventRightList[GameManager.eventRightListId, 3];
            int eventRightTextArrIdInt = int.Parse(eventRightTextArrId);  // 텍스트 ID값이 들어가고
            int eventRightTextArrIdRealInt = eventRightTextArrIdInt - 500;
            stringEventText.text = eventTextListArr[eventRightTextArrIdRealInt, 3];
        }
        else if (GameManager.divEventInt == 2)
        {
            string eventLeftTextArrId = CsvRead.doubleEventLeftList[GameManager.eventLeftListId, 3];
            int eventLeftTextArrIdInt = int.Parse(eventLeftTextArrId);  // 텍스트 ID값이 들어가고
            int eventLeftTextArrIdRealInt = eventLeftTextArrIdInt - 500;
            stringEventText.text = eventTextListArr[eventLeftTextArrIdRealInt, 3];
        }

        stringEventTextImage.gameObject.SetActive(true);
        stringEventText.gameObject.SetActive(true);
    }

    public void EventEndingTextPrint()
    {
        if (Save.optionPoint == 1)
        {
            string eventEndingFirTextArrId = CsvRead.doubleEventEndingList[GameManager.eventFirEndingListId, 3];
            int eventEndingFirTextArrIdInt = int.Parse(eventEndingFirTextArrId);  // 텍스트 ID값이 들어가고
            int eventEndingFirTextArrIdRealInt = eventEndingFirTextArrIdInt - 500;
            stringEventText.text = eventTextListArr[eventEndingFirTextArrIdRealInt, 3];
        }
        else if (Save.optionPoint == 3)
        {
            string eventEndingSecTextArrId = CsvRead.doubleEventEndingList[GameManager.eventSecEndingListId, 3];
            int eventEndingSecTextArrIdInt = int.Parse(eventEndingSecTextArrId);  // 텍스트 ID값이 들어가고
            int eventEndingSecTextArrIdRealInt = eventEndingSecTextArrIdInt - 500;
            stringEventText.text = eventTextListArr[eventEndingSecTextArrIdRealInt, 3];
        }
        else if (Save.optionPoint == 5)
        {
            string eventEndingThrTextArrId = CsvRead.doubleEventEndingList[GameManager.eventThrEndingListId, 3];
            int eventEndingThrTextArrIdInt = int.Parse(eventEndingThrTextArrId);  // 텍스트 ID값이 들어가고
            int eventEndingThrTextArrIdRealInt = eventEndingThrTextArrIdInt - 500;
            stringEventText.text = eventTextListArr[eventEndingThrTextArrIdRealInt, 3];
        }

        stringEventTextImage.gameObject.SetActive(true);
        stringEventText.gameObject.SetActive(true);
    }

    public void EventTextPrintClose()
    {
        stringEventTextImage.gameObject.SetActive(false);
        stringEventText.gameObject.SetActive(false);
    }
}
