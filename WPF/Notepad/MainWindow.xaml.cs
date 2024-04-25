using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;

namespace Notepad
{
    public partial class MainWindow : Window
    {
        private string _pathToFile;
        private readonly Encoding _defaultEncoding = Encoding.UTF8;

        private const string FileExtensions = "Text docs (*.txt)|*.txt|All Files (*.*)|*.*";

        public MainWindow()
        {
            InitializeComponent();

            _pathToFile = string.Empty;
        }

        private void SaveContentToFile(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_pathToFile))
            {
                var dialog = new SaveFileDialog { Filter = FileExtensions };

                if (IsOpenedDialog(dialog) == false)
                    return;

                _pathToFile = GetPathToFile(dialog);
            }

            File.WriteAllText(_pathToFile, contentBox.Text, _defaultEncoding);
        }

        private void SaveAsContentToFile(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog { Filter = FileExtensions };

            if (IsOpenedDialog(dialog) == false)
                return;

            _pathToFile = GetPathToFile(dialog);

            File.WriteAllText(_pathToFile, contentBox.Text, _defaultEncoding);
        }

        private void LoadContentFromFile(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = FileExtensions };

            if (IsOpenedDialog(dialog) == false)
                return;

            _pathToFile = GetPathToFile(dialog);

            contentBox.Text  = File.ReadAllText(_pathToFile, _defaultEncoding);
        }

        private void OpenAboutDialog(object sender, RoutedEventArgs e) => MessageBox.Show("Program made by Belousov Andrey", "About");

        private static string GetPathToFile(FileDialog dialog) => dialog.FileName;
        private static bool? IsOpenedDialog(FileDialog dialog) => dialog.ShowDialog();
    }
}
