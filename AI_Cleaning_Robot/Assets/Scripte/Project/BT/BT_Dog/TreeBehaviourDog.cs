using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviourDog : Tree
{
    [SerializeField]  private DogNode root = null;
    [SerializeField]
    DogRobot currentRobot =null;
    protected override Node SetupTree()
    {
        return null;
    }
    
    
}
