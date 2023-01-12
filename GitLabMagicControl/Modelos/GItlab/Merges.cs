using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabMagicControl.Modelos.GItlab
{
    public class Merges
    {
        public int id { get; set; }
        public int iid { get; set; }
        public int project_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string state { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public MergedBy merged_by { get; set; }
        public MergeUser merge_user { get; set; }
        public DateTime merged_at { get; set; }
        public object closed_by { get; set; }
        public object closed_at { get; set; }
        public string target_branch { get; set; }
        public string source_branch { get; set; }
        public int user_notes_count { get; set; }
        public int upvotes { get; set; }
        public int downvotes { get; set; }
        public Author author { get; set; }
        public List<Assignee> assignees { get; set; }
        public Assignee assignee { get; set; }
        public List<Reviewer> reviewers { get; set; }
        public int source_project_id { get; set; }
        public int target_project_id { get; set; }
        public List<string> labels { get; set; }
        public bool draft { get; set; }
        public bool work_in_progress { get; set; }
        public object milestone { get; set; }
        public bool merge_when_pipeline_succeeds { get; set; }
        public string merge_status { get; set; }
        public string sha { get; set; }
        public string merge_commit_sha { get; set; }
        public object squash_commit_sha { get; set; }
        public object discussion_locked { get; set; }
        public object should_remove_source_branch { get; set; }
        public bool force_remove_source_branch { get; set; }
        public string reference { get; set; }
        public References references { get; set; }
        public string web_url { get; set; }
        public TimeStats time_stats { get; set; }
        public bool squash { get; set; }
        public TaskCompletionStatus task_completion_status { get; set; }
        public bool has_conflicts { get; set; }
        public bool blocking_discussions_resolved { get; set; }
        public object approvals_before_merge { get; set; }
    }
}
