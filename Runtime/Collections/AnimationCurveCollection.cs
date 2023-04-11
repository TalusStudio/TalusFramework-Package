using UnityEngine;

using TalusFramework.Collections.Interfaces;

namespace TalusFramework.Collections
{
    [CreateAssetMenu(fileName = "New Animation Curve Collection", menuName = "Collections/Animation Curve", order = 9)]
    public class AnimationCurveCollection : BaseCollection<AnimationCurve>
    { }
}