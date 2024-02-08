using System;
using System.Collections;
using System.Collections.Generic;
using Plugins.ReflexityAI.Framework;
using UnityEngine;

namespace Scenes.Test.Scripts
{
    public class MyAi : ReflexityAI
    {
        public float MaxHP = 10;

        public float CurrentHP;
        
        // Start is called before the first frame update
        private void Awake()
        {
            CurrentHP = MaxHP;
        }
    }
}