using System;

namespace WorkshopApp
{
    public class WorkshopSession
    {
        public string Name { get; }
        private List<Seat> Seats { get; }

        public WorkshopSession(string name)
        {
            Name = name;
            Seats = new List<Seat>();

            for (int row = 1; row <= 5; row++)
                for (int seat = 1; seat <= 2; seat++)
                    Seats.Add(new Seat(row, seat, "Premium"));

            for (int row = 6; row <= 10; row++)
                for (int seat = 1; seat <= 2; seat++)
                    Seats.Add(new Seat(row, seat, "Standard"));
        }

        public bool AssignPremiumSeat(Participant p) => AssignSeat(1, 5, p);
        public bool AssignStandardSeat(Participant p) => AssignSeat(6, 10, p);

        private bool AssignSeat(int startRow, int endRow, Participant p)
        {
            int idx = FindFirstAvailableSeat(startRow, endRow);
            if (idx == -1) return false;
            return Seats[idx].AssignParticipant(p);
        }

        public bool IsPremiumFull() => FindFirstAvailableSeat(1, 5) == -1;
        public bool IsStandardFull() => FindFirstAvailableSeat(6, 10) == -1;
        public bool IsWorkshopFull() => FindFirstAvailableSeat(1, 10) == -1;

        public void DisplayAllSeats()
        {
            Console.WriteLine($"Workshop: {Name}\n");
            foreach (var seat in Seats)
            Console.WriteLine(seat.GetSeatStatus());
            Console.WriteLine();
        }

        private int FindFirstAvailableSeat(int startRow, int endRow)
        {
            for (int i = 0; i < Seats.Count; i++)
            {
                if (Seats[i].RowNumber >= startRow &&
                    Seats[i].RowNumber <= endRow &&
                    !Seats[i].IsBooked)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}


