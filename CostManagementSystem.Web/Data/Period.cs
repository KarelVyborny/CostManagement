﻿namespace CostManagementSystem.Web.Data
{
    public class Period
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }


    }
}
