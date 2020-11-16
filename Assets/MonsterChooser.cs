using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChooser : MonoBehaviour
{
    public GameObject lv4Canvas;
    public int choice;

    private void Awake()
    {
        Time.timeScale = 0f;
        PlayerPrefs.GetInt("Lv4 Chooser");
    }

    public void MonsterSelect(int _choice)
    {
        PlayerPrefs.SetInt("Lv4 Chooser", _choice);
        lv4Canvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
