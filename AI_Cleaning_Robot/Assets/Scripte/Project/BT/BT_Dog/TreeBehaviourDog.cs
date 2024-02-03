using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class TreeBehaviourDog : Tree
{
    [SerializeField]  private RootDog currentRoot= null;
    [SerializeField]
    DogRobot currentRobot =null;
   [SerializeField]
    RootDog root = null;
    protected override void Enter()
    {
        Debug.LogError("Enter TreeBehaviourDog");
        currentRoot = Instantiate(root);
        currentRobot =gameObject.AddComponent<DogRobot>();
        if (!currentRoot) Debug.LogError("not node");
        currentRoot.AddParent(root);
    }
    protected override void UpdateTree()
    {
        Debug.Log("UpdateTree TreeBehaviourDog");
        if (currentRoot != null)
            currentRoot.Execute();
    }
  
    public override void NextNode(Node  _node)
    { currentRoot = (RootDog)_node; }
    public override void Exit()
    {
        Debug.LogError("Exit TreeBehaviourDog");
        currentRoot = null; 

    }
}
