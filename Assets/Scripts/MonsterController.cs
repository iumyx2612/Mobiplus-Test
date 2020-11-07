using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> monsters;
    private Monster monster;
    [SerializeField]
    private GameObject level1Monster;
    private GameObject monsterContainer;
    private List<GameObject> monstersOnScreen;

    private float timer = 0f;
    private float waitingTime = 100f;
    // Start is called before the first frame update
    private void Awake()
    {
        monstersOnScreen = new List<GameObject>();
        monsterContainer = GameObject.Find("Monster Container");
    }
    void Start()
    {
        StartCoroutine(MonsterSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        Merge();
    }

    IEnumerator MonsterSpawn()
    {
        while (true)
        {
            Vector3 position = new Vector3(monsterContainer.transform.position.x + Random.Range(-4, 4), monsterContainer.transform.position.y, transform.position.z);
            GameObject newMonster = Instantiate(level1Monster, position, Quaternion.identity) as GameObject;
            newMonster.transform.parent = monsterContainer.transform;
            monstersOnScreen.Add(newMonster);
            yield return new WaitForSeconds(5f);
        }
    }

    void Merge()
    {
        if (monstersOnScreen.Count >= 2)
        {
            for (int i = 0; i < monstersOnScreen.Count - 1; i++)
            {
                int levelCheck = monstersOnScreen[i].GetComponent<Monster>().level;
                for (int j = i + 1; j < monstersOnScreen.Count; j++)
                {
                    if (monstersOnScreen[j].GetComponent<Monster>().level == levelCheck)
                    {
                        Vector3 position = new Vector3(monsterContainer.transform.position.x + Random.Range(-4, 4), monsterContainer.transform.position.y, transform.position.z);
                        GameObject newMonster = Instantiate(monsters[levelCheck], position, Quaternion.identity);
                        newMonster.transform.parent = monsterContainer.transform;
                        newMonster.SetActive(false);
                        monstersOnScreen.Add(newMonster);
                        while(timer < waitingTime)
                        {
                            timer += Time.deltaTime;
                        }                        
                        Destroy(monstersOnScreen[i]);
                        Destroy(monstersOnScreen[j]);
                        monstersOnScreen.RemoveAt(i);
                        monstersOnScreen.RemoveAt(i);
                        newMonster.SetActive(true);
                        break;
                    }                    
                }
            }
        }
    }    
}
