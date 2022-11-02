using Colony.Core;

namespace Colony.Core.Implementation
{
    public abstract class View : ColonyMainBehavior
    {
        private void Start()
        {
            OnStart();
        }

        private void Update()
        {
            OnUpdate();
        }

        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnStart() { }
        protected virtual void OnAwake() { }
        protected virtual void OnUpdate() { }
    }
}

