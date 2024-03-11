namespace Text_Editor
{
    public partial class Form1 : Form
    {
        private const string FileFilter = "Text docs (*.txt)|*.txt|All Files (*.*)|*.*";

        private string _pathToFile;

        public Form1()
        {
            InitializeComponent();

            _pathToFile = string.Empty;
        }

        private void SaveContentToFile(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_pathToFile))
            {
                var dialog = new SaveFileDialog { Filter = FileFilter };

                if (IsOpenedDialog(dialog) == DialogResult.Cancel)
                    return;

                _pathToFile = GetPathToFile(dialog);
            }

            File.WriteAllText(_pathToFile, contentBox.Text);
        }

        private void SaveAsContentToFile(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog { Filter = FileFilter };

            if (IsOpenedDialog(dialog) == DialogResult.Cancel)
                return;

            _pathToFile = GetPathToFile(dialog);

            File.WriteAllText(_pathToFile, contentBox.Text);
        }


        private void ReadContentFromFile(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = FileFilter };

            if (IsOpenedDialog(dialog) == DialogResult.Cancel)
                return;

            _pathToFile = GetPathToFile(dialog);

            contentBox.Text = File.ReadAllText(_pathToFile);
        }

        private static string GetPathToFile(FileDialog dialog) => dialog.FileName;
        private static DialogResult IsOpenedDialog(FileDialog dialog) => dialog.ShowDialog();
    }
}
