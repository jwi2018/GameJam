using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisText : MonoBehaviour
{             
    public List<Text> displayText;
    public List<Text> colon;
    public List<Text> displayNameText;
    private int TextLength;
    private int ranId = 0;
    private int ranTxt = 0;
    private string[] split_text;

    public Text waitText;     // 텍스트 박스 지정 전 대기 텍스트

    void Start()
    {
        StartCoroutine("TextMove");
    }

    IEnumerator TextMove()
    {
        while (true)
        {
            int num = 0;
            ranId = Random.Range(0, 40);
            //ranTxt = Random.Range(1, 3);
            ranTxt = 1;
            waitText.text = CsvRead.doubleDisplayList[ranId, ranTxt];
            TextLength = waitText.text.Length;
            split_text = waitText.text.Split('/');

            yield return new WaitForSeconds(1.5f);

            if (TextLength < 24)
            {
                displayText[num + 2].text = split_text[num];
                colon[num + 2].text = ":";

                if (ranTxt == 1)
                {
                    displayNameText[num + 2].text = "븝미";
                }
                else if (ranTxt == 2)
                {
                    displayNameText[num + 2].text = "플레이어";
                }
                for (int i = 3; i < 1; i++)
                {
                    for (int x = 10; x > 0; x--)
                    {
                        displayText[x].text = displayText[x - 1].text;
                        colon[x].text = colon[x - 1].text;
                        displayNameText[x].text = displayNameText[x - 1].text;
                    }
                }
            }
            else if (TextLength >= 24 && TextLength < 47)
            {
                displayText[num + 2].text = split_text[num];
                displayText[num + 1].text = split_text[num + 1];
                colon[num + 2].text = ":";

                if (ranTxt == 1)
                {
                    displayNameText[num + 2].text = "븝미";
                }
                else if (ranTxt == 2)
                {
                    displayNameText[num + 2].text = "플레이어";
                }
                for (int i = 0; i < 2; i++)
                {
                    for (int x = 10; x > 0; x--)
                    {
                        displayText[x].text = displayText[x - 1].text;
                        colon[x].text = colon[x - 1].text;
                        displayNameText[x].text = displayNameText[x - 1].text;
                    }
                }
            }
            else
            {
                displayText[num + 2].text = split_text[num];
                displayText[num + 1].text = split_text[num + 1];
                displayText[num].text = split_text[num + 2];
                colon[num + 2].text = ":";

                if (ranTxt == 1)
                {
                    displayNameText[num + 2].text = "븝미";
                }
                else if (ranTxt == 2)
                {
                    displayNameText[num + 2].text = "플레이어";
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int x = 10; x > 0; x--)
                    {
                        displayText[x].text = displayText[x - 1].text;
                        colon[x].text = colon[x - 1].text;
                        displayNameText[x].text = displayNameText[x - 1].text;
                    }
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
