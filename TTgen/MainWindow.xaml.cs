using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace TTgen
{
    public partial class MainWindow : Window
    {
        private Dictionary<int, List<string>> classes = new Dictionary<int, List<string>>();
        public ObservableCollection<string> Subjects { get; set; }
        public ObservableCollection<string> Teachers { get; set; }
        public ObservableCollection<string> Classes { get; set; }
        public ObservableCollection<ScheduleItem> Schedule { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
            InitializeClasses();
        }

        // Инициализация классов с 1 по 11, добавляем секцию "А"
        private void InitializeClasses()
        {
            for (int i = 1; i <= 11; i++)
            {
                classes[i] = new List<string> { "А" }; // Каждый класс начинается с секции "А"
            }

            UpdateClassList();
        }

        private void InitializeData()
        {
            // Инициализация списков
            Subjects = new ObservableCollection<string> { "Математика", "Физика", "Русский язык" };
            Teachers = new ObservableCollection<string> { "Учитель 1", "Учитель 2", "Учитель 3" };
            Classes = new ObservableCollection<string> { "11А", "10Б", "9В" };

            // Привязка списков к элементам UI
            SubjectsList.ItemsSource = Subjects;
            TeachersList.ItemsSource = Teachers;
            InitializeClasses();
        }

        // Обновление отображаемого списка классов в ItemsControl
        private void UpdateClassList()
        {
            List<string> classSections = new List<string>();

            foreach (var kvp in classes)
            {
                int classNumber = kvp.Key;
                foreach (var section in kvp.Value)
                {
                    classSections.Add($"{classNumber} {section}");
                }
            }

            ClassListControl.ItemsSource = classSections;
        }

        // Проверка на следующую доступную букву для класса
        private char GetNextAvailableSection(int classNumber)
        {
            // Получаем список существующих секций для данного класса
            var existingSections = classes[classNumber];
            // Проверяем по алфавиту, начиная с 'А', какую букву можно добавить
            for (char section = 'А'; section <= 'Я'; section++)
            {
                if (!existingSections.Contains(section.ToString()))
                {
                    return section; // Возвращаем первую свободную букву
                }
            }
            return '\0'; // Если все буквы заняты, возвращаем пустой символ
        }

        // Добавление секции (Б, В, и т.д.) к классу
        private void AddClassSection_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var stackPanel = button.Parent as StackPanel;
            var textBlock = stackPanel.Children[0] as TextBlock;
            string classText = textBlock.Text; // Например, "11 А"
            var classParts = classText.Split(' '); // Разделяем на номер класса и секцию
            int classNumber = int.Parse(classParts[0]);

            // Получаем следующую доступную секцию для этого класса
            char nextSection = GetNextAvailableSection(classNumber);

            if (nextSection != '\0')
            {
                classes[classNumber].Add(nextSection.ToString()); // Добавляем доступную секцию
                UpdateClassList();
            }
            else
            {
                MessageBox.Show($"Для класса {classNumber} больше нет доступных секций.");
            }
        }

        // Удаление последней секции у класса
        private void RemoveClassSection_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var stackPanel = button.Parent as StackPanel;
            var textBlock = stackPanel.Children[0] as TextBlock;
            string classText = textBlock.Text; // Например, "11 А"
            var classParts = classText.Split(' '); // Разделяем на номер класса и секцию
            int classNumber = int.Parse(classParts[0]);

            // Удаляем последнюю секцию, если она не единственная (оставляем хотя бы "А")
            if (classes[classNumber].Count > 1)
            {
                classes[classNumber].RemoveAt(classes[classNumber].Count - 1);
                UpdateClassList();
            }
        }
    }
}
