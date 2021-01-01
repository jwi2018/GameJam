using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class CGPlay : MonoBehaviour
{
    public static CGPlay cgPlay;

    public SpriteAtlas eventCg;
    public Image cgImage;
    public Image cgImageBg;
    //public Button cgImageButton;

    void Start()
    {
        cgImage.gameObject.SetActive(false);
        cgImageBg.gameObject.SetActive(false);
        //cgImageButton.gameObject.SetActive(false);
    }

    public void EventCgPlay()
    {
        if (GameManager.divEventInt == 1)
        {
            string eventRightCgName = CsvRead.doubleEventRightList[GameManager.eventRightListId, 3];
            cgImage.sprite = eventCg.GetSprite(eventRightCgName);
        }
        else if (GameManager.divEventInt == 2)
        {
            string eventLeftCgName = CsvRead.doubleEventLeftList[GameManager.eventLeftListId, 3];
            cgImage.sprite = eventCg.GetSprite(eventLeftCgName);
        }
        //string eventCgName = CsvRead.doubleEventList[GameManager.eventListId, 3];
        //cgImage.sprite = eventCg.GetSprite(eventCgName);

        cgImage.gameObject.SetActive(true);
        cgImageBg.gameObject.SetActive(true);
        //cgImageButton.gameObject.SetActive(true);
    }

    public void EventEndingCgPlay()
    {

        if (Save.optionPoint == 1)
        {
            string eventFirEndingCgName = CsvRead.doubleEventEndingList[GameManager.eventFirEndingListId, 3];
            cgImage.sprite = eventCg.GetSprite(eventFirEndingCgName);
        }
        else if (Save.optionPoint == 3)
        {
            string eventSecEndingCgName = CsvRead.doubleEventEndingList[GameManager.eventSecEndingListId, 3];
            cgImage.sprite = eventCg.GetSprite(eventSecEndingCgName);
        }
        else if (Save.optionPoint == 5)
        {
            string eventThrEndingCgName = CsvRead.doubleEventEndingList[GameManager.eventThrEndingListId, 3];
            cgImage.sprite = eventCg.GetSprite(eventThrEndingCgName);
        }

        cgImage.gameObject.SetActive(true);
        cgImageBg.gameObject.SetActive(true);
        //cgImageButton.gameObject.SetActive(true);
    }

    public void EventCgClose()
    {
        cgImage.gameObject.SetActive(false);
        cgImageBg.gameObject.SetActive(false);
        //cgImageButton.gameObject.SetActive(false);
    }
}