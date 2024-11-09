public class Quest
{
    public string Id { get; private set; }
    public string Description { get; private set; }

    public Quest(string id, string desc)
    {
        Id = id;
        Description = desc;
    }
}
