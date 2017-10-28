﻿using System;

namespace Common.Utility
{
    public static class ConnectionStore
    {
        public static string MachineName =>
            Environment.MachineName;
        public static string ConnectionString =>
            $"Data Source={MachineName};Initial Catalog=Dapper;Integrated Security=SSPI;persist security info=false;MultipleActiveResultSets=True;Connect Timeout=10";
        public static string ConnectionErrorProvider(string message) =>
            $"Wystąpił problem z połączeniem \n {message}";
    }
}