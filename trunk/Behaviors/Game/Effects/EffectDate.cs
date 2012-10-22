﻿using System;
using BiM.Protocol.Data;
using BiM.Protocol.Types;

namespace BiM.Behaviors.Game.Effects
{
    [Serializable]
    public class EffectDate : EffectBase
    {
        protected short m_day;
        protected short m_hour;
        protected short m_minute;
        protected short m_month;
        protected short m_year;

        public EffectDate()
        {
            
        }

        public EffectDate(EffectDate copy)
            : this(copy.Id, copy.m_year, copy.m_month, copy.m_day, copy.m_hour, copy.m_minute, copy)
        {
            
        }

        public EffectDate(short id, short year, short month, short day, short hour, short minute, EffectBase effect)
            : base(id, effect)
        {
            m_year = year;
            m_month = month;
            m_day = day;
            m_hour = hour;
            m_minute = minute;
        }

        public EffectDate(ObjectEffectDate effect)
            : base (effect)
        {

            m_year = effect.year;
            m_month = effect.month;
            m_day = effect.day;
            m_hour = effect.hour;
            m_minute = effect.minute;
        }

        public EffectDate(EffectInstanceDate effect)
            : base(effect)
        {
            m_year = (short) effect.year;
            m_month = (short) effect.month;
            m_day = (short) effect.day;
            m_hour = (short) effect.hour;
            m_minute = (short) effect.minute;
        }


        public override int ProtocoleId
        {
            get { return 72; }
        }

        public override object[] GetValues()
        {
            return new object[]
                {
                    m_year.ToString(), m_month.ToString("00") + m_day.ToString("00"),
                    m_hour.ToString("00") + m_minute.ToString("00")
                };
        }

        public DateTime GetDate()
        {
            return new DateTime(m_year, m_month, m_day, m_hour, m_minute, 0);
        }

        public override ObjectEffect GetObjectEffect()
        {
            return new ObjectEffectDate(Id, m_year, m_month, m_day, m_hour, m_minute);
        }

        public override EffectInstance GetEffectInstance()
        {
            return new EffectInstanceDate()
            {
                effectId = (uint)Id,
                targetId = (int)Targets,
                delay = Delay,
                duration = Duration,
                @group = Group,
                random = Random,
                modificator = Modificator,
                trigger = Trigger,
                hidden = Hidden,
                zoneMinSize = ZoneMinSize,
                zoneSize = ZoneSize,
                zoneShape = (uint) ZoneShape,
                year = (uint) m_year,
                month = (uint) m_month,
                day = (uint) m_day,
                hour = (uint) m_hour,
                minute = (uint) m_minute

            };
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EffectDate))
                return false;
            return base.Equals(obj) && GetDate().Equals((obj as EffectDate).GetDate());
        }

        public static bool operator ==(EffectDate a, EffectDate b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object) a == null) || ((object) b == null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EffectDate a, EffectDate b)
        {
            return !(a == b);
        }

        public bool Equals(EffectDate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.m_day == m_day && other.m_hour == m_hour && other.m_minute == m_minute &&
                   other.m_month == m_month && other.m_year == m_year;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ m_day.GetHashCode();
                result = (result*397) ^ m_hour.GetHashCode();
                result = (result*397) ^ m_minute.GetHashCode();
                result = (result*397) ^ m_month.GetHashCode();
                result = (result*397) ^ m_year.GetHashCode();
                return result;
            }
        }
    }
}