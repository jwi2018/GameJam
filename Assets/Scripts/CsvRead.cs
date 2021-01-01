using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Security.Principal;

public class CsvRead : MonoBehaviour
{
    public int disTableId_In = 0;       // 전광판
    public int chatTableId_In = 0;      // 클릭 시 캐릭터 대사창
    public int chatOptionTable_In = 0;      // 클릭 시 캐릭터 대사창 선택지
    public int eventTable_In = 0;
    public int eventTextTable_In = 0;
    //2020 - 08 - 28 이벤트 구분을 위해 오른쪽, 왼쪽 버튼 선택시 CSV 추가
    public int eventRightTable_In = 0;
    public int eventLeftTable_In = 0;
    public int eventEndingTable_In = 0;

    public static int disTableId = 0;
    public static int chatTableId = 0;
    public static int chatOptionTableId = 0;
    public static int eventTableId = 0;
    public static int eventTextTableId = 0;
    //2020 - 08 - 28 이벤트 구분을 위해 오른쪽, 왼쪽 버튼 선택시 CSV 추가
    public static int eventRightTableId = 0;
    public static int eventLeftTableId = 0;
    public static int eventEndingTableId = 0;

    public TextAsset display_Table, chat_Table, chat_Option_Table, event_Table, event_TextTable , event_RightTable, event_LeftTable , event_Ending;

    string fileFullPathChat, fileFullPathDisplay , fileFullPathChatOption, fileFullPathEvent, fileFullPathEventText, fileFullPathEventRight, fileFullPathEventLeft, fileFullPathEventEnding;

    public static string[,] doubleDisplayList; //  [id][내용1&2]
    public static string[,] doubleChatList;
    public static string[,] doubleChatOptionList;
    public static string[,] doubleEventList;
    public static string[,] doubleEventTextList;
    public static string[,] doubleEventRightList;
    public static string[,] doubleEventLeftList;
    public static string[,] doubleEventEndingList;

    void Awake()                // start에서 awake로 변경 = 다른 스크립트에서 변수가 적용되기 전에 0을 받아오는 경우가 생겼음.
    {
        disTableId = disTableId_In;
        chatTableId = chatTableId_In;
        chatOptionTableId = chatOptionTable_In;
        eventTableId = eventTable_In;
        eventTextTableId = eventTextTable_In;
        eventRightTableId = eventRightTable_In;
        eventLeftTableId = eventLeftTable_In;
        eventEndingTableId = eventEndingTable_In;

        fileFullPathChat = chat_Table.text;
        fileFullPathDisplay = display_Table.text;
        fileFullPathChatOption = chat_Option_Table.text;
        fileFullPathEvent = event_Table.text;
        fileFullPathEventText = event_TextTable.text;
        fileFullPathEventRight = event_RightTable.text;
        fileFullPathEventLeft = event_LeftTable.text;
        fileFullPathEventEnding = event_Ending.text;

        StartCoroutine("InputCsvArr");
    }

    IEnumerator InputCsvArr()
    {
        string[] chatList = fileFullPathChat.Split('\n', ',');    
        string[] displayList = fileFullPathDisplay.Split('\n', ',');
        string[] chatOptionList = fileFullPathChatOption.Split('\n', ',');
        string[] eventList = fileFullPathEvent.Split('\n', ',');
        string[] eventTextList = fileFullPathEventText.Split('\n', ',');
        string[] eventRightTextList = fileFullPathEventRight.Split('\n', ',');
        string[] eventLeftTextList = fileFullPathEventLeft.Split('\n', ',');
        string[] eventEndingTextList = fileFullPathEventEnding.Split('\n', ',');

        doubleDisplayList = new string[disTableId, 3]; 
        doubleChatList = new string[chatTableId, 6];
        doubleChatOptionList = new string[chatOptionTableId, 7];
        doubleEventList = new string[eventTableId, 5];
        doubleEventTextList = new string[eventTextTableId, 6];
        doubleEventRightList = new string[eventRightTableId, 5];
        doubleEventLeftList = new string[eventLeftTableId, 5];
        doubleEventEndingList = new string[eventEndingTable_In, 5];


        int listChatNum = 0;    
        int listTableNum = 0;
        int listChatOptionNum = 0;
        int listEventNum = 0;
        int listEventTextNum = 0;
        int listEventRightNum = 0;
        int listEventLeftNum = 0;
        int listEventEndingNum = 0;


        for (int disId = 0; disId < disTableId; disId++)
        {
            for (int disTxt = 0; disTxt < 3; disTxt++)     
            {
                doubleDisplayList[disId, disTxt] = displayList[listTableNum];
                listTableNum++;
            }
        }
        for (int chatId = 0; chatId < chatTableId; chatId++)
        {
            for (int chatTxt = 0; chatTxt < 6; chatTxt++)
            {
                doubleChatList[chatId, chatTxt] = chatList[listChatNum];
                listChatNum++;
            }
        }
        
        for (int chatOptionId = 0; chatOptionId < chatOptionTableId; chatOptionId++)
        {
            for (int chatOptionTxt = 0; chatOptionTxt < 7; chatOptionTxt++)
            {
                doubleChatOptionList[chatOptionId, chatOptionTxt] = chatOptionList[listChatOptionNum];
                listChatOptionNum++;
            }
        }

        for(int eventId = 0; eventId < eventTableId; eventId++)
        {
            for(int eventTxt = 0; eventTxt < 5; eventTxt++)
            {
                doubleEventList[eventId, eventTxt] = eventList[listEventNum];
                listEventNum++;
            }
        }

        for (int eventTextId = 0; eventTextId < eventTextTableId; eventTextId++)
        {
            for (int eventTextTxt = 0; eventTextTxt < 6; eventTextTxt++)
            {
                doubleEventTextList[eventTextId, eventTextTxt] = eventTextList[listEventTextNum];
                listEventTextNum++;
            }
        }

        for (int eventRightId = 0; eventRightId < eventRightTableId; eventRightId++)
        {
            for (int eventRightTxt = 0; eventRightTxt < 5; eventRightTxt++)
            {
                doubleEventRightList[eventRightId, eventRightTxt] = eventRightTextList[listEventRightNum];
                listEventRightNum++;
            }
        }

        for (int eventLeftId = 0; eventLeftId < eventLeftTableId; eventLeftId++)
        {
            for (int eventLeftTxt = 0; eventLeftTxt < 5; eventLeftTxt++)
            {
                doubleEventLeftList[eventLeftId, eventLeftTxt] = eventLeftTextList[listEventLeftNum];
                listEventLeftNum++;
            }
        }

        for (int eventEndingId = 0; eventEndingId < eventEndingTable_In; eventEndingId++)
        {
            for (int eventEndingTxt = 0; eventEndingTxt < 5; eventEndingTxt++)
            {
                doubleEventEndingList[eventEndingId, eventEndingTxt] = eventEndingTextList[listEventEndingNum];
                listEventEndingNum++;
            }
        }

        yield return new WaitForSeconds(1f);
    }
}