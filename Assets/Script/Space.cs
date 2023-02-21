using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    public int Total_Holding = 0;

    [SerializeField]
    GameObject Event;
    [Header("Player 1")]
    public int Player1_Holding;
    public Color Player1_color;

    [Header("Player 2")]
    public int Player2_Holding;
    public Color Player2_color;

    [Header("Basic Data")]
    public string Owner = "E";
    public string Lasted_Holding;
    public int Position;
    public int X;
    public int Y;

    [Header("State")]
    public bool Blocked;
    
    int BlockRound;


    public void Set_Lasted_Holding(string str)
    {
        Lasted_Holding = str;
    }

    private void Awake()
    {
        Event = GameObject.Find("EventSystem");
        Player1_color = Color.blue;
        Player2_color = Color.red;
    }

    private void Update()
    {
        system system = Event.GetComponent<system>();
        if(BlockRound == system.round)
        {
            Blocked = true;
        }
        else
        {
            Blocked = false;
        }



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