using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Data : MonoBehaviour
{
    public GameObject[] BlockHud;

    public bool Finish;

    public int Total_Round_num = 0;

    public string[,] Chessbroad = new string[3, 3] { { "E", "E", "E" }, { "E", "E", "E" }, { "E", "E", "E" } };

    public void Inlay(int X, int Y, string str)
    {
        Chessbroad[X, Y] = str;
    }

    public void Finished()
    {
        Finish = true;
    }

    public void Decision()
    {
        //橫
        for (int i = 0; i < 3; i++)
        {
            int cur_o = 0;
            int cur_x = 0;
            for (int j = 0; j < 3; j++)
            {
                //Debug.Log(i + " " + j + A[i, j]);
                if (Chessbroad[i, j] == "O")
                {
                    cur_o += 1;
                }
                else if (Chessbroad[i, j] == "X")
                {
                    cur_x += 1;
                }


            }
            //Debug.Log(i + " " + cur_o + " " + cur_x);

            if (cur_x == 3)
            {
                Debug.Log("Player2 win.");
                Invoke("Finished", 0);
            }
            if (cur_o == 3)
            {
                Debug.Log("Player1 win.");
                Invoke("Finished", 0);
            }
        }

        //直
        for (int i = 0; i < 3; i++)
        {
            int cur_o = 0;
            int cur_x = 0;
            for (int j = 0; j < 3; j++)
            {
                //Debug.Log(i + " " + j + A[i, j]);
                if (Chessbroad[j, i] == "O")
                {
                    cur_o += 1;
                }
                else if (Chessbroad[j, i] == "X")
                {
                    cur_x += 1;
                }
                else if (Chessbroad[j, i] == "E")
                {
                    break;
                }

            }
            //Debug.Log(i + " " + cur_o + " " + cur_x);

            if (cur_x == 3)
            {
                Debug.Log("Player2 win.");
                Invoke("Finished", 0);
            }
            if (cur_o == 3)
            {
                Debug.Log("Player1 win.");
                Invoke("Finished", 0);
            }
        }

        //斜 
        if (Chessbroad[0, 0] == "O" & Chessbroad[1, 1] == "O" & Chessbroad[2, 2] == "O")
        {
            Debug.Log("Player1 win.");
            Invoke("Finished", 0);
        }
        else if (Chessbroad[0, 0] == "X" & Chessbroad[1, 1] == "X" & Chessbroad[2, 2] == "X")
        {
            Debug.Log("Player2 win.");
            Invoke("Finished", 0);
        }

        if (Chessbroad[0, 2] == "O" & Chessbroad[1, 1] == "O" & Chessbroad[2, 0] == "O")
        {
            Debug.Log("Player1 win.");
            Invoke("Finished", 0);
        }
        else if (Chessbroad[0, 2] == "X" & Chessbroad[1, 1] == "X" & Chessbroad[2, 0] == "X")
        {
            Debug.Log("Player2 win.");
            Invoke("Finished", 0);
        }


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (string i in Chessbroad)
            {
                Debug.Log(i);
            }
        }

        foreach(GameObject GO in BlockHud)
        {
            Block block = GO.GetComponent<Block>();
            if(block.Owner == "E")
            {
                Inlay(block.x, block.y, "E");
            }
            else if(block.Owner == "O")
            {
                Inlay(block.x, block.y, "O");
            }
            else if (block.Owner == "X")
            {
                Inlay(block.x, block.y, "X");
            }
        }

        if (!Finish)
        {
            Decision();
        }
    }
}
