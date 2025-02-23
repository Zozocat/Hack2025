using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;


    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 4)
        {
            remainingTime -= Time.deltaTime / 25;
        }
        else if (remainingTime < 4)
        {
            remainingTime = 4;

        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        //timerText.text = $"{minutes}:{seconds}";
        timerText.text = (Mathf.Floor(remainingTime * 100f) / 100f).ToString();
    }
}
