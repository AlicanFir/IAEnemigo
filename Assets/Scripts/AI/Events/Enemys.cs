using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/Enemys")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "Enemys", message: "Enemy Spotted [Target]", category: "Events", id: "919952b14c097147d84501a4c03d7c4b")]
public sealed partial class Enemys : EventChannel<GameObject> { }

