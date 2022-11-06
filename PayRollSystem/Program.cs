using PayRollSystem;

namespace PayRollSoftware
{
    class Program
    {
        public static void Main()
        {
            #region initialization of objects and variables
            List<Staff> myStaff = new List<Staff>(); //variable to store list of staff objects
            FileReader fr = new FileReader(); //instance of FileReader class
            int month = 0;
            int year = 0;
            #endregion

            #region Enter value for year
            while (year == 0)
            {
                Console.Write("\nEnter year : ");

                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Conversion Unsuccessful");
                }
            }
            #endregion

            #region Enter value for month
            while (month == 0)
            {
                Console.Write("\nEnter Month : ");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());

                    if (month < 1 || month > 12)
                    {
                        month = 0;
                        Console.WriteLine("Invalid Month");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Conversion Unsuccessful");
                }
            }
            #endregion

            #region Add items in the list myStaff
            myStaff = fr.ReadFile();
            #endregion

            #region CalculatePay for all staffs in myStaff and run ToString to show the detail
            foreach (var staff in myStaff)
            {
                //take HoursWorked from user
                bool isValid = false;
                while (!isValid)
                {
                    Console.Write($"Enter HoursWorked for {staff.NameOfStaff} : ");
                    try
                    {
                        staff.HoursWorked = Convert.ToInt32(Console.ReadLine());
                        
                        isValid = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("InValid!!!");
                        isValid = false;
                    }
                }

                //Call CalculatePay method for each staff
                staff.CalculatePay();

                //Call ToString Method for each staff
                staff.ToString();
            }
            #endregion

            #region Generate PaySlip and PaySummary
            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);
            ps.ToString();
            #endregion

            Console.ReadKey();

        }
    }
}
