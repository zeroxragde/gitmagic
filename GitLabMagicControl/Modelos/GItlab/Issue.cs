using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabMagicControl.Modelos.GItlab
{
    public class Issue
    {
        public int id { get; set; }
        public int iid { get; set; }
        public int project_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string state { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object closed_at { get; set; }
        public object closed_by { get; set; }
        public List<string> labels { get; set; }
        public object milestone { get; set; }
        public List<Assignee> assignees { get; set; }
        public Author author { get; set; }
        public string type { get; set; }
        public Assignee assignee { get; set; }
        public int user_notes_count { get; set; }
        public int merge_requests_count { get; set; }
        public int upvotes { get; set; }
        public int downvotes { get; set; }
        public string due_date { get; set; }
        public bool confidential { get; set; }
        public object discussion_locked { get; set; }
        public string issue_type { get; set; }
        public string web_url { get; set; }
        public TimeStats time_stats { get; set; }
        public TaskCompletionStatus task_completion_status { get; set; }
        public int blocking_issues_count { get; set; }
        public bool has_tasks { get; set; }
        public Links _links { get; set; }
        public References references { get; set; }
        public string severity { get; set; }
        public object moved_to_id { get; set; }
        public object service_desk_reply_to { get; set; }
        public string task_status { get; set; }
    }
}
