using System;
namespace OnlineFoodDeliveryApplication
{
    public enum Gender{Default,Male,Female,Others}
    public class PersonalDetails
    {
        /// <summary>
        /// get and set the name
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Get and set Father name
        /// </summary>
        /// <value></value>
        public string FatherName { get; set; }
        /// <summary>
        /// Get and set the gender
        /// </summary>
        /// <value></value>
        public Gender Gender { get; set; }
        /// <summary>
        /// Get and set the MobileNumber
        /// </summary>
        /// <value></value>
        public long MobileNumber { get; set; }
        /// <summary>
        /// Get and set the DOB
        /// </summary>
        /// <value></value>
        public DateTime DOB { get; set; }
        /// <summary>
        /// get and set the MailID
        /// </summary>
        /// <value></value>
        public string MailID { get; set; }
        /// <summary>
        /// get and set the Location.
        /// </summary>
        /// <value></value>
        public string Location { get; set; }
        /// <summary>
        /// Constructor class that fetch data form creating the object of the class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="gender"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="dob"></param>
        /// <param name="mailID"></param>
        /// <param name="location"></param>
        public PersonalDetails(string name, string fatherName,Gender gender,long phoneNumber,DateTime dob,string mailID,string location)
        {
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            MobileNumber=phoneNumber;
            DOB=dob;
            MailID=mailID;
            Location=location;
        }
        /// <summary>
        /// Empty constructor to read the file from csv.
        /// </summary>
        public PersonalDetails()
        {
            
        }
        

    }
}