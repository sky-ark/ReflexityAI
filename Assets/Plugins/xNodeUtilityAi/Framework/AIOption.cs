﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Plugins.xNodeUtilityAi.Framework {
    [Serializable]
    public class AIOption {
        
        public List<AIAction> AiActions = new List<AIAction>();
        public float Rank;
        public int Weight;
        public float Probability;
        public string Description;

        public AIOption(List<ActionNode> actionNodes, Tuple<float, int> tuple, string description) {
            // Processing Simple Actions
            actionNodes.ForEach(node => AiActions.Add(new AIAction(node)));
            // Processing Utility
            Rank = tuple.Item1;
            Weight = tuple.Item2;
            AIAction actionWithData = AiActions.FirstOrDefault(action => action.Data != null);
            Description = description;
            if (actionWithData == null) return;
            foreach (object data in actionWithData.Data) {
                Description += " " + data;
            }
        }

        public void ExecuteActions() {
            AiActions = AiActions.OrderBy(action => action.Order).ToList();
            AiActions.ForEach(action => action.Action.Invoke(action.Context, action.Data));
        }

        public override string ToString() {
            return Description + " - Rank " + Rank + " - Weight " + Weight + " - Probability " + Probability;
        }

    }
}