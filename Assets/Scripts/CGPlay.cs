using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class CGPlay : MonoBehaviour
{
    public SpriteAtlas eventCg;
    public Image cgImage;

    void Start()
    {
        GameManager.gameManager.cg_Play += EventCgPlay;
    }
    
    public void EventCgPlay()
    {
        string eventCgName = CsvRead.doubleEventList[GameManager.eventListId, 3];

        cgImage.sprite = eventCg.GetSprite(eventCgName);
    }
}