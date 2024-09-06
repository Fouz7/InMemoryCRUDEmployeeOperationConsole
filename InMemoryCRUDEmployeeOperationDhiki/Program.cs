using InMemoryCRUDEmployeeOperationDhiki.Models;
using InMemoryCRUDEmployeeOperationDhiki.Services;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Inisialisasi employee service
        IEmployeeService employeeService = new EmployeeService();
        
        // Hardcode data karyawan
        var emp1 = new Employee { EmployeeID = "1001", FullName = "Rohmat", BirthDate = DateTime.ParseExact("01-Jan-1990", "dd-MMM-yyyy", CultureInfo.InvariantCulture) };
        var emp2 = new Employee { EmployeeID = "1002", FullName = "Anugrah", BirthDate = DateTime.ParseExact("15-Feb-1985", "dd-MMM-yyyy", CultureInfo.InvariantCulture) };
        var emp3 = new Employee { EmployeeID = "1003", FullName = "Faisal", BirthDate = DateTime.ParseExact("23-Mar-1992", "dd-MMM-yyyy", CultureInfo.InvariantCulture) };
        
        employeeService.AddEmployee(emp1);
        employeeService.AddEmployee(emp2);
        employeeService.AddEmployee(emp3);
        
        bool exit = false;

        // Loop utama
        while (!exit)
        {
            try
            {
                // Tampilkan menu utama
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
                        // Tambah Karyawan
                        while (true)
                        {
                            try
                            {
                                string id = null, name = null, birthDateString = null;
                                DateTime birthDate = default;

                                // Input dan validasi EmployeeID
                                Console.Write("Masukkan ID Karyawan (hanya angka): ");
                                id = Console.ReadLine();
                                if (string.IsNullOrEmpty(id) || !id.All(char.IsDigit))
                                {
                                    throw new Exception("ID tidak boleh kosong dan harus berupa angka.");
                                }
                                if (employeeService.GetEmployeeById(id) != null)
                                {
                                    throw new Exception("ID Karyawan sudah ada.");
                                }

                                // Input dan validasi FullName
                                Console.Write("Masukkan Nama Lengkap: ");
                                name = Console.ReadLine();
                                if (string.IsNullOrEmpty(name))
                                {
                                    throw new Exception("Nama tidak boleh kosong.");
                                }

                                // Input dan validasi BirthDate
                                Console.Write("Masukkan Tanggal Lahir (dd-MMM-yyyy): ");
                                birthDateString = Console.ReadLine();
                                if (string.IsNullOrEmpty(birthDateString))
                                {
                                    throw new Exception("Tanggal Lahir tidak boleh kosong.");
                                }
                                if (!DateTime.TryParseExact(birthDateString, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                                {
                                    throw new Exception("Format tanggal salah. Gunakan format dd-MMM-yyyy.");
                                }

                                // Tambahkan karyawan baru
                                Employee newEmployee = new Employee { EmployeeID = id, FullName = name, BirthDate = birthDate };
                                employeeService.AddEmployee(newEmployee);
                                Console.WriteLine("Karyawan berhasil ditambahkan.");
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
                            }
                        }
                        break;

                    case "2":
                        // Lihat Semua Karyawan
                        var employees = employeeService.GetAllEmployees();
                        if (employees.Count == 0)
                        {
                            Console.WriteLine("Tidak ada karyawan yang ditemukan.");
                        }
                        else
                        {
                            foreach (var emp in employees)
                            {
                                Console.WriteLine($"ID: {emp.EmployeeID}, Nama: {emp.FullName}, Tanggal Lahir: {emp.BirthDate.ToString("dd-MMM-yyyy")}");
                            }
                        }
                        break;

                    case "3":
                        // Cari Karyawan berdasarkan ID
                        Console.Write("Masukkan ID Karyawan: ");
                        string searchId = Console.ReadLine();
                        var employee = employeeService.GetEmployeeById(searchId);
                        if (employee != null)
                        {
                            Console.WriteLine($"ID: {employee.EmployeeID}, Nama: {employee.FullName}, Tanggal Lahir: {employee.BirthDate.ToString("dd-MMM-yyyy")}");
                        }
                        else
                        {
                            Console.WriteLine("Karyawan tidak ditemukan.");
                        }
                        break;

                    case "4":
                        // Update Karyawan
                        Console.Write("Masukkan ID Karyawan: ");
                        string updateId = Console.ReadLine();
                        var existingEmployee = employeeService.GetEmployeeById(updateId);
                        if (existingEmployee != null)
                        {
                            while (true)
                            {
                                try
                                {
                                    string newName = null, newBirthDateString = null;
                                    DateTime newBirthDate = default;

                                    // Input dan validasi FullName baru
                                    Console.Write("Masukkan Nama Lengkap Baru: ");
                                    newName = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newName))
                                    {
                                        throw new Exception("Nama tidak boleh kosong.");
                                    }

                                    // Input dan validasi BirthDate baru
                                    Console.Write("Masukkan Tanggal Lahir Baru (dd-MMM-yyyy): ");
                                    newBirthDateString = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newBirthDateString))
                                    {
                                        throw new Exception("Tanggal Lahir tidak boleh kosong.");
                                    }
                                    if (!DateTime.TryParseExact(newBirthDateString, "dd-MMM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out newBirthDate))
                                    {
                                        throw new Exception("Format tanggal salah. Gunakan format dd-MMM-yyyy.");
                                    }

                                    // Perbarui detail karyawan
                                    existingEmployee.FullName = newName;
                                    existingEmployee.BirthDate = newBirthDate;
                                    employeeService.UpdateEmployee(existingEmployee);
                                    Console.WriteLine("Karyawan berhasil diupdate.");
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Karyawan tidak ditemukan.");
                        }
                        break;

                    case "5":
                        // Hapus Karyawan
                        Console.Write("Masukkan ID Karyawan: ");
                        string deleteId = Console.ReadLine();
                        employeeService.DeleteEmployee(deleteId);
                        Console.WriteLine("Karyawan berhasil dihapus.");
                        break;

                    case "6":
                        // Keluar
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Catch dan tampilkan kesalahan
                Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
            }
        }
    }
}