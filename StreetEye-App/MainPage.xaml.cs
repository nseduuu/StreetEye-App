using StreetEye_App.ViewModels.Semaforos;

namespace StreetEye_App;

public partial class MainPage : ContentPage
{
    SemaforoViewModel viewModel;

    public MainPage()
    {
        InitializeComponent();
        viewModel = new SemaforoViewModel();
        BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = viewModel.ObterSemaforos();
    }
}