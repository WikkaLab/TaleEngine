using System;

namespace TaleEngine.Aggregates.ActivityAggregate
{
    public class Activity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Places { get; private set; }
        public string Image { get; private set; }

        public int? TimeSlot { get; private set; }

        public int Type { get; private set; }
        public int Status { get; private set; }
        public DateTime? EndDate { get; private set; }
        public DateTime? StartDate { get; private set; }

        public Activity SetTitle(string title)
        {
            int maxTitleLength = 50;

            if (!string.IsNullOrEmpty(title))
            {
                if (title.Length > maxTitleLength)
                {
                    Title = title.Substring(0, maxTitleLength);
                }
                else
                {
                    Title = title;
                }
            }
            return this;
        }

        public Activity SetDescription(string description)
        {
            int maxDescLength = 150;

            if (!string.IsNullOrEmpty(description))
            {
                if (description.Length > maxDescLength)
                {
                    Description = description.Substring(0, maxDescLength);
                }
                else
                {
                    Description = description;
                }
            }
            return this;
        }

        public Activity SetPlaces(int places)
        {
            if (places > 0)
            {
                Places = places;
            }
            return this;
        }

        public Activity SetType(int type)
        {
            Type = type;
            return this;
        }

        public Activity SetStatus(int type)
        {
            Type = type;
            return this;
        }

        public Activity SetTimeSlot(int timeSlot)
        {
            if (timeSlot > 0)
            {
                TimeSlot = timeSlot;
            }
            return this;
        }

        public Activity SetImage(string img)
        {
            if (!string.IsNullOrEmpty(img))
            {
                Image = img;
            }
            return this;
        }

        public Activity SetDates(DateTime start, DateTime end)
        {
            if (end.Date > start.Date)
            {
                EndDate = end;
                StartDate = start;
            }
            return this;
        }

        public Activity() { }
    }
}
