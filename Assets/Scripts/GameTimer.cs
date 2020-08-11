using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    [Tooltip("Level timer in seconds")] 
    [SerializeField] float levelTime = 10f;
    [SerializeField] float spawnTime;
    bool triggeredLevelFinished = false;
    
    void Start()
    {
        spawnTime = PlayerPrefsController.GetDifficulty() + levelTime;
    }
    void Update()
    {
        if (triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / spawnTime;

        bool timerFinished = (Time.timeSinceLevelLoad > spawnTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
