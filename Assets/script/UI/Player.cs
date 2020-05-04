using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int experience = 40;
    public int fruit = 0;
    public GameObject succes;
    public Quest quest;
    public Dialogue dialogue;

    void Start()
    {

    }

    public void FruitUP()
    {
        fruit++;
        if (quest.isActive)
        {

            quest.goal.Addfruit();
            if (quest.goal.isReached())
            {
                experience += quest.experience;
                quest.Completed();

                succes.SetActive(true);
            }

        }
    }

    public void CloseSucces()
    {
        succes.SetActive(false);

    }


}
