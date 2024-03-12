using System;
using System.Collections;
using System.Collections.Generic;
using Plugins.ReflexityAI.Framework;
using UnityEngine;

namespace Scenes.Test.Scripts
{
    public class MyAi : ReflexityAI
    {
        public MyCubeEntity MyCubeEntity;

        public List<MyCubeEntity> MyCubeEntities;
        
        private void Awake() {
            MyCubeEntity = GetComponent<MyCubeEntity>();
        }

        //     public float MaxHP = 10;
        //
        //     public float CurrentHP;
        //
        //     public bool IsFullHP; 
        //     
        //     // Start is called before the first frame update
        //     private void Awake()
        //     {
        //         CurrentHP = MaxHP;
        //     }
        //
        //     private void Update()
        //     {
        //         throw new NotImplementedException();
        //     }
        // }
    }
}