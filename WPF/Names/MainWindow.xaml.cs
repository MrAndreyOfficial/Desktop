using System.Windows;

namespace Names
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddNameToList(object sender, RoutedEventArgs e)
        {
            string name = nameBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name box is empty");
                return;
            }

            bool canAdd = !(string.IsNullOrWhiteSpace(name) || listOfNames.Items.Contains(name));

            if (!canAdd)
            {
                MessageBox.Show("This name is on the list");
                return;
            }

            listOfNames.Items.Add(name);
            nameBox.Clear();
        }

        private void RemoveNameFromList(object sender, RoutedEventArgs e)
        {
            object name = listOfNames.SelectedItem;

            bool canRemove = name != null;

            if (!canRemove)
            {
                MessageBox.Show("Select name");
                return;
            }

            listOfNames.Items.Remove(name);
        }
    }
}
