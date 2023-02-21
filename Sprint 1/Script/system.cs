using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class system : MonoBehaviour
{
    public List<GameObject> Player_1;
    public List<GameObject> Player_2;

    enum Rounds
    {
        Player_1,
        Player_2
    }

    [Header("Rounds")]
    [SerializeField]
    private Rounds Round;

    public GameObject CurrentOdject;
    private int CurrentNumber;

    public void SystemPackage(GameObject gameObject)
    {
        Data data = this.GetComponent<Data>();
        if (data.Total_Round_num < 16)
        {
            Choose(gameObject);
            Clone(gameObject);
        }
        data.Total_Round_num += 1;
    }

    public void Clone(GameObject gameObject)
    {
        Instantiate(CurrentOdject, gameObject.transform);
    }

    public void Choose(GameObject gameObject)
    {
        Block block = gameObject.GetComponent<Block>();
        Data data = this.GetComponent<Data>();

        if (block.Total_Holding < 4)
        {
            switch (Round)
            {
                case Rounds.Player_1:
                    block.Player1_Holding += 1;
                    block.Lasted_Holding = "O";
                    Round = Rounds.Player_2;
                    CurrentOdject = Player_1[block.Total_Holding];
                    break;
                case Rounds.Player_2:
                    block.Player2_Holding += 1;
                    block.Lasted_Holding = "X";
                    Round = Rounds.Player_1;
                    CurrentOdject = Player_2[block.Total_Holding];
                    break;
            }
            block.Total_Holding += 1;
        }
        else
        {
            Debug.Log("Full");
        }
    }

    private void Start()
    {
        
        //xDebug.Log(data.Chessbroad);
    }

    private void Update()
    {
        
    }
}
