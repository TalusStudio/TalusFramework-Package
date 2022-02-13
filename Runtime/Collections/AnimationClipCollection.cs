using TalusFramework.Runtime.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Runtime.Collections
{
    [CreateAssetMenu(fileName = "New Animation Clip Collection", menuName = "Collections/Animation Clip", order = 0)]
    public class AnimationClipCollection : BaseCollection<AnimationClip>
    { }
}