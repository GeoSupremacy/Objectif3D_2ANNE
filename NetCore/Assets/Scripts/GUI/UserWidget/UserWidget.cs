using UnityEngine;

public class UserWidget : MonoBehaviour
{
    [SerializeField] protected GameObject gameUI;
    private void Awake() => Bind();

    private void Start() => Init();
    protected virtual void Bind()
    {

    }
    protected virtual void Init()
    {

    }
}
