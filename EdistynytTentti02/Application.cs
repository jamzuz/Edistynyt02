using System;
using System.Collections.Generic;
using System.Text;

namespace EdistynytTentti02
{
    static class Application
    {
        //Muuttujat
        private static ConsoleControl JobMenu;
        private static ConsoleControl JobDetails;
        private static ConsoleControl JobEmployees;
        // ominaisuudet
        //metodit
        private static void BindMenuData(List<Job> jobs)
        {
            if (JobMenu.Items == null)
            {
                JobMenu.Items = new List<string>();
            }
            
            foreach (var item in jobs)
            {
                JobMenu.Items.Add($"{item.Id} {item.Title}");
            }   
        }

        private static void BindDetailsData(Job job)
        {
            if (JobDetails.Items == null)
            {
                JobDetails.Items = new List<string>();
            }
            else
            {
                JobDetails.Items.Clear();
            }
            JobDetails.Items.Add($"TYÖN TIEDOT");
            JobDetails.Items.Add($"Id: {job.Id}");
            JobDetails.Items.Add($"Nimi: {job.Title}");
            JobDetails.Items.Add($"Alkaa: {job.StartDate.ToShortDateString()}");
            JobDetails.Items.Add($"Loppuu: {job.EndDate.ToShortDateString()}");
        }

        private static void BindEmployeesData(Job job)
        {
            if (JobEmployees.Items == null)
            {
                JobEmployees.Items = new List<string>();
            }
            else
            {
                JobEmployees.Items.Clear();           
            }
            JobEmployees.Items.Add($"TYÖN TEKIJÄT");
            foreach (var employee in Data.employees)
            {
                if (employee.Jobs.Contains(job))
                {
                    foreach (var item in employee.Jobs)
                    {
                        if (job.Id == item.Id)
                        {
                            JobEmployees.Items.Add(employee.Name);
                        }
                    }
                    
                }
            }
            //foreach (var item in Data.employees)
            //{
            //    if (job.Id == item.Id)
            //    {
            //        JobEmployees.Items.Add($"{item.Name}");
            //    }
            //}

        }

        private static void Initialize()
        {
            JobMenu = new ConsoleControl(1, 2, (Console.WindowWidth / 2) - 1, Data.jobs.Count) {BackColor = ConsoleColor.Gray, TextColor = ConsoleColor.DarkBlue };
            JobDetails = new ConsoleControl(Console.WindowWidth/2 + 1, 2, Console.WindowWidth-1, 5) { BackColor = ConsoleColor.Gray, TextColor = ConsoleColor.DarkGreen };
            JobEmployees = new ConsoleControl(Console.WindowWidth/2 + 1, JobMenu.Height+3, JobDetails.Column, Console.WindowHeight-(JobDetails.Height+1)) { BackColor = ConsoleColor.Gray, TextColor = ConsoleColor.DarkRed };
            BindMenuData(Data.jobs);
            Mediator.Instance.JobChanged += (sender, e) => { BindDetailsData(e.Job); };
            Mediator.Instance.JobChanged += (sender, e) => { BindEmployeesData(e.Job); };

        }

        private static void MenuSelectionChanged(int Id)
        {
            foreach (var item in Data.jobs)
            {
                if (item.Id == Id)
                {
                    Mediator.Instance.OnJobChanged(JobMenu, item);
                    JobDetails.Draw();
                    JobEmployees.Draw();
                }
            }
        }

        public static void Run()
        {
             
            Initialize();
            JobMenu.Draw();
            
            int syote;

                do
                {

                    Console.SetCursorPosition(0, 0);
                    Console.Write("Valitse työn id(nolla lopettaa)");
                    
                if (!int.TryParse(Console.ReadLine(), out syote))
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write("Virheellinen syote. Paina Enter.");
                        Console.ReadLine();
                    }
                    else
                    {
                        //int.TryParse(Console.ReadLine(), out syote);
                        MenuSelectionChanged(syote);
                    }

                } while (syote != 0);

                //if (!int.TryParse(Console.ReadLine(), out int syote))
                //{
                //    Console.Write("Työn id on numero");
                //}
                
                //if (syote !<= 0 && syote !>= JobMenu.Items.Count)
                //{
                //    Console.SetCursorPosition(0, 0);
                //    Console.Write("Virheellinen syote. Paina Enter");
                //    Console.ReadLine();
                //}
                //if (syote == 0)
                //{
                //    break;
                //}
                //else
                //{
                //    MenuSelectionChanged(syote);
                //}

        }
        

    }
}
