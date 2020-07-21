using FitnessTracker.Common.Messages;
using FitnessTracker.UserHistory.Services;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.UserHistory.Messages
{
    public class ExerciseTrackedConsumer : IConsumer<ExerciseTrackedMessage>
    {
        private readonly IUserHistoryService userHistoryService;

        public ExerciseTrackedConsumer(IUserHistoryService userHistoryService)
            => this.userHistoryService = userHistoryService;

        public async Task Consume(ConsumeContext<ExerciseTrackedMessage> context)
            => await this.userHistoryService.TrackWorkout(context.Message.UserId, context.Message.Calories);
    }
}
