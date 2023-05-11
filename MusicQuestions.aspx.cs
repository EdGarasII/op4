using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OP2_LAB4_U4_05
{
    public partial class MusicQuestions : System.Web.UI.Page
    {
        private void UpdateTable()
        {
            EntriesTable.Rows.Clear();

            EntriesTable.AddTableRowFromStrings(
                "<b>Subject</b>",
                "<b>Author group</b>",
                "<b>Author</b>",
                "<b>Text</b>",
                "<b>Answer</b>",
                "<b>Complexity</b>",
                "<b>Reward</b>",
                "<b>Media file path</b>");

            if (Session["Entries"] is List<Question> entries)
            {
                foreach (MusicQuestion musicQuestion in entries
                    .Where(question => question is MusicQuestion)
                    .Select(question => question as MusicQuestion))
                    EntriesTable.AddTableRowFromStrings(
                        musicQuestion.Subject,
                        musicQuestion.AuthorGroup,
                        musicQuestion.Author,
                        musicQuestion.Text,
                        musicQuestion.CorrectAnswer,
                        musicQuestion.Complexity,
                        musicQuestion.RewardPoints,
                        musicQuestion.MediaFilePath);

                EntriesSection.Visible = entries.Count > 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Entries"] == null)
                Session["Entries"] = DefaultData.CreateList();

            UpdateTable();
        }

        protected void DefaultLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!InputQuestionSubjectValidator.IsValid ||
                !InputQuestionAuthorGroupValidator.IsValid ||
                !InputQuestionAuthorValidator.IsValid ||
                !InputQuestionTextValidator.IsValid ||
                !InputCorrectAnswerValidator.IsValid ||
                !InputQuestionComplexityValidator.IsValid ||
                !InputQuestionRewardValidator.IsValid ||
                !InputMediaFilePathValidator.IsValid) return;

            List<Question> questions;

            if (Session["Entries"] is List<Question> entries)
                questions = entries;
            else
            {
                questions = new List<Question>();
                Session["Entries"] = questions;
            }

            questions.Add(new MusicQuestion(
                InputQuestionSubject.Text,
                InputQuestionAuthorGroup.Text,
                InputQuestionAuthor.Text,
                InputQuestionText.Text,
                InputCorrectAnswer.Text,
                int.Parse(InputQuestionComplexity.Text),
                int.Parse(InputQuestionReward.Text),
                InputMediaFilePath.Text));

            UpdateTable();
        }

        protected void ButtonClearEntries_Click(object sender, EventArgs e)
        {
            if (Session["Entries"] is List<Question> entries)
            {
                Session["Entries"] = entries.Where(question => !(question is MusicQuestion)).ToList();
                UpdateTable();
            }
        }
    }
}