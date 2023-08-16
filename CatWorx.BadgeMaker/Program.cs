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
      // List<Employee> employees = PeopleFetcher.GetEmployees();
      List<Employee> employees = await PeopleFetcher.GetFromApi();
      Util.PrintEmployees(employees);
      Util.MakeCSV(employees);
      await Util.MakeBadges(employees);
     
    }
  }
}

/*
  Pseudo code ----

  Create CSV file in program if file does not exist already. 
  once user enters values. those values are saved to CSV file
  Once the file is saved the print employees util takes the info from that file and prints to page
  create automated random ID system if possible
*/