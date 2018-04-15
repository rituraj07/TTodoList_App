using db.Model;
using db.ViewModel;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace db
{
    public partial class MainPage : ContentPage //, INotifyPropertyChanged
    {
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new DBViewModel();
            //conn = DependencyService.Get<ISqlite>().GetConnection();
            //conn.CreateTable<Student>();
        }

       /* private void myb_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("qwerty");
        }*/
        /* private string _name { get; set; }
public string name
{
    get { return _name; }
    set { _name = value;OnPropertyChanged(); }
}
private string _add { get; set; }
public string add
{
    get { return _add; }
    set { _add = value; OnPropertyChanged(); }
}*/
        /* private void SaveButton_Clicked(object sender, EventArgs e)
         {
             student = new Student();
             student.Name = name.Text;
             student.Address = add.Text;
             conn.Insert(student);
             name.Text = "";
             add.Text = "";

         }

         private void ShowButton_Clicked(object sender, EventArgs e)
         {
             var data = (from Stu in conn.Table<Student>() select Stu);
             datalist.ItemsSource = data;
         }*/
        /*public new event PropertyChangedEventHandler PropertyChanged;
      override  protected void OnPropertyChanged([CallerMemberName] string n=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
        }*/
    }
}
