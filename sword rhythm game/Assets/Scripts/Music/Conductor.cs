using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    #region music vars
    // music
    public float songBpm;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public float dspSongTime;
    public int beatsShownInAdvance = 3;
    public AudioSource musicSource;
    int nextIndex = 0;
    #endregion

    [System.Serializable]
    private class SpawnPackage
    {
        public float spawnBeat;
        public int spawnpointIndex;
        public int monsterIndex;
    }

    [SerializeField] private List<SpawnPackage> spawns;

    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();
    }

    #region monster vars
    // monster

    #endregion

    void Update()
    {
        #region music
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
        #endregion

        if (nextIndex < spawns.Count && spawns[nextIndex].spawnBeat < songPositionInBeats + beatsShownInAdvance)
        {
            // SPAWN MONSTER HERE 
            //initialize the fields of the music note

            nextIndex++;
        }

        #region controls
        if (activeMonsters[0].ring == "perf" && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Hit");
            activeMonsters.RemoveAt(0);
        }

        if (activeMonsters[0].ring == "miss")
        {
            activeMonsters.RemoveAt(0);
        }
        #endregion
    }
}
