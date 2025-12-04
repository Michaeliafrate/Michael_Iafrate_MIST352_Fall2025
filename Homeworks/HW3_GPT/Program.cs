/*
* Name: Michael Iafrate
* Date: 12/01/2025
* Homework 3 – Workshop Reservation System
* LLM Used: ChatGPT
* Prompt: I gave it the instructions to the HW and told it to create a program.
*/

using System;
using System.Collections.Generic;

namespace WorkshopApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            WorkshopSession session = new WorkshopSession("MIST352 Workshop", logger);

            int choice;
            do
            {
                ShowMenu();
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AssignSeat(session, "Premium");
                        break;
                    case 2:
                        AssignSeat(session, "Standard");
                        break;
                    case 3:
                        session.DisplayAllSeats();
                        break;
                    case 4:
                        break;
                    case 9:
                        DebugFillAllSeats(session);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.\n");
                        break;
                }

            } while (choice != 4);

            Console.WriteLine("Thank you for using the system.");
        }

        static void ShowMenu()
        {
            Console.WriteLine("Welcome to the Workshop Reservation System.");
            Console.WriteLine("1) Assign Premium seat");
            Console.WriteLine("2) Assign Standard seat");
            Console.WriteLine("3) Display status of all seats");
            Console.WriteLine("4) Exit");
            Console.WriteLine("9) DEBUG: Auto-fill all seats");
            Console.Write("Your choice: ");
        }

        static void AssignSeat(WorkshopSession session, string section)
        {
            try
            {
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Participant p = new Participant(id, name, email);

                bool success = section == "Premium"
                    ? session.AssignPremiumSeat(p)
                    : session.AssignStandardSeat(p);

                if (!success)
                {
                    Console.WriteLine($"{section} section is full.");
                    Console.Write($"Assign to the other section instead? (Y/N): ");
                    string answer = Console.ReadLine().Trim().ToUpper();
                    if (answer == "Y")
                    {
                        success = section == "Premium"
                            ? session.AssignStandardSeat(p)
                            : session.AssignPremiumSeat(p);
                    }
                    else
                    {
                        Console.WriteLine("Next workshop starts in 3 hours.\n");
                    }
                }

                if (success)
                    Console.WriteLine($"{section} seat assigned.\n");
            }
            catch (FormatException)
            {
                Console.WriteLine("ID must be a number.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}\n");
            }
        }

        /// <summary>
        /// DEBUG METHOD – Automatically fills all seats in the workshop.
        /// --------------------------------------------------------------
        /// This method is used ONLY for testing and grading.
        /// </summary>
        static void DebugFillAllSeats(WorkshopSession session)
        {
            int nextId = 9000;

            while (!session.IsWorkshopFull())
            {
                bool preferPremium = !session.IsPremiumFull();

                string section = preferPremium ? "Premium" : "Standard";
                Participant p = new Participant(
                    nextId,
                    $"{section}_Debug_{nextId}",
                    $"{section.ToLower()}{nextId}@test.com"
                );

                bool assigned = preferPremium
                    ? session.AssignPremiumSeat(p)
                    : session.AssignStandardSeat(p);

                if (!assigned)
                {
                    if (preferPremium && !session.IsStandardFull())
                        session.AssignStandardSeat(p);
                    else if (!preferPremium && !session.IsPremiumFull())
                        session.AssignPremiumSeat(p);
                }

                nextId++;
            }

            Console.WriteLine("[DEBUG] Workshop fully populated with 20 auto-generated participants.\n");
        }
    }

    // -----------------------------
    // Participant Class
    // -----------------------------
    public class Participant
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Participant(int id, string name, string email)
        {
            if (id < 1) throw new InvalidIdException("ID must be greater than zero.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new InvalidEmailException("Email must contain '@'.");

            Id = id;
            Name = name;
            Email = email;
        }

        public override string ToString() => $"{Name} (ID {Id}, {Email})";
    }

    // -----------------------------
    // Custom Exceptions
    // -----------------------------
    public class InvalidIdException : Exception
    {
        public InvalidIdException(string message) : base(message) { }
    }

    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message) : base(message) { }
    }

    // -----------------------------
    // Logger Interface + ConsoleLogger
    // -----------------------------
    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG {DateTime.Now}] {message}");
        }
    }

    // -----------------------------
    // Abstract Seat + PremiumSeat + StandardSeat
    // -----------------------------
    public abstract class Seat
    {
        public int RowNumber { get; }
        public int SeatNumber { get; }
        public abstract string SectionType { get; }

        public bool IsBooked { get; private set; }
        public Participant AssignedParticipant { get; private set; }
        public DateTime ReservationTime { get; private set; }

        protected Seat(int rowNumber, int seatNumber)
        {
            if (rowNumber < 1 || rowNumber > 10)
                throw new ArgumentException("RowNumber must be between 1 and 10.");
            if (seatNumber != 1 && seatNumber != 2)
                throw new ArgumentException("SeatNumber must be 1 or 2.");

            RowNumber = rowNumber;
            SeatNumber = seatNumber;
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
                return $"Row {RowNumber} | Seat {SeatNumber} | {SectionType} | FREE";

            return $"Row {RowNumber} | Seat {SeatNumber} | {SectionType} | TAKEN by {AssignedParticipant.Name} (ID {AssignedParticipant.Id}) at {ReservationTime}";
        }
    }

    public class PremiumSeat : Seat
    {
        public PremiumSeat(int rowNumber, int seatNumber) : base(rowNumber, seatNumber) { }
        public override string SectionType => "Premium";
    }

    public class StandardSeat : Seat
    {
        public StandardSeat(int rowNumber, int seatNumber) : base(rowNumber, seatNumber) { }
        public override string SectionType => "Standard";
    }

    // -----------------------------
    // WorkshopSession
    // -----------------------------
    public class WorkshopSession
    {
        public string Name { get; }
        private readonly List<Seat> seats;
        private readonly ILogger logger;

        public WorkshopSession(string name, ILogger logger = null)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Unnamed Workshop" : name;
            this.logger = logger ?? new ConsoleLogger();
            seats = new List<Seat>(20);

            // Rows 1–5 Premium, 6–10 Standard, 2 seats per row
            for (int row = 1; row <= 5; row++)
                for (int seat = 1; seat <= 2; seat++)
                    seats.Add(new PremiumSeat(row, seat));

            for (int row = 6; row <= 10; row++)
                for (int seat = 1; seat <= 2; seat++)
                    seats.Add(new StandardSeat(row, seat));
        }

        public IReadOnlyList<Seat> Seats => seats;

        public bool AssignPremiumSeat(Participant p)
        {
            int idx = FindFirstAvailableSeat(1, 5);
            if (idx == -1) return false;

            bool assigned = seats[idx].AssignParticipant(p);
            if (assigned) logger.Log($"Premium seat assigned: Row {seats[idx].RowNumber}, Seat {seats[idx].SeatNumber} to {p.Name} (ID {p.Id}).");
            return assigned;
        }

        public bool AssignStandardSeat(Participant p)
        {
            int idx = FindFirstAvailableSeat(6, 10);
            if (idx == -1) return false;

            bool assigned = seats[idx].AssignParticipant(p);
            if (

