using InMemoryCRUDEmployeeOperationDhiki.Models;
using InMemoryCRUDEmployeeOperationDhiki.Services;

class Program
{
    static void Main(string[] args)
    {
        IEmployeeService employeeService = new EmployeeService();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Tambah Karyawan");
            Console.WriteLine("2. Tampilkan Semua Karyawan");
            Console.WriteLine("3. Cari Karyawan Berdasarkan ID");
            Console.WriteLine("4. Update Karyawan");
            Console.WriteLine("5. Hapus Karyawan");
            Console.WriteLine("6. Keluar");
            Console.Write("Pilih opsi: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Masukkan ID Karyawan: ");
                    string id = Console.ReadLine();
                    Console.Write("Masukkan Nama Lengkap: ");
                    string name = Console.ReadLine();
                    Console.Write("Masukkan Tanggal Lahir (yyyy-mm-dd): ");
                    DateTime birthDate = DateTime.Parse(Console.ReadLine());

                    Employee newEmployee = new Employee { EmployeeID = id, FullName = name, BirthDate = birthDate };
                    employeeService.AddEmployee(newEmployee);
                    Console.WriteLine("Karyawan berhasil ditambahkan.");
                    break;

                case "2":
                    var employees = employeeService.GetAllEmployees();
                    foreach (var emp in employees)
                    {
                        Console.WriteLine($"ID: {emp.EmployeeID}, Nama: {emp.FullName}, Tanggal Lahir: {emp.BirthDate.ToShortDateString()}");
                    }
                    break;

                case "3":
                    Console.Write("Masukkan ID Karyawan: ");
                    string searchId = Console.ReadLine();
                    var employee = employeeService.GetEmployeeById(searchId);
                    if (employee != null)
                    {
                        Console.WriteLine($"ID: {employee.EmployeeID}, Nama: {employee.FullName}, Tanggal Lahir: {employee.BirthDate.ToShortDateString()}");
                    }
                    else
                    {
                        Console.WriteLine("Karyawan tidak ditemukan.");
                    }
                    break;

                case "4":
                    Console.Write("Masukkan ID Karyawan: ");
                    string updateId = Console.ReadLine();
                    var existingEmployee = employeeService.GetEmployeeById(updateId);
                    if (existingEmployee != null)
                    {
                        Console.Write("Masukkan Nama Lengkap Baru: ");
                        existingEmployee.FullName = Console.ReadLine();
                        Console.Write("Masukkan Tanggal Lahir Baru (yyyy-mm-dd): ");
                        existingEmployee.BirthDate = DateTime.Parse(Console.ReadLine());

                        employeeService.UpdateEmployee(existingEmployee);
                        Console.WriteLine("Karyawan berhasil diupdate.");
                    }
                    else
                    {
                        Console.WriteLine("Karyawan tidak ditemukan.");
                    }
                    break;

                case "5":
                    Console.Write("Masukkan ID Karyawan: ");
                    string deleteId = Console.ReadLine();
                    employeeService.DeleteEmployee(deleteId);
                    Console.WriteLine("Karyawan berhasil dihapus.");
                    break;

                case "6":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Pilihan tidak valid.");
                    break;
            }
        }
    }
}