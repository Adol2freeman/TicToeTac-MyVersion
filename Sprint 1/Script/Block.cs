using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int Total_Holding = 0;

    [SerializeField]
    GameObject Event;

    public int Player1_Holding;
    public int Player2_Holding;

    public string Owner = "E";
    public string Lasted_Holding;

    public int Position;

    public int x;
    public int y;

    public void Set_Lasted_Holding(string str)
    {
        Lasted_Holding = str;
    }

    private void Awake()
    {
        Event = GameObject.Find("EventSystem");
    }

    public void ShowPosition()
    {
        Debug.Log(x + " " + y);
    }

    private void Update()
    {
        if (Player1_Holding > Player2_Holding)
        {
            Owner = "O";
        }

        if (Player1_Holding < Player2_Holding)
        {
            Owner = "X";
        }

        if (Player1_Holding == Player2_Holding && Total_Holding == 2)
        {
            Owner = "E";
        }

        if (Player1_Holding == Player2_Holding && Total_Holding == 4)
        {
            Owner = Lasted_Holding;
        }
    }
}