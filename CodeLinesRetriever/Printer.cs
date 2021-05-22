using LOCRetriever;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeLinesRetriever
{
    public class Printer
    {
        public static void PrintResult(string RepositoryName, List<Requirement> Requirements, List<CountResponseItem> Items)
        {
            try
            {
                Console.WriteLine("Desplegando información...");

                Items.ForEach(i =>
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Req: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(i.Requirement);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(", LOC: ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(i.LinesOfCodeAdded);


                    if (Items.Count == 1 && Items.FirstOrDefault().Requirement == "Todos")
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        //Console.Write(dr.Item1);
                        //Console.Write(" - ");
                        //Console.WriteLine(dr.Item2);
                        //i.Commits.Where(c => DateTime.Parse(c.CreatedAt) >= dr.Item1 && DateTime.Parse(c.CreatedAt) <= dr.Item2.AddDays(1).AddSeconds(-1)).ToList().ForEach(c =>
                        //{
                        // Console.WriteLine(string.Format("{0} - {1} - {2}", c.CommitId, c.CreatedAt, c.Message));
                        //});
                        Items.FirstOrDefault().Commits.ForEach(c =>
                        {
                            Console.WriteLine(string.Format("{0} - {1} - {2}", c.CommitId, c.CreatedAt, c.Message));
                        });

                    }
                    else
                    {
                        Requirements.Where(r => r.Identifier == i.Requirement).FirstOrDefault().DateRange.ForEach(dr =>
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(dr.Item1);
                            Console.Write(" - ");
                            Console.WriteLine(dr.Item2);
                            i.Commits.Where(c => DateTime.Parse(c.CreatedAt) >= dr.Item1 && DateTime.Parse(c.CreatedAt) <= dr.Item2.AddDays(1).AddSeconds(-1)).ToList().ForEach(c =>
                            {
                                Console.WriteLine(string.Format("{0} - {1} - {2}", c.CommitId, c.CreatedAt, c.Message));
                            });
                        });
                        Console.WriteLine("");
                        Console.WriteLine("");
                    }
                });

                Console.ResetColor();
                Console.WriteLine("Proceso ejecutado con éxito...");
                Console.ReadLine();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MyMethodCustom(int SelectedOption)
        {
            try
            {
                switch (SelectedOption)
                {
                    case 1:
                        {
                            //Do something
                            break;
                        }
                    case 2:
                        {
                            //Do something
                            break;
                        }
                    case 3:
                        {
                            //Do something
                            break;
                        }
                    default:
                        { //Do something
                            break;
                        }
                }

                //another action
            }
            catch (Exception)
            {
                //Do shomething.
            }
        }
    }
}