using UnityEngine;

//[CreateAssetMenu(fileName ="Root", menuName ="BehaviourTree/Root")]
public class Root : TreeNode
{
    [SerializeField] TreeNode child = null;
    [SerializeField] static Root instance= null;

    public Root Instance => instance;

    public TreeNode Child { get => child; set { child = value; } }

    void Init()
    {
        if(instance != null)
         {
            Destroy(this);
            return;
        }
        // instance =ScriptableObject.CreateInstance<Root>();
        instance = this;
    }
    protected override ENodeReturnStatus ProcessNode()
    {
        if (!child) return ENodeReturnStatus.FAILED;
        Debug.Log("ProcessNode " + name);
        return child.Execute();
      
    }

    protected override void StartNode()
    {
        Debug.Log("StartNode " + name);
    }

    protected override void StopNode()
    {
        Debug.Log("StartNode "+ name);
    }

    public override TreeNode Clone()
    {
        Root _node = Instantiate(this);
        if(_node.child) return _node;
        _node.child = child.Clone();
        return _node;
    }
}
