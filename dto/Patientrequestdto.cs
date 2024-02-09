using hallodoc.Models;

namespace hallodoc.dto
{
    public class Patientrequestdto
    {
        
        public string Symptoms { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Street { get; set; }
        public String State { get; set; }   
        public String City { get; set; }
        public String Zipcode { get; set; }
        public String Room { get; set; }

        public DateTime dob { get; set; }

        public IFormFile File {  get; set; }

    }
}
