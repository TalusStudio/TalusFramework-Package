using TalusFramework.Collections.Interfaces;

using UnityEngine;

namespace TalusFramework.Collections
{
    [CreateAssetMenu(fileName = "New Animation Clip Collection", menuName = "Collections/Animation Clip", order = 8)]
    public class AnimationClipCollection : BaseCollection<AnimationClip>
    { }
}