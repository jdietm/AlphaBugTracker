namespace AlphaBugTracker.TICKET_UPGRADE_ZACH_INTERVIEW
{
    public class TicketUsingDesignPatterns
    {
    }

//    /*
//   Factory Pattern 
// */

//    public abstract class SupportDepartment
//    {
//        public Ticket TicketRequest(string ticketRequest)
//        {
//            Ticket ticket = createTicket(ticketRequest);
//            ticket.PerformSlaResponseDeadline();
//            ticket.PerformSlaBreachDeadline();

//            return ticket;
//        }
//        public abstract Ticket createTicket(string ticketRequest);
//    }

//    public class BugReportArea : SupportDepartment
//    {
//        public override Ticket createTicket(string ticketRequest)
//        {
//            Ticket ticket = null;
//            if (ticketRequest == "1")
//            {
//                ticket = new BugReport();

//            }
//            else
//            {
//                throw new Exception("Error");
//            }
//            return ticket;
//        }
//    }


//    public class ServiceRequestArea : SupportDepartment
//    {
//        public override Ticket createTicket(string ticketRequest)
//        {
//            Ticket ticket = null;
//            if (ticketRequest == "2")
//            {
//                ticket = new ServiceRequest();

//            }
//            else
//            {
//                throw new Exception("Error");
//            }
//            return ticket;
//        }
//    }

//    public class WebFormRequest : SupportDepartment
//    {
//        public override Ticket createTicket(string ticketRequest)
//        {

//            Ticket ticket = null;
//            if (ticketRequest == "1")
//            {
//                ticket = new BugReport();

//            }
//            else if (ticketRequest == "2")
//            {
//                ticket = new ServiceRequest();

//            }
//            else
//            {
//                throw new Exception("Error");
//            }
//            return ticket;
//        }
//    }


//    /*
//         Strategic Pattern 
//     */

//    public interface ISlasCalculating
//    {
//        int ResponseDeadLineCalculating();
//        int BreachDeadLineCalculating();
//    }

//    public class SlasBugReport : ISlasCalculating
//    {
//        public int BreachDeadLineCalculating()
//        {
//            // Custom Rules to determine the SLA based on Priority, Type of Ticket, others...
//            int formula = 1 + 0;
//            return formula;
//        }

//        public int ResponseDeadLineCalculating()
//        {
//            // Custom Rules to determine the SLA  Note: Depending on the formula  (if are specific criteria to add up or deduct hourse, It could be implemented with Decorator
//            int formula = 10 * 1;
//            return formula;
//        }
//    }

//    public class SlasServiceRequest : ISlasCalculating
//    {
//        public int BreachDeadLineCalculating()
//        {
//            // Custom Rules to determine the SLA 
//            int formula = 2 + 0;
//            return formula;
//        }

//        public int ResponseDeadLineCalculating()
//        {
//            // Custom Rules to determine the SLA 
//            int formula = 20 + 2;
//            return formula;
//        }
//    }



//    public abstract class Ticket
//    {
//        public int Id { get; set; }
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public string User { get; set; }    // FK To the correspondent entity
//        public DateTime dateTime { get; set; } = DateTime.Now;
//        public int ResponseDeadline { get; set; }
//        public int BreachDeadline { get; set; }

//        public ISlasCalculating slasCalculating { get; set; }

//        public int PerformSlaResponseDeadline()
//        {
//            return slasCalculating.ResponseDeadLineCalculating();
//        }
//        public int PerformSlaBreachDeadline()
//        {
//            return slasCalculating.BreachDeadLineCalculating();
//        }
//    }


//    public class BugReport : Ticket
//    {
//        public string ErrorCodes { get; set; }
//        public string ErrorLogs { get; set; }
//        public BugReport()
//        {
//            Id = 1;
//            Title = "Ticket Bug Report";
//            Description = "This a bug report";
//            User = "Johnny";
//            slasCalculating = new SlasBugReport();
//            ResponseDeadline = slasCalculating.ResponseDeadLineCalculating();
//            BreachDeadline = slasCalculating.BreachDeadLineCalculating();
//        }
//    }


//    public class ServiceRequest : Ticket
//    {
//        public TypeOfRequest TypeOfRequest { get; set; }
//        public ServiceRequest()
//        {
//            Id = 2;
//            Title = "Ticket Service Request";
//            Description = "This a ticket requiesting a Service";
//            User = "Johnny";
//            slasCalculating = new SlasServiceRequest();
//            ResponseDeadline = slasCalculating.ResponseDeadLineCalculating();
//            BreachDeadline = slasCalculating.BreachDeadLineCalculating();
//        }
//    }

//    public enum TypeOfRequest
//    {
//        Service_A,
//        Service_B,
//        Service_C
//    }


//}
