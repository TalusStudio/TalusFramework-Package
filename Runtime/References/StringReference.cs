using TalusFramework.References.Interfaces;

namespace TalusFramework.References
{
    [System.Serializable]
    public sealed class StringReference : BaseReference<string>
    {
        public static implicit operator string(StringReference reference) => reference.Value;
    }
}
