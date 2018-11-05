using System;
using System.Collections;

namespace Payroll.Domain
{
    public class HourlyClassification : PaymentClassification
    {
        private double hourlyRate { get; set; }
        private Hashtable timeCards = new Hashtable(); 

        public double HourlyRate
        {
            get { return hourlyRate; }
        }
        public HourlyClassification(double rate)
        {
            this.hourlyRate = rate;
        }

        

        public TimeCard GetTimeCard(DateTime date)
        {
            return timeCards[date] as TimeCard;
        }

        public void AddTimeCard(TimeCard card)
        {
            timeCards[card.Date] = card;
        }
    }
}