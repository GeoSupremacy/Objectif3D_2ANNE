using System.Collections;
using UnityEngine;


[RequireComponent(typeof(RobotSightSensorComponent))]
public class DogRobot : Robot
{
    RobotSightSensorComponent sightSensorComponent;
   
    protected override void Init()
    {
        sightSensorComponent = this.GetComponent<RobotSightSensorComponent>();
    }
   
 

}
