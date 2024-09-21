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

using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Xml;

namespace WpfApp13
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            var person = new Person
            {
                Name = "Anna",
                Age = 30,
                Address = new Address
                {
                    Street = "aaaa",
                    City = "Moscow",
                    ZipCode = "fffff"
                }
            };

            string jsonString = JsonConvert.SerializeObject(person, Formatting.Indented);
            File.WriteAllText("person.json", jsonString);
            MessageBox.Show("Object serialized to person.json");
        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("person.json"))
            {
                string jsonString = File.ReadAllText("person.json");
                Person person = JsonConvert.DeserializeObject<Person>(jsonString);
                MessageBox.Show($"Name: {person.Name}\nAge: {person.Age}\nStreet: {person.Address.Street}\nCity: {person.Address.City}\nZipCode: {person.Address.ZipCode}");
            }
            else
            {
                MessageBox.Show("person.json not found");
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}