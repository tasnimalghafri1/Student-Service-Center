namespace project01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Student service center
            Dictionary<int, string> students = new Dictionary<int, string>();
            Queue<int> serviceQueue = new Queue<int>();
            Stack<int> servedStack = new Stack<int>();

            int choice = 0;

            do
            {
                Console.WriteLine("\n---- Student Service Center ----");

                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Remove Student");
                Console.WriteLine("4. Show All Students");
                Console.WriteLine("5. Join Service Queue");
                Console.WriteLine("6. Serve Next Student");
                Console.WriteLine("7. Undo Last Service");
                Console.WriteLine("8. Show Queue");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");



                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Student ID: ");
                            int addId = Convert.ToInt32(Console.ReadLine());

                            if (students.ContainsKey(addId))
                            {
                                Console.WriteLine("Student ID already exists!");
                            }
                            else
                            {
                                Console.Write("Enter Student Name: ");
                                string name = Console.ReadLine();
                                students.Add(addId, name);
                                Console.WriteLine("Student added.");
                            }
                            break;

                        case 2:
                            Console.Write("Enter Student ID: ");
                            int updateId = Convert.ToInt32(Console.ReadLine());

                            if (students.ContainsKey(updateId))
                            {
                                Console.Write("Enter New Name: ");
                                students[updateId] = Console.ReadLine();
                                Console.WriteLine("Student updated.");
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            break;

                        case 3:
                            Console.Write("Enter Student ID: ");
                            int removeId = Convert.ToInt32(Console.ReadLine());

                            if (students.ContainsKey(removeId))
                            {
                                students.Remove(removeId);
                                Console.WriteLine("Student removed.");
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            break;

                        case 4:
                            Console.WriteLine("\nAll Students:");
                            foreach (var s in students)
                            {
                                Console.WriteLine($"ID: {s.Key}, Name: {s.Value}");
                            }
                            break;

                        case 5:
                            Console.Write("Enter Student ID: ");
                            int queueId = Convert.ToInt32(Console.ReadLine());

                            if (students.ContainsKey(queueId))
                            {
                                serviceQueue.Enqueue(queueId);
                                Console.WriteLine($"{students[queueId]} joined the queue.");
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            break;

                        case 6:
                            if (serviceQueue.Count > 0)
                            {
                                int servedId = serviceQueue.Dequeue();
                                servedStack.Push(servedId);

                                Console.WriteLine($"Serving: {students[servedId]}");
                            }
                            else
                            {
                                Console.WriteLine("Queue is empty.");
                            }
                            break;

                        case 7:
                            if (servedStack.Count > 0)
                            {
                                int undoId = servedStack.Pop();
                                serviceQueue.Enqueue(undoId);

                                Console.WriteLine($"{students[undoId]} returned to queue.");
                            }
                            else
                            {
                                Console.WriteLine("No service to undo.");
                            }
                            break;

                        case 8:
                            Console.WriteLine("\nQueue:");
                            foreach (int id in serviceQueue)
                            {
                                Console.WriteLine($"{id} - {students[id]}");
                            }
                            Console.WriteLine($"Total in queue: {serviceQueue.Count}");
                            break;

                        case 9:
                            Console.WriteLine("Exiting...");
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input! Please enter numbers only.");
                }

            } while (choice != 9);

            #endregion
        }
    }
}

