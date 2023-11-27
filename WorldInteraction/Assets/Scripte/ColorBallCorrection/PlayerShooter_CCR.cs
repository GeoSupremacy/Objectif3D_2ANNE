using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooter_CCR : MonoBehaviour
{
    [SerializeField] Camera playerCamera = null;
    [SerializeField] Transform shootPoint = null;
    [SerializeField, Range(1,100)] int shootPower = 2;
    [SerializeField] PlayerColorBall_CCR projectile = null;
    [SerializeField] LayerMask shootLayer;
    [SerializeField] Color[] gunColors = new Color[] { Color.red, Color.green };
    [SerializeField, Range(1, 100)] float range = 100;

    bool canShoot = false;
    readonly Vector2 crossHair = new Vector2(0.5f, 0.5f);
  //  private void Start() =>InvokeRepeating(nameof(Shoot), 0, 1); //TODO

    private void Update()
    {
        canShoot = CanShot();
    }
    public void Shoot(int _colorIndex = 0)
    {
        if (!canShoot)
            return;
        PlayerColorBall_CCR _projectile = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
        _projectile.InitBall(gunColors[_colorIndex], shootPower);
    }

    public bool CanShot()
    {
        Ray _ray = playerCamera.ViewportPointToRay(crossHair);
        return Physics.Raycast(_ray.origin, _ray.direction, range, shootLayer);
       
    }
}
