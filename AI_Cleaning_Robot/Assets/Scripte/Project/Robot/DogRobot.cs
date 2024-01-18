using System.Collections;
using UnityEngine;


[RequireComponent(typeof(RobotSightSensorComponent))]
public class DogRobot : Robot
{
    RobotSightSensorComponent sightSensorComponent;
    protected override void Update()
    {
        base.Update();

        if (!sightSensorComponent)
            return;

      

    }
    protected override void Init()
    {
        sightSensorComponent = this.GetComponent<RobotSightSensorComponent>();
    }
    protected override void DrawDebug()
    {
        

       
    }
    protected override void Bind()
    {
        base.Bind();
       
    }

}
