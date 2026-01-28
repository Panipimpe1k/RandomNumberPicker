using RandomNumbers.Services;

namespace RandomNumbers.Views
{
    public partial class MainPage : ContentPage
    {
        private List<string> students = new();
        private string selectedClass = "";

        public MainPage()
        {
            InitializeComponent();
            LoadClasses();
        }

        private void LoadClasses()
        {
            ClassPicker.Items.Add("1A");
            ClassPicker.Items.Add("1B");
            ClassPicker.Items.Add("2A");
            ClassPicker.Items.Add("2B");
        }

        private void OnClassChanged(object sender, EventArgs e)
        {
            if (ClassPicker.SelectedIndex == -1) return;

            selectedClass = ClassPicker.SelectedItem.ToString();
            students = FileService.LoadStudents(selectedClass);
            StudentsList.ItemsSource = students;
        }

        private void OnAddStudent(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StudentEntry.Text))
            {
                students.Add(StudentEntry.Text);
                RefreshList();
                StudentEntry.Text = "";
            }
        }

        private void OnRemoveStudent(object sender, EventArgs e)
        {
            if (StudentsList.SelectedItem != null)
            {
                students.Remove(StudentsList.SelectedItem.ToString());
                RefreshList();
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedClass))
            {
                FileService.SaveStudents(selectedClass, students);
                DisplayAlert("Zapis", "Lista została zapisana", "OK");
            }
        }

        private void OnDrawStudent(object sender, EventArgs e)
        {
            if (students.Count == 0) return;

            Random rnd = new Random();
            int index = rnd.Next(students.Count);
            DrawnStudentLabel.Text = $"Wylosowano: {students[index]}";
        }

        private void RefreshList()
        {
            StudentsList.ItemsSource = null;
            StudentsList.ItemsSource = students;
        }
    }
}
