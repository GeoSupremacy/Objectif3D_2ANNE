using System;
namespace RPG_Correction
{
    internal interface IStats
    {
        int Life { get; set; }
        int Damages { get; set; }
        void SetLife(int _life);
        void SetDamages(int _damages);
    }
}
