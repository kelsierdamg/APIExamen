namespace APIExamen
{
    public partial class MainPage : ContentPage
    {
        private readonly UserServices _service = new UserServices(); 
        private List<User> _usuarios = new(); 
        public MainPage()
        { 
            InitializeComponent();
        }
        private async void BtnConsulta_Clicked(object sender, EventArgs e)
        {
            BtnConsulta.IsEnabled = false; 
            try 
            { 
                _usuarios = await _service.GetUsersAsync();
                if (_usuarios.Count == 0)
                {
                    await DisplayAlert("Error", "No se pudo obtener la información.", "OK"); 
                    return;
                } 
                ListaUsuarios.ItemsSource = _usuarios;
            } 
            catch (Exception ex)
            { 
                await DisplayAlert("Error", $"Ocurrió un problema: {ex.Message}", "OK"); 
            } 
            finally 
            { 
                BtnConsulta.IsEnabled = true; 
            } 
        }
        private void TxtFiltro_TextChanged(object sender, TextChangedEventArgs e) 
        { 
            if (string.IsNullOrWhiteSpace(e.NewTextValue)) 
            { 
                ListaUsuarios.ItemsSource = _usuarios; 
                return; 
            } 
            var letra = e.NewTextValue.ToUpper()[0];
            ListaUsuarios.ItemsSource = _usuarios
                .Where(u => u.Name.ToUpper().StartsWith(letra))
                .ToList(); 
        }
    }
}
