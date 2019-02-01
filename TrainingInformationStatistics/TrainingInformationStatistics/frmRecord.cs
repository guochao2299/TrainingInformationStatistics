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
    public partial class frmRecord : Form
    {
        private TrainRecord m_record;
        public frmRecord(TrainRecord record)
        {
            InitializeComponent();

            m_record = record;
        }

        public TrainRecord EditedRecord
        {
            get
            {
                if (m_record == null)
                {
                    m_record = new TrainRecord();
                    m_record.Guid = Guid.NewGuid().ToString();
                }

                m_record.Content = txtContent.Text;
                m_record.Date = dtpDate.Value;
                m_record.Duration = Convert.ToSingle(txtTime.Text);
                m_record.Host = txtHost.Text;
                m_record.Position = txtPosition.Text;
                m_record.Theme = txtTheme.Text;

                m_record.Participants.Clear();
                if (!string.IsNullOrWhiteSpace(txtPeople.Text))
                {
                    string[] subPeople = txtPeople.Text.Split(';', '；');
                    foreach (string subP in subPeople)
                    {
                        string[] pInfo = subP.Split(',', '，');
                        if (pInfo == null || pInfo.Length != 2)
                        {
                            continue;
                        }

                        TrainParticipant tp = new TrainParticipant();
                        tp.Department = pInfo[0];
                        tp.Name = pInfo[1];

                        m_record.Participants.Add(tp);
                    }
                }

                return m_record;
            }
        }

        private bool CheckPeopleTextSynatx()
        {
            if (string.IsNullOrWhiteSpace(txtPeople.Text))
            {
                return false;
            }

            string[] subPeople = txtPeople.Text.Split(';', '；');
            foreach (string subP in subPeople)
            {
                string[] pInfo = subP.Split(',', '，');
                if(pInfo==null || pInfo.Length!=2)
                {
                    return false;
                }
            }

            return true;
        }

        private string SynatxCheck()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                sb.AppendLine("培训地点不能为空");
            }

            if (string.IsNullOrWhiteSpace(txtHost.Text))
            {
                sb.AppendLine("主持人不能为空");
            }

            float tmp = 0;
            if (string.IsNullOrWhiteSpace(txtTime.Text) || !float.TryParse(txtTime.Text, out tmp))
            {
                sb.AppendLine("培训时间不能为空且必须为数字");
            }

            if (string.IsNullOrWhiteSpace(txtTheme.Text))
            {
                sb.AppendLine("培训主题不能为空");
            }

            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                sb.AppendLine("培训内容不能为空");
            }

            if (string.IsNullOrWhiteSpace(txtPeople.Text) || !CheckPeopleTextSynatx())
            {
                sb.AppendLine("参加人员不能为空且格式必须符合窗口下侧给出的格式说明");
            }

            return sb.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string checkResult = SynatxCheck();

            if (!string.IsNullOrEmpty(checkResult))
            {
                MessageBox.Show(this, checkResult);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmRecord_Load(object sender, EventArgs e)
        {
            if (m_record != null)
            {
                dtpDate.Value = m_record.Date;
                txtPosition.Text = m_record.Position;
                txtHost.Text = m_record.Host;
                txtTheme.Text = m_record.Theme;
                txtTime.Text = m_record.Duration.ToString();
                txtContent.Text = m_record.Content;
                
                if(m_record.Participants.Count>0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (TrainParticipant tp in m_record.Participants)
                    {
                        sb.Append(string.Format("{0},{1};", tp.Department, tp.Name));
                    }

                    txtPeople.Text = sb.ToString().TrimEnd(';');
                }               
            }
        }
    }
}
