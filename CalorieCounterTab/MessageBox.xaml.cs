using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CalorieCounterTab
{
    public sealed partial class MessageBox : UserControl
    {
        public MessageBox()
        {
            this.InitializeComponent();
            this.Visibility = Visibility.Collapsed;
        }

        public void showMessage(string message)
        {
            this.Visibility = Visibility.Visible;
            TextBlockMessage.Text = message;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
