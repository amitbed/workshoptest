﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class Member : User
    {
        public string id { get; set; }
        public string username { get; set; }
        private string email;
        public string password { get; set; }
        private bool isActive;
        private List<long> myFriends;
        private List<long> myThreads;
        private List<long> mySubForums;
        private List<long> myForums;
        //private double seniority;
        private double timeLoggedIn;
        //private int numberOfMessagesLastYear;

        public Member() { }

        public Member(string username, string password, string emailAddress)
        {
            if ((String.IsNullOrEmpty(username)) || (String.IsNullOrEmpty(password)) || (String.IsNullOrEmpty(emailAddress)))
            {
                if (String.IsNullOrEmpty(username))
                {
                    Logger.logError("Failed to create a new member. Reason: username is empty");
                }
                if (String.IsNullOrEmpty(password))
                {
                    Logger.logError("Failed to create a new member. Reason: password is empty");
                }
                if (String.IsNullOrEmpty(emailAddress))
                {
                    Logger.logError("Failed to create a new member. Reason: email is empty");
                }
            }
            else
            {
                this.username = username;
                this.password = password;
                this.email = emailAddress;
                this.timeLoggedIn = 0;
                this.id = IdGen.generateMemberId();
                this.isActive = true;
                this.myForums = new List<long>();
                this.mySubForums = new List<long>();
                this.myThreads = new List<long>();
                this.myFriends = new List<long>();
                Logger.logDebug(String.Format("A new user has been created. ID: {0} username: {1}, password: {2}, email: {3}",id,username,password,emailAddress));
            }
        }

        //This method creates a sub-forum
        public bool createSubForum(string title, string parent, List<string> moderators)
        {
            ForumSystem forumSystem = ForumSystem.initForumSystem();
            if ((String.IsNullOrEmpty(title)) || (String.IsNullOrEmpty(parent) || (moderators == null)))
            {
                if ((String.IsNullOrEmpty(title)))
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: title is empty");
                }

                if ((String.IsNullOrEmpty(parent)))
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: parent is empty");
                }

                if (moderators == null)
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: moderators is null");
                }

                return false;
            }
            else
            {
                SubForum subForum = new SubForum(title, moderators, parent);
                foreach (Forum forum in forumSystem.getForums())
                {
                    if (string.Equals(forum.Title, parent))
                    {
                        forum.addSubForum(subForum);
                        Logger.logDebug(String.Format("Sub forum has added succesfully. ID: {0}, title: {1}",subForum.ID,subForum.Title));
                        return true;
                    }
                }
                Logger.logError("Failed to add a new subform. Reason: parent can not be found");
                return false;
            }
        }

        //This method shows all sub forums of a given forum
        public void viewSubForums(string forumName, ForumSystem mainForum)
        {
            foreach (Forum forum in mainForum.getForums())
            {
                if (String.Equals(forumName, forum.Title))
                {
                    forum.displaySubforums();
                }
            }
        }

        //This method shows all discussions of a given sub-forum
        public void viewDiscussions(string subForumName, string parent, ForumSystem mainForum)
        {
            foreach (Forum forum in mainForum.getForums())
            {
                if (String.Equals(parent, forum.Title))
                {
                    foreach (SubForum subForum in forum.getSubForums())
                    {
                        if (String.Equals(subForumName, subForum.Title))
                        {
                            subForum.displayThreads();
                        }
                    }
                }
            }
        }

        //This method displays messages of a thread
        public void viewMessages(int threadId, string subForumName, string parent, ForumSystem mainForum)
        {
            foreach (Forum forum in mainForum.getForums())
            {
                if (String.Equals(parent, forum.Title))
                {
                    foreach (SubForum subForum in forum.getSubForums())
                    {
                        if (String.Equals(subForumName, subForum.Title))
                        {
                            foreach (Thread thread in subForum.getThreads())
                            {
                                if (threadId.Equals(thread.ID))
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
        public void displayReplies(ForumSystem mainForum, string forumName, string subForumName, int discussionId, int messageId)
        {
            foreach (Forum forum in mainForum.getForums())
            {
                if (String.Equals(forumName, forum.Title))
                {
                    foreach (SubForum subForum in forum.getSubForums())
                    {
                        if (String.Equals(subForumName, subForum.Title))
                        {
                            foreach (Thread thread in subForum.getThreads())
                            {
                                if (discussionId.Equals(thread.ID))
                                {
                                    foreach (Message message in thread.getMessages())
                                    {
                                        if (messageId.Equals(message.ID))
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

        public void createThread(ForumSystem forumSystem)
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
            Message message = new Message(content, this.id);
            thread.getMessages().Add(message);
            foreach (Forum forumName in forumSystem.getForums())
            {
                if (string.Equals(forumName.Title, forum))
                {
                    foreach (SubForum subForumName in forumName.getSubForums())
                    {
                        if (string.Equals(subForumName.Title, subForum))
                        {
                            subForumName.getThreads().Add(thread);
                        }
                    }
                }
            }
        }

        public string enterForum(string forumName)
        {
            ForumSystem forumSystem = ForumSystem.initForumSystem();
            string forumID = forumSystem.getForumIdByName(forumName);
            string allSubForums=forumSystem.searchForum(forumID).displaySubforum();
            if (String.IsNullOrEmpty(allSubForums))
            {
                Logger.logError(String.Format("Failed to recieve all sub fours in {0}", forumID));
            }
            else
            {
                Logger.logDebug(String.Format("{0} enterd to forum {1}",this.id,forumID));
                return allSubForums;
            }
        }

        public void postReply(ForumSystem forumSystem, string username)
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
            viewMessages(discussionId, subForum, forum, forumSystem);
            int messageId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Message Content:");
            string content = Console.ReadLine();
            Message message = new Message(content, id);
            foreach (Forum forumName in forumSystem.Forums)
            {
                if (String.Equals(forum, forumName.Title))
                {
                    foreach (SubForum subForumName in forumName.getSubForums())
                    {
                        if (String.Equals(subForum, subForumName.Title))
                        {
                            foreach (Thread thread in subForumName.getThreads())
                            {
                                if (discussionId.Equals(thread.ID))
                                {
                                    foreach (Message threadMessage in thread.getMessages())
                                    {
                                        if (messageId.Equals(threadMessage.ID))
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
