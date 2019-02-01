using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace TrainingInformationStatistics
{
    public partial class frmMain : Form,IViewTrainRecord
    {
        private Dictionary<string,TrainRecord> m_initRecords = new Dictionary<string, TrainRecord>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                string recordPath = Path.Combine(Application.StartupPath, CConstValues.TRAIN_RECORD_DIR_NAME);
                if (!Directory.Exists(recordPath))
                {
                    Directory.CreateDirectory(recordPath);
                }
                
                string[] recordPaths = Directory.GetFiles(recordPath, "*.xml");

                if (recordPaths != null && recordPaths.Length > 0)
                {
                    XmlSerializer xs = new XmlSerializer(typeof(TrainRecord));
                    
                    foreach (string rp in recordPaths)
                    {
                        using (XmlTextReader xtr = new XmlTextReader(rp))
                        {
                            TrainRecord tr =(TrainRecord)xs.Deserialize(xtr);
                            if (tr != null)
                            {
                                dgvRecords.Rows.Add(CreateRecordDataRow(tr));

                                m_initRecords.Add(tr.Guid,tr.DeepClone());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载已有培训记录失败，错误消息位：" + ex.Message);
            }
        }

        private DataGridViewRow CreateRecordDataRow(TrainRecord tr)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            dgvr.CreateCells(dgvRecords);
            UpdateRecordDataRow(dgvr, tr);
            return dgvr;
        }

        private void UpdateRecordDataRow(DataGridViewRow dgvr,TrainRecord tr)
        {
            dgvr.Tag = tr;

            dgvr.Cells[0].Value = dgvRecords.Rows.Count + 1;
            dgvr.Cells[1].Value = tr.Date.ToString();
            dgvr.Cells[2].Value = tr.Position;
            dgvr.Cells[3].Value = tr.Host;
            dgvr.Cells[4].Value = tr.Theme;
            dgvr.Cells[5].Value = tr.Content;
            dgvr.Cells[6].Value = tr.Duration;

            if (tr.Participants.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (TrainParticipant tp in tr.Participants)
                {
                    sb.Append(tp.Department + "," + tp.Name + ";");
                }

                dgvr.Cells[7].Value = sb.ToString();
            }
        }
        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            frmRecord fr = new frmRecord(null);
            fr.Text = "新建培训记录";

            if (fr.ShowDialog(this)== DialogResult.OK)
            {
                dgvRecords.ClearSelection();
                DataGridViewRow dgvr = CreateRecordDataRow(fr.EditedRecord);
                dgvRecords.Rows.Add(dgvr);
                dgvr.Selected = true;
                dgvRecords.CurrentCell = dgvr.Cells[0];

                if (rbSaveNow.Checked)
                {
                    SaveRecord2Local(fr.EditedRecord);
                }
            }
        }

        private void SaveRecord2Local(TrainRecord tr)
        {
            try
            {
                string recordPath = Path.Combine(Application.StartupPath, CConstValues.TRAIN_RECORD_DIR_NAME);
                if (!Directory.Exists(recordPath))
                {
                    Directory.CreateDirectory(recordPath);
                }

                string recordFileName = Path.Combine(recordPath, tr.Guid + ".xml");
                if (File.Exists(recordFileName))
                {
                    File.Delete(recordFileName);
                }

                XmlSerializer xs = new XmlSerializer(typeof(TrainRecord));

                using (XmlTextWriter xtw = new XmlTextWriter(recordFileName,Encoding.Default))
                {
                    xs.Serialize(xtw, tr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载已有培训记录失败，错误消息位：" + ex.Message);
            }
        }

        private Dictionary<string, TrainRecord> GetEditedRecords()
        {
            Dictionary<string, TrainRecord> newRecords = new Dictionary<string, TrainRecord>();
            foreach (DataGridViewRow dgvr in dgvRecords.Rows)
            {
                TrainRecord tr = dgvr.Tag as TrainRecord;
                newRecords.Add(tr.Guid, tr);
            }

            return newRecords;
        }

        private bool IsRecordsChanged(Dictionary<string, TrainRecord> oldRecords, Dictionary<string, TrainRecord> newRecords)
        {
            if (oldRecords.Count != newRecords.Count)
            {
                return true;
            }

            foreach (string newKey in newRecords.Keys)
            {
                if (!oldRecords.ContainsKey(newKey))
                {
                    return true;
                }

                if (!newRecords[newKey].Equals(oldRecords[newKey]))
                {
                    return true;
                }
            }

            return false;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (rbQuitWinTipSave.Checked)
            {
                Dictionary<string, TrainRecord> editedRecords = GetEditedRecords();

                if (IsRecordsChanged(m_initRecords, editedRecords))
                {
                    if (MessageBox.Show(this, "培训记录发生变化，是否保存？", "提示",  MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                         DialogResult.Yes)
                    {
                        foreach (string newKey in editedRecords.Keys)
                        {
                            if (m_initRecords.ContainsKey(newKey))
                            {
                                if (!m_initRecords[newKey].Equals(editedRecords[newKey]))
                                {
                                    SaveRecord2Local(editedRecords[newKey]);
                                }
                            }
                            else
                            {
                                SaveRecord2Local(editedRecords[newKey]);
                            }
                        }

                        foreach (string oldKey in m_initRecords.Keys)
                        {
                            if (!editedRecords.ContainsKey(oldKey))
                            {
                                DeleteTrainRecord(m_initRecords[oldKey]);
                            }
                        }
                    }
                }

            }

            this.Close();
        }

        private DataGridViewRow GetDataGridRow(Point p)
        {
            dgvRecords.ClearSelection();
            DataGridView.HitTestInfo hitInfo = dgvRecords.HitTest(p.X, p.Y);
            if (hitInfo != null && hitInfo.RowIndex >= 0 && hitInfo.RowIndex < dgvRecords.Rows.Count)
            {
                dgvRecords.Rows[hitInfo.RowIndex].Selected = true;
                return dgvRecords.Rows[hitInfo.RowIndex];
            }

            return null;
        }

        private void dgvRecords_MouseClick(object sender, MouseEventArgs e)
        {
            GetDataGridRow(e.Location);
        }

        private void dgvRecords_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow dgvr= GetDataGridRow(e.Location);
            if (dgvr != null)
            {
                ModifyTrainRecord(dgvr);
            }
        }

        private void ModifyTrainRecord(DataGridViewRow dgvr)
        {
            frmRecord fr = new frmRecord(dgvr.Tag as TrainRecord);
            fr.Text = "修改培训记录";

            if (fr.ShowDialog(this) == DialogResult.OK)
            {
                UpdateRecordDataRow(dgvr, fr.EditedRecord);

                if (rbSaveNow.Checked)
                {
                    SaveRecord2Local(fr.EditedRecord);
                }
            }
        }

        private void btnModifyRecord_Click(object sender, EventArgs e)
        {
            if(dgvRecords.SelectedRows.Count<=0)
            {
                MessageBox.Show("请先选中要修改的记录");
                return;
            }

            ModifyTrainRecord(dgvRecords.SelectedRows[0]);
        }

        public bool HasPreRecord()
        {
            return m_curRowIndex > 0;
        }

        public TrainRecord Change2PreRecord()
        {
            m_curRowIndex--;
            return SetSelectedDataGridRow();
        }

        private TrainRecord SetSelectedDataGridRow()
        {
            dgvRecords.ClearSelection();

            DataGridViewRow dgvr = dgvRecords.Rows[m_curRowIndex];
            dgvr.Selected = true;
            dgvRecords.CurrentCell = dgvr.Cells[0];

            return dgvr.Tag as TrainRecord;
        }

        public bool HasNextRecord()
        {
            return m_curRowIndex < (dgvRecords.Rows.Count - 1);
        }

        public TrainRecord Change2NextRecord()
        {
            m_curRowIndex++;
            return SetSelectedDataGridRow();
        }

        private int m_curRowIndex = -1;
        private void btnBrowseRecord_Click(object sender, EventArgs e)
        {
            if (dgvRecords.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中要浏览的记录");
                return;
            }

            m_curRowIndex = dgvRecords.SelectedRows[0].Index;
            frmViewRecord vr = new frmViewRecord(dgvRecords.SelectedRows[0].Tag as TrainRecord, this);
            vr.ShowDialog(this);
        }

        private void DeleteTrainRecord(TrainRecord tr)
        {
            string recordPath = Path.Combine(Application.StartupPath, CConstValues.TRAIN_RECORD_DIR_NAME);
            string recordFileName = Path.Combine(recordPath, tr.Guid + ".xml");
            if (File.Exists(recordFileName))
            {
                File.Delete(recordFileName);
            }
        }

        private void btnDeleteRecords_Click(object sender, EventArgs e)
        {
            if (dgvRecords.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中要浏览的记录");
                return;
            }

            try
            {
                if(MessageBox.Show(this,"确定删除该培训记录?","提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)!= DialogResult.Yes)
                {
                    return;
                }

                if (rbSaveNow.Checked)
                {
                    DeleteTrainRecord(dgvRecords.SelectedRows[0].Tag as TrainRecord);
                }

                dgvRecords.Rows.Remove(dgvRecords.SelectedRows[0]);
                dgvRecords.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除培训记录失败，错误消息为：" + ex.Message);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("程序名称：培训信息统计");
            sb.AppendLine("程序版本：V1.0");
            sb.AppendLine("作    者：gc_2299");

            MessageBox.Show(this, sb.ToString());
        }
    }
}
