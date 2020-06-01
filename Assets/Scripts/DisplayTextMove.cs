using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTextMove : MonoBehaviour
{
    public RectTransform displayTop, displayMid, displayBot;
    public List<Text> displayTopText;
    public List<Text> displayMidText;
    public List<Text> displayBotText;
    private int ranId = 0;
    private int ranTxt = 0;
    private float speed = 10.0f;

    void Awake()
    {
        StartCoroutine("DisplayTopTextReset");
        StartCoroutine("DisplayMidTextReset");
        StartCoroutine("DisplayBotTextReset");
        StartCoroutine("TextBoxMove");
    }

    void Update()
    {
        if (displayTop.anchoredPosition.y >= 150.0f)
        {
            StartCoroutine("DisplayTopTextReset");
            displayTop.anchoredPosition = new Vector2(-3, -150f);
        }
        if (displayMid.anchoredPosition.y >= 150.0f)
        {
            StartCoroutine("DisplayMidTextReset");
            displayMid.anchoredPosition = new Vector2(-3, -150f);
        }
        if (displayBot.anchoredPosition.y >= 150.0f)
        {
            StartCoroutine("DisplayBotTextReset");
            displayBot.anchoredPosition = new Vector2(-3, -150f);
        }
    }

    IEnumerator TextBoxMove()
    {
        while(true)
        {
            for (int pos = 0; pos < 50; pos++)
            {
                displayTop.anchoredPosition = new Vector2(-3, displayTop.anchoredPosition.y + 0.1f);
                displayMid.anchoredPosition = new Vector2(-3, displayMid.anchoredPosition.y + 0.1f);
                displayBot.anchoredPosition = new Vector2(-3, displayBot.anchoredPosition.y + 0.1f);
                yield return new WaitForSecondsRealtime(0.01f);
            }
            yield return new WaitForSecondsRealtime(1.0f);
        }
    }

    IEnumerator DisplayTopTextReset()
    {
        yield return new WaitForSeconds(0.5f);
        for (int top=0; top < displayTopText.Count; top++)
        {
            ranId = Random.Range(0, 40);
            ranTxt = Random.Range(1, 3);
            displayTopText[top].text = CsvRead.doubleDisplayList[ranId, ranTxt];
        }
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator DisplayMidTextReset()
    {
        yield return new WaitForSeconds(0.5f);
        for (int mid = 0; mid < displayMidText.Count; mid++)
        {
            ranId = Random.Range(0, 40);
            ranTxt = Random.Range(1, 3);
            displayMidText[mid].text = CsvRead.doubleDisplayList[ranId, ranTxt];
        }
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator DisplayBotTextReset()
    {
        yield return new WaitForSeconds(0.5f);
        for (int bot = 0; bot < displayBotText.Count; bot++)
        {
            ranId = Random.Range(0, 40);
            ranTxt = Random.Range(1, 3);
            displayBotText[bot].text = CsvRead.doubleDisplayList[ranId, ranTxt];
        }
        yield return new WaitForSeconds(0.5f);
    }
}