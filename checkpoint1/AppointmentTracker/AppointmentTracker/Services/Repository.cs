using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentTracker.Models;

namespace AppointmentTracker.Services
{
    public class Repository
    {

        //start by getting customer working with a repo and a list

        //usually has crud functions

        //lists of data: customers and service providers and appointments
        //CHECKER function to see if appt is available, or make that it's own clss
        //Look through the appt list, if the appt time equals the proposed and the provider == the proposed provider, checking before adding
        //cust bob wants appt with suzy at 6, look through each item in the list, does suzy have the appt at 6pm with anyone, a loop with an if statement
        //OR linq
        //IS appt available method (date time property to check, service provider to check) in appt repository
        //write down on paper, loop through appt list, if appt time = the proposed time and the appt provide = proposed provide return false
        //have to think through all the options 
        //for seperation of concerns, you 
        //

        //make three repositories for each of our three data structures


    }
}
