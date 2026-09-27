namespace MAUI_Authentication
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            // Get the username and password from the entry fields
            string username = txtUserID.Text;
            string password = txtPassword.Text;

            // Create an instance of the UserAuthentication class and call the AuthenticateUser method
            var userAuth = new DataAccess.UserAuthentication();

            // Authenticate the user and display an alert based on the result
            bool isAuthenticated = userAuth.AuthenticateUser(username, password);

            // Display an alert based on the authentication result
            if (isAuthenticated)
            {
                DisplayAlert("Success", "User authenticated successfully!", "OK");
            }
            else
            {
                DisplayAlert("Error", "Invalid username or password.", "OK");
            }
        }
    }
}
