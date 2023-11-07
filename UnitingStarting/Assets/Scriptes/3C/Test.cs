using UnityEngine;
using System.Collections;
public class Test : MonoBehaviour
{
    Vector3 origin;

    void Start()
    {
        origin = transform.position;
        Tweener.StartToMoveCallback(this, origin, Vector3.zero, TweenEase.EaseOutBounce, 5, () =>
        {

            Debug.Log("StartToMoveCallback");
            Tweener.StartToMove(this, Vector3.zero, origin, TweenEase.EaseInBounce, 2);
        });
        //imagine ajouter des fonctions par extension sans toucher à l'object:  les methodes d'extension
        this.MoveTo(TweenEase.EaseOutBounce, origin, 5);
        gameObject.transform.DebugPosition();
        gameObject.ToSpawn(this);
        int _a = "toto".ToInt();

    }

    #region Ex
    /*
    Vector3 origin;
    void Start()
    {
        origin = transform.position;
        TweenerLibrary.StartToMove(this, origin, Vector3.zero, TweenerFunctions.EaseInSine, 5, () => Debug.Log("Hi")); ;//,
        //() =>TweenerLibray.StartMoveTo(this, orign, Vectir.zeo, TweenerFunctions.Easing.EaseInBounce, 5));
    }
    */
    #endregion
}
