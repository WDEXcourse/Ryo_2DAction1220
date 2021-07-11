using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralObstacle : MonoBehaviour
{
    public Vector3 firstpos;
    public bool Lateral;
    // Start is called before the first frame update
    void Start()
    {
        firstpos = transform.position;

        Lateral = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Lateral == true)
        {
            Vector3 pos = transform.position;
            pos.x -= 10f * Time.deltaTime;
            transform.position = pos;
            if (gameObject.transform.position.x <= -216.5f)
            {
                Restart1();
            }
        }
    }

    public void Restart1()
    {
        Lateral = false;

        if (Lateral == false)
        {
            transform.position = firstpos;

            Lateral = true;
        }
    }
}
