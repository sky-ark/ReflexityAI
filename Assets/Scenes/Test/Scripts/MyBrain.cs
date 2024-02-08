using Plugins.ReflexityAI.Framework;
using UnityEngine;

namespace Scenes.Test.Scripts
{
    [CreateAssetMenu(fileName = "MyGraph", menuName = "ReflexityAI/MyGraph")]
    public class MyBrain : AIBrainGraph<MyAi> {}
}