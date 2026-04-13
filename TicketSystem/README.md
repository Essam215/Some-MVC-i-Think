Case Study: Event Ticket Booking System
🔹 Scenario
Imagine you are building a system that helps users discover events and book tickets.
The system allows users to browse events, reserve tickets, and track their bookings.
🔹 Entities (Main Objects in the System)
User
Represents a person using the system.
Attributes
UserId: Unique identifier
Name: User’s name
Phone: Required, must be 11 digits
Event
Represents an event available for booking.
Attributes
EventId: Unique identifier
Title: Event name (Required)
Location: Event location (Required)
EventDate: Cannot be in the past
Capacity: Maximum number of attendees (Must be > 0)
Ticket
Represents a ticket type for an event.
Attributes
TicketId: Unique identifier
Type: (Regular / VIP)
Price: Must be greater than 0
EventId: Related event
Booking
Represents a user booking tickets.
Attributes
BookingId: Unique identifier
BookingDate: Cannot be in the future
Quantity: Number of tickets (Must be > 0)
UserId: Related user
TicketId: Related ticket
🔹 Relationships
User → Booking (One-to-Many)
One user can make many bookings
Each booking belongs to one user
Event → Ticket (One-to-Many)
One event can have multiple ticket types
Each ticket belongs to one event
Ticket → Booking (One-to-Many)
One ticket type can be booked many times
Each booking is for one ticket type
🔹 Sample Data
Users
UserId	Name	Phone
1	Ahmed Ali	01012345678
2	Sara Mohamed	01198765432
Events
EventId	Title	Location	Date	Capacity
1	Music Night	Cairo	2025-06-01	200
Tickets
TicketId	Type	Price	EventId
1	Regular	200	1
2	VIP	500	1
Bookings
BookingId	Date	Quantity	UserId	TicketId
1	2025-05-20	2	1	1
🔹 Application Navigation (Navbar)
Home
Events
Tickets
Bookings
🔹 Views
Events Views
Events List (Index)
Purpose: Display all events
Columns
Title (Required)
Location
Event Date
Capacity
Actions (Edit / Delete)
Actions
Edit → Update event details
Delete → Delete event after confirmation
Create New Event
Form Fields
Title (Required)
Location (Required)
Event Date (Cannot be in the past)
Capacity (> 0)
Action Result
If valid → saved + redirect
If invalid → show errors
Tickets Views
Tickets List
Columns
Type
Price
Event Name
Actions (Edit / Delete)
Create Ticket
Form Fields
Type
Price (> 0)
Event (Dropdown)
Bookings Views
Bookings List
Columns
Booking Date
User Name
Ticket Type
Quantity
Actions (Details / Delete)
Create Booking
Form Fields
Booking Date (Cannot be in future)
User (Dropdown)
Ticket (Dropdown)
Quantity (> 0)
Booking Details
Displayed Data
User
Event
Ticket Type
Quantity
Booking Date
