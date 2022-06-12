using UnityEngine;

using TalusFramework.Collections.Interfaces;

namespace TalusFramework.Collections
{
    [CreateAssetMenu(fileName = "New Sprite Collection", menuName = "Collections/Sprite", order = 7)]
    public class SpriteCollection : BaseCollection<Sprite>
    { }
}