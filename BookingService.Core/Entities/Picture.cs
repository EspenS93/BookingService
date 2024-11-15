﻿using BookingService.Core.Entities.Room;

namespace BookingService.Core.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Alt { get; set; } = string.Empty;

        public ICollection<RoomDetail> RoomDetails { get; set; } = [];
    }
}