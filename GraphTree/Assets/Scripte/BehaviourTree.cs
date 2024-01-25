using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : MonoBehaviour
{

    [SerializeField] List<TreeNode> allNodes =new List<TreeNode> ();
    [SerializeField] Root root = null;
    [SerializeField] bool canRun = false;

    public List<TreeNode> AllNodes => allNodes;
    public Root Root {  get => root; set { root = value; } }

    public int TreeSize => allNodes.Count;
    void Clone()
    {
        root =(Root)root.Clone();
    }

    private void Start()
    {
       // Clone();
    }
    private void Update()
    {
        TreeUpdate();
    }

    void TreeUpdate()
    {
        if(canRun) 
            if(!root)
            {
                Debug.LogError("need root");
                return;
            }
        Debug.LogError("Execute "+ name);
        root.Execute();
    }
}
