using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebApplication.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        // Data Annotations 
        //  -  Used to tell the UI/User that this data would be in appropriate
        // to be sent to the Database. Without this The database would receive bad requests
        // all the time without the User knowing why the application is having issues. The database
        // needs a way to validate potentially bad/incompatable input.
        //   -  The converse is the same.  Data that comes in from the database can also be checked.
        // For example, A null value from the database can be processed before getting pushed to
        // UI logic.
        //
        // Types (Reasons to use Data Annotaions)
        // - Authorization
        // - Display purposes
        // - Annotation purposes
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string UserPass { get; set; }
        public long? Phone { get; set; }

    }
}
