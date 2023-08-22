using EventGenerationWithEF;

public class RecurringEvent
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public DaysOfWeek DaysOfWeek { get; set; }
    // Other properties for recurrence pattern
}

[Flags]
public enum DaysOfWeek
{
    None = 0,
    Sunday = 1,
    Monday = 2,
    Tuesday = 4,
    Wednesday = 8,
    Thursday = 16,
    Friday = 32,
    Saturday = 64
}


public class Program
{
    public static void Main(string[] args)
    {
        using (var context = new ApplicationDbContext())
        {
            int eventId = 1; // ID of the event you're editing
            var editedEvent = context.RecurringEvents.FirstOrDefault(e => e.Id == eventId);

            if (editedEvent != null)
            {
                editedEvent.DaysOfWeek = DaysOfWeek.Monday; // Set to the desired day
                // Update other recurrence pattern properties if needed

                context.SaveChanges();
                Console.WriteLine("Event updated successfully.");
            }
            else
            {
                var recurringEvent = new RecurringEvent { DaysOfWeek = DaysOfWeek.Monday | DaysOfWeek.Tuesday | DaysOfWeek.Friday,Id=2,Title="Title2" };
                context.RecurringEvents.Add(recurringEvent);
                context.SaveChanges();
                Console.WriteLine("Event not found.");
            }
        }
    }
}
