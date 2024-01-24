using System.Collections;
using UnityEngine;

public class EndPath : MonoBehaviour
{
    [SerializeField]
    GridPointData datas;
    [field:SerializeField]
    public Corr_Node currentNode { get; private set; } =null;

    private void Start()
    {
        StartCoroutine(CurrentNode());
        
    }
    IEnumerator CurrentNode()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < datas.Nodes.Count; i++)
        {
            if (Vector3.Distance(transform.position, datas.Nodes[i].Position) < 1.5f)
                currentNode = datas.Nodes[i];

        }
    }
    private void OnDrawGizmos()
    {
     
        Gizmos.color = Color.red;
        if (currentNode != null)
            Gizmos.DrawLine(currentNode.Position, transform.position);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
