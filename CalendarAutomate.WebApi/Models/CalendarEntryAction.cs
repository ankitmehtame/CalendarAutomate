namespace CalendarAutomate.WebApi.Models;

public class CalendarEntryAction
{
    public CalendarEntryAction(CalendarEntry entry, CalendarEntryActionType actionType)
    {
        Entry = entry;
        ActionType = actionType;
    }

    public CalendarEntry Entry { get; }
    public CalendarEntryActionType ActionType { get; }
}
