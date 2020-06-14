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

    public static int disTableId = 0;
    public static int chatTableId = 0;
    public static int chatOptionTableId = 0;
    public static int eventTableId = 0;
    public static int eventTextTableId = 0;

    public TextAsset display_Table, chat_Table, chat_Option_Table, event_Table, event_TextTable;

    string fileFullPathChat, fileFullPathDisplay , fileFullPathChatOption, fileFullPathEvent, fileFullPathEventText;

    public static string[,] doubleDisplayList; //  [id][내용1&2]
    public static string[,] doubleChatList;
    public static string[,] doubleChatOptionList;
    public static string[,] doubleEventList;
    public static string[,] doubleEventTextList;
    void Start()
    {
        disTableId = disTableId_In;
        chatTableId = chatTableId_In;
        chatOptionTableId = chatOptionTable_In;
        eventTableId = eventTable_In;
        eventTextTableId = eventTextTable_In;

        fileFullPathChat = chat_Table.text;
        fileFullPathDisplay = display_Table.text;
        fileFullPathChatOption = chat_Option_Table.text;
        fileFullPathEvent = event_Table.text;
        fileFullPathEventText = event_TextTable.text;

        StartCoroutine("InputCsvArr");
    }

    IEnumerator InputCsvArr()
    {
        string[] chatList = fileFullPathChat.Split('\n', ',');    
        string[] displayList = fileFullPathDisplay.Split('\n', ',');
        string[] chatOptionList = fileFullPathChatOption.Split('\n', ',');
        string[] eventList = fileFullPathEvent.Split('\n', ',');
        string[] eventTextList = fileFullPathEventText.Split('\n', ',');

        doubleDisplayList = new string[disTableId, 3]; 
        doubleChatList = new string[chatTableId, 6];
        doubleChatOptionList = new string[chatOptionTableId, 7];
        doubleEventList = new string[eventTableId, 5];
        doubleEventTextList = new string[eventTextTableId, 5];

        int listChatNum = 0;    
        int listTableNum = 0;
        int listChatOptionNum = 0;
        int listEventNum = 0;
        int listEventTextNum = 0;


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

        for (int eventTextId = 0; eventTextId < eventTableId; eventTextId++)
        {
            for (int eventTextTxt = 0; eventTextTxt < 5; eventTextTxt++)
            {
                doubleEventList[eventTextId, eventTextTxt] = eventList[listEventTextNum];
                listEventTextNum++;
            }
        }

        yield return new WaitForSeconds(1f);
    }
}