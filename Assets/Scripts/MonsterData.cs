using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster/Monster Data")]
public class MonsterData : ScriptableObject
{
    public int level;
    public int money;
    public Sprite monsterSprite;
    public MonsterParticle monsterParticle;
}
