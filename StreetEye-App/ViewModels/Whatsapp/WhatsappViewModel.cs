using StreetEye_App.Models;
using StreetEye_App.Services.Whatsapp;
using System.Windows.Input;

public class WhatsappViewModel
{
    private readonly WhatsappService _whatsappService;

    public ICommand SendHelpMessageCommand { get; }

    public WhatsappViewModel()
    {
        _whatsappService = new WhatsappService();
        SendHelpMessageCommand = new Command(async () => await SendHelpMessage());
    }

    private async Task SendHelpMessage()
    {
        Usuario usuario = new Usuario();

        string phoneNumber = "RECIPIENT_PHONE_NUMBER"; // Substituir pelo número de telefone real
        string message = "Preciso de ajuda!";// Mensagem de socorro

        bool success = await _whatsappService.SendMessage(phoneNumber, message);

        if (success)
        {
            await Application.Current.MainPage.DisplayAlert("Sucesso", "A mensagem de socorro foi enviada com sucesso!", "OK");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Erro", "Falha ao enviar a mensagem de socorro. Por favor, tente novamente.", "OK");
        }
    }
}
