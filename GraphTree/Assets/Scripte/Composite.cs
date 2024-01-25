using UnityEngine;
using System.Collections.Generic;


//[CreateAssetMenu(fileName = "Composite", menuName = "BehaviourTree/Composite")]
public abstract class Composite : TreeNode
{

    [SerializeField]  public List<TreeNode> allChidren = new List<TreeNode>();
    public int Count => allChidren.Count;

    public override TreeNode Clone()
    {
        Composite _composit = Instantiate(this);
        _composit.allChidren = allChidren.ConvertAll(c => c.Clone());
        return _composit;
    }

}
