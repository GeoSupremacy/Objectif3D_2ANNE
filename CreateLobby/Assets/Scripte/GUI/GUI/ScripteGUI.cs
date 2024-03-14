
using UnityEngine;

public class ScripteGUI : MonoBehaviour
{
    [SerializeField] protected GameObject gameUI = null;
    public GameObject GameUI => gameUI;
    void Awake() => Bind();
    private void Start() => Init();
    protected virtual void Init()
    {
        if (!gameUI)
            new System.NullReferenceException("ScripteGUI miss gameObject for UI");
    }
    protected virtual void Bind()
    {
        
    }
}
