using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerAgent : Agent
{
    protected override Vector3 CalcSteeringForce()
    {
        return Seek(target);
    }
}
