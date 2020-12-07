// Student.cs
//
// Huimin Zhao
// 
// Student class

using System;

abstract public class Student
{
    // private instance variable for storing first name
    private string firstNameValue;

    // private instance variable for storing last name
    private string lastNameValue;

    // private instance variable for storing credits
    private int creditsValue;

    // private instance variable for storing entrancedate
    private DateTime entranceDateValue;

    // parameter-less constructor
    public Student()
    {
    }

    // constructor
    public Student(string first, string last, int cedits, bool isMale, DateTime entrance, bool isResident, Address homeAddress, PhoneNumber homePhone, PhoneNumber mobilePhone)
    {
        this.FirstName = first;
        this.LastName = last;
        this.Credits = cedits;
        this.IsMale = isMale;
        this.IsResident = isResident;
        this.EntranceDate = entrance;
        this.HomeAddress = homeAddress;
        this.HomePhone = homePhone;
        this.MobilePhone = mobilePhone;
    } // end FacultyMember constructor

    // property to get and set student's first name
    public string FirstName
    {
        get
        {
            return Util.Capitalize(firstNameValue);
        } // end get
        set
        {
            value = value.Trim().ToUpper();
            if (value.Length < 1)
                throw new ApplicationException("First name is empty!");
            // check for letters
            foreach (char c in value)
                if (c < 'A' || c > 'Z')
                    throw new ApplicationException("First name must consist of letters only!");
            firstNameValue = value;
        } // end set
    } // end property FirstName

    // property to get and set student's last name
    public string LastName
    {
        get
        {
            return Util.Capitalize(lastNameValue);
        } // end get
        set
        {
            value = value.Trim().ToUpper();
            if (value.Length < 1)
                throw new ApplicationException("Last name is empty!");
            // check for letters
            foreach (char c in value)
                if (c < 'A' || c > 'Z')
                    throw new ApplicationException("Last name must consist of letters only!");
            lastNameValue = value;
        } // end set
    } // end property LastName

    // property to get and set student's credits
    public int Credits
    {
        get
        {
            return creditsValue;
        } // end get
        set
        {
            if (value > 21 || value < 1)
            {
                throw new ApplicationException("Credits taking must be between 1 and 21");
            }
            creditsValue = value;
        } // end set
    } // end property Rank


    // property to get and set whether gender is male
    public bool IsMale { get; set; }

    // read-only property to get name
    public string Name
    {
        get
        {
            return LastName + ", " + FirstName;
        } // end get
    } // end property Name

    // property to get and set whether gender is female
    public bool IsFemale
    {
        get
        {
            return !IsMale;
        } // end get
        set
        {
            IsMale = !value;
        } // end set
    } // end property IsFemale

    // property to get and set gender
    public string Gender
    {
        get
        {
            if (IsMale)
                return "Male";
            else
                return "Female";
        } // end get
        set
        {
            value = value.ToUpper();
            if (value == "MALE" || value == "M")
                IsMale = true;
            else if (value == "FEMALE" || value == "F")
                IsMale = false;
            else
                throw new ApplicationException("Gender should be Male or Female!");
        } // end set
    } // end property Gender

    // read-only property to get title
    public string Title
    {
        get
        {
            if (IsMale)
                return "Mr.";
            else
                return "Ms.";
        } // end get
    } // end property Title

    // read-only property to get title and name
    public string TitleName
    {
        get
        {
            return Title + " " + Name;
        } // end get
    } // end property TitleName

    // property to get and set whether student is state resident
    public bool IsResident { get; set; }

    // read-only property to get residency
    public string Residency
    {
        get
        {
            if (IsResident)
                return "In-state";
            else
                return "Out-state";
        } // end get
    } // end property Title

    // property to get and set student's entrance date
    public DateTime EntranceDate
    {
        get
        {
            return entranceDateValue;
        } // end get
        set
        {
            if (value > DateTime.Now)
                throw new ApplicationException("Entrance date must be prior to today!");
            entranceDateValue = value;
        } // end set
    }

    // read-only property to get years of study
    public byte YearsOfStudy
    {
        get
        {
            // Get the entrance date value for the current year.
            DateTime thisYearEntranceDate = new DateTime(DateTime.Now.Year, EntranceDate.Month, EntranceDate.Day);

            // Calculate and return the age based on if the birth date has occurred this year or not.
            if (thisYearEntranceDate <= DateTime.Now)
            {
                return (byte)(DateTime.Now.Year - EntranceDate.Year);
            }
            else
            {
                return (byte)(DateTime.Now.Year - EntranceDate.Year - 1);
            }
        }
    }

    // property to get and set home address
    public Address HomeAddress { get; set; }

    // property to get and set home phone
    public PhoneNumber HomePhone { get; set; }

    // property to get and set mobile phone
    public PhoneNumber MobilePhone { get; set; }

    // virtual readonly property for student type, will be overridden by derived classes
    public abstract string StudentType
    {
        get;
    } // no implementation here

    // virtual, read-only property to get the registration fee. Will be overriden by derived classes
    abstract public decimal RegistrationFee
    {
        get;
    }

    // virtual, read-only property to get the tuition rate. Will be overriden by derived classes
    abstract public decimal TuitionRate
    {
        get;
    }

    // read-only property to get the Tuition.
    public decimal Tuition
    {
        get
        {
                return TuitionRate * Credits;
        }
    }

    // read-only property to get the Total.
    public decimal Total
    {
        get
        {
            return RegistrationFee + Tuition;
        }
    }

    // returns string representation of reservation object
    public override string ToString()
    {
        return TitleName + "\t"
        + StudentType + ", "
        + Credits + " credits, "
        + Residency + ", "
        + YearsOfStudy + " years at CU\n"
        + "Registration: " + RegistrationFee.ToString("C") + "  "
        + "Tuition: " + Tuition.ToString("C") + "  "
        + "Total: " + Total.ToString("C") + "\n"
        + HomeAddress + "\t"
        + HomePhone.ToString() + "/"
        + MobilePhone.ToString();
    } // end method ToString

}