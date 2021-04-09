using System;
using System.Collections.Generic;
using System.Text;

namespace EdistynytTentti02
{
     sealed class Mediator
    {
        //kenttämuuttujat
        private static Mediator instance = new Mediator();
        //ominaisuudet
        public static Mediator Instance { get => instance; }
        //konstruktori
        private Mediator()
        {

        }
        //tapahtumat
        public event EventHandler<JobChangedEventArgs> JobChanged;
        //metodit
        //public void OnJobChanged(object sender, Job job) 
        //{
            //Delegate jobChangeDelegate = JobChanged as System.EventHandler<JobChangedEventArgs>;

            //if (jobChangeDelegate != null)
            //{
            //    JobChanged(sender, new JobChangedEventArgs() { Job = job });
            //}
            

        //}

        public void OnJobChanged(object sender, Job job)
        {
            Delegate jobChangeDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            if (jobChangeDelegate != null)
            {
                JobChanged(sender, new JobChangedEventArgs() { Job = job });
            }
        }
    }
}
