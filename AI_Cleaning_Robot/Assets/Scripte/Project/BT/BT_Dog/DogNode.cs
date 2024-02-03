using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;



public abstract class DogNode : Node
{
    [SerializeField] new public DogNode parent;

    [SerializeField]  public RootDog currentRoot;
    protected override void AddOwner(Robot _robot)
    {
        robot = (DogRobot) _robot;
    }
    public override void AddParent(Node _parent)
    {
        if (!_parent) Debug.LogError(name +" Not Parent");
        DogNode _parentDogNode = (DogNode)_parent;
        CurrentRoot(_parentDogNode.currentRoot);
        parent.AddOwner(_parentDogNode.Robot);
    }
    protected void CurrentRoot(RootDog rootDog)
    {
        if (!rootDog) Debug.LogError(name + " Not Root");
        currentRoot = rootDog;
    }
}
