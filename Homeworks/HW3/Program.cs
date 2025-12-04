/*
* Name: Michael Iafrate
* Date: 12/05/2025
* Homework 3
*/

using System;

namespace WorkshopApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkshopSession session = new WorkshopSession("MIST352 Workshop");

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
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}\n");
            }
        }

        ///// <summary>
        /// DEBUG METHOD – Automatically fills all seats in the workshop.
        /// --------------------------------------------------------------
        /// This method is used ONLY for testing and grading. It allows you
        /// to instantly fill all Premium and Standard seats without typing
        /// 20 participants manually.
        ///
        /// HOW IT WORKS:
        /// 1. Starts with ID = 9000 and increments for each debug participant.
        /// 2. While the workshop still has empty seats:
        ///    • If Premium section still has free seats → try Premium first.
        ///    • Otherwise → fill Standard section.
        /// 3. Creates a Participant object with:
        ///       ID    = nextId
        ///       Name  = "Premium_Debug_ID" or "Standard_Debug_ID"
        ///       Email = "premiumID@test.com" or "standardID@test.com"
        /// 4. Attempts to assign the participant to the preferred section:
        ///    - If assignment succeeds → continue.
        ///    - If assignment fails (section just filled):
        ///         • If Premium failed  → try Standard (if not full)
        ///         • If Standard failed → try Premium (if not full)
        /// 5. This logic guarantees:
        ///    - Every seat gets filled.
        ///    - No seat is overwritten.
        ///    - No infinite loops or invalid assignments.
        /// 6. When complete, prints: "DEBUG: All seats auto-filled."
        ///
        /// WHY THIS EXISTS:
        /// • Makes grading MUCH faster (fills full workshop in < 1 second)
        /// • You can test DisplayAllSeats() instantly.
        /// • Allows you to spot layout errors, timestamp issues,
        ///   and booking logic problems immediately.
        ///
        /// PARAMETERS:
        ///   <param name="session">
        ///     The WorkshopSession object the method will operate on.
        ///     Must already be created in Main(). This object contains:
        ///       - The 20 Seat objects
        ///       - All section/row information
        ///       - Seat-booking methods used internally
        ///   </param>
        ///
        /// RETURNS:
        ///   <returns>
        ///     This method does not return a value (void). It updates the state
        ///     of the WorkshopSession object by filling every empty seat with
        ///     auto-generated Participant objects.
        ///   </returns>
        ///
        /// NOTE:
        ///   • Do NOT modify this method.
        ///   • You must enable this by pressing option 9 (or similar) from the menu.
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

            Console.WriteLine("DEBUG: All seats auto-filled.\n");
        }
    }
}


