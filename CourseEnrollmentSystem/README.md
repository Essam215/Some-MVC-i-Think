Scenario: Course Enrollment System (Simple Version)

You are building a system where students join courses.

🧱 Data (Tables)
👤 Student
Name
Email
📚 Course
Title
Price
Category
🏷️ Category
Name
🔗 Enrollment (important table)

This connects students with courses.

Student
Course
Progress (0–100)
Enrollment Date
⚙️ What the system should do
1. ➕ Add Enrollment
Choose:
Student (dropdown)
Course (dropdown)
Enter progress
Save
2. 📋 Show All Enrollments

Each row should show:

Student Name
Course Title
Category
Progress
Date
3. ✏️ Update Progress
Edit the progress for any enrollment
4. ❌ Delete Enrollment
Remove any enrollment
5. 🔍 Filter (simple)
Show enrollments by:
Category
or Completed (progress = 100)
🎯 That’s it.

If you can build this clean:

relationships ✔️
dropdowns ✔️
view model ✔️
repo ✔️