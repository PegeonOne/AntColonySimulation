
namespace Colony.Views.Implementation
{
    public abstract class ViewWithModel<T> : View
    {
        private T _model;

        public virtual T Model
        {
            get { return _model; }
            set
            {
                _model = value;
                if(_model != null)
                {
                    OnModelChanged();
                }
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            //OnModelChanged();
        }

        public virtual void OnModelChanged() { }
    }
}

