using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] List<Monster> monsters;
    [SerializeField] List<Transform> spawnpoints;
    [SerializeField] public GameObject target;
    List<Monster> activeMonsters;

    [SerializeField] public List<SpawnPackage> spawns;


    public class SpawnPackage
    {
        public float spawnBeat;
        public int spawnpointIndex;
        public int monsterIndex;
    }

    public void SpawnMonster(int nextIndex)
    {
        var newMonster = Instantiate(monsters[spawns[nextIndex].monsterIndex],
                            spawnpoints[spawns[nextIndex].spawnpointIndex].position,
                            Quaternion.identity).GetComponent<Monster>();
        newMonster.targetPosition = target.transform.position;
        newMonster.beatOfThisNote = spawns[nextIndex].spawnBeat;
        newMonster.beatsInAdvance = beatsShownInAdvance;
        newMonster.songPosInBeats = songPositionInBeats;

        activeMonsters.Add(newMonster);
    }
}
