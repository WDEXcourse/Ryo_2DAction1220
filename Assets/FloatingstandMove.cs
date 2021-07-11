using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingstandMove : MonoBehaviour
{
    public Vector3 firstpos;
    public bool down;
    public int move;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        firstpos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (down == true)
        {
            Vector3 pos = transform.position;
            pos.y -= 5f * Time.deltaTime;
            count -= 1;
            transform.position = pos;
            //if (gameObject.transform.position.y <= -178.5f)
            //{
            //    Rebound1();
            //}
            if (count <= 0)
            {
                Rebound1();
            }
        }

        if (down == false)
        {
            Vector3 pos = transform.position;
            pos.y += 5f * Time.deltaTime;
            count += 1;
            transform.position = pos;
            //if (gameObject.transform.position.y >= -160)
            //{
            //    Rebound2();
            //}
            if (count >= 180)
            {
                Rebound2();
            }
        }
    }

    public void Rebound1()
    {
        down = false;
    }
    public void Rebound2()
    {
        down = true;
    }
}