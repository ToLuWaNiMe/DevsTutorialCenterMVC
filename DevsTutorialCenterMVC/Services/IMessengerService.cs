using DevsTutorialCenterMVC.Data.Entities;

namespace DevsTutorialCenterMVC.Services
{
    public interface IMessengerService
    {
        string Send(Message message, string Attachment = "");
    }
}