using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystem
{
    class PaySlip
    {
        //fields
        private int month, year;

        //enum
        enum monthsOfYear { NONE, JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC };

        //constructor
        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        //methods
        public void GeneratePaySlip(List<Staff> staffList)
        {
            string path;
            foreach (Staff staff in staffList)
            {
                path = staff.NameOfStaff + ".txt";

                //StreamWriter to Write to text file
                //StreamWriter(path) overrides the data in that file
                //StreamWriter(path, true) appends the data in that file
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine($"PAYSLIP FOR {(monthsOfYear)month} {year}");
                    sw.WriteLine("==========================");
                    sw.WriteLine($"Name of Staff: {staff.NameOfStaff}");
                    sw.WriteLine($"Hours Worked: {staff.HoursWorked}");
                    sw.WriteLine("---------------------");
                    sw.WriteLine($"Basic Pay: {staff.BasicPay}");

                    //if-else condition
                    if ((staff.NameOfStaff) == "Manager")
                    {
                        sw.WriteLine($"Allowance: {((Manager)staff).Allowance}");
                    }
                    if ((staff.NameOfStaff) == "Admin")
                    {
                        sw.WriteLine($"OverTime: {((Admin)staff).OverTime}");
                    }




                    sw.WriteLine("==========================");
                    sw.WriteLine($"Total Pay: {staff.TotalPay}");
                    sw.WriteLine("==========================");

                    sw.Close();
                }
            }

        }


        //method to generate summary of employees who worked less than 10 hours in this month.
        public void GenerateSummary(List<Staff> staffList)
        {
            var query =
                from staff in staffList
                where staff.HoursWorked < 10
                select new { staff.NameOfStaff, staff.HoursWorked };

            string path = "summary.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");

                foreach (var s in query)
                {
                    sw.WriteLine($"Name of Staff : {s.NameOfStaff},     Hours Worked : {s.HoursWorked} hours");
                }
            };
        }


        public override string ToString()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Staff Summary Created!");
            Console.WriteLine($"PaySlip for each members created!");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            return " ";
        }
    }
}
