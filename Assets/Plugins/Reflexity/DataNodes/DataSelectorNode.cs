using System.Collections.Generic;
using System.Linq;
using Plugins.Reflexity.Framework;
using UnityEngine;
using XNode;
using Object = UnityEngine.Object;

namespace Plugins.Reflexity.DataNodes {
    [CreateNodeMenu("Reflexity/Data/Selector")]
    public class DataSelectorNode : DataNode, ICacheable {
        
        [Input(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Inherited)] public Object Data;
        [Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None)] public Object Output;

        [HideInInspector] public SerializableInfo SelectedSerializableInfo;
        [HideInInspector] public List<SerializableInfo> SerializableInfos = new List<SerializableInfo>();
        [HideInInspector] public int ChoiceIndex;
        [HideInInspector] public string ChoiceName;

        public override void OnCreateConnection(NodePort from, NodePort to) {
            if (to.fieldName == nameof(Data) && to.node == this) {
                UpdateReflectedData();
            }
        }

        public override void OnRemoveConnection(NodePort port) {
            if (port.fieldName == nameof(Data)) {
                foreach (NodePort nodePort in GetPort(nameof(Output)).GetConnections()) {
                    nodePort.ClearConnections();
                }
                SerializableInfos.Clear();
                SelectedSerializableInfo = null;
                // ChoiceIndex = 0;
                // ChoiceName = string.Empty;
            }
        }

        public override object GetValue(NodePort port) {
            if (port.fieldName == nameof(Output)) {
                ReflectionData reflectionData = GetInputValue<ReflectionData>(nameof(Data));
                return Application.isPlaying
                    ? SelectedSerializableInfo.GetRuntimeValue(reflectionData.Value)
                    : SelectedSerializableInfo.GetEditorValue();
            }
            return null;
        }
        
        public void ClearCache() {
            SelectedSerializableInfo.ClearCache();
        }

        public void ClearShortCache() {
            if (SelectedSerializableInfo.IsShortCache) SelectedSerializableInfo.ClearCache();
        }
        
        private void OnValidate() {
            UpdateReflectedData();
        }

        private void UpdateReflectedData() {
            SerializableInfos.Clear();
            ReflectionData reflectionData = GetInputValue<ReflectionData>(nameof(Data));
            SerializableInfos.AddRange(reflectionData.Type
                .GetFields(SerializableInfo.DefaultBindingFlags)
                .Select(info => new SerializableInfo(info, reflectionData.FromIteration)));
            SerializableInfos.AddRange(reflectionData.Type
                .GetProperties(SerializableInfo.DefaultBindingFlags)
                .Select(info => new SerializableInfo(info, reflectionData.FromIteration)));
        }

    }
}