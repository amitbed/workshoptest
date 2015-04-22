using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem;

namespace ForumSystem
{
    class Program
    {
        static void Main(string[] args)
        {
           ForumSystem forumSystem = ForumSystem.getInstance();        //create singleton instance of Forum System
            forumSystem.addForum(new Forum(0, "Sports", new List<int>()));
            forumSystem.addForum(new Forum(0, "Politics", new List<int>()));
            forumSystem.addForum(new Forum(0, "Travel", new List<int>()));
            forumSystem.addForum(new Forum(0, "Cars", new List<int>()));
            forumSystem.addForum(new Forum(0, "Fashion", new List<int>()));
            bool flag = true;
            string forum;
            string subForum;
            bool loggedIn = false;
            string username = "guest";
            while (flag)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Use Case 6: Login");
                Console.WriteLine("2. Use Case 7: Create Sub-Forum");
                Console.WriteLine("3. Use Case 8: View Sub-Forums & Discussions");
                Console.WriteLine("4. Use Case 9: Create New Thread");
                Console.WriteLine("5. Use Case 10: Post Reply");
                Console.WriteLine();
                Console.WriteLine("Helper Functions:");
                Console.WriteLine("a. Display Forums");
                Console.WriteLine("b. Display Replies");
                Console.WriteLine();
                Console.WriteLine("0. Exit");
                string option = Console.ReadLine();
                switch (option)
                {
                    //Use Case 6: Login
                    case "1":
                        Console.WriteLine("Please enter your username:");
                        username = Console.ReadLine();
                        Console.WriteLine("Please enter your password");
                        string password = Console.ReadLine();
                        loggedIn = login(username, password);
                        break;

                    //Use Case 7: Create Sub-Forum
                    case "2":
                        Console.WriteLine("Enter sub-forum name:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter parent forum name:");
                        string parent = Console.ReadLine();
                        List<string> moderators = new List<string>();
                        Console.WriteLine("Enter list of moderator IDs - enter \"end\" to finish:");
                        string user = Console.ReadLine();
                        while (user != "end")
                        {
                            moderators.Add(user);
                            user = Console.ReadLine();
                        }
                        createSubForum(title, parent, moderators, forumSystem);
                        break;

                    //Use Case 8: View Sub-Forums and Discussions
                    case "3":
                        Console.WriteLine("Select a forum to view:");
                        forumSystem.displayForums();
                        forum = Console.ReadLine();
                        Console.WriteLine("Select a sub-forum to view:");
                        viewSubForums(forum, forumSystem);
                        subForum = Console.ReadLine();
                        viewDiscussions(subForum,forum,forumSystem);
                        break;

                    //Use Case 9: Create New Thread
                    case "4":
                        if (loggedIn)
                        {
                            createThread(forumSystem, username);
                        }
                        else
                        {
                            Console.WriteLine("Need to login to create thread!");
                        }
                        break;

                    //Use Case 9: Post Reply
                    case "5":
                        if (loggedIn)
                        {
                            postReply(forumSystem, username);
                        }
                        else
                        {
                            Console.WriteLine("Need to be logged in to post a reply!");
                        }
                        break;

                    //Display Forums
                    case "a":
                        forumSystem.displayForums();
                        break;

                    //Display Replies
                    case "b":
                        Console.WriteLine("Select a forum to view:");
                        forumSystem.displayForums();
                        forum = Console.ReadLine();
                        Console.WriteLine("Select a sub-forum to view:");
                        viewSubForums(forum, forumSystem);
                        subForum = Console.ReadLine();
                        Console.WriteLine("Select a Discussion ID:");
                        viewDiscussions(subForum, forum, forumSystem);
                        int threadId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Select a message ID:");
                        viewMessages(threadId,subForum, forum, forumSystem);
                        int replyId = Convert.ToInt32(Console.ReadLine());
                        displayReplies(forumSystem, forum, subForum, threadId, replyId);
                        break;

                    //Exit
                    case "0":
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        //This method performs a user login
        static bool login(string username, string password)
        {
            string test_username = "dean";
            string test_password = "1234";
            bool loggedIn = false;
            if (String.Equals(username, test_username) && String.Equals(password, test_password))
            {
                Console.WriteLine("Login Successfull.");
                loggedIn = true;
                Console.WriteLine(loggedIn);
                return loggedIn;
            }
            else
            {
                Console.WriteLine("Login Failed.");
                Console.WriteLine(loggedIn);
                return loggedIn;
            }
        }

        //This method creates a sub-forum
        static void createSubForum(string title, string parent, List<string> moderators, ForumSystem forumSystem)
        {
            SubForum subForum = new SubForum(0, title, moderators, parent);
            foreach (Forum forum in forumSystem.getForums())
            {
                if (string.Equals(forum.getTitle(), parent))
                {
                    forum.addSubForum(subForum);
                }
            }
        }

        //This method shows all sub forums of a given forum
        static void viewSubForums(string forumName, ForumSystem mainForum)
        {
            foreach (Forum forum in mainForum.getForums())
            {
                if (String.Equals(forumName, forum.getTitle()))
                {
                    forum.displaySubforums(); 
                }
            }
        }

        //This method shows all discussions of a given sub-forum
        static void viewDiscussions(string subForumName, string parent, ForumSystem mainForum)
        {
            foreach (Forum forum in mainForum.getForums())
            {
                if (String.Equals(parent, forum.getTitle()))
                {
                    foreach (SubForum subForum in forum.getSubForums())
                    {
                        if (String.Equals(subForumName, subForum.getTitle()))
                        {
                            subForum.displayThreads();
                        }
                    }
                }
            }
        }

        //This method displays messages of a thread
        static void viewMessages(int threadId,string subForumName, string parent, ForumSystem mainForum)
        {
            foreach (Forum forum in mainForum.getForums())
            {
                if (String.Equals(parent, forum.getTitle()))
                {
                    foreach (SubForum subForum in forum.getSubForums())
                    {
                        if (String.Equals(subForumName, subForum.getTitle()))
                        {
                            foreach (Thread thread in subForum.getThreads())
                            {
                                if (threadId == thread.getTopicId())
                                {
                                    thread.displayMessages();
                                }
                            }
                        }
                    }
                }
            }
        }

        //This method displays a message's replies
        static void displayReplies(ForumSystem mainForum, string forumName, string subForumName, int discussionId, int messageId)
        {
            foreach (Forum forum in mainForum.getForums())
            {
                if (String.Equals(forumName, forum.getTitle()))
                {
                    foreach (SubForum subForum in forum.getSubForums())
                    {
                        if (String.Equals(subForumName, subForum.getTitle()))
                        {
                            foreach (Thread thread in subForum.getThreads())
                            {
                                if (discussionId == thread.getTopicId())
                                {
                                    foreach (Message message in thread.getMessages())
                                    {
                                        if (messageId == message.getMessageId())
                                        {
                                            foreach (Message reply in message.getReplies())
                                            {
                                                reply.displayMessage();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //This method creates a new thread
        static void createThread(ForumSystem forumSystem, string username)
        {
            Console.WriteLine("Select a forum to view:");
            forumSystem.displayForums();
            string forum = Console.ReadLine();
            Console.WriteLine("Select a sub-forum to view");
            viewSubForums(forum, forumSystem);
            string subForum = Console.ReadLine();
            Console.WriteLine("Enter Thread Title:");
            string threadTitle = Console.ReadLine();
            Thread thread = new Thread(threadTitle);
            Console.WriteLine("Enter Message Content:");
            string content = Console.ReadLine();
            Message message = new Message(thread.getTopicId(), content, username);
            thread.getMessages().Add(message);
            foreach (Forum forumName in forumSystem.getForums())
            {
                if (string.Equals(forumName.getTitle(), forum))
                {
                    foreach (SubForum subForumName in forumName.getSubForums())
                    {
                        if (string.Equals(subForumName.getTitle(), subForum))
                        {
                            subForumName.getThreads().Add(thread);
                        }
                    }
                }
            }
        }

        //This method posts a reply
        static void postReply(ForumSystem forumSystem, string username)
        {
            Console.WriteLine("Select a forum to view:");
            forumSystem.displayForums();
            string forum = Console.ReadLine();
            Console.WriteLine("Select a sub-forum to view:");
            viewSubForums(forum, forumSystem);
            string subForum = Console.ReadLine();
            Console.WriteLine("Select a Discussion ID:");
            viewDiscussions(subForum, forum, forumSystem);
            int discussionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Select a message ID to reply to:");
            viewMessages(discussionId,subForum, forum, forumSystem);
            int messageId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Message Content:");
            string content = Console.ReadLine();
            Message message = new Message(messageId, content, username);
            foreach (Forum forumName in forumSystem.getForums())
            {
                if (String.Equals(forum, forumName.getTitle()))
                {
                    foreach (SubForum subForumName in forumName.getSubForums())
                    {
                        if (String.Equals(subForum, subForumName.getTitle()))
                        {
                            foreach (Thread thread in subForumName.getThreads())
                            {
                                if (discussionId == thread.getTopicId())
                                {
                                    foreach (Message threadMessage in thread.getMessages())
                                    {
                                        if (messageId == threadMessage.getMessageId())
                                        {
                                            threadMessage.getReplies().Add(message);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
