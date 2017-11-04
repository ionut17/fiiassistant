namespace Model.User.Entities {
    public class Student : Common.User {
        public int Year { get; set; }

        public string Group { get; set; }
    }
}