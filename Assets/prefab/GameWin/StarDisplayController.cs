using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplayController : MonoBehaviour
{
    public Image star1;
    public Image star2;
    public Image star3;

    public Sprite filledStar; // Sprite cho ngôi sao đầy
    public Sprite emptyStar; // Sprite cho ngôi sao trống

   // private int currentStarCount = 0;

    void Start()
    {
        // Đặt sprite ban đầu cho các ngôi sao là ngôi sao trống
        star1.sprite = emptyStar;
        star2.sprite = emptyStar;
        star3.sprite = emptyStar;
    }

    /*public void ShowNextStar()
    {
        if (currentStarCount < 3)
        {
            currentStarCount++;
            UpdateStarDisplay();
        }
    }*/

    private void Update()
    {
        if (SconeManager.instance.countEnemyDesTroy == 2) { star1.sprite = filledStar; }
        if (SconeManager.instance.countEnemyDesTroy == 1)
        {
            star1.sprite = filledStar;
            star2.sprite = filledStar;
        }
        if (SconeManager.instance.countEnemyDesTroy == 0)
        {
            star1.sprite = filledStar;
            star2.sprite = filledStar;
            star3.sprite = filledStar;
        }
    }
}
