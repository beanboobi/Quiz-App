using System;
using System.Data.SqlClient;


namespace QuizConnect.Pages
{
    public partial class LoginPage : ContentPage
    {
        // Define class-level variables
        private Entry usernameEntry;
        private Entry emailEntry;
        private Entry passwordEntry;
        private Entry confirmPasswordEntry;
        private Image usernameImage;
        private Image emailImage;
        private Image passwordImage;
        private Image reenterPasswordImage;


        public LoginPage()
        {
            InitializeComponent();
        }
        public class User
        {
            public string Username { get; set; }
            public string PasswordHash { get; set; }
        }
        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Check if usernameEntry and passwordEntry are not null
            if (usernameEntry != null && passwordEntry != null)
            {
                string username = usernameEntry.Text;
                string password = passwordEntry.Text;

                if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                {
                    // Here you would typically validate the username and password against your database
                    // For demonstration purposes, let's assume a simple check

                    if (username == "correct_username" && password == "correct_password")
                    {
                        // Authentication successful
                        // Navigate to the homepage
                        await Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        // Authentication failed
                        await DisplayAlert("Error", "Invalid username or password", "OK");
                    }
                }
                else
                {
                    // Display an error message if any field is empty
                    await DisplayAlert("Error", "Please fill in all fields", "OK");
                }
            }
            else
            {
                // Handle the case where usernameEntry or passwordEntry is null
                // This may occur if the XAML elements are not properly initialized
                await DisplayAlert("Error", "An unexpected error occurred. Please try again.", "OK");
            }
        }

        private async void OnSignUpLabelTapped(object sender, EventArgs e)
        {
            // Create labels
            var signUpLabel = new Label
            {
                Text = "Sign Up",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.FromHex("#034078"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 0, 0, 10),
                FontAttributes = FontAttributes.Bold
            };

            // Create images
            usernameImage = new Image { Source = "user.png", HeightRequest = 20, WidthRequest = 20, VerticalOptions = LayoutOptions.Center };
            emailImage = new Image { Source = "email.png", HeightRequest = 20, WidthRequest = 20, VerticalOptions = LayoutOptions.Center };
            passwordImage = new Image { Source = "password.png", HeightRequest = 20, WidthRequest = 20, VerticalOptions = LayoutOptions.Center };
            reenterPasswordImage = new Image { Source = "password.png", HeightRequest = 20, WidthRequest = 20, VerticalOptions = LayoutOptions.Center };

            // Create entry fields
            usernameEntry = new Entry { Placeholder = "Enter your username" };
            emailEntry = new Entry { Placeholder = "Enter your email", Keyboard = Keyboard.Email };
            passwordEntry = new Entry { Placeholder = "Enter your password", IsPassword = true };
            confirmPasswordEntry = new Entry { Placeholder = "Re-enter your password", IsPassword = true };

            // Create frames for entry fields
            var usernameEntryFrame = new Frame
            {
                Content = new Entry { Placeholder = "Enter your username" },
                Padding = new Thickness(5),
                BackgroundColor = Color.FromHex("D9D9D9"),
                CornerRadius = 5
            };

            var emailEntryFrame = new Frame
            {
                Content = new Entry { Placeholder = "Enter your email", Keyboard = Keyboard.Email },
                Padding = new Thickness(5),
                BackgroundColor = Color.FromHex("D9D9D9"),
                CornerRadius = 5
            };

            var passwordEntryFrame = new Frame
            {
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { new Entry { Placeholder = "Enter your password", IsPassword = true }, passwordImage },
                    VerticalOptions = LayoutOptions.Center
                },
                Padding = new Thickness(5),
                BackgroundColor = Color.FromHex("D9D9D9"),
                CornerRadius = 5
            };

