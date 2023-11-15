using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTester : MonoBehaviour
{
    [SerializeField] PNJCameraFollow pnjCameraFollow = null;
    //TODO REMOVE TEST
    WaitForSeconds _wait = new(2);
    IEnumerator Start()
    {
        CameraManager.Instance.CreateCamera(pnjCameraFollow,"PNJ", transform);
        CameraManager.Instance.CreateCameraFollow("TOTo", transform);
        yield return _wait;
        CameraManager.Instance.DisableCamera("player");
    }

}
