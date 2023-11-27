using UnityEngine;

public class ColorItem_CCR : MonoBehaviour
{
    [SerializeField] Renderer itemRenserer = null;
    // Start is called before the first frame update
    void Start() => Init();

    // Update is called once per frame
    void Init()=>itemRenserer =GetComponent<Renderer>();
    
   public void SetColor(Color _color)
    {
        itemRenserer.material.color = _color;
    }
}
