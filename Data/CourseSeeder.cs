using OnlineCourseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineCourseManagement.Data;

/// <summary>Adds sample catalogue entries without changing or duplicating existing courses.</summary>
public static class CourseSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        var courses = new List<Course>
        {
            new() { Title="Python Programming for Beginners", Instructor="Kiran Patel", Category="Programming", DurationWeeks=6, Fee=3499, Description="Learn Python syntax, data types, functions, modules and file handling. Build small practical programs." },
            new() { Title="Java Programming Masterclass", Instructor="Rohit Sharma", Category="Programming", DurationWeeks=10, Fee=3999, Description="Learn object-oriented Java, collections, exception handling and file I/O through practical exercises." },
            new() { Title="Full Stack Web Development", Instructor="Anjali Verma", Category="Web Development", DurationWeeks=12, Fee=5999, Description="Build responsive web applications using HTML, CSS, JavaScript and modern frontend concepts." },
            new() { Title="Responsive Web Design with Bootstrap", Instructor="Priya Desai", Category="Web Development", DurationWeeks=5, Fee=1999, Description="Create responsive layouts using Bootstrap components, grid, utilities and forms." },
            new() { Title="SQL and Database Design", Instructor="Suresh Nair", Category="Database Management", DurationWeeks=6, Fee=2799, Description="Learn SQL queries, joins, constraints, indexes and relational database design." },
            new() { Title="MongoDB for Developers", Instructor="Kavita Iyer", Category="Database Management", DurationWeeks=5, Fee=2999, Description="Explore NoSQL concepts, document modelling and aggregation pipelines." },
            new() { Title="Data Science with Python", Instructor="Dr. Meera Krishnan", Category="Data Science", DurationWeeks=14, Fee=7499, Description="Analyse and visualise datasets using Python, Pandas, NumPy and Matplotlib." },
            new() { Title="Data Analytics with Excel and Power BI", Instructor="Vikram Joshi", Category="Data Science", DurationWeeks=8, Fee=4499, Description="Transform data into reports and dashboards using Excel and Power BI." },
            new() { Title="Machine Learning Fundamentals", Instructor="Dr. Arvind Rao", Category="Artificial Intelligence", DurationWeeks=12, Fee=8499, Description="Understand supervised and unsupervised learning, model evaluation and practical ML workflows." },
            new() { Title="Introduction to Generative AI", Instructor="Sneha Kulkarni", Category="Artificial Intelligence", DurationWeeks=6, Fee=4999, Description="Understand generative AI concepts, language models and responsible AI application ideas." },
            new() { Title="Cybersecurity Fundamentals", Instructor="Nidhi Agarwal", Category="Cybersecurity", DurationWeeks=6, Fee=3499, Description="Learn security principles, safe authentication, cryptography basics and incident response." },
            new() { Title="Ethical Hacking Essentials", Instructor="Rahul Bhatt", Category="Cybersecurity", DurationWeeks=10, Fee=6499, Description="Study defensive security, vulnerability assessment and safe lab-based testing." },
            new() { Title="AWS Cloud Practitioner Basics", Instructor="Karthik Menon", Category="Cloud Computing", DurationWeeks=8, Fee=5499, Description="Explore cloud fundamentals, compute, storage, identity and cloud pricing concepts." },
            new() { Title="Microsoft Azure Fundamentals", Instructor="Pooja Reddy", Category="Cloud Computing", DurationWeeks=6, Fee=4799, Description="Learn Azure services, cloud concepts, security and basic application deployment." },
            new() { Title="Android App Development with Kotlin", Instructor="Manish Gupta", Category="Mobile App Development", DurationWeeks=12, Fee=6999, Description="Build Android applications with Kotlin, layouts, navigation and local data storage." },
            new() { Title="Flutter Cross-Platform Apps", Instructor="Ritu Chauhan", Category="Mobile App Development", DurationWeeks=10, Fee=6299, Description="Create cross-platform mobile interfaces using Dart, Flutter widgets and state concepts." },
            new() { Title="Git and GitHub for Beginners", Instructor="Aman Trivedi", Category="Programming", DurationWeeks=3, Fee=999, Description="Learn version control, commits, branches, merges and collaborative development workflows." },
            new() { Title="JavaScript for Modern Web Apps", Instructor="Ishita Shah", Category="Web Development", DurationWeeks=7, Fee=3299, Description="Learn modern JavaScript, DOM manipulation, asynchronous programming and browser APIs through small projects." },
            new() { Title="UI UX Design Fundamentals", Instructor="Devika Nair", Category="Web Development", DurationWeeks=6, Fee=2999, Description="Explore user research, wireframes, prototypes, accessibility and practical interface design." },
            new() { Title="Advanced SQL Querying", Instructor="Harsh Vora", Category="Database Management", DurationWeeks=5, Fee=3199, Description="Write efficient SQL queries using joins, window functions, CTEs, views and query plans." },
            new() { Title="Python for Data Analysis", Instructor="Dr. Rhea Kapoor", Category="Data Science", DurationWeeks=8, Fee=4299, Description="Clean, analyse and visualise real datasets using Python, Pandas and Matplotlib." },
            new() { Title="Deep Learning Essentials", Instructor="Dr. Kabir Sethi", Category="Artificial Intelligence", DurationWeeks=10, Fee=7999, Description="Understand neural networks, training workflows and deep learning applications with practical examples." },
            new() { Title="Network Security Basics", Instructor="Farhan Qureshi", Category="Cybersecurity", DurationWeeks=7, Fee=3799, Description="Learn network threats, secure configurations, monitoring and defensive security practices." },
            new() { Title="Cloud Native Development", Instructor="Aarav Kulkarni", Category="Cloud Computing", DurationWeeks=9, Fee=6299, Description="Explore containers, deployment concepts, managed services and cloud-native application design." },
            new() { Title="iOS App Design Fundamentals", Instructor="Simran Gill", Category="Mobile App Development", DurationWeeks=8, Fee=5799, Description="Learn mobile interface patterns, app navigation, accessibility and prototyping for iOS applications." },
            new() { Title="C++ Programming and Problem Solving", Instructor="Nikhil Desai", Category="Programming", DurationWeeks=9, Fee=3699, Description="Build programming foundations with C++, functions, classes, data structures and problem-solving exercises." },
            new() { Title="Digital Marketing Analytics", Instructor="Mitali Bose", Category="Data Science", DurationWeeks=6, Fee=3499, Description="Understand campaign metrics, audience insights, reporting and data-informed digital marketing decisions." }
        };

        var existing = await db.Courses.Select(c => c.Title).ToListAsync();
        var known = new HashSet<string>(existing, StringComparer.OrdinalIgnoreCase);
        var missing = courses.Where(c => !known.Contains(c.Title)).ToList();
        if (missing.Count > 0)
        {
            db.Courses.AddRange(missing);
            await db.SaveChangesAsync();
        }
    }
}
