namespace CatWorx.BadgeMaker{

        class Employee {

            public string FirstName;
            public string LastName;
            public int Id;
            public string? PhotoUrl;
            public Employee (string firstName, string lastName = "Smith", int id = 0, string photoUrl = "0"){
                FirstName = firstName;
                LastName = lastName;
                Id = id;
                PhotoUrl = photoUrl;
            }

            public string GetFullName(){
                return FirstName + " " + LastName;
            }

            public int GetId(){
                return Id;
            }

            public string GetPhotoUrl(){
                return PhotoUrl ?? "";
            }

            public string GetCompanyName(){
                return "Cat Worx";
            }
        }
}