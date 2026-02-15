using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platforms
{
    public abstract void Move(Transform platformPosition);
    public virtual void Activate() { }
}
