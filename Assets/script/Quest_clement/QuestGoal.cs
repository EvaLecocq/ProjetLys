using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal 
{
    public GoalType goaltype;

    public int fruit;
    public int currentfruit;

    public bool isReached()
    {
        return (currentfruit >= fruit);
    }
     public void Addfruit()
    {
        if(goaltype == GoalType.Finded)
        currentfruit++;
    }

    public enum GoalType
    {
        Finded,

    }
}
