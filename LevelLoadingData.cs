using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadingData
{
    private int _level;



    public int Level
    {
        get { return _level; }
        set
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException("value");

            _level = value;
        }
    }
}
