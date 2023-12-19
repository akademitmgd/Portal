using DevExpress.Blazor;
using DevExpress.ExpressApp.Blazor.Components.Models;
using iyibir.TMGD.Module.BusinessObjects;
using iyibir.TMGD.Module.POCO;

namespace iyibir.TMGD.Module.Blazor.Editors
{
    public class SchedulerListViewModel : ComponentModelBase
    {
        public IEnumerable<ActivityEvent> Data
        {
            get => GetPropertyValue<IEnumerable<ActivityEvent>>();
            set => SetPropertyValue(value);
        }

        DxSchedulerDataStorage DataStorage;
        public DxSchedulerDataStorage GetDataStorage()
        {
            var dataSource = new List<Appointment>();
            if (Data is not null)
            {
                foreach (var item in Data)
                {
                    dataSource.Add(ConvertToAppointmentPOCO(item));
                }

                DataStorage = new DxSchedulerDataStorage()
                {
                    AppointmentsSource = dataSource,
                    AppointmentMappings = new DxSchedulerAppointmentMappings()
                    {
                        Type = "AppointmentType",
                        Start = "StartDate",
                        End = "EndDate",
                        Subject = "Caption",
                        AllDay = "AllDay",
                        Location = "Location",
                        Description = "Description",
                        LabelId = "Label",
                        StatusId = "Status",
                        RecurrenceInfo = "Recurrence",
                        Id = "OidPoco"
                    }
                };
            }

            return DataStorage;
        }

        public static Appointment ConvertToAppointmentPOCO(ActivityEvent item)
        {
            Appointment appointmentPOCO = new Appointment
            {
                AllDay = item.AllDay,
                AppointmentType = item.Type,
                Caption = item.Subject,
                Description = item.Description,
                EndDate = item.EndOn,
                Label = item.Label,
                Location = item.Location,
                Recurrence = item.RecurrenceInfoXml,
                StartDate = item.StartOn,
                Status = item.Status,
                OidPoco = item.Oid
            };

            return appointmentPOCO;
        }

        public void Refresh() => RaiseChanged();

        public event EventHandler<SchedulerListViewModelAppointmentItemEventArgs> AppointmentInserted;
        public void OnAppointmentInserted(DxSchedulerAppointmentItem appointmentItem) =>
            AppointmentInserted?.Invoke(this, new SchedulerListViewModelAppointmentItemEventArgs(appointmentItem));

        public event EventHandler<SchedulerListViewModelAppointmentItemEventArgs> AppointmentUpdated;
        public void OnAppointmentUpdated(DxSchedulerAppointmentItem appointmentItem) =>
            AppointmentUpdated?.Invoke(this, new SchedulerListViewModelAppointmentItemEventArgs(appointmentItem));

        public event EventHandler<SchedulerListViewModelAppointmentItemEventArgs> AppointmentRemoved;
        public void OnAppointmentRemoved(DxSchedulerAppointmentItem appointmentItem) =>
            AppointmentRemoved?.Invoke(this, new SchedulerListViewModelAppointmentItemEventArgs(appointmentItem));

        public event EventHandler<SchedulerAppointmentOperationEventArgs> AppointmentInserting;
        public void OnAppointmentInserting(SchedulerAppointmentOperationEventArgs e) =>
            AppointmentInserting?.Invoke(this, e);
    }
}

public class SchedulerListViewModelAppointmentItemEventArgs : EventArgs
{
    public SchedulerListViewModelAppointmentItemEventArgs(DxSchedulerAppointmentItem appointmentItem)
    {
        AppointmentItem = appointmentItem;
    }
    public DxSchedulerAppointmentItem AppointmentItem { get; }
}

public class SchedulerListViewModelItemClickEventArgs : EventArgs
{
    public SchedulerListViewModelItemClickEventArgs(ActivityEvent item)
    {
        Item = item;
    }
    public ActivityEvent Item { get; }
}
