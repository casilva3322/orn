//Claudia Silva

using System;
using System.Collections.Generic;

using Students;

namespace PA1
{
    class Program
    {

        public static char LoginMenu()
        {
            char ch;
            Console.WriteLine("\n\n\n  MAIN MENU   ");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1- Login as Admin");
            Console.WriteLine("2- Login as U.grad student");
            Console.WriteLine("3- Login as Grad student");
            Console.WriteLine("4- Login as professor");
            Console.WriteLine("0- EXIT");
            Console.WriteLine("=================================");
            Console.WriteLine("Select 1..2 or 0 to exit");

            ch = Console.ReadKey(true).KeyChar;
            return ch;

        }


        public static void LoadUserData(char utype, List<User> users, string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);

            int i = 0;
            foreach (string line in lines)
            {
                string[] stdData = line.Split(',');
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                    if (utype == 'G')
                        users.Add(new GradStudent(stdData));
                    if (utype == 'U')
                        users.Add(new UndergradStudent(stdData));
                    if (utype == 'P')
                        users.Add(new Professor(stdData));
                    if (utype == 'A')
                        users.Add(new Registrar(stdData));

                }
                i++;
            }

        }
        public static void LoadStudData(char level, List<User> students, string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);

            int i = 0;
            foreach (string line in lines)
            {
                string[] stdData = line.Split(',');
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                    if (level == 'G')
                        students.Add(new GradStudent(stdData));
                    if (level == 'U')
                        students.Add(new UndergradStudent(stdData));
                }
                i++;
            }

        }

        public static void LoadProfData(List<User> profList, string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            //uId, pw  , pName, degree, rank
            int i = 0;
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                    string[] stdData = line.Split(',');
                    // Use a tab to indent each line of the file.

                    profList.Add(new Professor(stdData));
                }
                i++;
            }

        }

        public static void LoadCourseData(List<Course> crsList, string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            //id,  name, credits
            int i = 0;
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                    string[] stdData = line.Split(',');
                    // Use a tab to indent each line of the file.

                    crsList.Add(new Course(stdData));
                }
                i++;
            }

        }

        public static void LoadRegData(List<User> rList, string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            //id,  name, credits
            int i = 0;
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
                if (i != 0)
                {  ///skip first line (header)
                    string[] stdData = line.Split(',');
                    // Use a tab to indent each line of the file.

                    rList.Add(new Registrar(stdData));
                }
                i++;
            }

        }

        public static User findUser(List<User> users, string uid)
        {
            foreach (User u in users)
            {
                if (u.getUid().Equals(uid)) return u;
            }
            return null;
        }

        public static Course findCourse(List<Course> cList, int cId)
        {
            foreach (Course c in cList)
            {
                if (c.cId == cId) return c;
            }
            return null;
        }
        public static void Main(string[] args)
        {
            char ch, ch2;
            bool successLogin = false;
            GradStudent st;
            var admins = new List<User>();
            List<Course> coursesList = new List<Course>();
            List<Enrollment> courseEnrolls = new List<Enrollment>();



            List<User> profList = new List<User>();
            List<User> gslist = new List<User>();
            List<User> ugslist = new List<User>();



            LoadUserData('G', gslist, "GsList.txt");
            LoadUserData('U', ugslist, "UGsList.txt");
            LoadUserData('P', profList, "profData.txt");
            LoadCourseData(coursesList, "coursesData.txt");
            LoadUserData('A', admins, "adminData.txt");

            List<User> students = new List<User>();
            students.AddRange(gslist);
            students.AddRange(ugslist);


            do
            {
                ch = LoginMenu();

                switch (ch)
                {
                    case '1':

                        Console.WriteLine("\n \t Enter your Id:");
                        string tId = Console.ReadLine();
                        Console.Write("\t Enter your Password: ");
                        string tPw = Console.ReadLine();
                        Registrar admin = (Registrar)findUser(admins, tId);
                        successLogin = false;
                        // User admin =  findUser(admins,tId);
                        if (admin != null)
                            successLogin = admin.login(tId, tPw);

                        if (!successLogin)
                        {
                            Console.WriteLine("\n Error: user Id or password are not correct!");
                        }
                        else
                        {
                            do
                            {
                                //1- Add Grad student" , "2- Add undergrad student", "3- List All grad students",
                                //"4- List All undergrad students", "5- Add new course", "6- list students in course");
                                ch2 = admin.Menu();
                                switch (ch2)
                                {
                                    //TODO (1): Add new Grad Student
                                    case '1': 
                                        Console.Write("\nEnter  User ID number: ");
                                        string Id = Console.ReadLine();
                                        Console.Write("\nEnter  password: ");
                                        string pw = Console.ReadLine();
                                        Console.Write("\nEnter  name: ");
                                        string sName = Console.ReadLine();
                                        Console.Write("\nEnter  date of birth: ");
                                        string DoB = Console.ReadLine();
                                        Console.Write("\nEnter your student ID: ");
                                        string sId = Console.ReadLine();
                                        Console.Write("\nEnter GPA: ");
                                        string GPA = Console.ReadLine();
                                        Console.Write("\nEnter previous degree: ");
                                        string pDeg = Console.ReadLine();
                                        Console.Write("Enter the previous University:");
                                        string pUni = Console.ReadLine();
                                        Console.WriteLine("Enter department:");
                                        string Dept = Console.ReadLine();
                                        Console.Write("Enter UnderGrad GPA:");
                                        string uGPA = Console.ReadLine();
                                        string [] gradStudent = new string []{Id, pw, sName, sId, DoB, Dept, GPA, pDeg, pUni, uGPA };
                                        var rUser = findUser(gslist, Id);
                                        if(rUser != null)
                                        {
                                            Console.WriteLine("ID is already in use");
                                            break;
                                        }
                                        else
                                        {
                                            gslist.Add(st = new GradStudent(gradStudent));
                                            Console.WriteLine("\n Graduate student has been added");
                                            break;
                                        }
                                        
                                    //TODO (2): Add new undergrad Student,
                                    case '2':
                                        
                                        Console.Write("Enter your User ID: ");
                                        Id = Console.ReadLine();
                                        Console.Write("Enter your password: ");
                                        pw = Console.ReadLine();
                                        Console.Write("Enter your name: ");
                                        sName = Console.ReadLine();
                                        Console.Write("Enter your date of birth: ");
                                        DoB = Console.ReadLine();
                                        Console.Write("Enter your student ID: ");
                                        sId = Console.ReadLine();
                                        Console.Write("Enter your department: ");
                                        Dept = Console.ReadLine();
                                        Console.Write("Enter your GPA: ");
                                        GPA = Console.ReadLine();
                                        Console.Write("Enter your High School: ");
                                        string HS = Console.ReadLine();
                                        Console.Write("Enter your student classification: ");
                                        string Class = Console.ReadLine();
                                        string[] uGradStudent = new string[] { Id, pw, sName, sId, DoB, Dept, GPA, HS, Class };
                                        rUser = findUser(ugslist, Id);
                                        if(rUser != null)
                                        {
                                            Console.WriteLine("ID is already is use");
                                        }
                                        else
                                        {//Check for student, then add student
                                        Student nStu = new UndergradStudent(uGradStudent);
                                        foreach(var s in courseEnrolls)
                                        {
                                            var rStd = s.getStudent();
                                            if(nStu.getUid() == rStd.getUid())
                                            {
                                                        Console.WriteLine("Student is already enrolled in this class");
                                                        break;
                                            }

                                        }
                                        ugslist.Add(nStu);
                                        Console.WriteLine("\n Student has been added");

                                        }
                                    
                                     break;
                                    case '3':
                                        foreach (GradStudent std in gslist)
                                        {
                                            Console.WriteLine();
                                            std.DisplayStdInfo();

                                        }
                                        break;
                                    case '4':
                                        foreach (UndergradStudent std in ugslist)
                                        {
                                            Console.WriteLine();
                                            std.DisplayStdInfo();

                                        }
                                        break;

                                    case '5': //TODO (3): Add new  course by asking Admin for course info., verify inputs 1st
                                              //        : ++ Save new list to File if admin agrees
                                         Console.Write("Enter course ID:");
                                         var cid = Console.ReadLine();
                                         Console.Write("Enter Course name");
                                         var cN = Console.ReadLine();
                                         Console.Write("Enter amount of credits");
                                         var credits = Console.ReadLine();
                                         string[] course = new string[]{cN,cid,credits}; 
                                         Console.WriteLine("Is the information correct? y/n");
                                         foreach(var i in course)
                                         {
                                             Console.WriteLine(i);
                                         }   
                                         Console.WriteLine("Is information correct? y/n");
                                         var answer = Console.ReadLine();
                                         switch(answer)
                                         {
                                             case "y":
                                             case "Y":
                                             //if information is correct add course to course list
                                             coursesList.Add(new Course(course[0], Int32.Parse(course[1]), Int32.Parse(course[2])));
                                             Console.WriteLine("\nThe Course has been added to the list");
                                             //Extra Credit
                                             Console.WriteLine("Would you like to save updates to the course data file? y/n ");
                                             answer = Console.ReadLine();
                                             switch(answer)
                                             {
                                                 case "y":
                                                 case "Y":
                                                    var output = $"\n{course[0]}, {course[1]}, {course[2]}";
                                                    System.IO.File.AppendAllText(@"coursesData.txt", output);
                                                    break;
                                                    case "n":
                                                    case "N":
                                                        Console.WriteLine("Course was not saved to the data file.");
                                                        break;
                                                    default:
                                                        Console.WriteLine("There was an error");
                                                        break;
                                             }
                                                         break;
                                            case "n":
                                            case "N":
                                                Console.WriteLine("\nCourse information was not added.");
                                                break;
                                            default:
                                                break;
                                                        
                                                // Test: Currently adding one specific course
                                        
                                                //coursesList[0].professor = (Professor )profList[0];
                                             }
                                             coursesList.Add(new Course("Adv. Prog", 3312, 3));
                                             break;
                                         
                                        
                                    case '6': //TODO (4): Assign course to prof by getting ProfId, courseId,
                                              //        : verify inputs, and prof doesnot have >3 courses
                                              //        : ++ Save new list to File, and make the code initialize prof-course-assignment list from a file 

                                        // Test: Currently Assign all courses to 1st prof in the list
                                        foreach (var c in coursesList)
                                        {
                                            c.professor = (Professor)profList[0];
                                            c.professor.addCourseToTeach(c);
                                        }
                                        //Show the list of Professors
                                        Console.WriteLine("---Professor List---");
                                        string uId;
                                        
                                        foreach(var i in profList)
                                        {
                                            uId = i.getUid();
                                            Console.WriteLine(uId);
                                            
                                        }

                                        Console.WriteLine("Enter Professor ID");
                                        var profId = Console.ReadLine();

                                        //Showing the list of courses
                                        Console.WriteLine("--Course List--");
                                        int crsID;
                                        foreach(var c in coursesList)
                                        {
                                            crsID = c.cId;
                                            Console.WriteLine(crsID);
                                        }
                                        Console.WriteLine("\n Enter Course ID");
                                        var courseId = Int32.Parse(Console.ReadLine());
                                        //Verifying Professor information against Course information
                                        Professor prCheck = (Professor)findUser(profList,profId);
                                        Course crCheck = (Course)findCourse(coursesList,courseId);
                                        //check
                                        if(prCheck == null)
                                        {
                                            Console.WriteLine("Professor ID was not found or assigned to the course");
                                            break;
                                        }  
                                        else if(crCheck == null)
                                        {
                                            Console.WriteLine("Course ID was not found Professor was not assigned to this course");
                                            break;
                                        }
                                        int pfCount = 0;
                                        foreach(var c in coursesList)
                                        {
                                            if(c.professor.getUid() == profId)
                                            pfCount++;
                                        }
                                        if (pfCount > 3 )
                                        {
                                            Console.WriteLine("The Professor is assigned to more than 3 courses\n Professor is not assigned to this course ");
                                            break;
                                        }
                                        else
                                        {
                                            foreach(var c in coursesList)
                                            {
                                                if(courseId == c.cId)
                                                {
                                                    c.professor = prCheck;
                                                    c.professor.addCourseToTeach(c);
                                                    Console.WriteLine($"The professor with the id {profId} was assigned to {courseId} ");
                                                    //Extra credit
                                                    Console.Write("Would you like to save the course assignment to a file? y/n");
                                                    var saveIt = Console.ReadLine();
                                                    switch(saveIt)
                                                    {
                                                        case "y":
                                                        case "Y":
                                                            var info = $"{profId}, {courseId}";
                                                             System.IO.File.AppendAllText
                                                             (@"courseProfAssignment.txt", info);
                                                             Console.WriteLine("Professor course assignment was saved to coursesProfAssignment.txt");
                                                             break;
                                                        case "n":
                                                        case "N":
                                                             Console.WriteLine("Professor course assignment not saved to a file");
                                                            break;
                                                            default:
                                                                Console.WriteLine("There was an error");
                                                                break;
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                        default:
                                        break;

                                    case '7':
                                        foreach (var std in courseEnrolls)
                                        {
                                            std.displEnrolledStudInfo();
                                        }
                                        break;

                                } //end switch ch2

                            } while (ch2 != '0');
                        } // else 



                        break;

                    case '2':  //  Works for both grad & undergrad using student combined list
                    case '3':
                        Console.WriteLine("\n \t Enter your Id:");
                        tId = Console.ReadLine();
                        Console.Write("\t Enter your Password: ");
                        tPw = Console.ReadLine();
                        successLogin = false;
                        Student student = (Student)findUser(students, tId);

                        if (student != null)
                            successLogin = student.login(tId, tPw);

                        if (!successLogin)
                        {
                            Console.WriteLine("\n Error: user Id or password are not correct!");
                        }
                        else
                        {
                            do
                            {
                                //"1- List My courses", "2- Enroll in a course","3- submit course Assesment"
                                ch2 = student.Menu();
                                switch (ch2)
                                {
                                    case '1':
                                        student.DisplayEnrollments();

                                        break;
                                    case '2':
                                        Console.WriteLine("Enter Course Id: ");
                                        int cId = int.Parse(Console.ReadLine());

                                        Course selectedCourse = findCourse(coursesList, cId);
                                        // TODO (5): check if stud already enrolled in the course before adding
                                        if (selectedCourse != null)
                                        {
                                            Enrollment tEn = new Enrollment(selectedCourse, student);
                                            courseEnrolls.Add(tEn);
                                            student.addEnrollment(tEn);
                                            selectedCourse.addEnrollment(tEn);
                                        }
                                        break;


                                    case '3':
                                        student.DisplayEnrollments();
                                        Console.WriteLine("Select Course Id To submit Assessment for: ");

                                        cId = int.Parse(Console.ReadLine());

                                        //selectedCourse = findCourse(coursesList,  cId);
                                        // 
                                        Enrollment e = student.getEnrolmentByCourseId(cId);
                                        if (e != null)
                                        {
                                            e.getCourse().displayCourseAssessments();
                                            Console.WriteLine("Select Assessment Id To submit: ");
                                            string assessId = Console.ReadLine().Trim();
                                            e.submitAssesment(assessId, "12/12/2018");
                                        }
                                        break;

                                        case '4': 
                                        // TODO (6): Drop course, get cId, verify cId in student enrollments, then remove enrol.    
                                        Console.WriteLine("Drop Course-");
                                        Console.Write("Enter the course ID");
                                        var crsID = Int32.Parse(Console.ReadLine());
                                        var enroll = student.getEnrolmentByCourseId(crsID);
                                        if(enroll != null)
                                        {
                                            courseEnrolls.Remove(enroll);
                                            Console.WriteLine("\nThe Course has been dropped\n");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nStudent not enrolled in course\n");
                                            break;
                                        }
                                } // switch ch2
                            } while (ch2 != '0');
                        } //else
                        break;

                    case '4': //prof

                        Console.WriteLine("\n \t Enter your Id:");
                        tId = Console.ReadLine();
                        Console.Write("\t Enter your Password: ");
                        tPw = Console.ReadLine();
                        successLogin = false;
                        Professor prof = (Professor)findUser(profList, tId);
                        // User admin =  findUser(admins,tId);
                        if (prof != null)
                            successLogin = prof.login(tId, tPw);

                        if (!successLogin)
                        {
                            Console.WriteLine("\n Error: user Id or password are not correct!");
                        }
                        else
                        {
                            do
                            {
                                // 1- List my courses, 2- Add Assesment to course,3- Update student's Assesment points");
                                // 4- list students in a course
                                ch2 = prof.Menu();
                                switch (ch2)
                                {
                                    case '1':
                                        prof.displayCourses();
                                        break;
                                    case '2':
                                        prof.displayCourses();
                                        Console.WriteLine("Enter Course Id: ");
                                        int cId = int.Parse(Console.ReadLine());

                                        Course selectedCourse = findCourse(coursesList, cId);
                                        // TODO (7): get assessment type: assignment, exam, proj,...
                                        //         : then add assessment info 
                                        Console.Write("Enter assessment type: exam or assignment");
                                        var assessType = Console.ReadLine();
                                        switch(assessType)
                                        {   
                                            case "exam":
                                                Console.WriteLine("Enter assesment information");
                                                Console.Write("Name = ");
                                                var asName = Console.ReadLine();
                                                Console.Write("Percentage = ");
                                                var percentage =float.Parse(Console.ReadLine());
                                                Console.WriteLine("Total Points = ");
                                                var totPoints = float.Parse(Console.ReadLine());
                                                Console.Write("Due on = ");
                                                var duedate = Console.ReadLine();
                                                Console.Write("Number of attempts = ");
                                                var numofAttempts = Int32.Parse(Console.ReadLine());
                                                
                                                selectedCourse.AddCourseAssesment(new Exam(asName,percentage,totPoints,duedate,numofAttempts));
                                                break;
                                            case "assignment":
                                             if(selectedCourse != null)
                                            {
                                            Console.WriteLine("Enter Assessment info: ");
                                            Console.WriteLine("Id = ");
                                            string assesId = Console.ReadLine();
                                            Console.WriteLine("Weight = ");
                                            float aPercent = float.Parse(Console.ReadLine());
                                            Console.WriteLine("Descr = ");
                                            string asDescr = Console.ReadLine();
                                            Console.WriteLine("Points = ");
                                            float aPoints = float.Parse(Console.ReadLine());
                                            Console.WriteLine("Due on = ");
                                            string aDueDate = Console.ReadLine();
                                            Console.WriteLine("Late Pen = ");
                                            float latePen = float.Parse(Console.ReadLine());

                                            selectedCourse.AddCourseAssesment(new Assignment(assesId, aPercent, asDescr, aPoints, aDueDate, latePen));
                                            }
                                            break;
                                        
                           
            
                                        default:
                                            Console.WriteLine("There was an error");
                                            break;
                                        }

                                        //coursesList[0].AddCourseAssesmsnt(new Assignment("HW1",0.25f,"written assignment",200,"10/22/18",0.1f));
                                        //coursesList[0].AddCourseAssesmsnt(new Exam("MT",0.50f, 200,"10/22/18",2));
                                        //coursesList[0].AddCourseAssesmsnt(new Assignment("HW2",0.25f,"written assignment",300,"10/22/18",0.1f));

                                        break;
                                    case '3':
                                        prof.displayCourses();
                                        Console.WriteLine("Enter Course Id: ");
                                        cId = int.Parse(Console.ReadLine());

                                        selectedCourse = findCourse(coursesList, cId);

                                        if (selectedCourse != null)
                                        {
                                            selectedCourse.displayCourseStudents();
                                            Console.WriteLine("Select student name  ");
                                            //Console.WriteLine(" sName : ");
                                            string sName = Console.ReadLine().Trim();

                                            Student s = selectedCourse.getStudentByName(sName);

                                            Enrollment e = s.getEnrolmentByCourseId(cId);
                                            if (e != null)
                                            {
                                                e.getCourse().displayCourseAssessments();
                                                Console.WriteLine("Select Assessment Id To update: ");
                                                string assessId = Console.ReadLine().Trim();
                                                StudAssessment studAssessment = e.getStudAssessmentById(assessId);
                                                Console.WriteLine("Enter assessment Points :");
                                                float newPoints = float.Parse(Console.ReadLine());
                                                studAssessment.updateAssessmentPoints(newPoints);
                                            }
                                        }
                                        break;
                                    case '4':
                                        prof.displayCourses();
                                        Console.WriteLine("Enter Course Id: ");
                                        cId = int.Parse(Console.ReadLine());

                                        selectedCourse = findCourse(coursesList, cId);

                                        if (selectedCourse != null)
                                            selectedCourse.displayCourseStudents();
                                        break;
                                } // switch ch2
                            } while (ch2 != '0');
                        } //else
                        break;

                }// switch ch
            } while (ch != '0');

        }
    }
}
