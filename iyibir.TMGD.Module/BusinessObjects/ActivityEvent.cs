using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace iyibir.TMGD.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Workspace")]
    [ImageName("BO_Scheduler")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    public class ActivityEvent : Event
    { 
        public ActivityEvent(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

    }
}