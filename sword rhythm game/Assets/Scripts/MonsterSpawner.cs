using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    bool monsterActive = false;
    [SerializeField] GameObject monster;
    [SerializeField] float spawnMin;
    [SerializeField] float spawnMax;
    [SerializeField] List<Transform> spawnpoints;
    [SerializeField] float spawnY;
    [SerializeField] GameObject target;
    public float timeToTarget = 3;

    private Monster activeMonster;


    // Update is called once per frame
    void Update()
    {
        if (!monsterActive)
        {
            monsterActive = true;

            activeMonster = Instantiate(monster, spawnpoints[Random.Range(0, 3)].position, Quaternion.identity).GetComponent<Monster>();
            activeMonster.canMove = true;
            activeMonster.targetPosition = target.transform.position;
            activeMonster.timeToReachTarget = timeToTarget;
        }

        if (activeMonster.ring == "perf" && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Hit");
            Destroy(activeMonster.gameObject);
            //activeMonster = null;
            monsterActive = false;
        }

        if (activeMonster.ring == "miss")
        {
            Destroy(activeMonster.gameObject);
            //activeMonster = null;
            monsterActive = false;
        }
    }
}
