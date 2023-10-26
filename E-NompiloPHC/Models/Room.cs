﻿namespace E_NompiloPHC.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int HospitalInformationId { get; set; }
        public HospitalInformation HospitalInformation { get; set; }
    }
}