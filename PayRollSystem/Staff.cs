namespace PayRollSystem
{
    public class Staff
    {

        //Fields
        private float hourlyRate;
        private int hWorked;

        //Properties
        public float TotalPay { get; protected set; } //auto-implemented property
        public float BasicPay { get; private set; } //auto-implemented property
        public string NameOfStaff { get; private set; } //auto-implemented property
        public int HoursWorked
        {
            get
            {
                return hWorked;
            }

            set
            {
                if (value > 0)
                {
                    hWorked = value;
                }
                else hWorked = 0;
            }
        }

        //Constructor
        public Staff(string name, float rate)
        {
            NameOfStaff = name;   //value set to property
            hourlyRate = rate;      //value set to field
        }

        //Methods
        public virtual void CalculatePay()
        {
            Console.WriteLine("\nCalculating Payment...");
            BasicPay = hourlyRate * hWorked;
            TotalPay = BasicPay;
        }


        public override string ToString()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Name of Staff : {NameOfStaff}");
            Console.WriteLine($"Hours Worked : {hWorked}");
            Console.WriteLine($"Hourly Rate : {hourlyRate}");
            Console.WriteLine($"Basic Pay : {BasicPay}");
            Console.WriteLine($"Total Pay : {TotalPay}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            return " ";
        }

    }
}
