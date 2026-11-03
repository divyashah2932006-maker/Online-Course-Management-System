CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Courses" (
    "CourseId" INTEGER NOT NULL CONSTRAINT "PK_Courses" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NOT NULL,
    "Instructor" TEXT NOT NULL,
    "Category" TEXT NOT NULL,
    "DurationWeeks" INTEGER NOT NULL,
    "Fee" TEXT NOT NULL,
    "Description" TEXT NOT NULL
);

CREATE TABLE "Enrollments" (
    "EnrollmentId" INTEGER NOT NULL CONSTRAINT "PK_Enrollments" PRIMARY KEY AUTOINCREMENT,
    "LearnerName" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "Phone" TEXT NOT NULL,
    "CourseId" INTEGER NOT NULL,
    "EnrolledOn" TEXT NOT NULL,
    CONSTRAINT "FK_Enrollments_Courses_CourseId" FOREIGN KEY ("CourseId") REFERENCES "Courses" ("CourseId") ON DELETE CASCADE
);

INSERT INTO "Courses" ("CourseId", "Category", "Description", "DurationWeeks", "Fee", "Instructor", "Title")
VALUES (1, 'Programming', 'Learn C# from scratch.', 6, '2999.0', 'Rahul Mehta', 'C# Programming Basics');
SELECT changes();

INSERT INTO "Courses" ("CourseId", "Category", "Description", "DurationWeeks", "Fee", "Instructor", "Title")
VALUES (2, 'Web Development', 'Build web apps with ASP.NET Core.', 8, '4999.0', 'Neha Shah', 'ASP.NET Core MVC');
SELECT changes();

INSERT INTO "Courses" ("CourseId", "Category", "Description", "DurationWeeks", "Fee", "Instructor", "Title")
VALUES (3, 'Database', 'Queries, joins and design.', 5, '2499.0', 'Amit Joshi', 'SQL Server Essentials');
SELECT changes();


CREATE INDEX "IX_Enrollments_CourseId" ON "Enrollments" ("CourseId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20261101071900_InitialCreate', '8.0.10');

COMMIT;

-- Additional sample catalogue rows. Safe to run more than once.
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Python Programming for Beginners', 'Kiran Patel', 'Programming', 6, 3499, 'Learn Python syntax, data types, functions, modules and file handling. Build small practical programs.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Python Programming for Beginners'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Java Programming Masterclass', 'Rohit Sharma', 'Programming', 10, 3999, 'Learn object-oriented Java, collections, exception handling and file I/O through practical exercises.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Java Programming Masterclass'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Full Stack Web Development', 'Anjali Verma', 'Web Development', 12, 5999, 'Build responsive web applications using HTML, CSS, JavaScript and modern frontend concepts.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Full Stack Web Development'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Responsive Web Design with Bootstrap', 'Priya Desai', 'Web Development', 5, 1999, 'Create responsive layouts using Bootstrap components, grid, utilities and forms.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Responsive Web Design with Bootstrap'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'SQL and Database Design', 'Suresh Nair', 'Database Management', 6, 2799, 'Learn SQL queries, joins, constraints, indexes and relational database design.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('SQL and Database Design'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'MongoDB for Developers', 'Kavita Iyer', 'Database Management', 5, 2999, 'Explore NoSQL concepts, document modelling and aggregation pipelines.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('MongoDB for Developers'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Data Science with Python', 'Dr. Meera Krishnan', 'Data Science', 14, 7499, 'Analyse and visualise datasets using Python, Pandas, NumPy and Matplotlib.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Data Science with Python'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Data Analytics with Excel and Power BI', 'Vikram Joshi', 'Data Science', 8, 4499, 'Transform data into reports and dashboards using Excel and Power BI.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Data Analytics with Excel and Power BI'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Machine Learning Fundamentals', 'Dr. Arvind Rao', 'Artificial Intelligence', 12, 8499, 'Understand supervised and unsupervised learning, model evaluation and practical ML workflows.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Machine Learning Fundamentals'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Introduction to Generative AI', 'Sneha Kulkarni', 'Artificial Intelligence', 6, 4999, 'Understand generative AI concepts, language models and responsible AI application ideas.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Introduction to Generative AI'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Cybersecurity Fundamentals', 'Nidhi Agarwal', 'Cybersecurity', 6, 3499, 'Learn security principles, safe authentication, cryptography basics and incident response.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Cybersecurity Fundamentals'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Ethical Hacking Essentials', 'Rahul Bhatt', 'Cybersecurity', 10, 6499, 'Study defensive security, vulnerability assessment and safe lab-based testing.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Ethical Hacking Essentials'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'AWS Cloud Practitioner Basics', 'Karthik Menon', 'Cloud Computing', 8, 5499, 'Explore cloud fundamentals, compute, storage, identity and cloud pricing concepts.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('AWS Cloud Practitioner Basics'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Microsoft Azure Fundamentals', 'Pooja Reddy', 'Cloud Computing', 6, 4799, 'Learn Azure services, cloud concepts, security and basic application deployment.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Microsoft Azure Fundamentals'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Android App Development with Kotlin', 'Manish Gupta', 'Mobile App Development', 12, 6999, 'Build Android applications with Kotlin, layouts, navigation and local data storage.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Android App Development with Kotlin'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Flutter Cross-Platform Apps', 'Ritu Chauhan', 'Mobile App Development', 10, 6299, 'Create cross-platform mobile interfaces using Dart, Flutter widgets and state concepts.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Flutter Cross-Platform Apps'));
INSERT INTO "Courses" ("Title","Instructor","Category","DurationWeeks","Fee","Description") SELECT 'Git and GitHub for Beginners', 'Aman Trivedi', 'Programming', 3, 999, 'Learn version control, commits, branches, merges and collaborative development workflows.' WHERE NOT EXISTS (SELECT 1 FROM "Courses" WHERE lower("Title") = lower('Git and GitHub for Beginners'));
