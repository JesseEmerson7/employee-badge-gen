using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker{

class PeopleFetcher{
    
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

    //get info from api method

    async public static Task<List<Employee>> GetFromApi(){

        using(HttpClient client = new HttpClient()){
            string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
            
            JObject json = JObject.Parse(response);
            // ToDo: Need to loop though the items in the JObject and pull the values like javascript Json
        }
        List<Employee> employees = new List<Employee>();
        return employees;
    }
}

}