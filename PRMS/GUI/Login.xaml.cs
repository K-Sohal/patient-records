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
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Page
	{
		CRUDManager _crudManager = new CRUDManager();
		public Login()
		{
			InitializeComponent();
		}

		private void Registerbtn_Click(object sender, RoutedEventArgs e)
		{
			Register register = new Register(_crudManager);
			this.NavigationService.Navigate(register);
		}

		private void LoginBtn_Click(object sender, RoutedEventArgs e)
		{
			if (_crudManager.CheckLoginDetails(EmailTextBox.Text, PasswordTextBox.Password))
			{
				_crudManager.SetGP(EmailTextBox.Text);
				GPPatientView gpPatientView = new GPPatientView(_crudManager);
				MessageBox.Show($"Welcome {(_crudManager.selectedGP.FirstName)}");
				this.NavigationService.Navigate(gpPatientView);
			}
			else
			{
				MessageBox.Show("Email or password is incorrect");
			}
		}
	}
}
