using DevsTutorialCenterMVC.Models;

namespace DevsTutorialCenterMVC.Services.Interfaces;

public interface IMessengerService
{
    string Send(Message message, string Attachment = "");
}