using DevsTutorialCenterMVC.Models;

namespace DevsTutorialCenterMVC.Services
{
    public interface IMessengerService
    {
        string Send(Message message, string Attachment = "");
    }
}