using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownobstacleAction : MonoBehaviour
{
    public Vector3 firstpos;
    public bool down;
    // Start is called before the first frame update
    void Start()
    {
        firstpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {



        if (down == true)
        {
            Vector3 pos = transform.position;
            pos.y -= 10f * Time.deltaTime;
            transform.position = pos;
            if (gameObject.transform.position.y <= -180)
            {
                Restart();
            }
        }

        if (down == false)
        {
            Vector3 pos = transform.position;
            pos.y += 10f * Time.deltaTime;
            transform.position = pos;
            if (gameObject.transform.position.y >= -160)
            {
                Restart();
            }
        }
    }

    public void Restart()
    {
        transform.position = firstpos;
    }
}
