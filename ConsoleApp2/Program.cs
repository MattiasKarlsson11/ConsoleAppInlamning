using System;
using ConsoleApp2.models;

namespace StringManipulation
{
    class Program
    {
        public static string FilePath = @"C:\Users\matte\Desktop\skola\test.txt";
        private static List<AttendanceList> Attending = new List<AttendanceList>();
        static void Main(string[] args)
        {
            ImportAttendees();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("CHARITY GALA 2021!");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) New Attendee");
            Console.WriteLine("2) Remove Attendee");
            Console.WriteLine("3) View Attendees");
            Console.WriteLine("4) Get cupon");
            Console.WriteLine("5) Save and Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    
                    AddAttendee();
                    return true;
                case "2":
                    
                    RemoveAttendee();
                    return true;
                case "3":
                    
                    ViewAttendees();
                    return true;
                case "4":
                    GetCoupon();
                    return true;
                case "5":
                    SaveAttendees();
                    return false;
                default:
                    return true;
            }
        }
        public static void AddAttendee()
        {
            Console.Clear();
            Console.Write("Please enter firstname:");
            string FirstName = Console.ReadLine();
            Console.Clear();
            Console.Write("Please enter Lastname:");
            string LastName = Console.ReadLine();
            Console.Clear();
            Console.Write("Please enter Email:");
            string Email = Console.ReadLine();
            Console.Clear();
            Attending.Add(new AttendanceList
            {
                
                AttendanceEmail = Email,
                AttendanceFirstName = FirstName,
                AttendanceLastName = LastName,
                AttendanceNumber = Attending.Count() + 1,
                
            }); 

        }
        public static void ViewAttendees()
        {
            
            Console.Clear();
            foreach(AttendanceList Attendance in Attending)
            {
                Console.WriteLine( "[" +Attendance.AttendanceNumber +"] "+ Attendance.AttendanceFirstName + " " + Attendance.AttendanceLastName + " " + Attendance.AttendanceEmail);
                
            }
            Console.ReadLine();
        }
        public static void GetCoupon()
        {
            Guid coupon = Guid.NewGuid();
            Console.Clear();
            Console.WriteLine(coupon);
            Console.ReadLine();
        }
        public static void RemoveAttendee()
        {
            Console.Clear();
            foreach (AttendanceList Attendance in Attending)
            {
                Console.WriteLine("[" + Attendance.AttendanceNumber + "] " + Attendance.AttendanceFirstName + " " + Attendance.AttendanceLastName + " " + Attendance.AttendanceEmail);

            }
            Console.WriteLine("Choose the attendee you would like to remove:");
            
            string UserInput = Console.ReadLine();
            int number;

            bool isParsable = Int32.TryParse(UserInput, out number);

            if (isParsable)
                Console.Clear();

            else
                Console.WriteLine("Enter a number.");

            Attending.RemoveAt(number - 1);
            Console.WriteLine("The atendee has been removed.");
            Console.ReadLine();
        }
        public static void SaveAttendees()
        {
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                foreach(AttendanceList Attendance in Attending)
                {
                    sw.WriteLine(Attendance.AttendanceNumber);
                    sw.WriteLine(Attendance.AttendanceFirstName);
                    sw.WriteLine(Attendance.AttendanceLastName);
                    sw.WriteLine(Attendance.AttendanceEmail);
                    
                }
            }
        }
        public static void ImportAttendees()
        {
            using (StreamReader sr = new StreamReader(FilePath))
            {
                
               int i = 1;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    
                    
                    Attending.Add(new AttendanceList
                    {
                        AttendanceNumber = i,
                        AttendanceFirstName = sr.ReadLine(),
                        AttendanceLastName = sr.ReadLine(),
                        AttendanceEmail = sr.ReadLine(),
                        
                        
                    });
                    i++;
                }

                
            }
        }
        
    }
}
