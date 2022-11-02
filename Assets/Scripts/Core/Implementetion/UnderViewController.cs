namespace Colony.Core.Implementation
{
    public abstract class UnderViewController<T> : ColonyMainBehavior
    {
        private T _view;

        public T View
        {
            get { return _view; }
            set { _view = value; }
        }

        private void Awake()
        {
            OnControllerAwake();
        }

        private void Start()
        {
            OnControllerStart();
        }

        private void Update()
        {
            OnControllerUpdate();
        }
        public virtual void OnControllerAwake() { }
        public virtual void OnControllerStart() { }
        public virtual void OnControllerUpdate() { }
    }
}

