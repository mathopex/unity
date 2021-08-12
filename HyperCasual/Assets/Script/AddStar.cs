using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AddStar : MonoBehaviour
{
    private int starCount;
    public Text star;

    public void AddStars(int count)
    {
        starCount += count;
        UpdateStarUi();

    }

    public void UpdateStarUi()
    {
        star.text = starCount.ToString();
    }
}
