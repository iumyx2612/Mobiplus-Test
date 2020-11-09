using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;
    public int level;
    public Text moneyText;
    public Image artwork;
    public ParticleSystem monsterParticleSystem;
    public List<Text> tempTextList;

    private void Awake()
    {
        level = monsterData.level;
        moneyText.text = monsterData.money.ToString();
        artwork.sprite = monsterData.monsterSprite;
        monsterParticleSystem = monsterData.monsterParticle.particleSystem;
        tempTextList = new List<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        moneyText.gameObject.SetActive(false);        
    }
    
    private void OnMouseDown()
    {
        if(!moneyText.IsActive())
        {
            moneyText.gameObject.SetActive(true);
            Text tempText = Instantiate(moneyText, transform.position, transform.rotation) as Text;
            tempText.transform.SetParent(transform, false);
            tempTextList.Add(tempText);
            Invoke("TextDisappear", 0.5f);
        }
    }

    private void Update()
    {
        
    }

    void TextDisappear()
    {
        moneyText.gameObject.SetActive(false);
        Destroy(tempTextList[0].gameObject);
        tempTextList.RemoveAt(0);  
    }

    
}
