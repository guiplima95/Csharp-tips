using BenchmarkDotNet.Attributes;
using System.Linq;

namespace YieldReturn;

public class Benchmarks
{
    private Attendee[]? _attendees;

    private readonly Random _random = new();

    [Params(10000)]

    public int NumberOfElements { get; set; }

    [GlobalSetup]
    public void Init()
    {
        _attendees = Enumerable.Range(1, NumberOfElements)
            .Select(n => new Attendee(
                Id: Guid.NewGuid(), 
                FirstName: "Guilherme",
                LastName: "Lima",
                Age: _random.Next(1, 100), 
                Address: "Avenida Prof. Djalma Guimaraes"))
            .ToArray();
    }

    [Benchmark]
    public void With_Select()
    {
        var attendeeNames = GetAttendeeNamesWithSelect();
    }

    [Benchmark]
    public void Without_YieldReturn()
    {
        var attendeeNames = GetAttendeeNamesWithoutYieldReturn();
    }

    [Benchmark]
    public void With_YieldReturn()
    {
        var attendeeNames = GetAttendeeNamesWithYieldReturn();
    }

    IEnumerable<AttendeeName> GetAttendeeNamesWithYieldReturn()
    {
        ArgumentNullException.ThrowIfNull(_attendees);

        foreach (var attendee in _attendees)
        {
            yield return new(attendee.FirstName, attendee.LastName);
        }
    }

    IEnumerable<AttendeeName> GetAttendeeNamesWithoutYieldReturn()
    {
        ArgumentNullException.ThrowIfNull(_attendees);

        var attendeeNames = new List<AttendeeName>();

        foreach (var attendee in _attendees)
        {
            AttendeeName attendeeName = new(attendee.FirstName, attendee.LastName);
            attendeeNames.Add(attendeeName);
        }

        return attendeeNames;
    }

    IEnumerable<AttendeeName> GetAttendeeNamesWithSelect() =>
        _attendees.Select(a => new AttendeeName(a.FirstName, a.LastName));
}
