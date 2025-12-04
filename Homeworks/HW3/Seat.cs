using System;

namespace WorkshopApp
{
    public class Seat
    {
        public int RowNumber { get; }
        public int SeatNumber { get; }
        public string SectionType { get; }
        public bool IsBooked { get; private set; }
        public Participant AssignedParticipant { get; private set; }
        public DateTime ReservationTime { get; private set; }

        public Seat(int row, int seat, string section)
        {
            if (row < 1 || row > 10) throw new ArgumentException("RowNumber must be 1–10.");
            if (seat != 1 && seat != 2) throw new ArgumentException("SeatNumber must be 1 or 2.");
            if (section != "Premium" && section != "Standard") throw new ArgumentException("SectionType must be Premium or Standard.");

            RowNumber = row;
            SeatNumber = seat;
            SectionType = section;
            IsBooked = false;
            AssignedParticipant = null;
            ReservationTime = default; 
        }

        public bool AssignParticipant(Participant p)
        {
            if (IsBooked) return false;
            AssignedParticipant = p;
            IsBooked = true;
            ReservationTime = DateTime.Now; 
            return true;
        }

        public string GetSeatStatus()
        {
            if (!IsBooked)
                return $"Row {RowNumber}, Seat {SeatNumber} ({SectionType}) - FREE";

            return $"Row {RowNumber}, Seat {SeatNumber} ({SectionType}) - TAKEN by {AssignedParticipant.Name} (ID {AssignedParticipant.Id}) at {ReservationTime}";
        }
    }
}



