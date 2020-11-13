using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDisplay : MonoBehaviour
{
    [SerializeField]
    public Monster monster;
    [SerializeField]
    public Text monsterName;
    [SerializeField]
    public Image art;    

    private void Update()
    {
        monsterName.text = monster.monsterData.monsterName;
        art.sprite = monster.monsterData.monsterSprite;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }


}
