using MediatR;
using Microsoft.Extensions.Logging;

namespace Domain.Entities.Users.Events
{
    public class OnDepartmentUpdateEventHandler : INotificationHandler<OnDepartmentUpdateEvent>
    {
        private readonly ILogger<OnDepartmentUpdateEventHandler> _logger;

        public OnDepartmentUpdateEventHandler(ILogger<OnDepartmentUpdateEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Handle(OnDepartmentUpdateEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Deparment update event raised: {notification.CreatedOn}, {notification.EventId}, DeptId = {notification.DepartmentId}, UserId = {notification.UserId}.");
            return Task.CompletedTask;
        }
    }
}
