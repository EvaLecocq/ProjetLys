using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Player player;
    

    public GameObject questacceptation;
    public GameObject questproposition;

    public Text title;
    public Text description;
    public Text experience;
    
    
    public void QuestWindowOpen()
    {
        questacceptation.SetActive(true);
        questproposition.SetActive(false);
        title.text = quest.title;
        description.text = quest.description;
        experience.text = "Exp" + quest.experience.ToString();
    }

    public void AcceptetionQuest()
    {
        questacceptation.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
        
        Debug.Log( "Quest is accepted");
    }

    public void CloseQuest()
    {
        questacceptation.SetActive(false);
       
    }

}
