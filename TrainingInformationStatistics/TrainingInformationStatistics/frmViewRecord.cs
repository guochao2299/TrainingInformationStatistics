using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainingInformationStatistics
{
    public partial class frmViewRecord : Form
    {
        private TrainRecord m_curRecord;
        private IViewTrainRecord m_recordViewer = null;

        public frmViewRecord(TrainRecord record,IViewTrainRecord tr)
        {
            InitializeComponent();

            m_curRecord = record;
            m_recordViewer = tr;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UpdateViewRecordButtonStatus()
        {
            btnPreRecord.Enabled = m_recordViewer.HasPreRecord();
            btnNextRecord.Enabled = m_recordViewer.HasNextRecord();
        }

        private void UpdateRecordInfo(TrainRecord record)
        {
            dtpDate.Value = record.Date;
            txtPosition.Text = record.Position;
            txtHost.Text = record.Host;
            txtTheme.Text = record.Theme;
            txtTime.Text = record.Duration.ToString();
            txtContent.Text = record.Content;

            if (record.Participants.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (TrainParticipant tp in record.Participants)
                {
                    sb.Append(string.Format("{0},{1};", tp.Department, tp.Name));
                }

                txtPeople.Text = sb.ToString().TrimEnd(';');
            }
        }

        private void frmRecord_Load(object sender, EventArgs e)
        {
            UpdateRecordInfo(m_curRecord);
            UpdateViewRecordButtonStatus();
        }

        private void btnPreRecord_Click(object sender, EventArgs e)
        {
            m_curRecord = m_recordViewer.Change2PreRecord();
            UpdateRecordInfo(m_curRecord);
            UpdateViewRecordButtonStatus();
        }

        private void btnNextRecord_Click(object sender, EventArgs e)
        {
            m_curRecord = m_recordViewer.Change2NextRecord();
            UpdateRecordInfo(m_curRecord);
            UpdateViewRecordButtonStatus();
        }
    }
}
