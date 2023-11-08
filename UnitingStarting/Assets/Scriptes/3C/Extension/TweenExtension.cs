using UnityEngine;

public static class TweenExtension // no new != abstact ne vit que par héritage
{
    public static void MoveTo(this MonoBehaviour _ob, TweenEase _ease, Vector3 _target, float _duration) //etendre les MonoBehaviour
    {
        Vector3 _origin = _ob.transform.position;
        Tweener.StartToMove(_ob, _origin, _target, _ease, _duration);
    }
    public static void TeleportTo(this GameObject _ob, Vector3 _tatget)
    {
        _ob.transform.position = _tatget;
    }
    public static void DebugPosition(this Transform _transform)
    {
        Debug.Log($"Debug Position: {_transform.position}");
    }
    public static void DebugTransform(this Transform _transform)
    {
        Debug.Log($"Debug Transform: {_transform.position}, { _transform.rotation}");
    }
    public static T ToSpawn<T>(this GameObject _ob, T _object) where T : Component
     {
        return UnityEngine.Object.Instantiate(_object);
    }
    public static int ToInt(this string _string) 
    {
        return int.Parse( _string );
    }
    public static void SetPosition(this Transform _transform, Vector3 _position)
    { _transform.position = _position; }

}
