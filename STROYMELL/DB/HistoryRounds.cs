//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STROYMELL.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class HistoryRounds
    {
        public int ID_HistoryRound { get; set; }
        public Nullable<double> Bet { get; set; }
        public Nullable<double> Reward { get; set; }
        public Nullable<double> Сoefficient { get; set; }
        public string Outcome { get; set; }
        public Nullable<int> ID_Round { get; set; }
        public Nullable<int> ID_HistoryMatch { get; set; }
    
        public virtual HostoryMatches HostoryMatches { get; set; }
        public virtual Rounds Rounds { get; set; }
    }
}
