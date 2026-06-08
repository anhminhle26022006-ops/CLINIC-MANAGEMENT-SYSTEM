namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public class ComboItem
    {
        public int Id { get; }
        public string Name { get; }
        public ComboItem(int id, string name) { Id = id; Name = name; }
        public override string ToString() => Name;
    }

    public class ComboItemShift
    {
        public string Name { get; }
        public string Start { get; }
        public string End { get; }
        public ComboItemShift(string name, string start, string end)
        { Name = name; Start = start; End = end; }
        public override string ToString() => Name;
    }
}