            var confirmPasswordEntryFrame = new Frame
            {
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { new Entry { Placeholder = "Re-enter your password", IsPassword = true }, reenterPasswordImage },
                    VerticalOptions = LayoutOptions.Center
                },
                Padding = new Thickness(5),
                BackgroundColor = Color.FromHex("D9D9D9"),
                CornerRadius = 5
            };

            // Create sign-up button
            var signUpButton = new Button
            {
                Text = "Sign Up",
                BackgroundColor = Color.FromHex("#034078"),
                TextColor = Color.FromHex("#ffffff"),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(0, 20, 0, 0),
                FontAttributes = FontAttributes.Bold
            };
            signUpButton.Clicked += async (s, args) =>
            {
                await SignUpWithUsernameAndPassword(usernameEntry.Text, emailEntry.Text, passwordEntry.Text, confirmPasswordEntry.Text);
            };

            // Event handler for toggling password visibility
            var togglePasswordVisibility = new TapGestureRecognizer();
            togglePasswordVisibility.Tapped += (s, e) =>
            {
                passwordEntry.IsPassword = !passwordEntry.IsPassword;
                passwordImage.Source = passwordEntry.IsPassword ? "eye_hide.png" : "eye_show.png";
            };

            // Assign the event handler to the password image
            passwordImage.GestureRecognizers.Add(togglePasswordVisibility);

            // Event handler for toggling confirm password visibility
            var toggleConfirmPasswordVisibility = new TapGestureRecognizer();
            toggleConfirmPasswordVisibility.Tapped += (s, e) =>
            {
                confirmPasswordEntry.IsPassword = !confirmPasswordEntry.IsPassword;
                reenterPasswordImage.Source = confirmPasswordEntry.IsPassword ? "eye_hide.png" : "eye_show.png";
            };

            // Assign the event handler to the confirm password image
            reenterPasswordImage.GestureRecognizers.Add(toggleConfirmPasswordVisibility);

            // Create layout
            var signUpLayout = new StackLayout
            {
                Children =
        {
            signUpLabel,
            new Label { Text = "Please register with email and sign up to continue ...", TextColor = Color.FromHex("#000000"), HorizontalOptions = LayoutOptions.CenterAndExpand, Margin = new Thickness(0, 0, 0, 20) },
            new Label { Text = "Create an Account", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)), TextColor = Color.FromHex("#034078"), HorizontalOptions = LayoutOptions.CenterAndExpand, Margin = new Thickness(0, 0, 0, 20), FontAttributes = FontAttributes.Bold },
            new StackLayout { Orientation = StackOrientation.Horizontal, Children = { usernameImage, usernameEntry }, VerticalOptions = LayoutOptions.Center },
            new StackLayout { Orientation = StackOrientation.Horizontal, Children = { emailImage, emailEntry }, VerticalOptions = LayoutOptions.Center },
            usernameEntryFrame,
            emailEntryFrame,
            passwordEntryFrame,
            confirmPasswordEntryFrame,
            signUpButton
        },
                Padding = new Thickness(20),
                Spacing = 10,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Create sign-up page
            var signUpPage = new ContentPage
            {
                Content = signUpLayout,
                BackgroundImageSource = "background.png"
            };

            // Display the sign-up page as a modal dialog
            await Navigation.PushModalAsync(signUpPage);
        }

        private async Task SignUpWithUsernameAndPassword(string username, string email, string password, string confirmPassword)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(confirmPassword) && password == confirmPassword)
            {
                // Sign-up success
                await DisplayAlert("Sign Up", "Sign-up successful!", "OK");
                // Dismiss the modal dialog after sign-up
                await Navigation.PopModalAsync();
            }
            else
            {
                // Display an error message if any field is empty or passwords don't match
                await DisplayAlert("Error", "Please fill in all fields correctly", "OK");
            }
        }

        private void TogglePasswordVisibility(object sender, EventArgs e)
        {
            // Toggle the IsPassword property of the PasswordEntry
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
            // Change the eye icon based on password visibility
            if (PasswordEntry.IsPassword)
            {
                PasswordVisibilityIcon.Source = "eye_show.png";
            }
            else
            {
                PasswordVisibilityIcon.Source = "eye_hide.png";
            }
        }
    }
}
