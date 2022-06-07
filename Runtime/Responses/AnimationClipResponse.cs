using TalusFramework.Responses.Interfaces;

using UnityEngine;

namespace TalusFramework.Responses
{
    [CreateAssetMenu(fileName = "New Animation Clip Response", menuName = "Responses/AnimationClip", order = 9)]
    public sealed class AnimationClipResponse : Response<AnimationClip>
    { }
}