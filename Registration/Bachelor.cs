using System;

public class Bachelor : Student
{
    // parameter-less constructor
    public Bachelor()
        : base()
    {
    }

    // constructor
    public Bachelor(string first, string last, int cedits, bool isMale, DateTime entrance, bool isResident, Address homeAddress, PhoneNumber homePhone, PhoneNumber mobilePhone,
        bool scholar)
        : base(first, last, cedits, isMale, entrance, isResident, homeAddress, homePhone, mobilePhone)
   {
       this.Scholar = scholar; 
   } // end Lecturer constructor


    // property for Scholar Program
    public bool Scholar { get; set; }

    // readonly property for student type
    public override string StudentType
    {
        get
        {
            return "Bachelor";
        }
    } // no implementation here

    // read-only property to get the registration fee.
    override public decimal RegistrationFee
    {
        get
        {
            const decimal REGISTRATION_BACHELOR_INSTATE = 200;
            const decimal REGISTRATION_BACHELOR_OUTSTATE = 600;
            if (IsResident)
                return REGISTRATION_BACHELOR_INSTATE;
            else
                return REGISTRATION_BACHELOR_OUTSTATE;
        }
    }

    // read-only property to get the tuition rate. 
    override public decimal TuitionRate
    {
        get
        {
            const decimal TUITION_BACHELOR_INSTATE = 350;
            const decimal TUITION_BACHELOR_OUTSTATE = 700;

            if (IsResident)
                return TUITION_BACHELOR_INSTATE;
            else
                return TUITION_BACHELOR_OUTSTATE;
        }
    }

    // returns string representation of Employee reservation object
    public override string ToString()
    {
        if(Scholar)
            return base.ToString() + "  Scholar";
        else
            return base.ToString();
    } // end method ToString
}
