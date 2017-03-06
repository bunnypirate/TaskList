using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace TaskList
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var db = new Tasklistcontext())
            {
                // Create and save a new TaskList 
                Console.Write("Enter a name for a new Task List: ");
                var tasklistname = Console.ReadLine();

                var tasklist = new Tasklist { Name = tasklistname };
                db.Tasklists.Add(tasklist);
                db.SaveChanges();

                // Display all Tasklists from the database 
                var query = from t in db.Tasklists
                            orderby t.Name
                            select t;

                Console.WriteLine("All Tasklists in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
    public class Tasklist
    {
        public int TasklistId { get; set; }
        public string Name { get; set; }

        public virtual List<Task> Tasks { get; set; }
    }

    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string TaskInfo { get; set; }

        public int TasklistId { get; set; }
        public virtual Tasklist Tasklist { get; set; }
    }
    public class Tasklistcontext : DbContext
    {
        public DbSet<Tasklist> Tasklists { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }



}