using System.Collections;
using UnityEngine;

public class CameraManaged : MonoBehaviour
{
    [SerializeField] string cameraID = "Camera";
    [SerializeField] CameraMovements cameraSystem = null;
    [SerializeField] Camera cameraView = null;
    //TODO REMOVE TEST
    WaitForSeconds _wait = new(2);
     public string CameraID =>cameraID;
    private IEnumerator Start()
    {
        Init();
        yield return _wait;
            CameraManager.Instance?.DisableCamera(cameraID);
        yield return _wait;
        CameraManager.Instance?.EnableCamera(cameraID);
    }
    void Init()
    {
        cameraSystem = GetComponent<CameraMovements>();
        cameraView = GetComponent<Camera>();
        CameraManager.Instance?.AddCamera(this);
    }

    private void OnDestroy()=> CameraManager.Instance?.RemoveCamera(this);
    

    public void Enable()
    {
        cameraSystem.enabled = true;
        cameraView.enabled = true;

    }
    public void Disable()
    {

        cameraSystem.enabled = false;
        cameraView.enabled = false;
    }

    public void RegisterCamera(string _id)
    {
        cameraID = _id;
        CameraManager.Instance.AddCamera(this);
    }
}
