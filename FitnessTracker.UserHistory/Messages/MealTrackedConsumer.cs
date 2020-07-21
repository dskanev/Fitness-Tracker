using FitnessTracker.UserHistory.Services;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Common.Messages;

namespace FitnessTracker.UserHistory.Messages
{
    public class MealTrackedConsumer : IConsumer<MealTrackedMessage>
    {
        private readonly IUserHistoryService userHistoryService;

        public MealTrackedConsumer(IUserHistoryService userHistoryService)
            => this.userHistoryService = userHistoryService;

        public async Task Consume(ConsumeContext<MealTrackedMessage> context)
            => await this.userHistoryService.TrackMeal(context.Message.UserId);
    }
}
