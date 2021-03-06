﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public ItemDefinition itemDefinition;

    //Each item type should define its use in its script
    public abstract void Use();

}
