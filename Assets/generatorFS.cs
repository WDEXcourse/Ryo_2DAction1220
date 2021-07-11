using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorFS : MonoBehaviour
{
    public Vector2 startPos;
	public Vector2 posInterval;
    public int cloneNum;
    public GameObject FS;
    private Vector2 myPos;
	// Start is called before the first frame update
	void Start()
    {
        myPos = startPos;
        for(int i = 0; i < cloneNum; ++i)
        {
            Invoke("instantiateFS", i*0.2f);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void instantiateFS()
    {
        Instantiate(FS, new Vector3(myPos.x, myPos.y,0f),Quaternion.identity);
        myPos += posInterval;
    }
}