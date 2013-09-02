﻿using Content.Sync.Interfaces;
using Content.Sync.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Content.Sync.Clarifi
{
    public abstract class HotelUpdateCommand : IWorkItemCommand
    {
        public async Task Execute(WorkItem item, CancellationToken cancellationToken)
        {
            //Specification:
            // Convert the work item to a specific hotel work item.
            // Process the hotel work item.
            // Incase the processing is successful, checkpoint the work item id.
            // Incase the processing has failed, then handle the failure and checkpoint the id.
            var hotelWorkItem = item.ToHotelWorkItem();
            await ProcessHotelWorkItem(item.ToHotelWorkItem(), cancellationToken);
            
        }

        protected abstract Task ProcessHotelWorkItem( HotelWorkItem workItem, CancellationToken cancellationToken );
    }
}