using Colony.Ant.View;
using Colony.Core.Implementation;

namespace Colony.Ant.Controller
{
    public class AntController : UnderViewController<AntView>
    {
        public override void OnControllerStart()
        {
            base.OnControllerStart();
            View = GetComponent<AntView>();
        }
    }
}

