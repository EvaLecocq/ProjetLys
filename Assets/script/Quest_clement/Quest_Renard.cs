using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest_Renard 
{
    public bool isActive;
    

    public string title;
    public string description;
    public int experience;

    public QuestGoal goal;

    

    public void Completed()
    {
        isActive = false;
        Debug.Log("Quest was completed");
        
    }
}
