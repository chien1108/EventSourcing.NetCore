using Core.Commands;
using Core.Marten.Repository;
using Core.Queries;
using Marten;
using MeetingsManagement.Meetings.CreatingMeeting;
using MeetingsManagement.Meetings.GettingMeeting;
using MeetingsManagement.Meetings.SchedulingMeeting;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingsManagement.Meetings;

public static class Config
{
    public static IServiceCollection AddMeeting(this IServiceCollection services) =>
        services
            .AddMartenRepository<Meeting>()
            .AddCommandHandler<CreateMeeting, HandleCreateMeeting>()
            .AddCommandHandler<ScheduleMeeting, HandleScheduleMeeting>()
            .AddQueryHandler<GetMeeting, MeetingView?, HandleGetMeeting>();

    public static void ConfigureMarten(StoreOptions options)
    {
        options.Projections.SelfAggregate<Meeting>();
        options.Projections.Add(new MeetingViewProjection());
    }
}
