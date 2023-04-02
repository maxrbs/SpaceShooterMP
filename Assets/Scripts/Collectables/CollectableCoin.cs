using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : CollectableBase
{
    protected override void TryCollect(GameObject collidedObject)
    {
        if (collidedObject.TryGetComponent(out CollectorComponent collector))
            collector.AddCoins(1);
    }
}
