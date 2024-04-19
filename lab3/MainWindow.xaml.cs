using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int oper = 0;
        string[] digits = new string[10000];
        string[] equals = new string[10000];
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }
        private void rbVisible_Checked(object sender, RoutedEventArgs e)
        {
            txtOperations.Visibility = Visibility.Visible;
            AC_one.Visibility = Visibility.Visible;
            chkRecordOperations.Visibility = Visibility.Visible;
        }

        private void rbInvisible_Checked(object sender, RoutedEventArgs e)
        {
            txtOperations.Visibility = Visibility.Hidden;
            AC_one.Visibility = Visibility.Hidden;
            chkRecordOperations.Visibility = Visibility.Hidden;
        }
        private void Button_AC_one_Click(object sender, RoutedEventArgs e)
        {
            if (chkRecordOperations.IsChecked == true)
            {
                digits[oper - 1] = null;
                equals[oper - 1] = null;
                oper -= 1;
                txtOperations.Text = "";
                for (int i = 0; i < oper; i++)
                {
                    txtOperations.Text += digits[i];
                    txtOperations.Text += "=";
                    txtOperations.Text += equals[i];
                    txtOperations.Text += " ";
                }

                textlabel.Text = "";
            }
            else
            {
                textlabel.Text = "";
            }
        }
        private void Button_Click(Object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "AC")
            {
                textlabel.Text = "";
            }
            else if (str == "=")
            {
                string value = new DataTable().Compute(textlabel.Text, null).ToString();
                textlabel.Text = value;
            }
            else
                textlabel.Text += str;
        }
    }
}
