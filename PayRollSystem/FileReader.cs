namespace PayRollSystem
{
    class FileReader
    {
        /// <summary>
        /// This class has method ReadFile()
        /// ReadFile() method Reads the staffLists from Staff.txt file 
        /// 
        /// </summary>
        /// <returns>List of Staff objects for each staffs in the file Staff.txt</returns>
        public List<Staff> ReadFile()
        {
            List<Staff> staffList = new List<Staff>();
            string[] result = new string[2];
            string path = "Staff.txt";
            char separator = ',';

            if (File.Exists(path))
            {
                /*The using keyword here ensures that the Dispose() method is always called.
                    The Dispose() method is a pre-written method in the System namespace that
                    closes or releases any unmanaged resources such as files and streams once they
                    are no longer needed. When we use the using keyword, we ensure that the
                    Dispose() method is called even if an exception occurs and prevents our code
                    from reaching Line 9 where we manually close the file.*/
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        result = line.Split(separator);

                        if (result[1] == "Manager")
                        {
                            staffList.Add(new Manager(result[0]));
                        }
                        if (result[1] == "Admin")
                        {
                            staffList.Add(new Admin(result[0]));
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not Exist!!!");
            }
            return staffList;
        }
    }
}
