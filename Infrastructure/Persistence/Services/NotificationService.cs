using Application.Dtos;
using Application.Repositories;
using Application.Services;
using Application.Services.Hub;
using Application.Services.Security;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class NotificationService : INotificationService
    {
        readonly SignalRDbContext _context;
        readonly INotificationHubService _notificationHubService;
        readonly INotificationWriteRepository _notificationWriteRepository;
        readonly IAESService _aESService;

        public NotificationService(INotificationHubService notificationHubService, INotificationWriteRepository notificationWriteRepository, IAESService aESService, SignalRDbContext context)
        {
            _notificationHubService = notificationHubService;
            _notificationWriteRepository = notificationWriteRepository;
            _aESService = aESService;
            _context = context;
        }

        public async Task<List<GetNotificationDto>> GetUnreadNotifications(List<string> messageIds)
        {
            var notificationIds = messageIds.Select(id => Guid.Parse(id)).ToList();

            var notifications = await _context.Notifications
               .Where(n => !notificationIds.Contains(n.Id) && !n.IsRead)
                .ToListAsync();

            return notifications.Select(n => new GetNotificationDto
            {
                Id = n.Id.ToString(),
                Title = _aESService.Encrypt(n.Title),
                Message = _aESService.Encrypt(n.Message),
            }).ToList();


        }




        public async Task MarkMessagesAsReadAsync(List<string> messageIds)
        {
            var notificationIds = messageIds.Select(id => Guid.Parse(id)).ToList();

            var messagesToMarkAsRead = await _context.Notifications
                .Where(n => notificationIds.Contains(n.Id) && !n.IsRead)
                .ToListAsync();

            foreach (var message in messagesToMarkAsRead)
            {
                message.IsRead = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> SendNotificationAllClient(CreateNotificationDto notificationDto)
        {
            Notification notification = new()
            {
                Title = _aESService.Decrypt(notificationDto.Title),
                Message = _aESService.Decrypt(notificationDto.Message)
            };
            var result = await _notificationWriteRepository.AddAsync(notification);

            await _notificationWriteRepository.SaveAsync();

            if (result)
                await _notificationHubService.BroadcastMessageAsync(notification);

            return result;
        }


    }
}
