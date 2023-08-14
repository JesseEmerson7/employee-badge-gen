using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using SkiaSharp;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
  class Util
  {
    public static void PrintEmployees(List<Employee> employees){
        for (int i = 0; i < employees.Count; i++)
      {
        string template = "{0,-10}\t{1,-20}\t{2}";
        Console.WriteLine(string.Format(template,employees[i].GetId(),employees[i].GetFullName(), employees[i].GetPhotoUrl() ));
      }
    }

    public static List<Employee> GetEmployees(){
            List<Employee> employees = new List<Employee>();
      
      bool isTyping = true;
      while (isTyping)
      {
        //first name prompt
        Console.Write("Please enter a first name: ");
        string firstName = Console.ReadLine() ?? "";
        if(firstName == ""){
          break;
        }
        //last name prompt
        Console.Write("Last name: ");
        string lastName = Console.ReadLine() ?? "";
        //ID prompt
        Console.Write("Employee ID: ");
        int id = Int32.Parse(Console.ReadLine() ?? "");
        //photo url prompt
        Console.Write("Please enter a valid Photo URL: ");
        string photoUrl = Console.ReadLine() ?? "";

        Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
        employees.Add(currentEmployee);
      }
      return employees;
    }

    public static void MakeCSV (List<Employee>employees){
        if(!Directory.Exists("data")){
            //if no dir create new
            Directory.CreateDirectory("data");
        }

       using (StreamWriter file = new StreamWriter("data/employees.csv")){
            file.WriteLine("ID,Name,PhotoUrl");
            for (int i = 0; i < employees.Count; i++)
      {
        //writing file with new employees 
        file.WriteLine($"{employees[i].GetId()},{employees[i].GetFullName()},{employees[i].GetPhotoUrl()}");
      }
       }

    }

  async public static Task MakeBadges(List<Employee> employees)
{
  // SKImage newImage = SKImage.FromEncodedData(File.OpenRead("badge.png"));

  // SKData data = newImage.Encode();
  // data.SaveTo(File.OpenWrite("data/employeeBadge.png"));

  using (HttpClient client = new HttpClient())
{
  for (int i = 0; i < employees.Count; i++)
  {
    SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));
    SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));
    
    SKData data = photo.Encode();
    data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
  }
}

}
  }
}