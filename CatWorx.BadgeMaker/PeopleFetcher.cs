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

          List<Employee> employees = new List<Employee>();

        using(HttpClient client = new HttpClient()){
            string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
            
            JObject json = JObject.Parse(response);
            // ToDo: Need to loop though the items in the JObject and pull the values like javascript Json
            // Console.WriteLine(json.SelectToken("results"));
        
                JArray? results = json.SelectToken("results") as JArray;
            if(results != null){
                  foreach(JObject jsonObject in results){
                string firstName = jsonObject.SelectToken("name.first")?.ToString() ?? "";
                string lastName = jsonObject.SelectToken("name.last")?.ToString() ?? "";
                string idSting = jsonObject.SelectToken("id.value")?.ToString().Replace("-","") ?? "";
                int id = int.Parse(idSting);
                string photoUrl = jsonObject.SelectToken("picture.medium")?.ToString() ?? "";
                Employee newEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(newEmployee);

            }
            }
          
        }
      
        return employees;
    }
}

}