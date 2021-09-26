using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lateralmovement : MonoBehaviour
{
    public Vector3 firstpos;
    public bool Lateral;
    public int xLateral;
    // Start is called before the first frame update
    void Start()
    {
        firstpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Lateral == true)
        {
            Vector3 pos = transform.position;
            pos.x -= 5f * Time.deltaTime;
            transform.position = pos;
            if(gameObject.transform.position.x　<= xLateral)
            {
                Restart1();
            }
        }

        if(Lateral == false)
        {
            Vector3 pos = transform.position;
            pos.x += 5f * Time.deltaTime;
            transform.position = pos;
            if (gameObject.transform.position.x >= -180)
            {
                Restart2();
            }
        }
    }

    public void Restart1()
    {
        Lateral = false;
    }
    public void Restart2()
    {
        Lateral = true;
    }
}
