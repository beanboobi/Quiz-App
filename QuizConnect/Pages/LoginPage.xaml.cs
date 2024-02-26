using Microsoft.Maui.Controls;
using System;

namespace QuizConnect.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private async void SignUpButton_Clicked(object sender, EventArgs e)
    {
        // Show sign-up pop-up page
        await DisplayAlert("Sign Up", "Sign Up form will appear here", "OK");
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        // Navigate to the login page
        await Navigation.PushAsync(new LoginPage());
    }
}