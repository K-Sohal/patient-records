using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;

namespace GUI
{
	/// <summary>
	/// Interaction logic for Register.xaml
	/// </summary>
	public partial class Register : Page
	{
		CRUDManager _crudManager;
		public Register(CRUDManager cRUDManager)
		{
			InitializeComponent();
			_crudManager = cRUDManager;
		}

		private bool FieldValidation()
		{
			return string.IsNullOrWhiteSpace(FirstNameTextBox.Text) || string.IsNullOrWhiteSpace(LastNameTextBox.Text)
				|| string.IsNullOrWhiteSpace(EmailTextBox.Text) || string.IsNullOrWhiteSpace(Passwordbox.Password);
		}

		private void Registerbtn_Click(object sender, RoutedEventArgs e)
		{
			if (FieldValidation())
			{
				MessageBox.Show("Please enter a value in all fields");
			}
			else
			{
				if (_crudManager.EmailExists(EmailTextBox.Text))
				{
					MessageBox.Show("Email already exists");
				}
				else
				{
					if (_crudManager.CheckPassword(Passwordbox.Password, ConfirmPasswordBox.Password))
					{
						_crudManager.CreateGP(EmailTextBox.Text, Passwordbox.Password, FirstNameTextBox.Text, LastNameTextBox.Text);
						MessageBox.Show("Registration successful");
						this.NavigationService.Navigate(new Login());
					}
					else
					{
						MessageBox.Show("Passwords do not match");
					}
				}
			}
		}
	}
}
