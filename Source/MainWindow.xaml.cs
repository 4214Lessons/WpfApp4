using Bogus;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Source;

public partial class MainWindow : Window
{
    public List<User> Users { get; set; }



    public MainWindow()
    {
        InitializeComponent();

        DataContext = this;



        // Bogus > Faker (Fake data)

        Users = new Faker<User>()
            .RuleFor(u => u.Firstname, faker => faker.Person.FirstName)
            .RuleFor(u => u.Lastname, faker => faker.Person.LastName)
            .RuleFor(u => u.Gender, faker => faker.Person.Gender.ToString())
            .RuleFor(u => u.Phone, faker => faker.Person.Phone)
            .RuleFor(u => u.ImageUrl, faker => faker.Person.Avatar)
            .RuleFor(u => u.Email, faker => faker.Person.Email)
            .RuleFor(u => u.Address, faker => faker.Person.Address.City)
            .RuleFor(u => u.DateOfBirth, faker => faker.Person.DateOfBirth)
            .Generate(10);
    }



    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button btn = sender as Button;
        Grid grid = btn.Parent as Grid;
        StackPanel sp = grid.Children[1] as StackPanel;
        TextBlock textBlock = sp.Children[0] as TextBlock;

        MessageBox.Show(textBlock.Text);
    }



    private void AddUser(object sender, RoutedEventArgs e)
    {
        listView.ItemsSource = null;
        Users.Add(new User { Firstname = "AAA" });
        listView.ItemsSource = Users;
    }
}