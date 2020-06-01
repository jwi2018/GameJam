using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CsvRead : MonoBehaviour
{
    public int disTableId_In = 0;       // 전광판
    public int chatTableId_In = 0;      // 클릭 시 캐릭터 대사창
    public int chatOptionTable_In = 0;      // 클릭 시 캐릭터 대사창 선택지
    public static int disTableId = 0;
    public static int chatTableId = 0;
    public static int chatOptionTableId = 0;
    public TextAsset display_Table, chat_Table, chat_Option_Table;
    string fileFullPathChat, fileFullPathDisplay , fileFullPathChatOption;

    public static string[,] doubleDisplayList; //  [id][내용1&2]
    public static string[,] doubleChatList;
    public static string[,] doubleChatOptionList;
    void Start()
    {
        disTableId = disTableId_In;
        chatTableId = chatTableId_In;
        chatOptionTableId = chatOptionTable_In;
        fileFullPathChat = chat_Table.text;
        fileFullPathDisplay = display_Table.text;
        fileFullPathChatOption = chat_Option_Table.text;
        StartCoroutine("InputCsvArr");
    }

    IEnumerator InputCsvArr()
    {
        string[] chatList = fileFullPathChat.Split('\n', ',');    
        string[] displayList = fileFullPathDisplay.Split('\n', ',');
        string[] chatOptionList = fileFullPathChatOption.Split('\n', ',');
        doubleDisplayList = new string[disTableId, 3]; 
        doubleChatList = new string[chatTableId, 6];
        doubleChatOptionList = new string[chatOptionTableId, 7];
        int listChatNum = 0;    
        int listTableNum = 0;
        int listChatOptionNum = 0;

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
        
        yield return new WaitForSeconds(1f);
    }
}