using UnityEngine;
using System.Collections;

public class IA_NavigationComponent : MonoBehaviour
{
    [SerializeField] AstarAlgo astar =new AstarAlgo();
    [SerializeField] GridPointData data;
    [SerializeField] EndPath endPath;
    [SerializeField]
    GridPointData datas;
    [field: SerializeField]
    public Corr_Node currentNode { get; private set; } = null;
    [SerializeField] int index = 0;
    [SerializeField] bool reverse = false;
    bool destination = false;
    bool move = false;
    void Start() => StartCoroutine(CurrentNode());

    IEnumerator CurrentNode()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < datas.Nodes.Count; i++)
            if (Vector3.Distance(transform.position, datas.Nodes[i].Position) < 1.5f)
                currentNode = datas.Nodes[i];

        
        astar.ComputePath(currentNode, endPath.currentNode);
        move = true;
    }
    private void Update() => Move();

    private void OnDrawGizmos()=> astar.DrawPath();
    
    void Move()
    {
        if (!move)
            return;
        Distance();

        transform.position = Vector3.MoveTowards(transform.position, astar.correctPath[index].Position, .1f);
        if (Vector3.Distance(transform.position, astar.correctPath[index].Position) <= 1f)
            destination = true;

    }
    void Distance()
    {
       
        if (destination)
        {
            if (index == astar.correctPath.Count - 1)
                reverse = true;
            else if (index <= 0)
                reverse = false;

            if (reverse)
                index--;
            else
                index++;
            destination = false;
        }
    }
}
