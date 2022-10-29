using Sirenix.OdinInspector;

using TalusFramework.Base;

namespace TalusFramework.Systems.Interfaces
{
    public abstract class BaseCommand : BaseSO, ICommand
    {
        [Button, DisableInEditorMode]
        public abstract void Execute();

        [Button, DisableInEditorMode]
        public abstract void Undo();
    }
}