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
    [SerializeField] Transform leftRingPoint;
    [SerializeField] Transform centerRingPoint;
    [SerializeField] Transform rightRingPoint;

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

        if (Input.GetKeyDown(KeyCode.J) && Input.GetKeyDown(KeyCode.F))
        {
            // used notif

            float d = Vector3.Distance(leftRingPoint.position, activeMonster.GetComponent<Transform>().position);
            Debug.Log("center swing: " + d);

            CheckDistance(d);
        }

        if (Vector3.Distance(target.transform.position, activeMonster.GetComponent<Transform>().position) <= 0)
        {
            Debug.Log("Hit");
            Destroy(activeMonster.gameObject);
            //activeMonster = null;
            monsterActive = false;
        }
    }

    void OnLeftSwing()
    {
        // used notif

        float d = Vector3.Distance(leftRingPoint.position, activeMonster.GetComponent<Transform>().position);
        Debug.Log("left swing: " + d);
        CheckDistance(d);
    }

    void OnRightSwing()
    {
        // used notif

        float d = Vector3.Distance(rightRingPoint.position, activeMonster.GetComponent<Transform>().position);
        Debug.Log("right swing: " + d);

        CheckDistance(d);
    }

    void CheckDistance(float distance)
    {
        if (distance > 0.8)
        {
            Debug.Log("Miss");
            // miss notif
        }
        else
        {
            if (distance <= 0.3)
            {
                Debug.Log("Perfect");
                // perfect notif + actions

            }
            else if (distance > 0.3 && distance <= 0.8)
            {
                Debug.Log("Late");
                // late notif + actions
            }

            DestroyMonster();
            Debug.Log("Destroy");
        }
    }

    void DestroyMonster()
    {
        Destroy(activeMonster.gameObject);
        monsterActive = false;
    }
}
