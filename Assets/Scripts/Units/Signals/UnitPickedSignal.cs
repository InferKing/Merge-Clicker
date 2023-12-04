using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPickedSignal
{
    public readonly BaseUnit unit;
    public UnitPickedSignal(BaseUnit unit)
    { 
        this.unit = unit; 
    }
}
