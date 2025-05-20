using Application.Models;
using Azure.Core;
using Microsoft.Extensions.Logging;
using Persistance.Entities;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<EventResult> CreateEventAsync(CreateEventRequest request)
    {
        var eventEntity = new EventEntity
        {
            Image = request.Image,
            Title = request.Title,
            Description = request.Description,
            Location = request.Location,
            EventDate = request.EventDate,
            Packages = request.Packages.Select(p => new EventPackageEntity
            {
                Package = new PackageEntity
                {
                    Title = p.Title,
                    SeatingArrangement = p.SeatingArrangement,
                    Placement = p.Placement,
                    Price = p.Price,
                    Currency = p.Currency
                }
            }).ToList()
        };

        var result = await _eventRepository.AddAsync(eventEntity);

        return result.Success
            ? new EventResult { Success = true }
            : new EventResult { Success = false, Error = result.Error };
    }


    public async Task<EventResult<IEnumerable<Event>>> GetEventsAsync()
    {
        var result = await _eventRepository.GetAllAsync();
        var events = result.Result?.Select(x => new Event
        {
            Id = x.Id,
            Image = x.Image,
            Title = x.Title,
            Description = x.Description,
            Location = x.Location,
            EventDate = x.EventDate
        });

        return new EventResult<IEnumerable<Event>> { Success = true, Result = events };
    }

    public async Task<EventResult<Event?>> GetEventAsync(string eventId)
    {
        var result = await _eventRepository.GetAsync(x => x.Id == eventId);
        if (result.Success && result.Result != null)
        {
            var currentEvent = new Event
            {
                Id = result.Result.Id,
                Image = result.Result.Image,
                Title = result.Result.Title,
                Description = result.Result.Description,
                Location = result.Result.Location,
                EventDate = result.Result.EventDate
            };

            return new EventResult<Event?> { Success = true, Result = currentEvent };
        }

        return new EventResult<Event?> { Success = false, Error = "Event Not Found" };
    }

}
