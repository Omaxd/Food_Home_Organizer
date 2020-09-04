using System.Collections.Generic;
using DataLayer.Model;

namespace DataLayer
{
    public sealed class DataStore
    {
        private static DataStore _instance;
        private static readonly object Padlock = new object();

        private DataStore()
        {
            SeedData();
        }

        public State State { get; set; }

        public static DataStore Instance
        {
            get
            {
                lock (Padlock)
                {
                    _instance ??= new DataStore();

                    return _instance;
                }
            }
        }

        private void SeedData()
        {
            State = new State(
                users: new List<User>
                {
                    new User
                    {
                        Id = new System.Guid(),
                        Login = "Julia123",
                        Email = "julga@yahoo.com", 
                        Password = "haslo1234@",
                        FirstName = "Julia", 
                        Phone = "222333444"
                    },

                    new User
                    {
                        Id = new System.Guid(),
                        Login = "TurboSzymek",
                        Email = "szymi133@o2.pl",
                        Password = "userXd",
                        FirstName = "Szymon", 
                        Phone = "123456789"
                    },

                    new User
                    {
                        Id = new System.Guid(),
                        Login = "ElTomek",
                        Password = "userXd",
                        Email = "tomcioxd@gmail.eu", 
                        FirstName = "Tomek", 
                        Phone = "122333444",
                    },

                    new User
                    {
                        Id = new System.Guid(),
                        Login = "Test",
                        Password = "test123",
                        Email = "test123@gmail.eu",
                        FirstName = "Tester",
                        Phone = "122333444",
                    }
                },
                foods: new List<Food>
                {
                    new Food
                    {
                        Id = new System.Guid(),
                        Name = "Jajko",
                        Kcal = 145,
                        Protein = 14,
                        Carbohydrates = 14,
                        Fat = 10,
                        IsVegetarian = true
                    },
                    new Food
                    {
                        Name = "Kurczak",
                        Kcal = 121,
                        Protein = 22,
                        Carbohydrates = 0,
                        Fat = 4,
                        IsVegetarian = false
                    },
                    new Food
                    {
                        Name = "Chleb żytni",
                        Kcal = 259,
                        Protein = 9,
                        Carbohydrates = 48,
                        Fat = 3,
                        IsVegetarian = true
                    },

                },
                informations: new List<Information>
                {
                    new Information {Content = "WAKACJE"},
                    new Information {Content = "DARMOWA_DOSTAWA"},
                    new Information {Content = "NA_PLAZY"},
                    new Information {Content = "LUBIMY_CZYTAC"},
                    new Information {Content = "EBOOK"},
                    new Information {Content = "MAKULATURA"}
                }
            );
        }
    }
}