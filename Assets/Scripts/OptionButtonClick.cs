using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButtonClick : MonoBehaviour
{
    int liking = 0;
    int optionPoint = 0;
    int loveIntFir = 0;
    int pointIntFir = 0;
    string loveStringFir = "0";
    string pointStringFir = "0";
    int loveIntSec = 0;
    int pointIntSec = 0;
    string loveStringSec = "0";
    string pointStringSec = "0";
    int num = 0;
    public Button optionButtonFir;
    public Button optionButtonSec;
    int loveBarCur = 0;

    public void OnClickFirOptionButton()        // 1번째 버튼 클릭 시 발생해야 하는 상황
    {
        liking = Save.Liking;
        optionPoint = Save.optionPoint;

        loveStringFir = CsvRead.doubleChatOptionList[num, 3];
        loveIntFir = int.Parse(loveStringFir);
        pointStringFir = CsvRead.doubleChatOptionList[num, 5];
        pointIntFir = int.Parse(pointStringFir);

        Save.Liking += loveIntFir;
        LoveBarContraller.curLike += loveIntFir;
        Save.optionPoint += pointIntFir;

        num++;
        //Time.timeScale = 1.0f;
    }
    public void OnClickSecOptionButton()       // 2번째 버튼 클릭 시 발생해야 하는 상황
    {
        liking = Save.Liking;
        optionPoint = Save.optionPoint;

        loveStringSec = CsvRead.doubleChatOptionList[num, 4];
        loveIntSec = int.Parse(loveStringSec);

        pointStringSec = CsvRead.doubleChatOptionList[num, 6];
        pointIntSec = int.Parse(pointStringSec);

        Save.Liking += loveIntSec;
        LoveBarContraller.curLike += loveIntSec;
        Save.optionPoint += pointIntSec;

        num++;
        //Time.timeScale = 1.0f;
    }
}
