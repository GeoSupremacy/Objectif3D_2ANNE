using UnityEngine;


[CreateAssetMenu(fileName ="CameraSettings")]
public class CameraSettingsData : ScriptableObject
{
    #region settings

    public enum MovementType
    {
        Lerp,
        ConstantLerp,
    }

    public enum OffsetType
    {
        World,
        Local,
    }

    [SerializeField, Header("Camera settings"), Range(-20, 20)]
    float offsetX, offsetY, offsetZ;
    [SerializeField]
    MovementType movementType;
    [SerializeField]
    OffsetType offsetType;


    [SerializeField, Range(0, 10)]
    float speed;

    public float Speed => speed;
    public float OffsetX => offsetX;
    public float OffsetY => offsetY;
    public float OffsetZ => offsetZ;

    public OffsetType FOffsetType => offsetType;
    public MovementType FMovementType => movementType;
   

    #endregion settings
}
