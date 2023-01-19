using System.Collections.Generic;
using System.Linq;
using Examples.TankArena.Scripts.Entities;
using Examples.TankArena.Scripts.Framework;
using Plugins.ReflexityAI.Framework;
using UnityEngine;

namespace Examples.TankArena.Scripts.AI {
    public class TankAI : ReflexityAI {

        /**
         * Return this tank
         */
        [HideInInspector] public TankEntity TankEntity;
        
        /**
         * Return a list of all bonus on the map
         */
        public IEnumerable<BonusEntity> BonusEntities => BonusEntity.BonusEntities;
        
        /**
         * Return a list of all tanks on the map (be careful, this tank is contain inside)
         */
        public IEnumerable<TankEntity> TankEntities => TankEntity.TankEntities;
        
        /**
         * Return a list of all waypoints on the map (use TankEntity.SeekWaypointInRadius to get near waypoints)
         */
        public IEnumerable<WaypointEntity> WaypointEntities => WaypointEntity.WaypointEntities;
        
        /**
         * Return a list of all adversary tanks on the map (based on team)
         */
        public IEnumerable<TankEntity> EnnemyTankEntities => TankEntities
            .Where(entity => entity.GetFaction(TankEntity) == FactionType.Enemy);
        
        /**
         * Return a list of all ally tanks on the map (based on team)
         */
        public IEnumerable<TankEntity> AllyTankEntities => TankEntities
            .Where(entity => entity.GetFaction(TankEntity) == FactionType.Ally);
        // End of custom references

        private void Awake() {
            TankEntity = GetComponent<TankEntity>();
        }

    }
}