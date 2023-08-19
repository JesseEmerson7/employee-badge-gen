using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace CatWorx.BadgeMaker
{
  class Program
  {
    async static Task Main(string[] args)
    {
      
      Console.WriteLine("Would you like to enter in manually? write y or n");
      string answer = Console.ReadLine() ?? "";
      List<Employee> employees;
      if(answer == "y"){
        employees = PeopleFetcher.GetEmployees();
       
      }else {
              
        employees = await PeopleFetcher.GetFromApi();

      }

       Util.PrintEmployees(employees);
      Util.MakeCSV(employees);
      await Util.MakeBadges(employees);
  
     
    }
  }
}

