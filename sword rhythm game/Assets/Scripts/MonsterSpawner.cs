using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> monsters;
    [SerializeField] List<Transform> spawnpoints;
    [SerializeField] List<Transform> targets;
    int nextIndex = 0;

    [SerializeField] public List<SpawnPackage> spawns;

    private Conductor m_conductor;

    [System.Serializable]
    public struct SpawnPackage
    {
        public float spawnBeat;
        public int laneIndex;
        public int monsterIndex;
    }

    public void SpawnMonster(int nextIndex)
    {
        var newMonster = Instantiate(monsters[spawns[nextIndex].monsterIndex],
                            PlayerControls.Instance.Lanes[spawns[nextIndex].laneIndex].SpawnPoint.position,
                            Quaternion.identity).GetComponent<Monster>();
        newMonster.targetPosition = targets[spawns[nextIndex].laneIndex];
        PlayerControls.Instance.Lanes[spawns[nextIndex].laneIndex].Monsters.Enqueue(newMonster);
    }

    private void Awake()
    {
        m_conductor = FindObjectOfType<Conductor>();
    }

    private void Update()
    {
        if (nextIndex < spawns.Count && spawns[nextIndex].spawnBeat < m_conductor.songPositionInBeats + m_conductor.beatsShownInAdvance)
        {
            SpawnMonster(nextIndex);

            nextIndex++;
        }
    }
}
