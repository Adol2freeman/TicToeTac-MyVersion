using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class system : MonoBehaviour
{
    public List<GameObject> Player;
    public List<GameObject> Cards;
    public int round;

    enum Rounds
    {
        Player_1,
        Player_2
    }

    enum Scene
    {
        Card,
        Block,
        Replace,
        Exchange,
        Pass
    }

    [Header("Rounds")]
    [SerializeField]
    private Rounds Round;
    private Scene scene;


    public void Exchange(GameObject Player)
    {
        //Block
        Space space = Player.GetComponent<Space>();

        //Current
        int Cur_Player1 = space.Player1_Holding;
        int Cur_Player2 = space.Player2_Holding;

        space.Player1_Holding = Cur_Player2;
        space.Player2_Holding = Cur_Player1;
    }

    public void Pass(int i)
    {
        if (i == 0)
        {
            scene = Scene.Card;
        }
        else if (i == 1)
        {
            scene = Scene.Block;
        }
        else if (i == 2)
        {
            scene = Scene.Replace;
        }
        else if (i == 3)
        {
            scene = Scene.Exchange;
        }
        else if(i == 4)
        {
            scene = Scene.Pass;
        }

        switch
    }

    private void Update()
    {
        
    }
}
