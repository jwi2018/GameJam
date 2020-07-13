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

    void Start()
    {
        cgImage.gameObject.SetActive(false);
    }
    
    public void EventCgPlay()
    {
        string eventCgName = CsvRead.doubleEventList[GameManager.eventListId, 3];
        cgImage.sprite = eventCg.GetSprite(eventCgName);

        cgImage.gameObject.SetActive(true);
    }

    public void EventCgClose()
    {
        cgImage.gameObject.SetActive(false);
    }
}