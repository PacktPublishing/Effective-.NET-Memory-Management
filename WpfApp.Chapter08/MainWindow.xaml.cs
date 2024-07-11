using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Chapter08
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WeakEventManager<Button, RoutedEventArgs>.AddHandler(MyButton, "Click", MyButton_Click);
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked!");
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            WeakEventManager<Button, RoutedEventArgs>.RemoveHandler(MyButton, "Click", MyButton_Click);
        }
    }
}
