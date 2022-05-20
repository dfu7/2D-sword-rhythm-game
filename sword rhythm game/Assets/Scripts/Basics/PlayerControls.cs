using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    public static PlayerControls Instance;

    public delegate void HitAcc(string test);
    public HitAcc hitAcc;

    [System.Serializable]
    public class Lane
    {
        public Transform SpawnPoint;
        public Transform RingPoint;
        public Queue<Monster> Monsters;
    }

    public List<Lane> Lanes;

    //float timeSinceLeftPressed = 0;
    //float timeSinceRightPressed = 0;

    private void Start()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        foreach (Lane lane in Lanes)
        {
            lane.Monsters = new Queue<Monster>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.D))
        {
            timeSinceLeftPressed = 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
        {
            timeSinceRightPressed = 0.1f;
        }

        timeSinceLeftPressed = Mathf.Clamp01(timeSinceLeftPressed - Time.deltaTime);
        timeSinceRightPressed = Mathf.Clamp01(timeSinceRightPressed - Time.deltaTime);

        if (timeSinceLeftPressed > 0 && timeSinceRightPressed > 0)
        {
            OnUpSwing();
        }
        else if (timeSinceLeftPressed > 0)
        {
            OnLeftSwing();
        }
        else if (timeSinceRightPressed > 0)
        {
            OnRightSwing();
        }
        */

        foreach (Lane lane in Lanes)
        {
            if (lane.Monsters.Count > 0 && Vector3.Distance(lane.RingPoint.position, lane.Monsters.Peek().transform.position) <= 0)
            {
                // TODO: Miss
                //Destroy(lane.Monsters.Dequeue());
                // miss actions
            }
            
        }
    }

    void OnLeftSwing()
    {
        // used notif
        if (Lanes[0].Monsters.Count == 0)
        {
            return;
        }

        float d = Vector3.Distance(Lanes[0].RingPoint.position, Lanes[0].Monsters.Peek().transform.position);
        Debug.Log("left swing: " + d);
        CheckDistance(d, 0);
    }

    void OnRightSwing()
    {
        // used notif
        if (Lanes[2].Monsters.Count == 0)
        {
            return;
        }

        float d = Vector3.Distance(Lanes[2].RingPoint.position, Lanes[2].Monsters.Peek().transform.position);
        Debug.Log("right swing: " + d);

        CheckDistance(d, 2);
    }

    void OnUpSwing()
    {
        // used notif
        if (Lanes[1].Monsters.Count == 0)
        {
            return;
        }

        float d = Vector3.Distance(Lanes[1].RingPoint.position, Lanes[1].Monsters.Peek().transform.position);
        Debug.Log("center swing: " + d);

        CheckDistance(d, 1);
    }

    void CheckDistance(float distance, int lane)
    {
        if (distance > 0.8)
        {
            Debug.Log("Miss");
            hitAcc?.Invoke("Miss");
        }
        else
        {
            if (distance <= 0.3)
            {
                Debug.Log("Perfect");
                hitAcc?.Invoke("Perfect");
                // perfect notif + actions

            }
            else if (distance > 0.3 && distance <= 0.8)
            {
                Debug.Log("Almost");
                hitAcc?.Invoke("Almost");
                // late notif + actions
            }

            //Destroy(Lanes[lane].Monsters.Dequeue());
        }
    }
}
