using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> monsters = new List<GameObject>();
    private Monster monster;
    [SerializeField]
    private GameObject level1Monster;
    private GameObject monsterContainer;
    private List<GameObject> monstersOnScreen = new List<GameObject>();
    private List<int> levels = new List<int>();

    [SerializeField]
    private GameObject monsterCanvas;

    [SerializeField]
    private GameObject lv4Canvas;
    public int characterChoice;
    public bool hasActivated = false;
    [SerializeField]
    private List<GameObject> lv4s = new List<GameObject>();

    public bool gameisPause = false;
    // Start is called before the first frame update
    private void Awake()
    {
        monsterContainer = GameObject.Find("Monster Container");
    }
    void Start()
    {
        StartCoroutine(MonsterSpawn());
    }

    // Update is called once per frame
    void FixedUpdate()
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
                        if (levelCheck == 3)
                        {
                            if (!hasActivated)
                            {
                                lv4Canvas.SetActive(true);
                                hasActivated = true;
                            }
                            characterChoice = PlayerPrefs.GetInt("Chosen lv4");
                            Vector3 position = new Vector3(monsterContainer.transform.position.x + Random.Range(-4, 4), monsterContainer.transform.position.y, transform.position.z);
                            GameObject newMonster = Instantiate(lv4s[characterChoice], position, Quaternion.identity);
                            newMonster.transform.parent = monsterContainer.transform;
                            newMonster.SetActive(false);
                            monstersOnScreen.Add(newMonster);
                            DestroyMonsters(monstersOnScreen[i], monstersOnScreen[j], newMonster);
                            monstersOnScreen.RemoveAt(i);
                            monstersOnScreen.RemoveAt(i);
                            if (!levels.Contains(levelCheck))
                            {
                                levels.Add(levelCheck);
                                //monsterCanvas.SetActive(true);
                                //FindObjectOfType<MonsterDisplay>().monster = newMonster.GetComponent<Monster>();
                                //Time.timeScale = 0f;
                                CanvasActive(newMonster);
                            }
                            Instantiate(newMonster.GetComponent<Monster>().monsterParticleSystem, newMonster.transform);
                            break;
                        }
                        else
                        {
                            Vector3 position = new Vector3(monsterContainer.transform.position.x + Random.Range(-4, 4), monsterContainer.transform.position.y, transform.position.z);
                            GameObject newMonster = Instantiate(monsters[levelCheck], position, Quaternion.identity);
                            newMonster.transform.parent = monsterContainer.transform;
                            newMonster.SetActive(false);
                            monstersOnScreen.Add(newMonster);
                            DestroyMonsters(monstersOnScreen[i], monstersOnScreen[j], newMonster);
                            monstersOnScreen.RemoveAt(i);
                            monstersOnScreen.RemoveAt(i);
                            if (!levels.Contains(levelCheck))
                            {
                                levels.Add(levelCheck);
                                //monsterCanvas.SetActive(true);
                                //FindObjectOfType<MonsterDisplay>().monster = newMonster.GetComponent<Monster>();
                                //Time.timeScale = 0f;
                                CanvasActive(newMonster);
                            }
                            Instantiate(newMonster.GetComponent<Monster>().monsterParticleSystem, newMonster.transform);
                            break;
                        }
                    }
                        
                }
            }
        }
    }

    IEnumerator MonsterSpawn()
    {
        while (true)
        {
            Vector3 position = new Vector3(monsterContainer.transform.position.x + Random.Range(-4, 4), monsterContainer.transform.position.y, transform.position.z);
            GameObject newMonster = Instantiate(level1Monster, position, Quaternion.identity) as GameObject;
            newMonster.transform.parent = monsterContainer.transform;
            monstersOnScreen.Add(newMonster);
            yield return new WaitForSeconds(1f);
        }
    }

    void DestroyMonsters(GameObject monster1, GameObject monster2, GameObject newMonster)
    {
        Destroy(monster1);
        Destroy(monster2);
        newMonster.SetActive(true);
    }

    void CanvasActive(GameObject _monster)
    {
        monsterCanvas.SetActive(true);
        FindObjectOfType<MonsterDisplay>().monster = _monster.GetComponent<Monster>();
        Time.timeScale = 0f;
    }
}

