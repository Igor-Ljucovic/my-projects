﻿using System.ComponentModel.DataAnnotations;
using WeekMap.Attributes;

namespace WeekMap.DTOs
{
    [ValidActivityTimeRange]
    public class PlannedWeekMapActivityDTO
    {
        public long PlannedWeekMapActivityID { get; set; }
        public long ActivityID { get; set; }

        public long PlannedWeekMapID { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        public TimeSpan EndTime { get; set; }

        public bool RepeatEveryWeek { get; set; } = true;
        public DateTime ActivityDate { get; set; }
        public bool OnMonday { get; set; }
        public bool OnTuesday { get; set; }
        public bool OnWednesday { get; set; }
        public bool OnThursday { get; set; }
        public bool OnFriday { get; set; }
        public bool OnSaturday { get; set; }
        public bool OnSunday { get; set; }
    }
}