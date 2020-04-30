using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStat : MonoBehaviour
{
    public float Damage;
    public float Speed;
    public float Range;
    protected Vector3 initialDistance;
    protected bool hasCollide = false;
}
