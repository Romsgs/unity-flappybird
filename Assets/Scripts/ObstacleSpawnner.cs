using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawnner : MonoBehaviour
{
    private float Cooldown = 0;

    void Update()
    {
        if(GameManager.Instance.IsGameOVer())
        {
            return;
        }
        Cooldown -= Time.deltaTime;

        if (Cooldown <= 0f)
        {
            Cooldown = GameManager.Instance.obstacleInterval;
            //spawwn obstacle

            int prefabIndex = Random.Range(0, GameManager.Instance.ObstaclePrefabs.Count);
            GameObject prefab = GameManager.Instance.ObstaclePrefabs[prefabIndex];

            //float x = GameManager.Instance.obstacleOffsetX;
            //float y = Random.Range(GameManager.Instance.obstacleOffsetY.x, GameManager.Instance.obstacleOffsetY.y);
            //float z = 0;
            //Vector3 position = new Vector3(x, y, z);
            //Quaternion rotation = prefab.transform.rotation;
            //Instantiate(prefab, position, rotation);

            float prefabMaxY = GameManager.Instance.ObstacleMaxY;
            float prefabMinY = GameManager.Instance.ObstacleMinY;

            float prefabX = GameManager.Instance.ObstacleOrigin;
            float prefabY = Random.Range(prefabMinY, prefabMaxY);

            Vector3 position = new Vector3(prefabX, prefabY, 0);
            Quaternion rotation = prefab.transform.rotation;

            Instantiate(prefab, position, rotation);
        }
    }
}
