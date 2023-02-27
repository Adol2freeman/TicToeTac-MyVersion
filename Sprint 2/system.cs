using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class system : MonoBehaviour
{
    int TotalRounds;

    [Header("Text")]
    public Text RoundText;
    public Text remainingroundsText;

    [Header("Space")]
    public List<GameObject> SpaceHud;

    [Header("Chase")]
    public List<GameObject> Chases;
    public Color Player1Color;
    public GameObject Player1_skill_spawn;
    public Color Player2Color;
    public GameObject Player2_skill_spawn;
    GameObject Cur;
    Color cur_Color;

    [Header("Skill")]
    public List<GameObject> SkillHub;
    public GameObject Cur_Skill;

    [Header("Cover up")]
    public GameObject Cover_Player1;
    public GameObject Cover_Player2;

    enum Round
    {
        Player_1,
        Player_2
    }

    Round round;


    public void move(GameObject gameObject)
    {
        Space space = gameObject.GetComponent<Space>();
        if (TotalRounds != 0)
        {
            if (space.Total < 4)
            {
                Destroy(Cur_Skill);
                switch (round)
                {
                    case Round.Player_1:
                        RoundText.text = "Player 1";
                        Random_Skill(Player2_skill_spawn);
                        Cover_Player1.SetActive(true);
                        Cover_Player2.SetActive(false);
                        space.Player1 += 1;
                        round = Round.Player_2;
                        cur_Color = Player1Color;
                        break;
                    case Round.Player_2:
                        RoundText.text = "Player 2";
                        Random_Skill(Player1_skill_spawn);
                        Cover_Player1.SetActive(false);
                        Cover_Player2.SetActive(true);
                        space.Player2 += 1;
                        cur_Color = Player2Color;
                        round = Round.Player_1;
                        break;
                }
                space.Total += 1;
                TotalRounds -= 1;

                remainingroundsText.text = "余 " + TotalRounds;
                Cur = Chases[space.Total - 1];

                GameObject Clone = Instantiate(Cur, gameObject.transform);
                Clone.GetComponent<Image>().color = cur_Color;
            }
            else
            {
                Debug.Log("Full");
            }
        }
    }

    public void Random_Skill(GameObject gameObject)
    {
        int Random_num = Random.RandomRange(0, 2);
        Cur_Skill = Instantiate(SkillHub[Random_num],gameObject.transform);
    }

    private void Awake()
    {
        TotalRounds = 16;
        remainingroundsText.text = "余 " + TotalRounds;
        Random_Skill(Player1_skill_spawn); 
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TotalRounds == 0)
        {
            Cover_Player1.SetActive(true);
            Cover_Player2.SetActive(true);
            Destroy(Cur_Skill);

            Debug.Log("Draw");
            this.gameObject.GetComponent<system>().enabled = false;
        }
    }
}
