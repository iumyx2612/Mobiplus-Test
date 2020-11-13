using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChooser : MonoBehaviour
{   
    public int characterChoice;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void A4_1Confirm()
    {
        Debug.Log("A4(1)");
        characterChoice = 0;
        PlayerPrefs.SetInt("Chosen lv4", characterChoice);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void A4_2Confirm()
    {
        Debug.Log("A4(2)");
        characterChoice = 1;
        PlayerPrefs.SetInt("Chosen lv4", characterChoice);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
