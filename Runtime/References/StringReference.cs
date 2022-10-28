using TalusFramework.References.Interfaces;
using TalusFramework.Variables;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class StringReference : BaseReference<string, StringVariable>
    {
        public static implicit operator string(StringReference reference) => reference.Value;
    }
}
