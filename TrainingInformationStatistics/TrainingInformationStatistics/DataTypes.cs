using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TrainingInformationStatistics
{
    [Serializable()]
    public class TrainRecord:IEquatable<TrainRecord>
    {
        public TrainRecord()
        { }

        public string Guid = string.Empty;

        public DateTime Date;

        public string Position;

        public string Host = string.Empty;

        public string Theme = string.Empty;

        public string Content = string.Empty;

        public float Duration = 0;

        /// <summary>
        /// 参会人员，多个名字列
        /// </summary>
        public List<TrainParticipant> Participants = new List<TrainParticipant>();

        public bool Equals(TrainRecord other)
        {
            bool isBasicInfoEquals= DateTime.Equals(Date,other.Date)&&
                string.Equals(Position,other.Position)&&
                string.Equals(Host,other.Host)&&
                string.Equals(Theme,other.Theme)&&
                string.Equals(Content,other.Content)&&
                float.Equals(Duration,other.Duration);

            if (!isBasicInfoEquals)
            {
                return false;
            }

            if (this.Participants.Count != other.Participants.Count)
            {
                return false;
            }

            foreach (TrainParticipant tpOther in other.Participants)
            {
                bool isExisted = false;

                foreach (TrainParticipant tpThis in this.Participants)
                {
                    if(tpOther.Equals(tpThis))
                    {
                        isExisted = true;
                        break;
                    }                    
                }

                if (!isExisted)
                {
                    return false;
                }
            }

            return true;
        }

        public TrainRecord DeepClone()
        {
            TrainRecord tr = new TrainRecord();
            tr.Guid = this.Guid;
            tr.Date = this.Date;
            tr.Position = this.Position;
            tr.Host = this.Host;
            tr.Theme = this.Theme;
            tr.Content = this.Content;
            tr.Duration = this.Duration;

            foreach (TrainParticipant tp in this.Participants)
            {
                TrainParticipant newTp = new TrainParticipant();
                newTp.Department = tp.Department;
                newTp.Name = tp.Name;

                tr.Participants.Add(newTp);
            }

            return tr;
        }
    }

    [Serializable()]
    public class TrainParticipant : IEquatable<TrainParticipant>
    {
        public TrainParticipant()
        { }

        public string Department = string.Empty;

        public string Name = string.Empty;

        public bool Equals(TrainParticipant other)
        {
            return string.Equals(Department, other.Department) &&
                string.Equals(Name, other.Name);
        }
    }

    public static class CConstValues
    {
        public const string TRAIN_RECORD_DIR_NAME = "TrainRecord";
    }

    public interface IViewTrainRecord
    {
        bool HasPreRecord();

        TrainRecord Change2PreRecord();

        bool HasNextRecord();

        TrainRecord Change2NextRecord();
    }
}
