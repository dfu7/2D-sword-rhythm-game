using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;



public class PlayerControls : MonoBehaviour
{
    public static PlayerControls Instance;

    public static event Action<string> hitAcc;
    public static event Action<string> hitDir;

    [SerializeField]
    Animator animator;

    [System.Serializable]
    public class Lane
    {
        public Transform SpawnPoint;
        public Transform RingPoint;
        public Transform finalDestination;
        public Queue<Monster> Monsters;
    }

    public List<Lane> Lanes;

    bool[] headsHit = { false, false, false };

    public AudioSource audioSource;
    public AudioClip drum;

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

    void Update()
    {
        foreach (Lane lane in Lanes)
        {
            if (lane.Monsters.Count > 0)
            {
                foreach (Monster monster in lane.Monsters)
                {
                    if (Vector3.Distance(lane.RingPoint.transform.position, monster.transform.position) <= 0)
                    {
                        monster.targetPosition = monster.swordsmanT.transform;
                    }
                    else if (Vector3.Distance(monster.swordsmanT.transform.position, monster.transform.position) <= 0)
                    {
                        if (lane.Monsters.Peek().gameObject.tag == "Dragon")
                        {
                            monster.targetPosition = lane.finalDestination.transform;
                        }
                        // and dragon, set new travel point
                    }
                }

                if (Vector3.Distance(lane.Monsters.Peek().transform.position, lane.Monsters.Peek().targetPosition.position) <= 0)
                {
                    Destroy(lane.Monsters.Dequeue().gameObject);
                    hitAcc?.Invoke("Fail");
                }
            }

        }

    }


    public void Swing(InputAction.CallbackContext context, int lane, string animBoolName, string hitDirName)
    {
        if (context.interaction is TapInteraction)
        {
            if (context.started)
            {
                audioSource.PlayOneShot(drum);
                hitDir?.Invoke(hitDirName);
                animator.SetBool(animBoolName, true);

                if (Lanes[lane].Monsters.Count > 0 && !headsHit[lane])
                {
                    float d = Vector3.Distance(Lanes[lane].RingPoint.position, Lanes[lane].Monsters.Peek().transform.Find("target").position);
                    //Debug.Log(animBoolName + ": " + d);
                    CheckDistance(d, lane);
                }
                else
                {
                    //Debug.Log("Miss");
                    hitAcc?.Invoke("Miss");
                }
            }
            if (context.performed)
            {
                //Debug.LogWarning("tap performed");
                animator.SetBool(animBoolName, false);
            }
            if (context.canceled)
            {
                animator.SetBool("LongAttack", true);
                animator.SetBool(animBoolName, false);
            }
        }
        else if (context.interaction is PressInteraction)
        {
            if (context.canceled)
            {
                if (headsHit[lane])
                {
                    float d = Vector3.Distance(Lanes[lane].RingPoint.position, Lanes[lane].Monsters.Peek().transform.Find("tail end").position);
                    Debug.LogWarning(d);
                    CheckDistance(d, lane);
                }
                animator.SetBool("LongAttack", false);
            }
        }
    }
    public void OnLeftSwing(InputAction.CallbackContext context)
    {
        Swing(context, 0, "AttackLeft", "Left");
    }
    public void OnRightSwing(InputAction.CallbackContext context)
    {
        Swing(context, 2, "AttackRight", "Right");
    }
    public void OnUpSwing(InputAction.CallbackContext context)
    {
        Swing(context, 1, "AttackUp", "Up");
    }


    void CheckDistance(float distance, int lane)
    {
        // miss
        if (distance > 0.8)
        {
            //Debug.Log("Miss");
            hitAcc?.Invoke("Miss");
        }
        else
        {
            // perfect
            if (distance <= 0.3)
            {
                Debug.Log("Perfect");
                hitAcc?.Invoke("Perfect");
            }
            // almost
            else if (distance > 0.3 && distance <= 0.8)
            {
                Debug.Log("Almost");
                hitAcc?.Invoke("Almost");
            }

            if (Lanes[lane].Monsters.Peek().gameObject.tag == "Dragon")
            {
                if (headsHit[lane])
                {
                    headsHit[lane] = false;
                }
                else if (!headsHit[lane])
                {
                    headsHit[lane] = true;
                    return;
                }
            }

            Destroy(Lanes[lane].Monsters.Dequeue().gameObject);
        }
    }


    public void OnHoldingEscape(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("Start");
        //Debug.Log("Go back to start menu");
    }
}
