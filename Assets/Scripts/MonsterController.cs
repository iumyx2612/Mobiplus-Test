using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public List<MonsterData> monsterDatas = new List<MonsterData>();
    public GameObject monster;
    public GameObject monsterContainer;
    public List<GameObject> monstersOnScreen = new List<GameObject>();
    public List<int> levels = new List<int>();

    public GameObject newMonsterInfo;

    public GameObject lv4Canvas;
    public List<MonsterData> lv4s = new List<MonsterData>();
    public int choice;
    public bool hasActivated = false;

    private void Start()
    {
        StartCoroutine(lv1Spawner());
    }

    private void Update()
    {
        if (monstersOnScreen.Count >= 2)
        {
            for (int i = 0; i < monstersOnScreen.Count - 1; i++)
            {
                int levelCheck = monstersOnScreen[i].GetComponent<Monster>().level;               
                for (int j = i + 1; j < monstersOnScreen.Count; j++)
                {             
                    if(monstersOnScreen[j].GetComponent<Monster>().level == levelCheck)
                    {                        
                        if (levelCheck == 3)
                        {
                            if(!hasActivated)
                            {
                                lv4Canvas.SetActive(true);
                                hasActivated = true;
                                choice = PlayerPrefs.GetInt("Lv4 Chooser");
                                Vector3 position = new Vector3(monsterContainer.transform.position.x + Random.Range(-4, 4), monsterContainer.transform.position.y, transform.position.z);
                                GameObject newMonster = Instantiate(monster, position, Quaternion.identity);
                                newMonster.GetComponent<Monster>().LoadMonsterData(lv4s[choice]);
                                newMonster.transform.parent = monsterContainer.transform;
                                newMonster.SetActive(false);
                                monstersOnScreen.Add(newMonster);
                                DestroyMonsters(monstersOnScreen[i], monstersOnScreen[j], newMonster);
                                monstersOnScreen.RemoveAt(i);
                                monstersOnScreen.RemoveAt(i);
                                levels.Add(levelCheck);
                                CanvasActive(lv4s[choice]);
                                monsterDatas.Add(lv4s[choice]);
                                break;
                            }                            
                        }                        
                        {
                            Vector3 position = new Vector3(monsterContainer.transform.position.x + Random.Range(-4, 4), monsterContainer.transform.position.y, transform.position.z);
                            GameObject newMonster = Instantiate(monster, position, Quaternion.identity);
                            newMonster.GetComponent<Monster>().LoadMonsterData(monsterDatas[levelCheck]);
                            newMonster.transform.parent = monsterContainer.transform;
                            newMonster.SetActive(false);
                            monstersOnScreen.Add(newMonster);
                            DestroyMonsters(monstersOnScreen[i], monstersOnScreen[j], newMonster);
                            monstersOnScreen.RemoveAt(i);
                            monstersOnScreen.RemoveAt(i);
                            if (!levels.Contains(levelCheck))
                            {
                                levels.Add(levelCheck);
                                CanvasActive(monsterDatas[levelCheck]);
                            }
                            break;
                        }
                        
                    }
                }
            }
        }
    }

    IEnumerator lv1Spawner()
    {
        while(true)
        {
            GameObject lv1Monster = Instantiate(monster, monsterContainer.transform);
            lv1Monster.GetComponent<Monster>().LoadMonsterData(monsterDatas[0]);
            monstersOnScreen.Add(lv1Monster);
            yield return new WaitForSeconds(2f);
        }        
    }

    void DestroyMonsters(GameObject monster1, GameObject monster2, GameObject newMonster)
    {
        Destroy(monster1);
        Destroy(monster2);
        newMonster.SetActive(true);
    }

    void CanvasActive(MonsterData monsterData)
    {        
        newMonsterInfo.SetActive(true);
        FindObjectOfType<MonsterDisplay>().monsterData = monsterData;   
        Time.timeScale = 0f;
    }
}
