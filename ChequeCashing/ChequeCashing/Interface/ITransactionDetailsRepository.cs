﻿using ChequeCashing.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeCashing.Interface
{
    public interface ITransactionDetailsRepository
    {
        List<ChequeTransaction> GetAllData();

        void InsertData(ChequeTransaction cheques);
    }
}
