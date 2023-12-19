
using DevExpress.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using iyibir.TMGD.Module.BusinessObjects;
using Microsoft.AspNetCore.Components;
using System.Collections;
using System.ComponentModel;

namespace iyibir.TMGD.Module.Blazor.Editors
{
    [ListEditor(typeof(ActivityEvent))]
    public class SchedulerListEditor : ListEditor, IComplexListEditor
    {
        private CollectionSourceBase collectionSource;
        private XafApplication application;

        public override SelectionType SelectionType => SelectionType.Full;
        public override IList GetSelectedObjects() => selectedObjects;

        public class ActivityItemListViewHolder : IComponentContentHolder
        {
            private RenderFragment componentContent;
            public ActivityItemListViewHolder(SchedulerListViewModel componentModel)
            {
                ComponentModel =
                    componentModel ?? throw new ArgumentNullException(nameof(componentModel));
            }
            private RenderFragment CreateComponent() =>
                ComponentModelObserver.Create(ComponentModel,
                                               SchedulerListViewRenderer.Create(ComponentModel));
            public SchedulerListViewModel ComponentModel { get; }
            RenderFragment IComponentContentHolder.ComponentContent =>
                componentContent ??= CreateComponent();
        }

        public SchedulerListEditor(IModelListView model) : base(model) { }

        protected override object CreateControlsCore()
        {
            return new ActivityItemListViewHolder(new SchedulerListViewModel());
        }
        private ActivityEvent[] selectedObjects = Array.Empty<ActivityEvent>();

        protected override void OnControlsCreated()
        {
            if (Control is ActivityItemListViewHolder holder)
            {
                holder.ComponentModel.AppointmentInserted += ComponentModel_AppointmentInserted;
                holder.ComponentModel.AppointmentUpdated += ComponentModel_AppointmentUpdated;
                holder.ComponentModel.AppointmentRemoved += ComponentModel_AppointmentRemoved;
                holder.ComponentModel.AppointmentInserting += ComponentModel_AppointmentInserting;
            }
            base.OnControlsCreated();
        }

        private void ComponentModel_AppointmentInserting(object sender, SchedulerAppointmentOperationEventArgs e)
        {
            e.Appointment.Id = Guid.NewGuid();
        }

        private void ComponentModel_AppointmentInserted(object sender, SchedulerListViewModelAppointmentItemEventArgs e)
        {
            IObjectSpace objectSpace = collectionSource.ObjectSpace;
            ActivityEvent newActivity = objectSpace.CreateObject<ActivityEvent>();

            newActivity.AllDay = e.AppointmentItem.AllDay;
            newActivity.Subject = e.AppointmentItem.Subject;
            newActivity.Description = e.AppointmentItem.Description;
            newActivity.EndOn = e.AppointmentItem.End;

            if (e.AppointmentItem.LabelId != null)
                newActivity.Label = int.Parse(e.AppointmentItem.LabelId.ToString());

            newActivity.Location = e.AppointmentItem.Location;
            newActivity.StartOn = e.AppointmentItem.Start;
            newActivity.Status = int.Parse(e.AppointmentItem.StatusId.ToString());
            newActivity.RecurrenceInfoXml = e.AppointmentItem.RecurrenceInfo?.ToXml();
            //newActivity.Id = (System.Guid)e.AppointmentItem.Id;
            objectSpace.CommitChanges();

            //HACK: To Refresh Control datasource and see added Task in UI
            IList<ActivityEvent> baseActivities = objectSpace.GetObjects<ActivityEvent>();
            AssignDataSourceToControl(baseActivities);
        }

        private void ComponentModel_AppointmentUpdated(object sender, SchedulerListViewModelAppointmentItemEventArgs e)
        {
            ConvertToAppointment(e.AppointmentItem);
        }

        private void ConvertToAppointment(DxSchedulerAppointmentItem appointmentItem)
        {
            IObjectSpace objectSpace = collectionSource.ObjectSpace;
            ActivityEvent activity = objectSpace.FindObject<ActivityEvent>(new DevExpress.Data.Filtering.BinaryOperator("Oid", appointmentItem.Id));
            if (activity == null)
            {
                return;
            }
            activity.AllDay = appointmentItem.AllDay;
            activity.Subject = appointmentItem.Subject;
            activity.Description = appointmentItem.Description;
            activity.EndOn = appointmentItem.End;
            activity.Label = int.Parse(appointmentItem.LabelId.ToString());
            activity.Location = appointmentItem.Location;
            activity.StartOn = appointmentItem.Start;
            activity.Status = int.Parse(appointmentItem.StatusId.ToString());
            activity.RecurrenceInfoXml = appointmentItem.RecurrenceInfo?.ToXml();
            //activity.Oid = (System.Guid)appointmentItem.Id;
            objectSpace.CommitChanges();

            IList<ActivityEvent> baseActivities = objectSpace.GetObjects<ActivityEvent>();
            AssignDataSourceToControl(baseActivities);
        }

        private void ComponentModel_AppointmentRemoved(object sender, SchedulerListViewModelAppointmentItemEventArgs e)
        {
            IObjectSpace objectSpace = collectionSource.ObjectSpace;
            ActivityEvent activity = objectSpace.FindObject<ActivityEvent>(new DevExpress.Data.Filtering.BinaryOperator("Oid", e.AppointmentItem.Id));
            activity.Delete();
            objectSpace.CommitChanges();

            IList<ActivityEvent> baseActivities = objectSpace.GetObjects<ActivityEvent>();
            AssignDataSourceToControl(baseActivities);
        }

        private void ComponentModel_ItemClick(object sender, SchedulerListViewModelItemClickEventArgs e)
        {
            selectedObjects = new ActivityEvent[] { e.Item };
            OnSelectionChanged();
            OnProcessSelectedItem();
        }
        public override void BreakLinksToControls()
        {
            if (Control is ActivityItemListViewHolder holder)
            {
                holder.ComponentModel.AppointmentInserted -= ComponentModel_AppointmentInserted;
                holder.ComponentModel.AppointmentUpdated -= ComponentModel_AppointmentUpdated;
                holder.ComponentModel.AppointmentRemoved -= ComponentModel_AppointmentRemoved;
                holder.ComponentModel.AppointmentInserting -= ComponentModel_AppointmentInserting;
            }
            AssignDataSourceToControl(null);
            base.BreakLinksToControls();
        }
        protected override void AssignDataSourceToControl(object dataSource)
        {
            if (Control is ActivityItemListViewHolder holder)
            {
                if (holder.ComponentModel.Data is IBindingList bindingList)
                {
                    bindingList.ListChanged -= BindingList_ListChanged;
                }
                holder.ComponentModel.Data =
                    (dataSource as IEnumerable)?.OfType<ActivityEvent>().OrderBy(i => i.StartOn);
                if (dataSource is IBindingList newBindingList)
                {
                    newBindingList.ListChanged += BindingList_ListChanged;
                }
            }
        }

        private void BindingList_ListChanged(object sender, ListChangedEventArgs e)
        {
            Refresh();
        }

        public override void Refresh()
        {
            if (Control is ActivityItemListViewHolder holder)
            {
                holder.ComponentModel.Refresh();
            }
        }

        #region IComplexListEditor Members
        public void Setup(CollectionSourceBase collectionSource, XafApplication application)
        {
            this.collectionSource = collectionSource;
            this.application = application;
        }
        #endregion
    }
}
