// RegistrationSystem.cs
//
// Huimin Zhao
// 
// Registration System for Continental University

using System;

public class RegistrationSystem
{
    // The add method
    private void Add(ref Student student)
    {
        string answer;
        bool ok;

        // guest type
        do
        {
            ok = true;
            Console.Write("Student type: B(bachelor), M(master)? ");
            answer = Console.ReadLine().Trim();
            if (answer.Length < 1)
            {
                ok = false;
                continue;
            }
            switch (answer.ToUpper()[0])
            {
                case 'B':
                    student = new Bachelor();
                    break;
                case 'M':
                    student = new Master();
                    break;
                default:
                    ok = false;
                    break;
            }
        }
        while (!ok);

        // first name
        do
        {
            ok = true;
            try
            {
                Console.Write("First Name: ");
                student.FirstName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // last name
        do
        {
            ok = true;
            try
            {
                Console.Write("Last Name: ");
                student.LastName = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // gender
        do
        {
            ok = true;
            try
            {
                Console.Write("Gender: ");
                student.Gender = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // residency
        do
        {
            ok = true;
            Console.Write("Residency (I/O): ");
            answer = Console.ReadLine().Trim();
            if (answer.Length < 1)
            {
                ok = false;
                continue;
            }
            switch (answer.ToUpper()[0])
            {
                case 'I':
                    student.IsResident = true;
                    break;
                case 'O':
                    student.IsResident = false;
                    break;
                default:
                    ok = false;
                    break;
            }
        }
        while (!ok);

        // enter credits taking
        do
        {
            ok = true;
            try
            {
                Console.Write("Credits Taking: ");
                student.Credits = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // enter entrance date
        do
        {
            ok = true;
            try
            {
                Console.Write("Entrance Date: ");
                student.EntranceDate = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // home phone
        do
        {
            ok = true;
            try
            {
                Console.Write("Home Phone: ");
                student.HomePhone = new PhoneNumber(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // mobile phone
        do
        {
            ok = true;
            try
            {
                Console.Write("Mobile Phone: ");
                student.MobilePhone = new PhoneNumber(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // address
        student.HomeAddress = new Address();

        // street
        do
        {
            ok = true;
            try
            {
                Console.Write("Street Address: ");
                student.HomeAddress.Street = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // city
        do
        {
            ok = true;
            try
            {
                Console.Write("City: ");
                student.HomeAddress.City = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // state
        do
        {
            ok = true;
            try
            {
                Console.Write("State: ");
                student.HomeAddress.State = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // zip
        do
        {
            ok = true;
            try
            {
                Console.Write("Zip: ");
                student.HomeAddress.Zip = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ok = false;
            }
        }
        while (!ok);

        // if bachelor
        if (student is Bachelor)
        {
            // scholar program
            do
            {
                ok = true;
                Console.Write("Is this student in the scholar program (Y/N)?: ");
                answer = Console.ReadLine().Trim();
                if (answer.Length < 1)
                {
                    ok = false;
                    continue;
                }
                switch (answer.ToUpper()[0])
                {
                    case 'Y':
                        ((Bachelor)student).Scholar = true;
                        break;
                    case 'N':
                        ((Bachelor)student).Scholar = false;
                        break;
                    default:
                        ok = false;
                        break;
                }
            }
            while (!ok);
        }
        else if (student is Master)
        {
            // advisor's first name
            do
            {
                ok = true;
                try
                {
                    Console.Write("Advisor's First Name: ");
                    ((Master)student).AdvisorFirstName = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ok = false;
                }
            }
            while (!ok);

            // advisor's last name
            do
            {
                ok = true;
                try
                {
                    Console.Write("Advisor's Last Name: ");
                    ((Master)student).AdvisorLastName = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ok = false;
                }
            }
            while (!ok);
        }
    }

    private void Menu()
    {
        bool quit = false;
        bool valid;
        string choice;
        Student student = null;

        Console.WriteLine("Welcome to the Continental University Registration System!");

        do
        {
            Console.WriteLine("Enter data about a student");
            Console.WriteLine();
            Add(ref student);
            Console.WriteLine();
            Console.WriteLine(student.ToString());
            Console.WriteLine();

            Console.WriteLine();
            do
            {
                valid = true;
                Console.Write("Do you want to quit (Y/N)?: ");
                choice = Console.ReadLine().Trim();
                if (choice.Length < 1)
                {
                    valid = false;
                    continue;
                }
                Console.WriteLine();
                switch (choice.ToUpper()[0])
                {
                    case 'N':
                        quit = false;
                        break;
                    case 'Y':
                        quit = true;
                        break;
                    default:
                        valid = false;
                        break;
                }
            } while (!valid);
        }
        while (!quit);

        Console.WriteLine();
        Console.WriteLine("Thank you for using the Registration System!");
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        RegistrationSystem sys = new RegistrationSystem();
        sys.Menu();
    }
}
