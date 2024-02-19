using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{


    public float maxEsquerda = -10;
    public float ObstacleOrigin = 10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float x = GameManager.Instance.ObstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        if (transform.position.x < maxEsquerda)
        {
            Destroy(gameObject);
        }
    }
}
