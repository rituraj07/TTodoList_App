using db.Model;
using Java.IO;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace db.ViewModel
{
    class DBViewModel : INotifyPropertyChanged
    {

        private SQLiteConnection conn;
        public Student student;
        public DBViewModel()
        {
            //InitializeComponent();
            // BindingContext = new MainPage();
            conn = DependencyService.Get<ISqlite>().GetConnection();
            conn.CreateTable<Student>();
        }
        private string _name { get; set; }
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
         }
        private ObservableCollection<Student> _datalist;
        public ObservableCollection<Student> datalist
        {
            get
            {
                return _datalist;
            }
            set
            {
                _datalist = value;
                OnPropertyChanged();
            }
        }
        public Command SaveButton_Clicked
        {
            get
            {
                
                return new Command(() =>
                {
                    
                    student = new Student();
                    student.Name = name;
                    student.Address = add;
                    conn.Insert(student);
                    System.Diagnostics.Debug.WriteLine(student.Name);
                    name = "";
                    add = "";
                });
            }
            

        }

        public Command ShowButton_Clicked
        {
            get
            {
                return new Command(() =>
                {
                    
                    datalist = new ObservableCollection<Student>();
                    var data = (from Stu in conn.Table<Student>() select Stu);
                    //datalist = data;
                    foreach (var i in data)
                    { datalist.Add(i);  }
                    foreach(var i in datalist)
                    { System.Diagnostics.Debug.WriteLine(i.Name);  }
                });
            }
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string n=null)
        {
            System.Diagnostics.Debug.WriteLine("property called");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
        }
    }
}
