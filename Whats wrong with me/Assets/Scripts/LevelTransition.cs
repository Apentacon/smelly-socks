using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public List<GameObject> Levels;
    public List<GameObject> SpawnPoints;
    public float camPanDuration;
    private Vector3 NextLevelPosition;
    private Vector3 PreviousLevelPosition;
    private Vector3 SpawnPointPosition;


    private void Start()
    {
        NextLevelPosition = Levels[1].transform.position;
        PreviousLevelPosition = Levels[0].transform.position;
        SpawnPointPosition = SpawnPoints[0].transform.position;
    }
    
    public void LevelSwitch()
    {
        StartCoroutine(LerpToPosition(camPanDuration, NextLevelPosition, true));
    }
 
    IEnumerator LerpToPosition(float lerpSpeed, Vector3 newPosition, bool useRelativeSpeed = false)
    {    
        if (useRelativeSpeed)
        {
            float totalDistance = PreviousLevelPosition.x - NextLevelPosition.x;
            float diff = Camera.transform.position.x - NextLevelPosition.x;
            float multiplier = diff / totalDistance;
            lerpSpeed *= multiplier;
        }
 
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / lerpSpeed);
 
            Camera.transform.position = Vector3.Lerp(new Vector3(PreviousLevelPosition.x, Camera.transform.position.y, PreviousLevelPosition.z), new Vector3(newPosition.x, Camera.transform.position.y, newPosition.z), t);
            Player.transform.position = SpawnPointPosition;
            yield return null;
        }

        for (int i = 0; i < Levels.Count; i++)
        {
            PreviousLevelPosition = NextLevelPosition;
            NextLevelPosition = Levels[i].transform.position;
        }

        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            SpawnPointPosition = SpawnPoints[i].transform.position;
        }
    }
}
