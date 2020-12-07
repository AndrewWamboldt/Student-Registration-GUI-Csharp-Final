using System;

public class Master : Student
{
    // private instance variable for storing advisor first name
    private string advisorFirstNameValue;

    // private instance variable for storing advisor last name
    private string advisorLastNameValue;

    // parameter-less constructor
    public Master()
        : base()
    {
    }

    // constructor
    public Master(string first, string last, int cedits, bool isMale, DateTime entrance, bool isResident, Address homeAddress, PhoneNumber homePhone, PhoneNumber mobilePhone,
        string advisorFirst, string advisorLast)
        : base(first, last, cedits, isMale, entrance, isResident, homeAddress, homePhone, mobilePhone)
   {
        this.AdvisorFirstName = advisorFirst;
        this.AdvisorLastName = advisorLast;
    } // end Lecturer constructor


    // property to get and set advisor's first name
    public string AdvisorFirstName
    {
        get
        {
            return Util.Capitalize(advisorFirstNameValue);
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
            advisorFirstNameValue = value;
        } // end set
    } // end property AdvisorFirstName

    // property to get and set advisor's last name
    public string AdvisorLastName
    {
        get
        {
            return Util.Capitalize(advisorLastNameValue);
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
            advisorLastNameValue = value;
        } // end set
    } // end property advisorLastNameValue

    // readonly property for student type
    public override string StudentType
    {
        get
        {
            return "Master";
        }
    } // no implementation here

    // read-only property to get the registration fee.
    override public decimal RegistrationFee
    {
        get
        {
            const decimal REGISTRATION_MASTER_INSTATE = 300;
            const decimal REGISTRATION_MASTER_OUTSTATE = 900;
            if (IsResident)
                return REGISTRATION_MASTER_INSTATE;
            else
                return REGISTRATION_MASTER_OUTSTATE;
        }
    }

    // read-only property to get the tuition rate. 
    override public decimal TuitionRate
    {
        get
        {
            const decimal TUITION_MASTER_INSTATE = 450;
            const decimal TUITION_MASTER_OUTSTATE = 900;
            if (IsResident)
                return TUITION_MASTER_INSTATE;
            else
                return TUITION_MASTER_OUTSTATE;
        }
    }

    // returns string representation of Employee reservation object
    public override string ToString()
    {
            return base.ToString() + "  Advisor: " + AdvisorFirstName + " " + AdvisorLastName;
    } // end method ToString
}
