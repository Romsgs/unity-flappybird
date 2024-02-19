using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool touch = false;
    public static GameManager Instance { get; private set; }
    [HideInInspector]
    public int score = 0;
    public List<GameObject> ObstaclePrefabs;

    public float obstacleInterval = 2;

    public float obstacleOffsetX = 0;
    public Vector2 obstacleOffsetY = new Vector2(0,0);
    //public Vector2 yOffset = Vector2.zero;
    public float ObstacleMinY = -3;
    public float ObstacleMaxY = 3;
    public float ObstacleX = 5;
    public float ObstacleOrigin = 10;
    public float ObstacleSpeed = 2;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }
 
}
