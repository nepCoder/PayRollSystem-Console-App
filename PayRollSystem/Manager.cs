namespace PayRollSystem
{
    class Manager : Staff
    {
        #region private fields
        private const float managerHourlyRate = 50;
        #endregion

        #region properties
        public int Allowance { get; private set; }
        #endregion

        #region constructor
        public Manager(string name) : base(name, managerHourlyRate) //pass the value name and managerHourlyRate to its base constructor
        {

        }
        #endregion

        #region methods
        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
            {
                Allowance = 1000;
                TotalPay = BasicPay + Allowance;
            }
        }

        public override string ToString()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Name of Staff : {NameOfStaff}");
            Console.WriteLine($"Hours Worked : {HoursWorked}");
            Console.WriteLine($"Hourly Rate : {managerHourlyRate}");
            Console.WriteLine($"Basic Pay : {BasicPay}");
            Console.WriteLine($"Allowance : {Allowance}");
            Console.WriteLine($"Total Pay : {TotalPay}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            return " ";
        }
        #endregion
    }
}
