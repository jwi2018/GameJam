using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIButton : MonoBehaviour
{
    public Image ShopUI;
    //public Image ShopUIClose;
    public Image ShopUIOpen;
   
    void Start()
    {
        ShopUI.gameObject.SetActive(false);
        ShopUIOpen.gameObject.SetActive(true);
    }

    /*
    public void OnClickShopUIOpenButton()
    {
        ShopUIOpenButton.gameObject.SetActive(false);
        ShopUI.gameObject.SetActive(true);
    }
    
    public void OnClickShopUICloseButton()
    {
        ShopUI.gameObject.SetActive(false);
        ShopUIOpenButton.gameObject.SetActive(true);
    }
    */
}