using Application.Dtos;
using Application.Repositories;
using Application.Services;
using Application.Services.Hub;
using Application.Services.Security;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class NotificationService : INotificationService
    {
        readonly INotificationHubService _notificationHubService;
        readonly INotificationWriteRepository _notificationWriteRepository;
        readonly IAESService _aESService;

        public NotificationService(INotificationHubService notificationHubService, INotificationWriteRepository notificationWriteRepository, IAESService aESService)
        {
            _notificationHubService = notificationHubService;
            _notificationWriteRepository = notificationWriteRepository;
            _aESService = aESService;
        }

        public async Task<bool> SendNotificationAllClient(NotificationDto notificationDto)
        {
            Notification notification = new()
            {
                Title = _aESService.Decrypt(notificationDto.Title),
                Message = _aESService.Decrypt(notificationDto.Message)
            };
            var result = await _notificationWriteRepository.AddAsync(notification);

            await _notificationWriteRepository.SaveAsync();

            if(result)
              await _notificationHubService.BroadcastMessageAsync(notification);

            return result;
        }
    }
}
