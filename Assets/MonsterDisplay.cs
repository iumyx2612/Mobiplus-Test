using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDisplay : MonoBehaviour
{    
    public MonsterData monsterData;
    public Text monsterName;
    public Image art;    

    private void Update()
    {
        monsterName.text = monsterData.monsterName;
        art.sprite = monsterData.monsterSprite;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
