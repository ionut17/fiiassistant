namespace Timetable.Data.Model.Common
{
    public class GroupRequest : Request
    {
        public GroupRequest()
        {
        }

        public GroupRequest(string baseAddress, string group, int year)
        {
            BaseAddress = baseAddress;
            Group = group;
            Year = year;
        }

        public string Group { get; set; }

        public int Year { get; set; }

        public override string GetAddress()
        {
            return string.IsNullOrEmpty(Group) ? BaseAddress : BaseAddress + "/participanti/orar_" + Group + ".html";
        }
    }
}