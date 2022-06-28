﻿using Ardalis.GuardClauses;
using Forum.Backend.Core.Entities.UserAggregate.Events;
using Forum.Backend.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Backend.Core.Entities.UserAggregate.Handlers
{
    public class NewUserAddedEmailNotificationHandler : INotificationHandler<NewUserAddedEvent>
    {
        private readonly IEmailSender _emailSender;

        public NewUserAddedEmailNotificationHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Task Handle(NewUserAddedEvent domainEvent, CancellationToken cancellationToken)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            return _emailSender.SendEmailAsync(domainEvent.NewUser.Email, "test@test.com", "User registration", $"{domainEvent.NewUser.Name} your registration has been completed.");
        }
    }
}
