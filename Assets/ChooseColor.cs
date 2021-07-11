using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseColor : MonoBehaviour
{
    //public GameObject PlayerAction;
    [SerializeField]
    public static Color Color;
    public Color ColorTemp;
    public static string name;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        Color = ColorTemp;
    }

    public void Onclick(string colorname)
    {
        if(colorname == "blue")
        {
            name = "blue";
        }

        if(colorname == "black")
        {
            name = "black";
        }

        if(colorname == "red")
        {
            name = "red";
        }

        if(colorname == "yellow")
        {
            name = "yellow";
        }

        if (colorname == "green")
        {
            name = "green";
        }
    }
}